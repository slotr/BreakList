using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using MySql.Data.MySqlClient;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraScheduler.Drawing;
namespace Break_List.Forms.Rotalar
{
    public partial class frmRoster : XtraForm
    {
        public string _departmentNameFromMainForm { get; set; }
        public string UserName { get; set; }
        public frmRoster()
        {
            InitializeComponent();
            schedulerControl1.ActiveViewType = SchedulerViewType.Timeline;
            schedulerControl1.GroupType = SchedulerGroupType.Resource;
            TimeScaleCollection scales = schedulerControl1.TimelineView.Scales;
            schedulerControl1.TimelineView.AppointmentDisplayOptions.StartTimeVisibility = AppointmentTimeVisibility.Never;
            schedulerControl1.TimelineView.AppointmentDisplayOptions.EndTimeVisibility = AppointmentTimeVisibility.Never;
            scales.Clear();

            scales.Add(new TimeScaleMonth());
            //scales.Add(new TimeScaleWeek());
            scales.Add(new TimeScaleDay());

            DateTime startDate = schedulerControl1.SelectedInterval.Start;
            schedulerControl1.Start = new DateTime(startDate.Year, startDate.Month, 1);

            UpdateScaleWidth();

            schedulerStorage1.AppointmentsChanged += OnAppointmentChangedInsertedDeleted;
            schedulerStorage1.AppointmentsInserted += OnAppointmentChangedInsertedDeleted;
            schedulerStorage1.AppointmentsDeleted += OnAppointmentChangedInsertedDeleted;
            schedulerControl1.MouseWheel += schedulerControl_MouseWheel; 
        }
        private void OnAppointmentChangedInsertedDeleted(object sender, PersistentObjectsEventArgs e)
        {

            roster1TableAdapter.Update(livegameDataSet1);
            livegameDataSet1.AcceptChanges();
            roster1TableAdapter.Fill(livegameDataSet1.roster1);
        }

        void schedulerControl_MouseWheel(object sender, MouseEventArgs e) // Mouse asagi yukari hareket ediyor.
        {
            int index = schedulerControl1.ActiveView.FirstVisibleResourceIndex;
            if (e.Delta > 0 && index != 0)
                schedulerControl1.ActiveView.FirstVisibleResourceIndex--;
            if (e.Delta < 0 && index != schedulerControl1.Storage.Resources.Count - 1)
                schedulerControl1.ActiveView.FirstVisibleResourceIndex++;
        }
        void getNames()
        {
            using (MySqlConnection conn = new MySqlConnection(Properties.Settings.Default.livegameConnectionString2))
            {
                MySqlCommand cmd = new MySqlCommand("spRotaPersonel;", conn) { CommandType = CommandType.StoredProcedure };
                string _department = _departmentNameFromMainForm;
                // Add your parameters here if you need them
                cmd.Parameters.Add(new MySqlParameter("DepartmentName", _department));

                conn.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                {
                    DataTable dt = new DataTable();
                    adapter.SelectCommand = cmd;
                    {
                        adapter.Fill(dt);
                        schedulerStorage1.Resources.DataSource = dt;
                        //Text = _department + " Rotası ";
                    }
                }
                conn.Close();
            }

        }

        private void frmRoster_Load(object sender, EventArgs e)
        {
            //schedulerControl1.MouseWheel += schedulerControl_MouseWheel;
            //roster1TableAdapter.Fill(livegameDataSet1.roster1);
            //getNames();
            //getShifts();
            
        }

        private void UpdateScaleWidth()
        {
            schedulerControl1.TimelineView.GetBaseTimeScale().Width = 50;
        }
        void getShifts()
        {
            using (MySqlConnection conn = new MySqlConnection(Properties.Settings.Default.livegameConnectionString2))
            {
                MySqlCommand cmd = new MySqlCommand("Select ShiftNo as Shift, ShiftStart as Start, Hour as Hours from shifts", conn) { CommandType = CommandType.Text };



                conn.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                {
                    DataTable dt = new DataTable();
                    adapter.SelectCommand = cmd;
                    {
                        adapter.Fill(dt);
                        gridControl1.DataSource = dt;

                    }
                }
                conn.Close();
            }

        }
        GridHitInfo downHitInfo;
        readonly TimeSpan minTime = new TimeSpan(0, 0, 0);
        readonly TimeSpan maxTime = new TimeSpan(24, 0, 0);
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
                string subject = (string)view.GetRowCellValue(rowIndex, "Shift");
                TimeSpan start = (TimeSpan)view.GetRowCellValue(rowIndex, "Start");
                TimeSpan hour = (TimeSpan)view.GetRowCellValue(rowIndex, "Hours");
                TimeSpan end = start + hour;
                double totalDuration = Convert.ToDouble(hour.TotalHours);
                double totalHours = Convert.ToDouble(end.TotalHours);
                // MessageBox.Show(totalHours.ToString());
                if (totalHours > 24)
                {
                    TimeSpan _final = end - maxTime;
                    apt.Subject = subject;
                    //apt.Duration = start + hour;
                    apt.CustomFields["StartTime"] = start;
                    apt.CustomFields["EndTime"] = _final;
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
                    apt.CustomFields["Department"] = _departmentNameFromMainForm;
                    apt.CustomFields["Createdby"] = UserName;
                    apt.CustomFields["CreatedAt"] = DateTime.Now;
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
                    apt.CustomFields["Department"] = _departmentNameFromMainForm;
                    apt.CustomFields["Createdby"] = UserName;
                    apt.CustomFields["CreatedAt"] = DateTime.Now;
                    appointments.Add(apt);
                }
            }

            return new SchedulerDragData(appointments, 0);
        }
        #endregion #GetDragData

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



        private void schedulerControl1_AppointmentDrop(object sender, AppointmentDragEventArgs e)
        {
            DateTime srcStart = e.SourceAppointment.Start;
            DateTime newStart = e.EditedAppointment.Start;
            bool isNewAppointment = srcStart == DateTime.MinValue;
        }



        private void schedulerControl1_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            SchedulerControl scheduler = ((SchedulerControl)(sender));
            frmAddOverTime form = new frmAddOverTime(scheduler, e.Appointment, e.OpenRecurrenceForm);
            form.labelControl2.Text = UserName;
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
            if (e.ViewInfo.Appointment.Subject.Contains("OFF"))
            {
                e.ViewInfo.Appearance.Font = new Font(e.ViewInfo.Appearance.Font, FontStyle.Bold);
                e.ViewInfo.Appearance.ForeColor = Color.Red;
                e.ViewInfo.Appearance.BorderColor = Color.Red;
                
            }


               
        }

        private void schedulerControl1_CustomDrawResourceHeader(object sender, CustomDrawObjectEventArgs e)
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

        private void frmRoster_Shown(object sender, EventArgs e)
        {
            roster1TableAdapter.Fill(livegameDataSet1.roster1);
            getNames();
            getShifts();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            
            
        }
    }
}