namespace Break_List.Forms.Raporlar
{
    partial class FrmCcalismaSaatleriByManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCcalismaSaatleriByManager));
            this.colOverTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErkenGonderim = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.colHVA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.dateEdit = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.btnGoster = new DevExpress.XtraBars.BarButtonItem();
            this.DptcomboBox = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnYazdır = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
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
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 83);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1398, 479);
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
            this.colCTV,
            this.colHVA,
            this.colID});
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
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsMenu.ShowConditionalFormattingItem = true;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsPrint.ExpandAllGroups = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPozisyon, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPersonel, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
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
            this.colAR.Caption = "AR";
            this.colAR.FieldName = "AR";
            this.colAR.Name = "colAR";
            this.colAR.Visible = true;
            this.colAR.VisibleIndex = 9;
            this.colAR.Width = 42;
            // 
            // colBJ
            // 
            this.colBJ.Caption = "BJ";
            this.colBJ.FieldName = "BJ";
            this.colBJ.Name = "colBJ";
            this.colBJ.Visible = true;
            this.colBJ.VisibleIndex = 10;
            this.colBJ.Width = 42;
            // 
            // colCSP
            // 
            this.colCSP.Caption = "CP";
            this.colCSP.FieldName = "CP";
            this.colCSP.Name = "colCSP";
            this.colCSP.Visible = true;
            this.colCSP.VisibleIndex = 11;
            this.colCSP.Width = 42;
            // 
            // colRPK
            // 
            this.colRPK.Caption = "RP";
            this.colRPK.FieldName = "RP";
            this.colRPK.Name = "colRPK";
            this.colRPK.Visible = true;
            this.colRPK.VisibleIndex = 12;
            this.colRPK.Width = 42;
            // 
            // colSPK
            // 
            this.colSPK.Caption = "SP";
            this.colSPK.FieldName = "SP";
            this.colSPK.Name = "colSPK";
            this.colSPK.Visible = true;
            this.colSPK.VisibleIndex = 13;
            this.colSPK.Width = 42;
            // 
            // colUPK
            // 
            this.colUPK.Caption = "UT";
            this.colUPK.FieldName = "UT";
            this.colUPK.Name = "colUPK";
            this.colUPK.Visible = true;
            this.colUPK.VisibleIndex = 14;
            this.colUPK.Width = 42;
            // 
            // colNPK
            // 
            this.colNPK.Caption = "NP";
            this.colNPK.FieldName = "NP";
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
            this.colCTV.Caption = "CH";
            this.colCTV.FieldName = "CH";
            this.colCTV.Name = "colCTV";
            this.colCTV.Visible = true;
            this.colCTV.VisibleIndex = 19;
            this.colCTV.Width = 42;
            // 
            // colHVA
            // 
            this.colHVA.Caption = "HVA";
            this.colHVA.FieldName = "HVA";
            this.colHVA.Name = "colHVA";
            this.colHVA.Visible = true;
            this.colHVA.VisibleIndex = 21;
            this.colHVA.Width = 38;
            // 
            // colID
            // 
            this.colID.Caption = "gridColumn1";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.dateEdit,
            this.btnGoster,
            this.DptcomboBox,
            this.btnYazdır});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 5;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemComboBox1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.TabletOffice;
            this.ribbonControl1.Size = new System.Drawing.Size(1398, 83);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // dateEdit
            // 
            this.dateEdit.Caption = "Tarih:";
            this.dateEdit.Edit = this.repositoryItemDateEdit1;
            this.dateEdit.EditWidth = 150;
            this.dateEdit.Glyph = ((System.Drawing.Image)(resources.GetObject("dateEdit.Glyph")));
            this.dateEdit.Id = 1;
            this.dateEdit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("dateEdit.LargeGlyph")));
            this.dateEdit.Name = "dateEdit";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // btnGoster
            // 
            this.btnGoster.Caption = "Göster";
            this.btnGoster.Glyph = ((System.Drawing.Image)(resources.GetObject("btnGoster.Glyph")));
            this.btnGoster.Id = 2;
            this.btnGoster.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnGoster.LargeGlyph")));
            this.btnGoster.Name = "btnGoster";
            this.btnGoster.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGoster_ItemClick);
            // 
            // DptcomboBox
            // 
            this.DptcomboBox.Caption = "Departman";
            this.DptcomboBox.Edit = this.repositoryItemComboBox1;
            this.DptcomboBox.EditWidth = 150;
            this.DptcomboBox.Glyph = ((System.Drawing.Image)(resources.GetObject("DptcomboBox.Glyph")));
            this.DptcomboBox.Id = 3;
            this.DptcomboBox.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("DptcomboBox.LargeGlyph")));
            this.DptcomboBox.Name = "DptcomboBox";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // btnYazdır
            // 
            this.btnYazdır.Caption = "Yazdır";
            this.btnYazdır.Glyph = ((System.Drawing.Image)(resources.GetObject("btnYazdır.Glyph")));
            this.btnYazdır.Id = 4;
            this.btnYazdır.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.btnYazdır.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnYazdır.LargeGlyph")));
            this.btnYazdır.Name = "btnYazdır";
            this.btnYazdır.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnYazdır_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Raporlamalar";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.dateEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.DptcomboBox);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnGoster);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnYazdır);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 562);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1398, 21);
            // 
            // FrmCcalismaSaatleriByManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1398, 583);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FrmCcalismaSaatleriByManager";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Manager Rapor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCcalismaSaatleriByManager_FormClosing);
            this.Load += new System.EventHandler(this.frmCcalismaSaatleriByManager_Load);
            this.Shown += new System.EventHandler(this.frmCcalismaSaatleriByManager_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private DevExpress.XtraGrid.Columns.GridColumn colHVA;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarEditItem dateEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarButtonItem btnGoster;
        private DevExpress.XtraBars.BarEditItem DptcomboBox;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraBars.BarButtonItem btnYazdır;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
    }
}