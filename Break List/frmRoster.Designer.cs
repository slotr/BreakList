namespace Break_List
{
    partial class frmRoster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.livegameDataSet1 = new Break_List.livegameDataSet1();
            this.roster1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.roster1TableAdapter = new Break_List.livegameDataSet1TableAdapters.roster1TableAdapter();
            this.resourcesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.resourcesTableAdapter = new Break_List.livegameDataSet1TableAdapters.resourcesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roster1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Timeline;
            this.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl1.Location = new System.Drawing.Point(0, 0);
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.OptionsView.FirstDayOfWeek = DevExpress.XtraScheduler.FirstDayOfWeek.Monday;
            this.schedulerControl1.OptionsView.ResourceHeaders.Height = 150;
            this.schedulerControl1.OptionsView.ResourceHeaders.ImageInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
            this.schedulerControl1.OptionsView.ResourceHeaders.ImageSize = new System.Drawing.Size(30, 30);
            this.schedulerControl1.OptionsView.ResourceHeaders.ImageSizeMode = DevExpress.XtraScheduler.HeaderImageSizeMode.StretchImage;
            this.schedulerControl1.OptionsView.ResourceHeaders.RotateCaption = false;
            this.schedulerControl1.Size = new System.Drawing.Size(932, 594);
            this.schedulerControl1.Start = new System.DateTime(2016, 9, 30, 0, 0, 0, 0);
            this.schedulerControl1.Storage = this.schedulerStorage1;
            this.schedulerControl1.TabIndex = 0;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.AgendaView.Enabled = false;
            this.schedulerControl1.Views.DayView.Enabled = false;
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl1.Views.GanttView.Enabled = false;
            this.schedulerControl1.Views.MonthView.Enabled = false;
            this.schedulerControl1.Views.TimelineView.ResourcesPerPage = 30;
            this.schedulerControl1.Views.WeekView.Enabled = false;
            this.schedulerControl1.Views.WorkWeekView.Enabled = false;
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            // 
            // schedulerStorage1
            // 
            this.schedulerStorage1.Appointments.DataSource = this.roster1BindingSource;
            this.schedulerStorage1.Appointments.Mappings.End = "EndDate";
            this.schedulerStorage1.Appointments.Mappings.ResourceId = "ResourceID";
            this.schedulerStorage1.Appointments.Mappings.Start = "StartDate";
            this.schedulerStorage1.Appointments.Mappings.Subject = "Subject";
            this.schedulerStorage1.Resources.DataSource = this.resourcesBindingSource;
            this.schedulerStorage1.Resources.Mappings.Caption = "ResourceName";
            this.schedulerStorage1.Resources.Mappings.Color = "Color";
            this.schedulerStorage1.Resources.Mappings.Id = "ResourceID";
            // 
            // livegameDataSet1
            // 
            this.livegameDataSet1.DataSetName = "livegameDataSet1";
            this.livegameDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // roster1BindingSource
            // 
            this.roster1BindingSource.DataMember = "roster1";
            this.roster1BindingSource.DataSource = this.livegameDataSet1;
            // 
            // roster1TableAdapter
            // 
            this.roster1TableAdapter.ClearBeforeFill = true;
            // 
            // resourcesBindingSource
            // 
            this.resourcesBindingSource.DataMember = "resources";
            this.resourcesBindingSource.DataSource = this.livegameDataSet1;
            // 
            // resourcesTableAdapter
            // 
            this.resourcesTableAdapter.ClearBeforeFill = true;
            // 
            // frmRoster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 594);
            this.Controls.Add(this.schedulerControl1);
            this.Name = "frmRoster";
            this.Text = "frmRoster";
            this.Load += new System.EventHandler(this.frmRoster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roster1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private livegameDataSet1 livegameDataSet1;
        private System.Windows.Forms.BindingSource roster1BindingSource;
        private livegameDataSet1TableAdapters.roster1TableAdapter roster1TableAdapter;
        private System.Windows.Forms.BindingSource resourcesBindingSource;
        private livegameDataSet1TableAdapters.resourcesTableAdapter resourcesTableAdapter;
    }
}