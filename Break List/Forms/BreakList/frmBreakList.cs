using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler.Drawing;
using MySql.Data.MySqlClient;
using Break_List.Properties;
using DevExpress.XtraScheduler.Services.Internal;

namespace Break_List.Forms.BreakList
{
    public partial class frmBreakList : XtraForm
    {
        public string _departmentNameFromMainForm { get; set; }
        public string _userRoleIDFromMainForm { get; set; }
        public DateTime _operationDate { get; set; }
        public DateTime _EndDate { get; set; }

        public TimeSpan _Duration { get; set; }
        public frmBreakList()
        {
            InitializeComponent();

            schedulerControl.Views.DayView.Enabled = false;
            schedulerControl.ActiveViewType = SchedulerViewType.Timeline;
            schedulerControl.GroupType = SchedulerGroupType.Resource;
            _operationDate = Settings.Default.operationDate; // Başlangıç saatini ayarlıyor
            _EndDate = Settings.Default.EndDate;

            _Duration = _EndDate - _operationDate;

            TimeSpan tsStart = TimeSpan.FromHours(_operationDate.Hour);
            TimeSpan tsEnd = TimeSpan.FromHours(_EndDate.Hour);
            schedulerControl.Start = _operationDate;

            schedulerControl.TimelineView.WorkTime = new TimeOfDayInterval(tsStart, tsStart + _Duration);

            TimeScaleCollection scales = schedulerControl.TimelineView.Scales;
            schedulerControl.TimelineView.Scales.BeginUpdate();
            try
            {
                scales.Clear();
                scales.Add(new TimeScaleFixedInterval(TimeSpan.FromDays(1), tsStart, maxTime));
                //scales.Add(new TimeInterval(TimeSpan.FromHours(1), tsStart, maxTime));
                scales.Add(new TimeScaleFixedInterval(TimeSpan.FromMinutes(20), minTime, maxTime));
                schedulerControl.LimitInterval.Start = _operationDate;
                schedulerControl.LimitInterval.End = _EndDate;
            }
            finally
            {
                schedulerControl.TimelineView.Scales.EndUpdate();
            }

            schedulerStorage1.AppointmentsChanged += OnAppointmentChangedInsertedDeleted;
            schedulerStorage1.AppointmentsInserted += OnAppointmentChangedInsertedDeleted;
            schedulerStorage1.AppointmentsDeleted += OnAppointmentChangedInsertedDeleted;
            
        }




        private void OnAppointmentChangedInsertedDeleted(object sender, PersistentObjectsEventArgs e)
        {

            appointmentsTableAdapter.Update(livegameDataSet1);
            livegameDataSet1.AcceptChanges();
            appointmentsTableAdapter.Fill(livegameDataSet1.appointments);
        }

        readonly TimeSpan minTime = new TimeSpan(0, 0, 0);
        readonly TimeSpan maxTime = new TimeSpan(24, 0, 0);
        GridHitInfo downHitInfo;


        void getNames()
        {
            using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                MySqlCommand cmd = new MySqlCommand("spBreakListNames;", conn) { CommandType = CommandType.StoredProcedure };
                //string _department = _departmentNameFromMainForm;                
                // Add your parameters here if you need them
                cmd.Parameters.Add(new MySqlParameter("DepartmentName", _departmentNameFromMainForm));
                cmd.Parameters.Add(new MySqlParameter("OperationDate", _operationDate));
                conn.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                {
                    DataTable dt = new DataTable();
                    adapter.SelectCommand = cmd;
                    {
                        adapter.Fill(dt);
                        schedulerStorage1.Resources.DataSource = dt;
                        Text = "Break List of:" + _departmentNameFromMainForm;
                    }
                }
                conn.Close();
            }

        }

        void getNamesGelecek()
        {
            using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                MySqlCommand cmd = new MySqlCommand("spBreakListNamesGrid;", conn) { CommandType = CommandType.StoredProcedure };               
                cmd.Parameters.Add(new MySqlParameter("DepartmentName", _departmentNameFromMainForm));
                cmd.Parameters.Add(new MySqlParameter("OperationDate", _operationDate));
                conn.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                {
                    DataTable dt = new DataTable();
                    adapter.SelectCommand = cmd;
                    {
                        adapter.Fill(dt);
                        gridPErsonel.DataSource = dt;
                       
                    }
                }
                conn.Close();
            }

        }
        void getTables()
        {
            using (var conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
            using (var command = new MySqlCommand("SELECT * FROM livegame.tables where open = 1", conn)
            {
                CommandType = CommandType.Text
            })
            {
                conn.Open();
                command.ExecuteNonQuery();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                {
                    DataTable dt = new DataTable();
                    adapter.SelectCommand = command;
                    {
                        adapter.Fill(dt);
                        gridMasa.DataSource = dt;
                       
                        var rows = dt.Select();


                    }
                }


            }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            schedulerControl.MouseWheel += schedulerControl_MouseWheel;
            appointmentsTableAdapter.Fill(livegameDataSet1.appointments);
            getNames();
            getNamesGelecek();
            switch (_departmentNameFromMainForm)
            {
                case "Live Game":
                    getTables();                    
                    gridView1.Columns["No"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    break;
                default:
                    break;
            }
            
        }

        void schedulerControl_MouseWheel(object sender, MouseEventArgs e) // Mouse asagi yukari hareket ediyor.
        {
            int index = schedulerControl.ActiveView.FirstVisibleResourceIndex;
            if (e.Delta > 0 && index != 0)
                schedulerControl.ActiveView.FirstVisibleResourceIndex--;
            if (e.Delta < 0 && index != schedulerControl.Storage.Resources.Count - 1)
                schedulerControl.ActiveView.FirstVisibleResourceIndex++;
        }
      



        #region #GetDragData
        SchedulerDragData GetDragData(GridView view)
        {
            int[] selection = view.GetSelectedRows();
            if (selection == null)
                return null;

            AppointmentBaseCollection appointments = new AppointmentBaseCollection();
            int count = selection.Length;
            for (int i = 0; i < count; i++)
            {

                int rowIndex = selection[i];
                Appointment apt = schedulerStorage1.CreateAppointment(AppointmentType.Normal);
                string subject = (string)view.GetRowCellValue(rowIndex, "Game");
                string location = (string)view.GetRowCellValue(rowIndex, "No");
                apt.Subject = subject;
                apt.Location = location;
                apt.CustomFields["Department"] = _departmentNameFromMainForm;
                apt.CustomFields["ActualShiftDate"] = _operationDate;
                apt.Duration = TimeSpan.FromMinutes(20);
                //apt.CustomFields["Sure"] = 20;                          
                appointments.Add(apt);

            }

            return new SchedulerDragData(appointments, 0);
            
        }
        #endregion #GetDragData

        private void gridView1_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 1,
                    downHitInfo.HitPoint.Y - dragSize.Height / 1), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    view.GridControl.DoDragDrop(GetDragData(view), DragDropEffects.All);
                    downHitInfo = null;
                }
            }
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            downHitInfo = null;

            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None)
                return;
            if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.HitTest != GridHitTest.RowIndicator)
                downHitInfo = hitInfo;

        }
        
        
        int resourceID { get; set; }
        string resourceName { get; set; }
        private void schedulerControl_PopupMenuShowing(object sender, DevExpress.XtraScheduler.PopupMenuShowingEventArgs e)
        {
            e.Menu.Items.Clear();
            SchedulerControl scheduler = (SchedulerControl)sender;
            Point clickPoint = scheduler.PointToClient(Control.MousePosition);
            SchedulerHitInfo hi = scheduler.ActiveView.ViewInfo.CalcHitInfo(clickPoint, true);
            if (hi.HitTest == SchedulerHitTest.ResourceHeader)
            {
                e.Menu.Items.Clear();
                resourceID = (int)hi.ViewInfo.Resource.Id;
                resourceName = (string)hi.ViewInfo.Resource.Caption;
                e.Menu.Items.Add(new SchedulerMenuItem(resourceName + " Bitir", eveGonder));
                
            }

            if (hi.HitTest == SchedulerHitTest.Cell)
            {
                
                if (schedulerControl.SelectedAppointments.Count == 1)
                {
                    
                    e.Menu.Items.Clear();                    
                    e.Menu.Items.Add(new SchedulerMenuItem("İşaretle", isaretle));
                    e.Menu.Items.Add(new SchedulerMenuItem("İşareti Kaldır", isaretiKaldir));
                }
                else
                {
                    e.Menu.Items.Clear();
                }
                
            }
            if ((hi.HitTest == SchedulerHitTest.TimeScaleHeader)){
                
                AddCustomppointmentComparer(schedulerControl);
            }
                
        }
        public void eveGonder(object sender, EventArgs e)
        {
            DialogResult dialogResult = XtraMessageBox.Show(string.Format("{0} Bitirilecek", resourceName), "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    MySqlCommand cmd = new MySqlCommand("spBreakPersonelBitir;", conn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.Add(new MySqlParameter("resourceID", resourceID));
                    cmd.Parameters.Add(new MySqlParameter("operationDate", _operationDate));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                XtraMessageBox.Show(string.Format("{0} Bitirildi", resourceName));
                getNames();
            }
            else
            {
                XtraMessageBox.Show("OK Sen Bilirsin", "Bitirilmedi");
            }
            
        }
        public void isaretle(object sender, EventArgs e)
        {
            Appointment apt;
            if (schedulerControl.SelectedAppointments.Count == 1)
            {
                apt = schedulerControl.SelectedAppointments[0];
                SchedulerMenuItem menu = (SchedulerMenuItem)sender;
                //apt.Location = menu.Caption;
                apt.LabelKey = 1;
            }
        }
        public void isaretiKaldir(object sender, EventArgs e)
        {
            Appointment apt;
            if (schedulerControl.SelectedAppointments.Count == 1)
            {
                apt = schedulerControl.SelectedAppointments[0];
                SchedulerMenuItem menu = (SchedulerMenuItem)sender;
                //apt.Location = menu.Caption;
                apt.LabelKey = 0;
            }
        }
        private static void DeleteSelectedRows(GridView view)
        {
            
                view.DeleteRow(view.FocusedRowHandle);            
                

        }

        private void gridControl1_DragLeave(object sender, EventArgs e)
        {
           DeleteSelectedRows(gridView1);
          
                
        }

       

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            getTables();
            gridView1.Columns["No"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            using (frmMasalar form = new frmMasalar())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    getTables();
                }

            }
        }

        private void schedulerControl_CustomDrawResourceHeader(object sender, CustomDrawObjectEventArgs e)
        {
            ResourceHeader header = (ResourceHeader)e.ObjectInfo;

            if (header.Resource.CustomFields["Position"].Equals("Inspector"))
            {
                header.Appearance.HeaderCaption.ForeColor = Color.Red;
                
            }

            if (header.Resource.CustomFields["Position"].Equals("Dealer"))
            {
                header.Appearance.HeaderCaption.ForeColor = Color.Blue;

            }
            
        }

        private void schedulerControl_InitAppointmentDisplayText(object sender, AppointmentDisplayTextEventArgs e)
        {
            e.Text = e.Appointment.Location;
            //e.Appointment.Subject = "";
        }
        string locationData { get; set; }
        string subjectData { get; set; }
        private void schedulerStorage1_AppointmentDeleting(object sender, PersistentObjectCancelEventArgs e)
        {
            Appointment apt = (Appointment)e.Object;
            locationData = apt.Location;
            subjectData = apt.Subject;
            DataTable sourceTable = gridMasa.DataSource as DataTable;
            DataRow row = sourceTable.NewRow();
            if (subjectData != "Break")
            {
                row["Game"] = subjectData;
                row["No"] = locationData;
                sourceTable.Rows.Add(row);
                gridView1.Columns["No"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            }
            
        }

        private void schedulerControl_AppointmentViewInfoCustomizing_1(object sender, AppointmentViewInfoCustomizingEventArgs e)
        {
            if (e.ViewInfo.Appointment.Location.Contains("C"))
            {
                e.ViewInfo.Appearance.Font = new Font(e.ViewInfo.Appearance.Font, FontStyle.Bold);
                e.ViewInfo.Appearance.ForeColor = Color.Red;
                e.ViewInfo.Appearance.BorderColor = Color.Red;

            }
        }

        private void schedulerControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SchedulerHitInfo hInfo = schedulerControl.ActiveView.ViewInfo.CalcHitInfo(new Point(e.X, e.Y), true);          

            Point pos = new Point(e.X, e.Y);
            SchedulerViewInfoBase viewInfo = schedulerControl.ActiveView.ViewInfo;
            SchedulerHitInfo hitInfo = viewInfo.CalcHitInfo(pos, true);

            if (hitInfo.HitTest == SchedulerHitTest.ResourceHeader)
            {
                var resourceID = (int)hInfo.ViewInfo.Resource.Id;
                MessageBox.Show(resourceID.ToString());
            }
        }

        private void gridViewPers_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            var Column = e.Column;
            if(Column == colGetir)
            {
                int rowid = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "ResourceID");
                using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    MySqlCommand cmd = new MySqlCommand("spBreakPersonelGetir;", conn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.Add(new MySqlParameter("resourceID", rowid));
                    cmd.Parameters.Add(new MySqlParameter("operationDate", _operationDate));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
               
                
                //getNamesGelecek();
                DeleteSelectedRows(gridViewPers);
                getNames();
                
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = XtraMessageBox.Show("Yeni Gune Gecmek istediginizden Emin misiniz", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand("kopyala;", conn) { CommandType = CommandType.StoredProcedure };
                        cmd.Parameters.Add(new MySqlParameter("departmentName", _departmentNameFromMainForm));
                        cmd.Parameters.Add(new MySqlParameter("operationDate", _operationDate));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch(Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        // Get the parameters/arguments passed to program if any
                        string arguments = string.Empty;
                        string[] args = Environment.GetCommandLineArgs();
                        for (int i = 1; i < args.Length; i++) // args[0] is always exe path/filename
                            arguments += args[i] + " ";

                        // Restart current application, with same arguments/parameters
                        Application.Exit();
                        System.Diagnostics.Process.Start(Application.ExecutablePath, arguments);
                    }
                   
                }
               
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            

        }

        
        void AddCustomppointmentComparer(SchedulerControl serviceProvider)
        {
            MyAppointmentComparerService comparer = new MyAppointmentComparerService("Location");
            serviceProvider.Services.AddService(typeof(IExternalAppointmentCompareService), comparer);
        }
    }
}
