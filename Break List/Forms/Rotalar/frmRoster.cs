using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using MySql.Data.MySqlClient;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Globalization;
using NodaTime.Text;

namespace Break_List
{
    public partial class frmRoster : DevExpress.XtraEditors.XtraForm
    {
        public string _departmentNameFromMainForm;
        public frmRoster()
        {
            InitializeComponent();
            schedulerControl1.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Timeline;
            schedulerControl1.GroupType = SchedulerGroupType.Resource;
            TimeScaleCollection scales = schedulerControl1.TimelineView.Scales;

            scales.Clear();

            scales.Add(new TimeScaleMonth());
            //scales.Add(new TimeScaleWeek());
            scales.Add(new TimeScaleDay());
            
            DateTime startDate = schedulerControl1.SelectedInterval.Start;
            schedulerControl1.Start = new DateTime(startDate.Year, startDate.Month, 1);

            UpdateScaleWidth();

            this.schedulerStorage1.AppointmentsChanged += OnAppointmentChangedInsertedDeleted;
            this.schedulerStorage1.AppointmentsInserted += OnAppointmentChangedInsertedDeleted;
            this.schedulerStorage1.AppointmentsDeleted += OnAppointmentChangedInsertedDeleted;
        }
        private void OnAppointmentChangedInsertedDeleted(object sender, PersistentObjectsEventArgs e)
        {

            roster1TableAdapter.Update(livegameDataSet1);
            livegameDataSet1.AcceptChanges();
            this.roster1TableAdapter.Fill(this.livegameDataSet1.roster1);
        }
        void getNames()
        {
            using (MySqlConnection conn = new MySqlConnection(Properties.Settings.Default.livegameConnectionString2))
            {
                MySqlCommand command = new MySqlCommand("spRotaPersonel;", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                string _department = _departmentNameFromMainForm;
                // Add your parameters here if you need them
                command.Parameters.Add(new MySqlParameter("DepartmentName", _department));

                conn.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                {
                    DataTable dt = new DataTable();
                    adapter.SelectCommand = command;
                    {
                        adapter.Fill(dt);
                        schedulerStorage1.Resources.DataSource = dt;
                        this.Text = "Rota of: " +_department;
                    }
                }
                conn.Close();
            }

        }

        private void frmRoster_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'livegameDataSet1.resources' table. You can move, or remove it, as needed.
           // this.resourcesTableAdapter.Fill(this.livegameDataSet1.resources);
            // TODO: This line of code loads data into the 'livegameDataSet1.roster1' table. You can move, or remove it, as needed.
            this.roster1TableAdapter.Fill(this.livegameDataSet1.roster1);
            getNames();
            getShifts();

        }

        private void UpdateScaleWidth()
        {
            schedulerControl1.TimelineView.GetBaseTimeScale().Width = 50;
        }
        void getShifts()
        {
            using (MySqlConnection conn = new MySqlConnection(Properties.Settings.Default.livegameConnectionString2))
            {
                MySqlCommand command = new MySqlCommand("Select ShiftNo as Shift, ShiftStart as Start, Hour as Hours from shifts", conn);
                command.CommandType = CommandType.Text;
                
                

                conn.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                {
                    DataTable dt = new DataTable();
                    adapter.SelectCommand = command;
                    {
                        adapter.Fill(dt);
                        gridControl1.DataSource = dt;
                        
                    }
                }
                conn.Close();
            }

        }
        GridHitInfo downHitInfo;
        TimeSpan minTime = new TimeSpan(0, 0, 0);
        TimeSpan maxTime = new TimeSpan(24, 0, 0);
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
            Forms.frmAddOverTime form = new Forms.frmAddOverTime(scheduler, e.Appointment, e.OpenRecurrenceForm);
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
    }
}