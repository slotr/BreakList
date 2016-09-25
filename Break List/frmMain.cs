﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraScheduler;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.Data.SqlClient;
using DevExpress.XtraScheduler.Drawing;
using MySql.Data.MySqlClient;

namespace Break_List
{
    public partial class frmMain : RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();           
            schedulerControl.Start = System.DateTime.Now;
            schedulerControl.Views.DayView.Enabled = false;
            schedulerControl.ActiveViewType = SchedulerViewType.Timeline;
            schedulerControl.GroupType = SchedulerGroupType.Resource;
            getTables();
            getNames();

            TimeScaleCollection scales = schedulerControl.TimelineView.Scales;
            schedulerControl.TimelineView.Scales.BeginUpdate();
            try
            {
                scales.Clear();
                scales.Add(new MyTimeScaleFixedInterval(TimeSpan.FromDays(1), minTime, maxTime));
                scales.Add(new MyTimeScaleFixedInterval(TimeSpan.FromHours(1), minTime, maxTime));
                scales.Add(new MyTimeScaleFixedInterval(TimeSpan.FromMinutes(20), minTime, maxTime));
            }
            finally
            {
                schedulerControl.TimelineView.Scales.EndUpdate();
            }

            this.schedulerStorage1.AppointmentsChanged += OnAppointmentChangedInsertedDeleted;
            this.schedulerStorage1.AppointmentsInserted += OnAppointmentChangedInsertedDeleted;
            this.schedulerStorage1.AppointmentsDeleted += OnAppointmentChangedInsertedDeleted;
        }

        private void OnAppointmentChangedInsertedDeleted(object sender, PersistentObjectsEventArgs e)
        {
            this.appointmentsTableAdapter.Fill(this.livegameDataSet1.appointments);
            appointmentsTableAdapter.Update(livegameDataSet1);
            livegameDataSet1.AcceptChanges();
        }

        TimeSpan minTime = new TimeSpan(0, 0, 0);
        TimeSpan maxTime = new TimeSpan(24, 0, 0);
        GridHitInfo downHitInfo;


        void getNames()
        {
            using (var conn = new MySqlConnection(Properties.Settings.Default.livegameConnectionString2))
            using (var command = new MySqlCommand("spResources", conn)
            {
                CommandType = CommandType.StoredProcedure
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
                        schedulerStorage1.Resources.DataSource = dt;
                    }
                }


            }

        }
    
        void getTables()
        {
            using (var conn = new MySqlConnection(Properties.Settings.Default.livegameConnectionString2))
            using (var command = new MySqlCommand("SELECT Game, No FROM livegame.tables where open = 1", conn)
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
                        gridControl1.DataSource = dt;

                       
                    }
                }


            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'livegameDataSet1.resources' table. You can move, or remove it, as needed.
            this.resourcesTableAdapter.Fill(this.livegameDataSet1.resources);
            // TODO: This line of code loads data into the 'livegameDataSet1.appointments' table. You can move, or remove it, as needed.
            this.appointmentsTableAdapter.Fill(this.livegameDataSet1.appointments);

            

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
                
                apt.Duration = TimeSpan.FromMinutes(20);                           
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

        

        private void schedulerControl_PopupMenuShowing(object sender, DevExpress.XtraScheduler.PopupMenuShowingEventArgs e)
        {
            e.Menu.Items.Clear();            
        }

      

        private void DeleteSelectedRows(GridView view)
        {
            view.DeleteRow(view.FocusedRowHandle);

        }

        private void gridControl1_DragLeave(object sender, EventArgs e)
        {
            DeleteSelectedRows(gridView1);
        }

        private void btnYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            getTables();
        }

        //Raporlar
        private void btnReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmExport report = new frmExport();
            report.ShowDialog();

        }
        //Personel
        private void btnPersonel_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPersonel personel = new frmPersonel();
            personel.ShowDialog();
        }
        //Rotalar
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRota Rota = new frmRota();
            Rota.ShowDialog();
        }
        //Masalar
        private void btnMasalar_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMasalar Masalar = new frmMasalar();
            Masalar.ShowDialog();
        }

        private void btnPersonelYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            getNames();
            
            schedulerControl.RefreshData();
        }

      

        private void schedulerControl_AppointmentDrag(object sender, AppointmentDragEventArgs e)
        {
            

        }
    }
}