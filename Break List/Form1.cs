using System;
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

namespace Break_List
{
    public partial class Form1 : RibbonForm
    {
        public Form1()
        {
            InitializeComponent();           
            schedulerControl.Start = System.DateTime.Now;
            schedulerControl.Views.DayView.Enabled = false;
            schedulerControl.ActiveViewType = SchedulerViewType.Timeline;
            schedulerControl.GroupType = SchedulerGroupType.Resource;
        }
        TimeSpan minTime = new TimeSpan(0, 0, 0);
        TimeSpan maxTime = new TimeSpan(24, 0, 0);
        GridHitInfo downHitInfo;
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
            tablesTableAdapter.Fill(this.liveGameDataSet._Tables);
            //tablesTableAdapter.FillByGames(this.liveGameDataSet._Tables, "AR");            
            this.resourcesTableAdapter.Fill(this.liveGameDataSet.Resources);            
            this.appointmentsTableAdapter.Fill(this.liveGameDataSet.Appointments);
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
        }

        private void schedulerStorage_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            appointmentsTableAdapter.Update(liveGameDataSet.Appointments);
            
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
                Appointment apt = schedulerStorage.CreateAppointment(AppointmentType.Normal);
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

        private void schedulerControl_AppointmentDrop(object sender, AppointmentDragEventArgs e)
        {
                        
            appointmentsTableAdapter.Update(liveGameDataSet.Appointments);
            
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
            tablesTableAdapter.Fill(this.liveGameDataSet._Tables);
        }

        private void schedulerControl_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            DevExpress.XtraScheduler.SchedulerControl scheduler = ((DevExpress.XtraScheduler.SchedulerControl)(sender));
            Break_List.CustomAppointmentForm form = new Break_List.CustomAppointmentForm(scheduler, e.Appointment, e.OpenRecurrenceForm);
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

        private void btnReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmExport report = new frmExport();
            report.Show();

        }

        private void btnPersonel_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPersonel personel = new frmPersonel();
            personel.Show();
        }
    }
}