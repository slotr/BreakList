using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Break_List.Properties;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using MySql.Data.MySqlClient;
using PopupMenuShowingEventArgs = DevExpress.XtraScheduler.PopupMenuShowingEventArgs;
using System.Linq;

namespace Break_List.Forms.BreakList
{
    public partial class FrmBreakList : XtraForm
    {
        private readonly TimeSpan _minTime = new TimeSpan(0, 0, 0);
        

        public FrmBreakList()
        {
            InitializeComponent();

            schedulerControl.Views.DayView.Enabled = false;
            schedulerControl.ActiveViewType = SchedulerViewType.Timeline;
            schedulerControl.GroupType = SchedulerGroupType.Resource;
            OperationDate = Settings.Default.operationDate; // Başlangıç saatini ayarlıyor
            EndDate = Settings.Default.EndDate;

            Duration = EndDate - OperationDate;

            var tsStart = TimeSpan.FromHours(OperationDate.Hour);
            schedulerControl.Start = OperationDate;

            schedulerControl.TimelineView.WorkTime = new TimeOfDayInterval(tsStart, tsStart + Duration);

            var scales = schedulerControl.TimelineView.Scales;
            schedulerControl.TimelineView.Scales.BeginUpdate();
            try
            {
                scales.Clear();
                //scales.Add(new TimeScaleFixedInterval(TimeSpan.FromDays(1), tsStart, MaxTime));
                scales.Add(new TimeScaleFixedInterval(TimeSpan.FromHours(1), _minTime, MaxTime));
                scales.Add(new TimeScaleFixedInterval(TimeSpan.FromMinutes(20), _minTime, MaxTime));
                schedulerControl.LimitInterval.Start = OperationDate;
                schedulerControl.LimitInterval.End = EndDate;
            }
            finally
            {
                schedulerControl.TimelineView.Scales.EndUpdate();
            }

            schedulerStorage1.AppointmentsChanged += OnAppointmentChangedInsertedDeleted;
            schedulerStorage1.AppointmentsInserted += OnAppointmentChangedInsertedDeleted;
            schedulerStorage1.AppointmentsDeleted += OnAppointmentChangedInsertedDeleted;
        }

        public string DepartmentNameFromMainForm { get; set; }

        public DateTime OperationDate { get; set; }
        public DateTime EndDate { get; set; }

        public TimeSpan Duration { get; set; }


        private int ResourceId { get; set; }
        private string ResourceName { get; set; }
        private string LocationData { get; set; }
        private string SubjectData { get; set; }
        private string LogismosNo { get; set; }

        public TimeSpan MaxTime { get; } = new TimeSpan(24, 0, 0);


        private void OnAppointmentChangedInsertedDeleted(object sender, PersistentObjectsEventArgs e)
        {
            appointmentsTableAdapter.Update(livegameDataSet1);
            livegameDataSet1.AcceptChanges();
            appointmentsTableAdapter.Fill(livegameDataSet1.appointments);
        }


        private void GetNames() // Break LIst Isimlerini Getiriyor.
        {
            using (var conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                var cmd = new MySqlCommand("spBreakListNames;", conn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.Add(new MySqlParameter("DepartmentName", DepartmentNameFromMainForm));
                cmd.Parameters.Add(new MySqlParameter("OperationDate", OperationDate));
                conn.Open();
                using (var adapter = new MySqlDataAdapter())
                {
                    var dt = new DataTable();
                    adapter.SelectCommand = cmd;
                    {
                        adapter.Fill(dt);
                        schedulerStorage1.Resources.DataSource = dt;
                        Text = @"Break List of:" + DepartmentNameFromMainForm;
                    }
                }
                conn.Close();
                conn.Dispose();
            }
        }

        private void GetNamesGelecek() // Rotadaki gelecek isimler
        {
            using (var conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                var cmd = new MySqlCommand("spBreakListNamesGrid;", conn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.Add(new MySqlParameter("DepartmentName", DepartmentNameFromMainForm));
                cmd.Parameters.Add(new MySqlParameter("OperationDate", OperationDate));
                conn.Open();

                using (var adapter = new MySqlDataAdapter())
                {
                    var dt = new DataTable();
                    adapter.SelectCommand = cmd;
                    {
                        adapter.Fill(dt);
                        gridPErsonel.DataSource = dt;
                    }
                }
                conn.Close();
                conn.Dispose();
            }
        }

        private void GetTables() // Masalar
        {
            using (var conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                using (
                    var command = new MySqlCommand("SELECT Game, No,logismosno  FROM livegame.tables where open = 1",
                        conn)
                    {
                        CommandType = CommandType.Text
                    })
                {
                    conn.Open();
                    command.ExecuteNonQuery();

                    using (var adapter = new MySqlDataAdapter())
                    {
                        var dt = new DataTable();
                        adapter.SelectCommand = command;
                        {
                            adapter.Fill(dt);
                            gridMasa.DataSource = dt;
                        }
                    }

                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        private void GetBolgeler() // Masalar
        {
            using (var conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                var cmd = new MySqlCommand("spbolgeler;", conn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.Add(new MySqlParameter("DepartmentName", DepartmentNameFromMainForm));

                conn.Open();

                using (var adapter = new MySqlDataAdapter())
                {
                    var dt = new DataTable();
                    adapter.SelectCommand = cmd;
                    {
                        adapter.Fill(dt);
                        gridMasa.DataSource = dt;
                    }
                }
                conn.Close();
                conn.Dispose();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            schedulerControl.MouseWheel += schedulerControl_MouseWheel;
            appointmentsTableAdapter.Fill(livegameDataSet1.appointments);
            GetNames();
            GetNamesGelecek();
            if (DepartmentNameFromMainForm != "Live Game")
            {
                GetBolgeler();
                btnMasalar.Visible = false;
                btnYenile.Visible = false;
                gridView1.Columns["logismosno"].Visible = false;
            }
            else
            {
                GetTables();
                gridView1.Columns["No"].SortOrder = ColumnSortOrder.Ascending;
                gridView1.Columns["logismosno"].Visible = false;
            }
        }

        private void schedulerControl_MouseWheel(object sender, MouseEventArgs e) // Mouse asagi yukari hareket ediyor.
        {
            var index = schedulerControl.ActiveView.FirstVisibleResourceIndex;
            if ((e.Delta > 0) && (index != 0))
                schedulerControl.ActiveView.FirstVisibleResourceIndex--;
            if ((e.Delta < 0) && (index != schedulerControl.Storage.Resources.Count - 1))
                schedulerControl.ActiveView.FirstVisibleResourceIndex++;
        }

      

        
        private void schedulerControl_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            e.Menu.Items.Clear();
            var scheduler = (SchedulerControl) sender;
            var clickPoint = scheduler.PointToClient(MousePosition);
            var hi = scheduler.ActiveView.ViewInfo.CalcHitInfo(clickPoint, true);
            if (hi.HitTest == SchedulerHitTest.ResourceHeader)
            {
                e.Menu.Items.Clear();
                ResourceId = (int) hi.ViewInfo.Resource.Id;
                ResourceName = hi.ViewInfo.Resource.Caption;
                e.Menu.Items.Add(new SchedulerMenuItem(ResourceName + " Bitir", EveGonder));
                e.Menu.Items.Add(new SchedulerMenuItem(ResourceName + " Geri Gönder", GeriGonder));
            }

            if (hi.HitTest == SchedulerHitTest.Cell)
                if (schedulerControl.SelectedAppointments.Count == 1)
                {
                    
                    e.Menu.Items.Clear();
                    e.Menu.Items.Add(new SchedulerMenuItem("İşaretle", Isaretle));
                    e.Menu.Items.Add(new SchedulerMenuItem("İşareti Kaldır", IsaretiKaldir));
                    e.Menu.Items.Add(new SchedulerMenuItem("Şu ana git",
                        GoToNow));
                }
            
            else
            {
                e.Menu.Items.Clear();
                 e.Menu.Items.Add(new SchedulerMenuItem("Şu ana git",
                        GoToNow));
            }
           
        }

        private void GoToNow(object sender, EventArgs e)
        {
            var tTime = new TimeInterval { Start = DateTime.Now };
            schedulerControl.TimelineView.GotoTimeInterval(tTime);}

        public void GeriGonder(object sender, EventArgs e)
        {
            var dialogResult = XtraMessageBox.Show($"{ResourceName} Geri Gönderilecek", "Dikkat",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                using (var conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    var cmd = new MySqlCommand("spBreakPersonelGeriGotur;", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new MySqlParameter("resourceID", ResourceId));
                    cmd.Parameters.Add(new MySqlParameter("operationDate", OperationDate));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                GetNames();
                GetNamesGelecek();
            }
            else
            {
                XtraMessageBox.Show("OK Sen Bilirsin", "Bitirilmedi");
            }
        }

        public void EveGonder(object sender, EventArgs e)
        {
            var dialogResult = XtraMessageBox.Show($"{ResourceName} Bitirilecek", "Dikkat", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                using (var conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    var cmd = new MySqlCommand("spBreakPersonelBitir;", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new MySqlParameter("resourceID", ResourceId));
                    cmd.Parameters.Add(new MySqlParameter("operationDate", OperationDate));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                GetNames();
            }
            else
            {
                XtraMessageBox.Show("OK Sen Bilirsin", "Bitirilmedi");
            }
        }

        public void Isaretle(object sender, EventArgs e)
        {
            if (schedulerControl.SelectedAppointments.Count != 1) return;
            var apt = schedulerControl.SelectedAppointments[0];
            apt.LabelKey = 1;
        }

        public void IsaretiKaldir(object sender, EventArgs e)
        {
            if (schedulerControl.SelectedAppointments.Count != 1) return;
            var apt = schedulerControl.SelectedAppointments[0];
            apt.LabelKey = 0;
        }

        private static void DeleteSelectedRows(GridView view)
        {
            view.DeleteRow(view.FocusedRowHandle);
        }

        private void gridControl1_DragLeave(object sender, EventArgs e)
        {
            if (DepartmentNameFromMainForm == "Live Game")
                DeleteSelectedRows(gridView1);
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (DepartmentNameFromMainForm == "Live Game")
            {
                GetTables();
                gridView1.Columns["No"].SortOrder = ColumnSortOrder.Ascending;
            }
            if (DepartmentNameFromMainForm == "F&B")
                GetBolgeler();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            using (var form = new frmMasalar())
            {
                var dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                    GetTables();
            }
        }

        private void schedulerControl_CustomDrawResourceHeader(object sender, CustomDrawObjectEventArgs e)
        {
            var header = (ResourceHeader) e.ObjectInfo;

            if (header.Resource.CustomFields["Position"].Equals("Inspector"))
                header.Appearance.HeaderCaption.ForeColor = Color.Red;

            if (header.Resource.CustomFields["Position"].Equals("Dealer"))
                header.Appearance.HeaderCaption.ForeColor = Color.Blue;
            

        }

        private void schedulerControl_InitAppointmentDisplayText(object sender, AppointmentDisplayTextEventArgs e)
        {
            e.Text = e.Appointment.Location;}

        private void schedulerStorage1_AppointmentDeleting(object sender, PersistentObjectCancelEventArgs e)
        {
            var apt = (Appointment) e.Object;
            LocationData = apt.Location;
            SubjectData = apt.Subject;
            LogismosNo = apt.CustomFields["Logismosno"].ToString();
            var sourceTable = gridMasa.DataSource as DataTable;
            if (sourceTable == null) return;
            var row = sourceTable.NewRow();
            if (DepartmentNameFromMainForm == "Live Game")
                if (SubjectData != "BREAK")
                {
                    row["Game"] = SubjectData;
                    row["No"] = LocationData;
                    row["logismosno"] = LogismosNo;
                    sourceTable.Rows.Add(row);
                    gridView1.Columns["No"].SortOrder = ColumnSortOrder.Ascending;
                }
            
        }

        
       

        private void schedulerControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SchedulerHitInfo hi = schedulerControl.ActiveView.ViewInfo.CalcHitInfo(e.Location, false);
            if (hi.HitTest == SchedulerHitTest.Cell) // Eger bos alana tiklanirsa
            {
                
                TimeInterval interval = hi.ViewInfo.Interval;
                string resource = hi.ViewInfo.Resource.Id.ToString();
                DateTime StartTime = interval.Start;
                DateTime EndTime = interval.End;
                var selection = gridView1.GetSelectedRows();

                var count = selection.Length;
                for (var i = 0; i < count; i++)
                {
                    var rowIndex = selection[i];
                    var apt = schedulerStorage1.CreateAppointment(AppointmentType.Normal);

                    if (DepartmentNameFromMainForm == "Live Game")
                    {
                        var subject = (string)gridView1.GetRowCellValue(rowIndex, "Game");
                        var location = (string)gridView1.GetRowCellValue(rowIndex, "No");
                        var logismosno = (string)gridView1.GetRowCellValue(rowIndex, "logismosno");

                        apt.Subject = subject;
                        apt.Location = location;
                        apt.ResourceId = resource;
                        apt.Start = StartTime;
                        apt.End = EndTime;
                        apt.CustomFields["Department"] = DepartmentNameFromMainForm;
                        apt.CustomFields["ActualShiftDate"] = OperationDate;
                        apt.CustomFields["Logismosno"] = logismosno;
                        apt.Duration = TimeSpan.FromMinutes(20);
                        schedulerStorage1.Appointments.Add(apt);
                        schedulerControl.Storage.RefreshData();
                        if(subject != "BREAK")
                        {
                            DeleteSelectedRows(gridView1);
                            schedulerControl.AppointmentViewInfoCustomizing += schedulerControl_AppointmentViewInfoCustomizing;
                        }
                        
                    }
                    else
                    {
                        var subject = (string)gridView1.GetRowCellValue(rowIndex, "Bolge");
                        var location = (string)gridView1.GetRowCellValue(rowIndex, "bolge2");
                        apt.Subject = subject;
                        apt.Location = location;
                        apt.CustomFields["Department"] = DepartmentNameFromMainForm;
                        apt.CustomFields["ActualShiftDate"] = OperationDate;
                        apt.Duration = TimeSpan.FromMinutes(20);
                        schedulerStorage1.Appointments.Add(apt);
                        schedulerControl.Storage.RefreshData();
                        
                    }
                }
            }
            
        }
        
        private void gridViewPers_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            var column = e.Column;
            if (column != colGetir) return;
            var rowid = (int) ((GridView) sender).GetRowCellValue(e.RowHandle, "ResourceID");
            using (var conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                var cmd = new MySqlCommand("spBreakPersonelGetir;", conn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.Add(new MySqlParameter("resourceID", rowid));
                cmd.Parameters.Add(new MySqlParameter("operationDate", OperationDate));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
            }
            DeleteSelectedRows(gridViewPers);
            GetNames();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            
            var dialogResult = XtraMessageBox.Show("Yeni Gune Gecmek istediginizden Emin misiniz", "Dikkat",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    using (var conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                    {
                        try
                        {
                            var cmd = new MySqlCommand("spBitir;", conn) {CommandType = CommandType.StoredProcedure};
                            cmd.Parameters.Add(new MySqlParameter("departmentName", DepartmentNameFromMainForm));
                            cmd.Parameters.Add(new MySqlParameter("operationDate", OperationDate));
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            conn.Dispose();
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            // Get the parameters/arguments passed to program if any
                            var arguments = string.Empty;
                            var args = Environment.GetCommandLineArgs();
                            for (var i = 1; i < args.Length; i++) // args[0] is always exe path/filename
                                arguments += args[i] + " ";

                            // Restart current application, with same arguments/parameters
                            Application.Exit();
                            Process.Start(Application.ExecutablePath, arguments);
                        }
                    }
                    break;
                case DialogResult.No:
                    //do something else
                    break;
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private void schedulerControl_AppointmentViewInfoCustomizing(object sender, AppointmentViewInfoCustomizingEventArgs e)
        {
            if (e.ViewInfo.Appointment.Subject.Contains("AR"))
            {
                e.ViewInfo.Appointment.LabelKey = 2;

            }
            if (e.ViewInfo.Appointment.Subject.Contains("BJ"))
            {
                e.ViewInfo.Appointment.LabelKey = 3;

            }
            if (e.ViewInfo.Appointment.Subject.Contains("NP"))
            {
                e.ViewInfo.Appointment.LabelKey = 8;

            }
            if (e.ViewInfo.Appointment.Subject.Contains("RP"))
            {
                e.ViewInfo.Appointment.LabelKey = 9;

            }
        }

        private void schedulerControl_CustomDrawTimeCell(object sender, CustomDrawObjectEventArgs e)
        {
            if (e.ObjectInfo is SelectionBarCell)
            {
                SelectionBarCell cell = e.ObjectInfo as SelectionBarCell;
                
                
                e.DrawDefault();
                int breakerCount = CountBreakers(cell, cell.Interval);
                Rectangle rect1 = new Rectangle(cell.Bounds.X, cell.Bounds.Y, cell.Bounds.Width, cell.Bounds.Height/2);
                e.Graphics.FillRectangle(new SolidBrush(Color.White), rect1);
                e.Graphics.DrawRectangle(Pens.Lavender, rect1);
                e.Graphics.DrawString("B: "+breakerCount, cell.Appearance.Font, new SolidBrush(Color.Black), rect1);


                int tableCount = CountTables(cell, cell.Interval);
                Rectangle rect2 = new Rectangle(cell.Bounds.X, cell.Bounds.Y + cell.Bounds.Height / 2, cell.Bounds.Width, cell.Bounds.Height / 2);
                e.Graphics.FillRectangle(new SolidBrush(Color.Lavender), rect2);
                e.Graphics.DrawRectangle(Pens.Fuchsia, rect2);
                e.Graphics.DrawString("T: " + tableCount, cell.Appearance.Font, new SolidBrush(Color.Black), rect2);
                e.Handled = true;
            }
        }
        private int CountBreakers(SelectionBarCell rh, TimeInterval visTime)
        {
            AppointmentBaseCollection col = schedulerControl.ActiveView.GetAppointments().FindAll(delegate (Appointment apt) { return (apt.Location.Contains("/")) && (visTime.Contains(new TimeInterval(apt.Start, apt.End))); });
            return col.Count;


        }
        private int CountTables(SelectionBarCell rh, TimeInterval visTime)
        {
            
            AppointmentBaseCollection col = schedulerControl.ActiveView.GetAppointments().FindAll(delegate (Appointment apt) { return (apt.Location != "/") && (visTime.Contains(new TimeInterval(apt.Start, apt.End))); });
            return col.Count;
        }
    }
}