namespace Break_List.Forms.Kasa
{
    partial class frmTipListesi
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
            this.pivotGridField4 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldPersonelNo1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldPersonel1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldTipPuani1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.spTipListesiAllPersonelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.livegameDataSet1 = new Break_List.livegameDataSet1();
            this.fieldSickCall1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldNoCallNoShow1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldSickSentHome1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldRapor1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldTarih1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldLate1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldSuspend1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldSentHomeD1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.spTipListesiAllPersonelTableAdapter = new Break_List.livegameDataSet1TableAdapters.spTipListesiAllPersonelTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTipListesiAllPersonelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pivotGridField4
            // 
            this.pivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField4.AreaIndex = 0;
            this.pivotGridField4.Caption = "Departman";
            this.pivotGridField4.FieldName = "Department";
            this.pivotGridField4.Name = "pivotGridField4";
            this.pivotGridField4.Width = 80;
            // 
            // fieldPersonelNo1
            // 
            this.fieldPersonelNo1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldPersonelNo1.AreaIndex = 1;
            this.fieldPersonelNo1.FieldName = "Personel No";
            this.fieldPersonelNo1.Name = "fieldPersonelNo1";
            this.fieldPersonelNo1.Width = 40;
            // 
            // fieldPersonel1
            // 
            this.fieldPersonel1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldPersonel1.AreaIndex = 2;
            this.fieldPersonel1.FieldName = "Personel";
            this.fieldPersonel1.Name = "fieldPersonel1";
            this.fieldPersonel1.Width = 120;
            // 
            // fieldTipPuani1
            // 
            this.fieldTipPuani1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldTipPuani1.AreaIndex = 3;
            this.fieldTipPuani1.FieldName = "Tip Puani";
            this.fieldTipPuani1.Name = "fieldTipPuani1";
            this.fieldTipPuani1.Width = 40;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.dateEdit2);
            this.panelControl1.Controls.Add(this.dateEdit1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1201, 31);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(431, 3);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 4;
            this.simpleButton2.Text = "Print";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(215, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(23, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Bitiş:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(43, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Başlangıç:";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(350, 3);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Listele";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(244, 5);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Size = new System.Drawing.Size(100, 20);
            this.dateEdit2.TabIndex = 1;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(97, 5);
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
            this.pivotGridControl1.DataSource = this.spTipListesiAllPersonelBindingSource;
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldPersonelNo1,
            this.fieldPersonel1,
            this.fieldTipPuani1,
            this.fieldSickCall1,
            this.fieldNoCallNoShow1,
            this.fieldSickSentHome1,
            this.fieldRapor1,
            this.fieldTarih1,
            this.fieldLate1,
            this.fieldSuspend1,
            this.fieldSentHomeD1,
            this.pivotGridField1,
            this.pivotGridField2,
            this.pivotGridField3,
            this.pivotGridField4});
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 31);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsBehavior.BestFitMode = DevExpress.XtraPivotGrid.PivotGridBestFitMode.None;
            this.pivotGridControl1.OptionsCustomization.AllowExpand = false;
            this.pivotGridControl1.OptionsData.AutoExpandGroups = DevExpress.Utils.DefaultBoolean.True;
            this.pivotGridControl1.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridControl1.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridControl1.OptionsPrint.PrintRowHeaders = DevExpress.Utils.DefaultBoolean.True;
            this.pivotGridControl1.OptionsView.ShowColumnGrandTotals = false;
            this.pivotGridControl1.OptionsView.ShowColumnHeaders = false;
            this.pivotGridControl1.OptionsView.ShowColumnTotals = false;
            this.pivotGridControl1.OptionsView.ShowDataHeaders = false;
            this.pivotGridControl1.OptionsView.ShowFilterHeaders = false;
            this.pivotGridControl1.OptionsView.ShowFilterSeparatorBar = false;
            this.pivotGridControl1.OptionsView.ShowRowGrandTotalHeader = false;
            this.pivotGridControl1.OptionsView.ShowRowGrandTotals = false;
            this.pivotGridControl1.OptionsView.ShowRowHeaders = false;
            this.pivotGridControl1.OptionsView.ShowRowTotals = false;
            this.pivotGridControl1.Size = new System.Drawing.Size(1201, 560);
            this.pivotGridControl1.TabIndex = 1;
            this.pivotGridControl1.CellDoubleClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.pivotGridControl1_CellDoubleClick);
            this.pivotGridControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pivotGridControl1_MouseDown);
            // 
            // spTipListesiAllPersonelBindingSource
            // 
            this.spTipListesiAllPersonelBindingSource.DataMember = "spTipListesiAllPersonel";
            this.spTipListesiAllPersonelBindingSource.DataSource = this.livegameDataSet1;
            // 
            // livegameDataSet1
            // 
            this.livegameDataSet1.DataSetName = "livegameDataSet1";
            this.livegameDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fieldSickCall1
            // 
            this.fieldSickCall1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldSickCall1.AreaIndex = 0;
            this.fieldSickCall1.FieldName = "Sick Call";
            this.fieldSickCall1.Name = "fieldSickCall1";
            this.fieldSickCall1.Width = 55;
            // 
            // fieldNoCallNoShow1
            // 
            this.fieldNoCallNoShow1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldNoCallNoShow1.AreaIndex = 1;
            this.fieldNoCallNoShow1.FieldName = "No Call No Show";
            this.fieldNoCallNoShow1.Name = "fieldNoCallNoShow1";
            this.fieldNoCallNoShow1.Width = 94;
            // 
            // fieldSickSentHome1
            // 
            this.fieldSickSentHome1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldSickSentHome1.AreaIndex = 2;
            this.fieldSickSentHome1.FieldName = "Sick Sent Home";
            this.fieldSickSentHome1.Name = "fieldSickSentHome1";
            this.fieldSickSentHome1.Width = 87;
            // 
            // fieldRapor1
            // 
            this.fieldRapor1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldRapor1.AreaIndex = 3;
            this.fieldRapor1.FieldName = "Rapor";
            this.fieldRapor1.Name = "fieldRapor1";
            this.fieldRapor1.Width = 41;
            // 
            // fieldTarih1
            // 
            this.fieldTarih1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldTarih1.AreaIndex = 0;
            this.fieldTarih1.FieldName = "Tarih";
            this.fieldTarih1.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateMonth;
            this.fieldTarih1.Name = "fieldTarih1";
            this.fieldTarih1.UnboundFieldName = "fieldTarih1";
            // 
            // fieldLate1
            // 
            this.fieldLate1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldLate1.AreaIndex = 4;
            this.fieldLate1.CellFormat.FormatString = "n1";
            this.fieldLate1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldLate1.FieldName = "Late";
            this.fieldLate1.Name = "fieldLate1";
            this.fieldLate1.Width = 35;
            // 
            // fieldSuspend1
            // 
            this.fieldSuspend1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldSuspend1.AreaIndex = 5;
            this.fieldSuspend1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldSuspend1.FieldName = "Suspend";
            this.fieldSuspend1.Name = "fieldSuspend1";
            this.fieldSuspend1.Width = 53;
            // 
            // fieldSentHomeD1
            // 
            this.fieldSentHomeD1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldSentHomeD1.AreaIndex = 6;
            this.fieldSentHomeD1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldSentHomeD1.FieldName = "SentHomeD";
            this.fieldSentHomeD1.Name = "fieldSentHomeD1";
            this.fieldSentHomeD1.Width = 72;
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField1.AreaIndex = 7;
            this.pivotGridField1.Caption = "Topalm Tip";
            this.pivotGridField1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.UnboundExpression = "[fieldTipPuani1] * 90";
            this.pivotGridField1.UnboundExpressionMode = DevExpress.XtraPivotGrid.UnboundExpressionMode.UseSummaryValues;
            this.pivotGridField1.UnboundFieldName = "pivotGridField1";
            this.pivotGridField1.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.pivotGridField1.Width = 61;
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField2.AreaIndex = 8;
            this.pivotGridField2.Caption = "Kesinti";
            this.pivotGridField2.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField2.Name = "pivotGridField2";
            this.pivotGridField2.UnboundExpression = "([Late] + [No Call No Show] + [SentHomeD] + [Sick Call] + [Sick Sent Home] + [Sus" +
    "pend]) * [pivotGridField1] / 30";
            this.pivotGridField2.UnboundExpressionMode = DevExpress.XtraPivotGrid.UnboundExpressionMode.UseSummaryValues;
            this.pivotGridField2.UnboundFieldName = "pivotGridField2";
            this.pivotGridField2.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.pivotGridField2.Width = 45;
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.Appearance.Cell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.pivotGridField3.Appearance.Cell.Options.UseFont = true;
            this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField3.AreaIndex = 9;
            this.pivotGridField3.Caption = "Alacağı";
            this.pivotGridField3.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField3.Name = "pivotGridField3";
            this.pivotGridField3.UnboundExpression = "[pivotGridField1] - [pivotGridField2]";
            this.pivotGridField3.UnboundExpressionMode = DevExpress.XtraPivotGrid.UnboundExpressionMode.UseSummaryValues;
            this.pivotGridField3.UnboundFieldName = "pivotGridField3";
            this.pivotGridField3.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.pivotGridField3.Width = 51;
            // 
            // spTipListesiAllPersonelTableAdapter
            // 
            this.spTipListesiAllPersonelTableAdapter.ClearBeforeFill = true;
            // 
            // frmTipListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 591);
            this.Controls.Add(this.pivotGridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmTipListesi";
            this.Text = "Tip Listesi";
            this.Load += new System.EventHandler(this.frmTipListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTipListesiAllPersonelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldPersonelNo1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldPersonel1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldTipPuani1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldSickCall1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldNoCallNoShow1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldSickSentHome1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldRapor1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldTarih1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldLate1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldSuspend1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldSentHomeD1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.BindingSource spTipListesiAllPersonelBindingSource;
        private livegameDataSet1 livegameDataSet1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField4;
        private livegameDataSet1TableAdapters.spTipListesiAllPersonelTableAdapter spTipListesiAllPersonelTableAdapter;
    }
}