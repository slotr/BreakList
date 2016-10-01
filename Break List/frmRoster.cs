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

        }

        private void UpdateScaleWidth()
        {
            schedulerControl1.TimelineView.GetBaseTimeScale().Width = 50;
        }
    }
}