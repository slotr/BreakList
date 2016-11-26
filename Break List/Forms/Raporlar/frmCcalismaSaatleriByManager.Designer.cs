namespace Break_List.Forms.Raporlar
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression3 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression4 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.colOverTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErkenGonderim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
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
            this.colPozisyon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTRV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCTV = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // colOverTime
            // 
            this.colOverTime.FieldName = "Over Time";
            this.colOverTime.Name = "colOverTime";
            this.colOverTime.Visible = true;
            this.colOverTime.VisibleIndex = 7;
            this.colOverTime.Width = 81;
            // 
            // colErkenGonderim
            // 
            this.colErkenGonderim.FieldName = "Erken Gonderim";
            this.colErkenGonderim.Name = "colErkenGonderim";
            this.colErkenGonderim.Visible = true;
            this.colErkenGonderim.VisibleIndex = 8;
            this.colErkenGonderim.Width = 92;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnPrint);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.comboBoxEdit1);
            this.panelControl1.Controls.Add(this.dateEdit1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1398, 65);
            this.panelControl1.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(514, 22);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "Yazdir";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(336, 27);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(162, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "departmanının raporunu Göster...";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(182, 27);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "tarihinde";
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(230, 24);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Size = new System.Drawing.Size(100, 20);
            this.comboBoxEdit1.TabIndex = 2;
            this.comboBoxEdit1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
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
            this.dateEdit1.Size = new System.Drawing.Size(153, 20);
            this.dateEdit1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 65);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1398, 518);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
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
            this.colBreak,
            this.colPozisyon,
            this.colTR,
            this.colTRV,
            this.colCT,
            this.colCTV});
            gridFormatRule3.Column = this.colOverTime;
            gridFormatRule3.Name = "Format0";
            formatConditionRuleExpression3.Expression = "[Over Time] <> \'YOK\'";
            formatConditionRuleExpression3.PredefinedName = "Green Fill";
            gridFormatRule3.Rule = formatConditionRuleExpression3;
            gridFormatRule4.Column = this.colErkenGonderim;
            gridFormatRule4.Name = "Format1";
            formatConditionRuleExpression4.Expression = "[Erken Gonderim] <> \'YOK\'";
            formatConditionRuleExpression4.PredefinedName = "Red Fill";
            gridFormatRule4.Rule = formatConditionRuleExpression4;
            this.gridView1.FormatRules.Add(gridFormatRule3);
            this.gridView1.FormatRules.Add(gridFormatRule4);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.PlainText;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsPrint.ExpandAllGroups = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPozisyon, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPersonel, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colPersonel
            // 
            this.colPersonel.FieldName = "Personel";
            this.colPersonel.Name = "colPersonel";
            this.colPersonel.Visible = true;
            this.colPersonel.VisibleIndex = 0;
            this.colPersonel.Width = 145;
            // 
            // colTarih
            // 
            this.colTarih.FieldName = "Tarih";
            this.colTarih.Name = "colTarih";
            this.colTarih.Visible = true;
            this.colTarih.VisibleIndex = 1;
            this.colTarih.Width = 61;
            // 
            // colShift
            // 
            this.colShift.FieldName = "Shift";
            this.colShift.Name = "colShift";
            this.colShift.Visible = true;
            this.colShift.VisibleIndex = 2;
            this.colShift.Width = 32;
            // 
            // colBaslangicSaati
            // 
            this.colBaslangicSaati.FieldName = "Baslangic Saati";
            this.colBaslangicSaati.Name = "colBaslangicSaati";
            this.colBaslangicSaati.Visible = true;
            this.colBaslangicSaati.VisibleIndex = 3;
            this.colBaslangicSaati.Width = 82;
            // 
            // colBitisSaati
            // 
            this.colBitisSaati.FieldName = "Bitis Saati";
            this.colBitisSaati.Name = "colBitisSaati";
            this.colBitisSaati.Visible = true;
            this.colBitisSaati.VisibleIndex = 4;
            this.colBitisSaati.Width = 56;
            // 
            // colCalismasiGereken
            // 
            this.colCalismasiGereken.DisplayFormat.FormatString = "{0:HH} Saat";
            this.colCalismasiGereken.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colCalismasiGereken.FieldName = "Calismasi Gereken";
            this.colCalismasiGereken.Name = "colCalismasiGereken";
            this.colCalismasiGereken.Visible = true;
            this.colCalismasiGereken.VisibleIndex = 5;
            this.colCalismasiGereken.Width = 101;
            // 
            // colCalistigiSure
            // 
            this.colCalistigiSure.DisplayFormat.FormatString = "{0:HH} Saat {1:mm} Dakika";
            this.colCalistigiSure.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colCalistigiSure.FieldName = "Calistigi Sure";
            this.colCalistigiSure.Name = "colCalistigiSure";
            this.colCalistigiSure.Visible = true;
            this.colCalistigiSure.VisibleIndex = 6;
            this.colCalistigiSure.Width = 103;
            // 
            // colAR
            // 
            this.colAR.FieldName = "AR";
            this.colAR.Name = "colAR";
            this.colAR.Visible = true;
            this.colAR.VisibleIndex = 9;
            this.colAR.Width = 42;
            // 
            // colBJ
            // 
            this.colBJ.FieldName = "BJ";
            this.colBJ.Name = "colBJ";
            this.colBJ.Visible = true;
            this.colBJ.VisibleIndex = 10;
            this.colBJ.Width = 42;
            // 
            // colCSP
            // 
            this.colCSP.FieldName = "CSP";
            this.colCSP.Name = "colCSP";
            this.colCSP.Visible = true;
            this.colCSP.VisibleIndex = 11;
            this.colCSP.Width = 42;
            // 
            // colRPK
            // 
            this.colRPK.FieldName = "RPK";
            this.colRPK.Name = "colRPK";
            this.colRPK.Visible = true;
            this.colRPK.VisibleIndex = 12;
            this.colRPK.Width = 42;
            // 
            // colSPK
            // 
            this.colSPK.FieldName = "SPK";
            this.colSPK.Name = "colSPK";
            this.colSPK.Visible = true;
            this.colSPK.VisibleIndex = 13;
            this.colSPK.Width = 42;
            // 
            // colUPK
            // 
            this.colUPK.FieldName = "UTP";
            this.colUPK.Name = "colUPK";
            this.colUPK.Visible = true;
            this.colUPK.VisibleIndex = 14;
            this.colUPK.Width = 42;
            // 
            // colNPK
            // 
            this.colNPK.FieldName = "NPK";
            this.colNPK.Name = "colNPK";
            this.colNPK.Visible = true;
            this.colNPK.VisibleIndex = 15;
            this.colNPK.Width = 42;
            // 
            // colBreak
            // 
            this.colBreak.Caption = "Break";
            this.colBreak.FieldName = "Break";
            this.colBreak.Name = "colBreak";
            this.colBreak.Visible = true;
            this.colBreak.VisibleIndex = 20;
            this.colBreak.Width = 40;
            // 
            // colPozisyon
            // 
            this.colPozisyon.Caption = "Pozisyon";
            this.colPozisyon.FieldName = "Pozisyon";
            this.colPozisyon.Name = "colPozisyon";
            this.colPozisyon.Visible = true;
            this.colPozisyon.VisibleIndex = 17;
            // 
            // colTR
            // 
            this.colTR.Caption = "TR";
            this.colTR.FieldName = "TR";
            this.colTR.Name = "colTR";
            this.colTR.Visible = true;
            this.colTR.VisibleIndex = 16;
            this.colTR.Width = 42;
            // 
            // colTRV
            // 
            this.colTRV.Caption = "TRV";
            this.colTRV.FieldName = "TRV";
            this.colTRV.Name = "colTRV";
            this.colTRV.Visible = true;
            this.colTRV.VisibleIndex = 17;
            this.colTRV.Width = 42;
            // 
            // colCT
            // 
            this.colCT.Caption = "CT";
            this.colCT.FieldName = "CT";
            this.colCT.Name = "colCT";
            this.colCT.Visible = true;
            this.colCT.VisibleIndex = 18;
            this.colCT.Width = 42;
            // 
            // colCTV
            // 
            this.colCTV.Caption = "CTV";
            this.colCTV.FieldName = "CTV";
            this.colCTV.Name = "colCTV";
            this.colCTV.Visible = true;
            this.colCTV.VisibleIndex = 19;
            this.colCTV.Width = 42;
            // 
            // frmCcalismaSaatleriByManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 583);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmCcalismaSaatleriByManager";
            this.Text = "Manager Rapor";
            this.Load += new System.EventHandler(this.frmCcalismaSaatleriByManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colBreak;
        private DevExpress.XtraGrid.Columns.GridColumn colPozisyon;
        private DevExpress.XtraGrid.Columns.GridColumn colTR;
        private DevExpress.XtraGrid.Columns.GridColumn colTRV;
        private DevExpress.XtraGrid.Columns.GridColumn colCT;
        private DevExpress.XtraGrid.Columns.GridColumn colCTV;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
    }
}