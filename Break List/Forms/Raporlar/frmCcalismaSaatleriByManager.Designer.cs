namespace Break_List
{
    partial class frmCcalismaSaatleriByManager
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.colOverTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErkenGonderim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.spCalismaSaatleriAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.livegameDataSet1 = new Break_List.livegameDataSet1();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPersonel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShift = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaslangicSaati = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBitisSaati = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCalismasiGereken = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCalistigiSure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBJ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRPK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSPK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUPK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNPK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBreak = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spCalismaSaatleriAllTableAdapter = new Break_List.livegameDataSet1TableAdapters.spCalismaSaatleriAllTableAdapter();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCalismaSaatleriAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // colOverTime
            // 
            this.colOverTime.FieldName = "Over Time";
            this.colOverTime.Name = "colOverTime";
            this.colOverTime.Visible = true;
            this.colOverTime.VisibleIndex = 7;
            // 
            // colErkenGonderim
            // 
            this.colErkenGonderim.FieldName = "Erken Gonderim";
            this.colErkenGonderim.Name = "colErkenGonderim";
            this.colErkenGonderim.Visible = true;
            this.colErkenGonderim.VisibleIndex = 8;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.comboBoxEdit1);
            this.panelControl1.Controls.Add(this.dateEdit2);
            this.panelControl1.Controls.Add(this.dateEdit1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1004, 65);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(522, 27);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(162, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "departmanının raporunu Göster...";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(369, 27);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "arasında";
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(416, 24);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Size = new System.Drawing.Size(100, 20);
            this.comboBoxEdit1.TabIndex = 2;
            this.comboBoxEdit1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(201, 24);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.DisplayFormat.FormatString = "g";
            this.dateEdit2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit2.Properties.Mask.EditMask = "dd.MM.yyyy HH:mm";
            this.dateEdit2.Size = new System.Drawing.Size(153, 20);
            this.dateEdit2.TabIndex = 0;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(12, 24);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.DisplayFormat.FormatString = "g";
            this.dateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit1.Properties.Mask.EditMask = "dd.MM.yyyy HH:mm";
            this.dateEdit1.Size = new System.Drawing.Size(153, 20);
            this.dateEdit1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.spCalismaSaatleriAllBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 65);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1004, 518);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // spCalismaSaatleriAllBindingSource
            // 
            this.spCalismaSaatleriAllBindingSource.DataMember = "spCalismaSaatleriAll";
            this.spCalismaSaatleriAllBindingSource.DataSource = this.livegameDataSet1;
            // 
            // livegameDataSet1
            // 
            this.livegameDataSet1.DataSetName = "livegameDataSet1";
            this.livegameDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPersonel,
            this.colTarih,
            this.colShift,
            this.colBaslangicSaati,
            this.colBitisSaati,
            this.colCalismasiGereken,
            this.colCalistigiSure,
            this.colOverTime,
            this.colErkenGonderim,
            this.colAR,
            this.colBJ,
            this.colCSP,
            this.colRPK,
            this.colSPK,
            this.colUPK,
            this.colNPK,
            this.colBreak});
            gridFormatRule1.Column = this.colOverTime;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Expression = "[Over Time] <> \'YOK\'";
            formatConditionRuleExpression1.PredefinedName = "Green Fill";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            gridFormatRule2.Column = this.colErkenGonderim;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleExpression2.Expression = "[Erken Gonderim] <> \'YOK\'";
            formatConditionRuleExpression2.PredefinedName = "Red Fill";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.FormatRules.Add(gridFormatRule2);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted;
            this.gridView1.OptionsPrint.ExpandAllGroups = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPersonel, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colPersonel
            // 
            this.colPersonel.FieldName = "Personel";
            this.colPersonel.Name = "colPersonel";
            this.colPersonel.Visible = true;
            this.colPersonel.VisibleIndex = 0;
            // 
            // colTarih
            // 
            this.colTarih.FieldName = "Tarih";
            this.colTarih.Name = "colTarih";
            this.colTarih.Visible = true;
            this.colTarih.VisibleIndex = 1;
            // 
            // colShift
            // 
            this.colShift.FieldName = "Shift";
            this.colShift.Name = "colShift";
            this.colShift.Visible = true;
            this.colShift.VisibleIndex = 2;
            // 
            // colBaslangicSaati
            // 
            this.colBaslangicSaati.FieldName = "Baslangic Saati";
            this.colBaslangicSaati.Name = "colBaslangicSaati";
            this.colBaslangicSaati.Visible = true;
            this.colBaslangicSaati.VisibleIndex = 3;
            // 
            // colBitisSaati
            // 
            this.colBitisSaati.FieldName = "Bitis Saati";
            this.colBitisSaati.Name = "colBitisSaati";
            this.colBitisSaati.Visible = true;
            this.colBitisSaati.VisibleIndex = 4;
            // 
            // colCalismasiGereken
            // 
            this.colCalismasiGereken.FieldName = "Calismasi Gereken";
            this.colCalismasiGereken.Name = "colCalismasiGereken";
            this.colCalismasiGereken.Visible = true;
            this.colCalismasiGereken.VisibleIndex = 5;
            // 
            // colCalistigiSure
            // 
            this.colCalistigiSure.FieldName = "Calistigi Sure";
            this.colCalistigiSure.Name = "colCalistigiSure";
            this.colCalistigiSure.Visible = true;
            this.colCalistigiSure.VisibleIndex = 6;
            // 
            // colAR
            // 
            this.colAR.FieldName = "AR";
            this.colAR.Name = "colAR";
            this.colAR.Visible = true;
            this.colAR.VisibleIndex = 9;
            // 
            // colBJ
            // 
            this.colBJ.FieldName = "BJ";
            this.colBJ.Name = "colBJ";
            this.colBJ.Visible = true;
            this.colBJ.VisibleIndex = 10;
            // 
            // colCSP
            // 
            this.colCSP.FieldName = "CSP";
            this.colCSP.Name = "colCSP";
            this.colCSP.Visible = true;
            this.colCSP.VisibleIndex = 11;
            // 
            // colRPK
            // 
            this.colRPK.FieldName = "RPK";
            this.colRPK.Name = "colRPK";
            this.colRPK.Visible = true;
            this.colRPK.VisibleIndex = 12;
            // 
            // colSPK
            // 
            this.colSPK.FieldName = "SPK";
            this.colSPK.Name = "colSPK";
            this.colSPK.Visible = true;
            this.colSPK.VisibleIndex = 13;
            // 
            // colUPK
            // 
            this.colUPK.FieldName = "UPK";
            this.colUPK.Name = "colUPK";
            this.colUPK.Visible = true;
            this.colUPK.VisibleIndex = 14;
            // 
            // colNPK
            // 
            this.colNPK.FieldName = "NPK";
            this.colNPK.Name = "colNPK";
            this.colNPK.Visible = true;
            this.colNPK.VisibleIndex = 15;
            // 
            // colBreak
            // 
            this.colBreak.Caption = "Break";
            this.colBreak.FieldName = "Break";
            this.colBreak.Name = "colBreak";
            this.colBreak.Visible = true;
            this.colBreak.VisibleIndex = 16;
            // 
            // spCalismaSaatleriAllTableAdapter
            // 
            this.spCalismaSaatleriAllTableAdapter.ClearBeforeFill = true;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(185, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(10, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "ile";
            // 
            // frmCcalismaSaatleriByManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 583);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmCcalismaSaatleriByManager";
            this.Text = "Manager Rapor";
            this.Load += new System.EventHandler(this.frmCcalismaSaatleriByManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCalismaSaatleriAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource spCalismaSaatleriAllBindingSource;
        private livegameDataSet1 livegameDataSet1;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonel;
        private DevExpress.XtraGrid.Columns.GridColumn colTarih;
        private DevExpress.XtraGrid.Columns.GridColumn colShift;
        private DevExpress.XtraGrid.Columns.GridColumn colBaslangicSaati;
        private DevExpress.XtraGrid.Columns.GridColumn colBitisSaati;
        private DevExpress.XtraGrid.Columns.GridColumn colCalismasiGereken;
        private DevExpress.XtraGrid.Columns.GridColumn colCalistigiSure;
        private DevExpress.XtraGrid.Columns.GridColumn colOverTime;
        private DevExpress.XtraGrid.Columns.GridColumn colErkenGonderim;
        private DevExpress.XtraGrid.Columns.GridColumn colAR;
        private DevExpress.XtraGrid.Columns.GridColumn colBJ;
        private DevExpress.XtraGrid.Columns.GridColumn colCSP;
        private DevExpress.XtraGrid.Columns.GridColumn colRPK;
        private DevExpress.XtraGrid.Columns.GridColumn colSPK;
        private DevExpress.XtraGrid.Columns.GridColumn colUPK;
        private DevExpress.XtraGrid.Columns.GridColumn colNPK;
        private livegameDataSet1TableAdapters.spCalismaSaatleriAllTableAdapter spCalismaSaatleriAllTableAdapter;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colBreak;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}