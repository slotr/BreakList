namespace Break_List.Forms.Personel
{
    partial class frmCalismaIzinleri
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.spCalismaIzinTakibiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.livegameDataSet1 = new Break_List.livegameDataSet1();
            this.spCalismaIzinTakibiTableAdapter = new Break_List.livegameDataSet1TableAdapters.spCalismaIzinTakibiTableAdapter();
            this.colPersonel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCalismaIzniBitisTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCalismaIzinTakibiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.spCalismaIzinTakibiBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(659, 106);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPersonel,
            this.colCalismaIzniBitisTarihi});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
            this.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl1.Location = new System.Drawing.Point(0, 106);
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.OptionsCustomization.AllowAppointmentCopy = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.OptionsCustomization.AllowAppointmentCreate = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.OptionsCustomization.AllowAppointmentDelete = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.OptionsCustomization.AllowAppointmentDrag = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.OptionsCustomization.AllowAppointmentDragBetweenResources = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.OptionsCustomization.AllowAppointmentEdit = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.OptionsCustomization.AllowAppointmentResize = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.OptionsCustomization.AllowDisplayAppointmentDependencyForm = DevExpress.XtraScheduler.AllowDisplayAppointmentDependencyForm.Never;
            this.schedulerControl1.OptionsCustomization.AllowDisplayAppointmentForm = DevExpress.XtraScheduler.AllowDisplayAppointmentForm.Never;
            this.schedulerControl1.OptionsCustomization.AllowInplaceEditor = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.Size = new System.Drawing.Size(659, 458);
            this.schedulerControl1.Start = new System.DateTime(2016, 10, 16, 0, 0, 0, 0);
            this.schedulerControl1.Storage = this.schedulerStorage1;
            this.schedulerControl1.TabIndex = 1;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.AgendaView.Enabled = false;
            this.schedulerControl1.Views.DayView.Enabled = false;
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl1.Views.GanttView.Enabled = false;
            this.schedulerControl1.Views.MonthView.Appearance.Appointment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.schedulerControl1.Views.MonthView.Appearance.Appointment.Font = new System.Drawing.Font("Tahoma", 12F);
            this.schedulerControl1.Views.MonthView.Appearance.Appointment.ForeColor = System.Drawing.Color.White;
            this.schedulerControl1.Views.MonthView.Appearance.Appointment.Options.UseBackColor = true;
            this.schedulerControl1.Views.MonthView.Appearance.Appointment.Options.UseFont = true;
            this.schedulerControl1.Views.MonthView.Appearance.Appointment.Options.UseForeColor = true;
            this.schedulerControl1.Views.MonthView.AppointmentDisplayOptions.EndTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Never;
            this.schedulerControl1.Views.MonthView.AppointmentDisplayOptions.StartTimeVisibility = DevExpress.XtraScheduler.AppointmentTimeVisibility.Never;
            this.schedulerControl1.Views.TimelineView.Enabled = false;
            this.schedulerControl1.Views.WeekView.Enabled = false;
            this.schedulerControl1.Views.WorkWeekView.Enabled = false;
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            // 
            // schedulerStorage1
            // 
            this.schedulerStorage1.Appointments.DataSource = this.spCalismaIzinTakibiBindingSource;
            this.schedulerStorage1.Appointments.Mappings.Description = "Personel";
            this.schedulerStorage1.Appointments.Mappings.Label = "Personel";
            this.schedulerStorage1.Appointments.Mappings.Start = "Calisma Izni Bitis Tarihi";
            this.schedulerStorage1.Appointments.Mappings.Subject = "Personel";
            // 
            // spCalismaIzinTakibiBindingSource
            // 
            this.spCalismaIzinTakibiBindingSource.DataMember = "spCalismaIzinTakibi";
            this.spCalismaIzinTakibiBindingSource.DataSource = this.livegameDataSet1;
            // 
            // livegameDataSet1
            // 
            this.livegameDataSet1.DataSetName = "livegameDataSet1";
            this.livegameDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spCalismaIzinTakibiTableAdapter
            // 
            this.spCalismaIzinTakibiTableAdapter.ClearBeforeFill = true;
            // 
            // colPersonel
            // 
            this.colPersonel.FieldName = "Personel";
            this.colPersonel.Name = "colPersonel";
            this.colPersonel.Visible = true;
            this.colPersonel.VisibleIndex = 0;
            // 
            // colCalismaIzniBitisTarihi
            // 
            this.colCalismaIzniBitisTarihi.FieldName = "Calisma Izni Bitis Tarihi";
            this.colCalismaIzniBitisTarihi.Name = "colCalismaIzniBitisTarihi";
            this.colCalismaIzniBitisTarihi.Visible = true;
            this.colCalismaIzniBitisTarihi.VisibleIndex = 1;
            // 
            // frmCalismaIzinleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 564);
            this.Controls.Add(this.schedulerControl1);
            this.Controls.Add(this.gridControl1);
            this.Name = "frmCalismaIzinleri";
            this.Text = "Çalışma İzni Takibi";
            this.Load += new System.EventHandler(this.frmCalismaIzinleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCalismaIzinTakibiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private livegameDataSet1 livegameDataSet1;
        private System.Windows.Forms.BindingSource spCalismaIzinTakibiBindingSource;
        private livegameDataSet1TableAdapters.spCalismaIzinTakibiTableAdapter spCalismaIzinTakibiTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonel;
        private DevExpress.XtraGrid.Columns.GridColumn colCalismaIzniBitisTarihi;
    }
}