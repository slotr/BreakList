using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using MySql.Data.MySqlClient;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraScheduler.Drawing;
namespace Break_List.Forms.Rotalar
{
    public partial class FrmRoster : XtraForm
    {
        public string DepartmentNameFromMainForm { get; set; }
        public string UserName { get; set; }
        public FrmRoster()
        {
           
            InitializeComponent();
            schedulerControl1.ActiveViewType = SchedulerViewType.Timeline;
            schedulerControl1.GroupType = SchedulerGroupType.Resource;
            var scales = schedulerControl1.TimelineView.Scales;
            schedulerControl1.TimelineView.AppointmentDisplayOptions.StartTimeVisibility = AppointmentTimeVisibility.Never;
            schedulerControl1.TimelineView.AppointmentDisplayOptions.EndTimeVisibility = AppointmentTimeVisibility.Never;
            scales.Clear();

            scales.Add(new TimeScaleMonth());
            //scales.Add(new TimeScaleWeek());
            scales.Add(new TimeScaleDay());

            var startDate = schedulerControl1.SelectedInterval.Start;
            schedulerControl1.Start = new DateTime(startDate.Year, startDate.Month, 1);

            UpdateScaleWidth();

            schedulerStorage1.AppointmentsChanged += OnAppointmentChangedInsertedDeleted;
            schedulerStorage1.AppointmentsInserted += OnAppointmentChangedInsertedDeleted;
            schedulerStorage1.AppointmentsDeleted += OnAppointmentChangedInsertedDeleted;
            }
        private void OnAppointmentChangedInsertedDeleted(object sender, PersistentObjectsEventArgs e)
        {
            try
            {
                rosterTableAdapter.Update(livegameDataSet1);
                livegameDataSet1.AcceptChanges();
                rosterTableAdapter.Fill(livegameDataSet1.roster);
            }
            catch (DBConcurrencyException ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Database de bir hata olustu.");
                
            }
            
        }

        private void schedulerControl_MouseWheel(object sender, MouseEventArgs e) // Mouse asagi yukari hareket ediyor.
        {
            int index = schedulerControl1.ActiveView.FirstVisibleResourceIndex;
            if (e.Delta > 0 && index != 0)
                schedulerControl1.ActiveView.FirstVisibleResourceIndex--;
            if (e.Delta < 0 && index != schedulerControl1.Storage.Resources.Count - 1)
                schedulerControl1.ActiveView.FirstVisibleResourceIndex++;
        }

        private void GetNames()
        {
            using (var conn = new MySqlConnection(Properties.Settings.Default.livegameConnectionString2))
            {
                var cmd = new MySqlCommand("spRotaPersonel;", conn) { CommandType = CommandType.StoredProcedure };
                var department = DepartmentNameFromMainForm;
                // Add your parameters here if you need them
                cmd.Parameters.Add(new MySqlParameter("DepartmentName", department));

                conn.Open();

                using (var adapter = new MySqlDataAdapter())
                {
                    var dt = new DataTable();
                    adapter.SelectCommand = cmd;
                    {
                        adapter.Fill(dt);
                        schedulerStorage1.Resources.DataSource = dt;
                        Text = department + @" Rotası ";
                    }
                }
                conn.Close();
            }

        }

        private void frmRoster_Load(object sender, EventArgs e)
        {
            rosterTableAdapter.Fill(livegameDataSet1.roster);
            schedulerControl1.MouseWheel += schedulerControl_MouseWheel;
            GetNames();
            GetShifts();

        }

        private void UpdateScaleWidth()
        {
            schedulerControl1.TimelineView.GetBaseTimeScale().Width = 50;
        }

        private void GetShifts()
        {
            using (var conn = new MySqlConnection(Properties.Settings.Default.livegameConnectionString2))
            {
                var cmd = new MySqlCommand("Select ShiftNo as Shift, ShiftStart as Start, Hour as Hours from shifts", conn)
                { CommandType = CommandType.Text };
                conn.Open();

                using (var adapter = new MySqlDataAdapter())
                {
                    var dt = new DataTable();
                    adapter.SelectCommand = cmd;
                    {
                        adapter.Fill(dt);
                        gridControl1.DataSource = dt;
                    }
                }
                conn.Close();
            }

        }

        private GridHitInfo _downHitInfo;
        private readonly TimeSpan _minTime = new TimeSpan(0, 0, 0);
        private readonly TimeSpan _maxTime = new TimeSpan(24, 0, 0);
        #region #GetDragData

        private SchedulerDragData GetDragData(GridView view)
        {
            var selection = view.GetSelectedRows();
            if (selection == null)
                return null;

            var appointments = new AppointmentBaseCollection();
            var count = selection.Length;
            for (var i = 0; i < count; i++)
            {

                var rowIndex = selection[i];
                var apt = schedulerStorage1.CreateAppointment(AppointmentType.Normal);
                var subject = (string)view.GetRowCellValue(rowIndex, "Shift");
                var start = (TimeSpan)view.GetRowCellValue(rowIndex, "Start");
                var hour = (TimeSpan)view.GetRowCellValue(rowIndex, "Hours");
                var end = start + hour;
                var totalDuration = Convert.ToDouble(hour.TotalHours);
                var totalHours = Convert.ToDouble(end.TotalHours);
                // MessageBox.Show(totalHours.ToString());
                if (totalHours > 24)
                {
                    var final = end - _maxTime;
                    apt.Subject = subject;
                    //apt.Duration = start + hour;
                    apt.CustomFields["StartTime"] = start;
                    apt.CustomFields["EndTime"] = final;
                    apt.CustomFields["ToplamSure"] = totalDuration;
                    apt.CustomFields["OverTime"] = 0;
                    apt.CustomFields["ErkenGonderim"] = 0;
                    apt.CustomFields["SickCall"] = 0;
                    apt.CustomFields["NoCall"] = 0;
                    apt.CustomFields["SickSentHome"] = 0;
                    apt.CustomFields["Rapor"] = 0;
                    apt.CustomFields["SentHome"] = 0;
                    apt.CustomFields["Late"] = 0;
                    apt.CustomFields["Suspend"] = 0;
                    apt.CustomFields["Department"] = DepartmentNameFromMainForm;
                    apt.CustomFields["Createdby"] = UserName;
                    apt.CustomFields["CreatedAt"] = DateTime.Now;
                    apt.CustomFields["Bitir"] = 0;
                    appointments.Add(apt);
                }

                else
                {
                    apt.Subject = subject;
                    //apt.Duration = start + hour;
                    apt.CustomFields["StartTime"] = start;
                    apt.CustomFields["EndTime"] = end;
                    apt.CustomFields["ToplamSure"] = totalDuration;
                    apt.CustomFields["OverTime"] = 0;
                    apt.CustomFields["ErkenGonderim"] = 0;
                    apt.CustomFields["SickCall"] = 0;
                    apt.CustomFields["NoCall"] = 0;
                    apt.CustomFields["SickSentHome"] = 0;
                    apt.CustomFields["Rapor"] = 0;
                    apt.CustomFields["SentHome"] = 0;
                    apt.CustomFields["Late"] = 0;
                    apt.CustomFields["Suspend"] = 0;
                    apt.CustomFields["Department"] = DepartmentNameFromMainForm;
                    apt.CustomFields["Createdby"] = UserName;
                    apt.CustomFields["CreatedAt"] = DateTime.Now;
                    apt.CustomFields["Bitir"] = 0;
                    appointments.Add(apt);
                }
            }

            return new SchedulerDragData(appointments, 0);
        }
        #endregion #GetDragData

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            var view = sender as GridView;
            _downHitInfo = null;

            if (view == null) return;
            var hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (ModifierKeys != Keys.None)
                return;
            if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.HitTest != GridHitTest.RowIndicator)
                _downHitInfo = hitInfo;
        }

        private void gridView1_MouseMove(object sender, MouseEventArgs e)
        {
            var view = sender as GridView;
            if (e.Button != MouseButtons.Left || _downHitInfo == null) return;
            var dragSize = SystemInformation.DragSize;
            var dragRect = new Rectangle(new Point(_downHitInfo.HitPoint.X - dragSize.Width / 1,
                _downHitInfo.HitPoint.Y - dragSize.Height / 1), dragSize);

            if (dragRect.Contains(new Point(e.X, e.Y))) return;
            view?.GridControl.DoDragDrop(GetDragData(view), DragDropEffects.All);
            _downHitInfo = null;
        }



        private void schedulerControl1_AppointmentDrop(object sender, AppointmentDragEventArgs e)
        {
        }



        private void schedulerControl1_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            var scheduler = (SchedulerControl)sender;
            var form = new FrmAddOverTime(scheduler, e.Appointment, e.OpenRecurrenceForm)
            {
                labelControl2 = {Text = UserName}
            };
            try
            {   
                e.DialogResult = form.ShowDialog();
                
                e.Handled = true;
            }
            finally
            {
                form.Dispose();
            }

        }

        private void schedulerControl1_AppointmentViewInfoCustomizing(object sender, AppointmentViewInfoCustomizingEventArgs e)
        {
            if (!e.ViewInfo.Appointment.Subject.Contains("OFF")) return;
            e.ViewInfo.Appearance.Font = new Font(e.ViewInfo.Appearance.Font, FontStyle.Bold);
            e.ViewInfo.Appearance.ForeColor = Color.Red;
            e.ViewInfo.Appearance.BorderColor = Color.Red;
        }

        private void schedulerControl1_CustomDrawResourceHeader(object sender, CustomDrawObjectEventArgs e)
        {
            var header = (ResourceHeader)e.ObjectInfo;

            if (header.Resource.CustomFields["Position"].Equals("Inspector"))
            {
                header.Appearance.HeaderCaption.ForeColor = Color.DarkRed;

            }

            if (header.Resource.CustomFields["Position"].Equals("Dealer"))
            {
                header.Appearance.HeaderCaption.ForeColor = Color.DarkBlue;

            }

            if (header.Resource.CustomFields["Position"].Equals("Dealer Inspector"))
            {
                header.Appearance.HeaderCaption.ForeColor = Color.DarkGreen;

            }
        }

        private void frmRoster_Shown(object sender, EventArgs e)
        {
            //rosterTableAdapter.Fill(livegameDataSet1.roster);
            //getNames();
            //getShifts();
        }

    }
}