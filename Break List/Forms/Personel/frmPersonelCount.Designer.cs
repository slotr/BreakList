namespace Break_List.Forms.Personel
{
    partial class FrmPersonelCount
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.fieldDepartman1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldTarih1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.avg = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldSayi1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.spCountPersonelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.livegameDataSet1 = new Break_List.livegameDataSet1();
            this.spCountPersonelTableAdapter = new Break_List.livegameDataSet1TableAdapters.spCountPersonelTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCountPersonelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.dateEdit2);
            this.panelControl1.Controls.Add(this.dateEdit1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1099, 45);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(34, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(33, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Tarih 1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(197, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(33, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Tarih 2";
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(236, 12);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Size = new System.Drawing.Size(100, 20);
            this.dateEdit2.TabIndex = 0;
            this.dateEdit2.EditValueChanged += new System.EventHandler(this.dateEdit2_EditValueChanged);
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(73, 12);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(100, 20);
            this.dateEdit1.TabIndex = 0;
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.DataSource = this.spCountPersonelBindingSource;
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldDepartman1,
            this.fieldTarih1,
            this.avg,
            this.fieldSayi1,
            this.pivotGridField1});
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 45);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsView.ShowDataHeaders = false;
            this.pivotGridControl1.OptionsView.ShowFilterHeaders = false;
            this.pivotGridControl1.OptionsView.ShowGrandTotalsForSingleValues = true;
            this.pivotGridControl1.OptionsView.ShowRowHeaders = false;
            this.pivotGridControl1.Size = new System.Drawing.Size(1099, 526);
            this.pivotGridControl1.TabIndex = 1;
            // 
            // fieldDepartman1
            // 
            this.fieldDepartman1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldDepartman1.AreaIndex = 0;
            this.fieldDepartman1.FieldName = "Departman";
            this.fieldDepartman1.Name = "fieldDepartman1";
            this.fieldDepartman1.Width = 180;
            // 
            // fieldTarih1
            // 
            this.fieldTarih1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldTarih1.AreaIndex = 1;
            this.fieldTarih1.FieldName = "Tarih";
            this.fieldTarih1.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateMonth;
            this.fieldTarih1.Name = "fieldTarih1";
            this.fieldTarih1.UnboundFieldName = "fieldTarih1";
            // 
            // avg
            // 
            this.avg.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.avg.AreaIndex = 1;
            this.avg.Caption = "Average";
            this.avg.FieldName = "Sayi";
            this.avg.Name = "avg";
            this.avg.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average;
            this.avg.Width = 40;
            // 
            // fieldSayi1
            // 
            this.fieldSayi1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldSayi1.AreaIndex = 0;
            this.fieldSayi1.FieldName = "Sayi";
            this.fieldSayi1.Name = "fieldSayi1";
            this.fieldSayi1.Options.ShowGrandTotal = false;
            this.fieldSayi1.Width = 40;
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField1.AreaIndex = 0;
            this.pivotGridField1.FieldName = "Tarih";
            this.pivotGridField1.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateYear;
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.UnboundFieldName = "pivotGridField1";
            // 
            // spCountPersonelBindingSource
            // 
            this.spCountPersonelBindingSource.DataMember = "spCountPersonel";
            this.spCountPersonelBindingSource.DataSource = this.livegameDataSet1;
            // 
            // livegameDataSet1
            // 
            this.livegameDataSet1.DataSetName = "livegameDataSet1";
            this.livegameDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spCountPersonelTableAdapter
            // 
            this.spCountPersonelTableAdapter.ClearBeforeFill = true;
            // 
            // FrmPersonelCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 571);
            this.Controls.Add(this.pivotGridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmPersonelCount";
            this.Text = "Personel Count";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCountPersonelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private System.Windows.Forms.BindingSource spCountPersonelBindingSource;
        private livegameDataSet1 livegameDataSet1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldDepartman1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldTarih1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldSayi1;
        private livegameDataSet1TableAdapters.spCountPersonelTableAdapter spCountPersonelTableAdapter;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraPivotGrid.PivotGridField avg;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}