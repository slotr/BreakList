namespace Break_List.Forms.Raporlar
{
    partial class frmBreakMusteri
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
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMasa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPozisyon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaatGor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMasagor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIncele = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colResourceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colMusteri = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colAVG = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colCashChips = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colDrop = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colCashOut = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colPlaquesOUT = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colWinLoss = new DevExpress.XtraPivotGrid.PivotGridField();
            this.theoDrop = new DevExpress.XtraPivotGrid.PivotGridField();
            this.theoLoss = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colHandsPlayed = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colPlayTime = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colPlyTime = new DevExpress.XtraPivotGrid.PivotGridField();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColRes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Break_List.Forms.Raporlar.WaitForm1), true, true, true);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(13, 12);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(126, 20);
            this.dateEdit1.TabIndex = 0;
            this.dateEdit1.EditValueChanged += new System.EventHandler(this.dateEdit1_EditValueChanged);
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Mask.EditMask = "dd-MMM-yyyy HH:mm:ss";
            this.repositoryItemDateEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMasa,
            this.colSaat,
            this.colPersonel,
            this.colPozisyon,
            this.colSaatGor,
            this.colMasagor,
            this.colIncele,
            this.colResourceID});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 2;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPozisyon, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMasagor, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // colMasa
            // 
            this.colMasa.Caption = "Masa";
            this.colMasa.FieldName = "Masa";
            this.colMasa.Name = "colMasa";
            // 
            // colSaat
            // 
            this.colSaat.Caption = "Saat";
            this.colSaat.FieldName = "Saat";
            this.colSaat.Name = "colSaat";
            this.colSaat.Width = 232;
            // 
            // colPersonel
            // 
            this.colPersonel.Caption = "Personel";
            this.colPersonel.CustomizationCaption = "Personel";
            this.colPersonel.FieldName = "Personel";
            this.colPersonel.Name = "colPersonel";
            this.colPersonel.Visible = true;
            this.colPersonel.VisibleIndex = 0;
            this.colPersonel.Width = 120;
            // 
            // colPozisyon
            // 
            this.colPozisyon.Caption = "Pozisyon";
            this.colPozisyon.FieldName = "Pozisyon";
            this.colPozisyon.Name = "colPozisyon";
            this.colPozisyon.Visible = true;
            this.colPozisyon.VisibleIndex = 2;
            // 
            // colSaatGor
            // 
            this.colSaatGor.Caption = "Saat";
            this.colSaatGor.FieldName = "SaatGorunen";
            this.colSaatGor.Name = "colSaatGor";
            this.colSaatGor.Visible = true;
            this.colSaatGor.VisibleIndex = 1;
            // 
            // colMasagor
            // 
            this.colMasagor.Caption = "Masa";
            this.colMasagor.FieldName = "MasaGorunen";
            this.colMasagor.Name = "colMasagor";
            this.colMasagor.Visible = true;
            this.colMasagor.VisibleIndex = 2;
            // 
            // colIncele
            // 
            this.colIncele.Caption = "Incele";
            this.colIncele.ColumnEdit = this.repositoryItemButtonEdit1;
            this.colIncele.Name = "colIncele";
            this.colIncele.Visible = true;
            this.colIncele.VisibleIndex = 2;
            this.colIncele.Width = 20;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // colResourceID
            // 
            this.colResourceID.Caption = "ResourceID";
            this.colResourceID.FieldName = "ResourceID";
            this.colResourceID.Name = "colResourceID";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemButtonEdit1});
            this.gridControl1.Size = new System.Drawing.Size(340, 667);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.TabStop = false;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl3);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1212, 667);
            this.splitContainerControl1.SplitterPosition = 340;
            this.splitContainerControl1.TabIndex = 3;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.pivotGridControl1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 43);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(860, 624);
            this.panelControl3.TabIndex = 2;
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.Appearance.Cell.BackColor = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.Cell.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.ColumnHeaderArea.BackColor = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.ColumnHeaderArea.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.DataHeaderArea.BackColor = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.DataHeaderArea.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.FieldHeader.BackColor = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.FieldHeader.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.FieldValue.BackColor = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.FieldValue.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.FieldValueTotal.BackColor = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.FieldValueTotal.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.FilterHeaderArea.BackColor = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.FilterHeaderArea.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.GrandTotalCell.BackColor = System.Drawing.Color.White;
            this.pivotGridControl1.Appearance.GrandTotalCell.Options.UseBackColor = true;
            this.pivotGridControl1.Appearance.GrandTotalCell.Options.UseTextOptions = true;
            this.pivotGridControl1.Appearance.GrandTotalCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.pivotGridControl1.BackColor = System.Drawing.Color.White;
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField1,
            this.pivotGridField2,
            this.colMusteri,
            this.colAVG,
            this.colCashChips,
            this.colDrop,
            this.colCashOut,
            this.colPlaquesOUT,
            this.colWinLoss,
            this.theoDrop,
            this.theoLoss,
            this.colHandsPlayed,
            this.colPlayTime,
            this.colPlyTime});
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 0);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.OptionsBehavior.CopyToClipboardWithFieldValues = true;
            this.pivotGridControl1.OptionsBehavior.SortBySummaryDefaultOrder = DevExpress.XtraPivotGrid.PivotSortBySummaryOrder.Ascending;
            this.pivotGridControl1.OptionsBehavior.UseAsyncMode = true;
            this.pivotGridControl1.OptionsCustomization.AllowHideFields = DevExpress.XtraPivotGrid.AllowHideFieldsType.Never;
            this.pivotGridControl1.OptionsView.ShowColumnGrandTotalHeader = false;
            this.pivotGridControl1.OptionsView.ShowColumnGrandTotals = false;
            this.pivotGridControl1.OptionsView.ShowColumnHeaders = false;
            this.pivotGridControl1.OptionsView.ShowDataHeaders = false;
            this.pivotGridControl1.OptionsView.ShowFilterHeaders = false;
            this.pivotGridControl1.OptionsView.ShowFilterSeparatorBar = false;
            this.pivotGridControl1.Size = new System.Drawing.Size(860, 624);
            this.pivotGridControl1.TabIndex = 0;
            this.pivotGridControl1.TabStop = false;
            this.pivotGridControl1.CustomCellDisplayText += new DevExpress.XtraPivotGrid.PivotCellDisplayTextEventHandler(this.pivotGridControl1_CustomCellDisplayText_1);
            this.pivotGridControl1.CellDoubleClick += new DevExpress.XtraPivotGrid.PivotCellEventHandler(this.pivotGridControl1_CellDoubleClick);
            this.pivotGridControl1.CustomDrawFieldValue += new DevExpress.XtraPivotGrid.PivotCustomDrawFieldValueEventHandler(this.pivotGridControl1_CustomDrawFieldValue);
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField1.AreaIndex = 0;
            this.pivotGridField1.FieldName = "FIRST_NAME";
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.Visible = false;
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField2.AreaIndex = 0;
            this.pivotGridField2.FieldName = "LAST_NAME";
            this.pivotGridField2.Name = "pivotGridField2";
            this.pivotGridField2.Visible = false;
            // 
            // colMusteri
            // 
            this.colMusteri.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.colMusteri.AreaIndex = 0;
            this.colMusteri.Caption = "Müşteri";
            this.colMusteri.Name = "colMusteri";
            this.colMusteri.UnboundExpression = "[FIRST_NAME] + \' \' + [LAST_NAME]";
            this.colMusteri.UnboundFieldName = "colMusteri";
            this.colMusteri.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colMusteri.Width = 179;
            // 
            // colAVG
            // 
            this.colAVG.Appearance.ValueGrandTotal.Options.UseTextOptions = true;
            this.colAVG.Appearance.ValueGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAVG.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.colAVG.AreaIndex = 0;
            this.colAVG.Caption = "x̄ Bet";
            this.colAVG.EmptyValueText = "0";
            this.colAVG.FieldName = "AVG_BET";
            this.colAVG.GrandTotalCellFormat.FormatString = "n1";
            this.colAVG.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAVG.Name = "colAVG";
            this.colAVG.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average;
            this.colAVG.Width = 79;
            // 
            // colCashChips
            // 
            this.colCashChips.Appearance.Cell.ForeColor = System.Drawing.Color.Green;
            this.colCashChips.Appearance.Cell.Options.UseForeColor = true;
            this.colCashChips.Appearance.ValueGrandTotal.Options.UseTextOptions = true;
            this.colCashChips.Appearance.ValueGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCashChips.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.colCashChips.AreaIndex = 1;
            this.colCashChips.Caption = "Σ Cash Chips (+)";
            this.colCashChips.FieldName = "CASH_CHIPS";
            this.colCashChips.Name = "colCashChips";
            // 
            // colDrop
            // 
            this.colDrop.Appearance.Cell.ForeColor = System.Drawing.Color.Green;
            this.colDrop.Appearance.Cell.Options.UseForeColor = true;
            this.colDrop.Appearance.ValueGrandTotal.Options.UseTextOptions = true;
            this.colDrop.Appearance.ValueGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDrop.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.colDrop.AreaIndex = 2;
            this.colDrop.Caption = "Σ Drop (+)";
            this.colDrop.EmptyValueText = "0";
            this.colDrop.FieldName = "DROP_PLAQUES";
            this.colDrop.Name = "colDrop";
            this.colDrop.Width = 85;
            // 
            // colCashOut
            // 
            this.colCashOut.Appearance.Cell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colCashOut.Appearance.Cell.Options.UseForeColor = true;
            this.colCashOut.Appearance.ValueGrandTotal.Options.UseTextOptions = true;
            this.colCashOut.Appearance.ValueGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCashOut.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.colCashOut.AreaIndex = 3;
            this.colCashOut.Caption = "Σ Cash Out (-)";
            this.colCashOut.EmptyValueText = "0";
            this.colCashOut.FieldName = "CASH_OUT";
            this.colCashOut.Name = "colCashOut";
            this.colCashOut.Width = 99;
            // 
            // colPlaquesOUT
            // 
            this.colPlaquesOUT.Appearance.Cell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colPlaquesOUT.Appearance.Cell.Options.UseForeColor = true;
            this.colPlaquesOUT.Appearance.ValueGrandTotal.Options.UseTextOptions = true;
            this.colPlaquesOUT.Appearance.ValueGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPlaquesOUT.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.colPlaquesOUT.AreaIndex = 4;
            this.colPlaquesOUT.Caption = "Σ Plq. OUT (-)";
            this.colPlaquesOUT.FieldName = "PLQSOUT_ENTRY";
            this.colPlaquesOUT.Name = "colPlaquesOUT";
            this.colPlaquesOUT.Width = 90;
            // 
            // colWinLoss
            // 
            this.colWinLoss.Appearance.Cell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.colWinLoss.Appearance.Cell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colWinLoss.Appearance.Cell.ForeColor = System.Drawing.Color.White;
            this.colWinLoss.Appearance.Cell.Options.UseBackColor = true;
            this.colWinLoss.Appearance.Cell.Options.UseFont = true;
            this.colWinLoss.Appearance.Cell.Options.UseForeColor = true;
            this.colWinLoss.Appearance.CellGrandTotal.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.colWinLoss.Appearance.CellGrandTotal.ForeColor = System.Drawing.Color.Green;
            this.colWinLoss.Appearance.CellGrandTotal.Options.UseFont = true;
            this.colWinLoss.Appearance.CellGrandTotal.Options.UseForeColor = true;
            this.colWinLoss.Appearance.Header.BackColor = System.Drawing.Color.Green;
            this.colWinLoss.Appearance.Header.Options.UseBackColor = true;
            this.colWinLoss.Appearance.Value.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.colWinLoss.Appearance.Value.Options.UseFont = true;
            this.colWinLoss.Appearance.ValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colWinLoss.Appearance.ValueGrandTotal.Options.UseFont = true;
            this.colWinLoss.Appearance.ValueGrandTotal.Options.UseTextOptions = true;
            this.colWinLoss.Appearance.ValueGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWinLoss.Appearance.ValueTotal.BackColor = System.Drawing.Color.Green;
            this.colWinLoss.Appearance.ValueTotal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.colWinLoss.Appearance.ValueTotal.ForeColor = System.Drawing.Color.Green;
            this.colWinLoss.Appearance.ValueTotal.Options.UseBackColor = true;
            this.colWinLoss.Appearance.ValueTotal.Options.UseFont = true;
            this.colWinLoss.Appearance.ValueTotal.Options.UseForeColor = true;
            this.colWinLoss.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.colWinLoss.AreaIndex = 5;
            this.colWinLoss.Caption = "Σ Win/Loss";
            this.colWinLoss.CellFormat.FormatString = "n0";
            this.colWinLoss.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colWinLoss.EmptyValueText = "0";
            this.colWinLoss.Name = "colWinLoss";
            this.colWinLoss.UnboundExpression = "[CASH_CHIPS] + [DROP_PLAQUES] - [CASH_OUT] - [PLQSOUT_ENTRY]";
            this.colWinLoss.UnboundFieldName = "colWinLoss";
            this.colWinLoss.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colWinLoss.Width = 111;
            // 
            // theoDrop
            // 
            this.theoDrop.Appearance.ValueGrandTotal.Options.UseTextOptions = true;
            this.theoDrop.Appearance.ValueGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.theoDrop.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.theoDrop.AreaIndex = 6;
            this.theoDrop.Caption = "Σ Theo. Drop";
            this.theoDrop.EmptyValueText = "0";
            this.theoDrop.FieldName = "THEORET_DROP";
            this.theoDrop.Name = "theoDrop";
            this.theoDrop.Width = 79;
            // 
            // theoLoss
            // 
            this.theoLoss.Appearance.ValueGrandTotal.Options.UseTextOptions = true;
            this.theoLoss.Appearance.ValueGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.theoLoss.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.theoLoss.AreaIndex = 7;
            this.theoLoss.Caption = "Σ Theo. Loss";
            this.theoLoss.EmptyValueText = "0";
            this.theoLoss.FieldName = "THEORET_LOSS";
            this.theoLoss.Name = "theoLoss";
            this.theoLoss.Width = 77;
            // 
            // colHandsPlayed
            // 
            this.colHandsPlayed.Appearance.ValueGrandTotal.Options.UseTextOptions = true;
            this.colHandsPlayed.Appearance.ValueGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colHandsPlayed.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.colHandsPlayed.AreaIndex = 8;
            this.colHandsPlayed.Caption = "Σ Hands";
            this.colHandsPlayed.FieldName = "HANDS_PLAYED";
            this.colHandsPlayed.Name = "colHandsPlayed";
            this.colHandsPlayed.UnboundFieldName = "colHandsPlayed";
            this.colHandsPlayed.Width = 53;
            // 
            // colPlayTime
            // 
            this.colPlayTime.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.colPlayTime.AreaIndex = 9;
            this.colPlayTime.Caption = "Ply. Time";
            this.colPlayTime.FieldName = "PLAY_TIME";
            this.colPlayTime.Name = "colPlayTime";
            this.colPlayTime.Visible = false;
            // 
            // colPlyTime
            // 
            this.colPlyTime.Appearance.ValueGrandTotal.Options.UseTextOptions = true;
            this.colPlyTime.Appearance.ValueGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colPlyTime.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.colPlyTime.AreaIndex = 9;
            this.colPlyTime.Caption = "Σ Play Time";
            this.colPlyTime.CellFormat.FormatString = "n2";
            this.colPlyTime.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPlyTime.Name = "colPlyTime";
            this.colPlyTime.UnboundExpression = "[PLAY_TIME] * 60";
            this.colPlyTime.UnboundFieldName = "colPlyTime";
            this.colPlyTime.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colPlyTime.Width = 72;
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.dateEdit1);
            this.panelControl2.Controls.Add(this.gridControl2);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(860, 43);
            this.panelControl2.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(145, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(176, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Görüntülemek istediğiniz tarihi seçin. ";
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.gridControl2.Location = new System.Drawing.Point(529, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(331, 43);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.TabStop = false;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colResult,
            this.ColRes});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsView.ShowColumnHeaders = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsView.ShowIndicator = false;
            this.gridView2.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView2_CustomDrawCell);
            // 
            // colResult
            // 
            this.colResult.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.colResult.AppearanceCell.Options.UseFont = true;
            this.colResult.Caption = "Result";
            this.colResult.FieldName = "RESULT";
            this.colResult.Name = "colResult";
            this.colResult.Visible = true;
            this.colResult.VisibleIndex = 1;
            // 
            // ColRes
            // 
            this.ColRes.Caption = "ColRes";
            this.ColRes.FieldName = "ColRes";
            this.ColRes.Name = "ColRes";
            this.ColRes.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.ColRes.Visible = true;
            this.ColRes.VisibleIndex = 0;
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // frmBreakMusteri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 667);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmBreakMusteri";
            this.Text = "Masa Detay Raporu";
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colMasa;
        private DevExpress.XtraGrid.Columns.GridColumn colSaat;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonel;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
        private DevExpress.XtraPivotGrid.PivotGridField colMusteri;
        private DevExpress.XtraPivotGrid.PivotGridField colAVG;
        private DevExpress.XtraPivotGrid.PivotGridField colCashOut;
        private DevExpress.XtraPivotGrid.PivotGridField colDrop;
        private DevExpress.XtraPivotGrid.PivotGridField theoDrop;
        private DevExpress.XtraPivotGrid.PivotGridField theoLoss;
        private DevExpress.XtraPivotGrid.PivotGridField colWinLoss;
        private DevExpress.XtraGrid.Columns.GridColumn colPozisyon;
        private DevExpress.XtraGrid.Columns.GridColumn colSaatGor;
        private DevExpress.XtraGrid.Columns.GridColumn colMasagor;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colResult;
        private DevExpress.XtraGrid.Columns.GridColumn ColRes;
        private DevExpress.XtraPivotGrid.PivotGridField colHandsPlayed;
        private DevExpress.XtraGrid.Columns.GridColumn colIncele;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraPivotGrid.PivotGridField colPlayTime;
        private DevExpress.XtraPivotGrid.PivotGridField colPlaquesOUT;
        private DevExpress.XtraPivotGrid.PivotGridField colCashChips;
        private DevExpress.XtraPivotGrid.PivotGridField colPlyTime;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colResourceID;
    }
}