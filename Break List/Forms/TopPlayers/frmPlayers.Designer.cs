namespace Break_List.Forms.TopPlayers
{
    partial class FrmPlayers
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Break_List.Forms.Raporlar.WaitForm1), true, true);
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.colGameDate = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colDropPlq = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colActualLoss = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colSlotActualLoss = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colDiscChipsPlus = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colDiscChipMinus = new DevExpress.XtraPivotGrid.PivotGridField();
            this.coDiscCashPlus = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colDiscCashMinus = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colDepositPlus = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colDepositMinus = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colCreditPlus = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colCreditMinus = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colExpenses = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colNETRESULT = new DevExpress.XtraPivotGrid.PivotGridField();
            this.colCustom = new DevExpress.XtraPivotGrid.PivotGridField();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.colPlayTime = new DevExpress.XtraPivotGrid.PivotGridField();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton3);
            this.panelControl1.Controls.Add(this.checkEdit1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.radioGroup1);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.dateEdit2);
            this.panelControl1.Controls.Add(this.dateEdit1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(930, 87);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(366, 58);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(75, 23);
            this.simpleButton3.TabIndex = 6;
            this.simpleButton3.Text = "Yazdır";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(220, 58);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Data Başlıklarını Göster";
            this.checkEdit1.Size = new System.Drawing.Size(145, 19);
            this.checkEdit1.TabIndex = 5;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 38);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(19, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Bitiş";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Başlangıç";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(220, 5);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "Günlük"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(2)), "Aylık"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(5, "Yıllık")});
            this.radioGroup1.Size = new System.Drawing.Size(221, 31);
            this.radioGroup1.TabIndex = 3;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Location = new System.Drawing.Point(823, 13);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(95, 23);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "Görünümü Kaydet";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(94, 58);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(100, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Göster";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(94, 31);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Size = new System.Drawing.Size(100, 20);
            this.dateEdit2.TabIndex = 0;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(94, 5);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(100, 20);
            this.dateEdit1.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.colGameDate,
            this.colDropPlq,
            this.pivotGridField1,
            this.pivotGridField2,
            this.pivotGridField3,
            this.colActualLoss,
            this.colSlotActualLoss,
            this.colDiscChipsPlus,
            this.colDiscChipMinus,
            this.coDiscCashPlus,
            this.colDiscCashMinus,
            this.colDepositPlus,
            this.colDepositMinus,
            this.colCreditPlus,
            this.colCreditMinus,
            this.colExpenses,
            this.colNETRESULT,
            this.colCustom,
            this.colPlayTime});
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 87);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.Size = new System.Drawing.Size(930, 517);
            this.pivotGridControl1.TabIndex = 1;
            this.pivotGridControl1.CustomCellDisplayText += new DevExpress.XtraPivotGrid.PivotCellDisplayTextEventHandler(this.pivotGridControl1_CustomCellDisplayText);
            // 
            // colGameDate
            // 
            this.colGameDate.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.colGameDate.AreaIndex = 0;
            this.colGameDate.Caption = "DATE";
            this.colGameDate.FieldName = "GAMEDATE";
            this.colGameDate.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.DateMonth;
            this.colGameDate.Name = "colGameDate";
            this.colGameDate.UnboundFieldName = "colGameDate";
            // 
            // colDropPlq
            // 
            this.colDropPlq.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.colDropPlq.AreaIndex = 0;
            this.colDropPlq.Caption = "LG. DROP";
            this.colDropPlq.FieldName = "DROP_PLAQUES";
            this.colDropPlq.Name = "colDropPlq";
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField1.AreaIndex = 2;
            this.pivotGridField1.FieldName = "FIRST_NAME";
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.Options.ShowInExpressionEditor = false;
            this.pivotGridField1.Visible = false;
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.pivotGridField2.AreaIndex = 3;
            this.pivotGridField2.FieldName = "LAST_NAME";
            this.pivotGridField2.Name = "pivotGridField2";
            this.pivotGridField2.Options.ShowInExpressionEditor = false;
            this.pivotGridField2.Visible = false;
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField3.AreaIndex = 0;
            this.pivotGridField3.Caption = "NAME SURNAME";
            this.pivotGridField3.Name = "pivotGridField3";
            this.pivotGridField3.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False;
            this.pivotGridField3.Options.IsFilterRadioMode = DevExpress.Utils.DefaultBoolean.True;
            this.pivotGridField3.Options.ShowInExpressionEditor = false;
            this.pivotGridField3.UnboundExpression = "[FIRST_NAME] + \' \' + [LAST_NAME]";
            this.pivotGridField3.UnboundFieldName = "pivotGridField3";
            this.pivotGridField3.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.pivotGridField3.Width = 247;
            // 
            // colActualLoss
            // 
            this.colActualLoss.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.colActualLoss.AreaIndex = 1;
            this.colActualLoss.Caption = "LG. ACTUAL LOSS";
            this.colActualLoss.FieldName = "ACTUAL_LOSS";
            this.colActualLoss.Name = "colActualLoss";
            // 
            // colSlotActualLoss
            // 
            this.colSlotActualLoss.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.colSlotActualLoss.AreaIndex = 2;
            this.colSlotActualLoss.Caption = "SL. ACTUAL LOSS";
            this.colSlotActualLoss.FieldName = "SACTUAL_LOSS";
            this.colSlotActualLoss.Name = "colSlotActualLoss";
            // 
            // colDiscChipsPlus
            // 
            this.colDiscChipsPlus.AreaIndex = 0;
            this.colDiscChipsPlus.Caption = "DSC. CHIP +";
            this.colDiscChipsPlus.FieldName = "DISC_CHIPS_PLUS";
            this.colDiscChipsPlus.Name = "colDiscChipsPlus";
            // 
            // colDiscChipMinus
            // 
            this.colDiscChipMinus.AreaIndex = 1;
            this.colDiscChipMinus.Caption = "DISC. CHIP -";
            this.colDiscChipMinus.FieldName = "DISC_CHIPS_MINUS";
            this.colDiscChipMinus.Name = "colDiscChipMinus";
            // 
            // coDiscCashPlus
            // 
            this.coDiscCashPlus.AreaIndex = 2;
            this.coDiscCashPlus.Caption = "DISC. CASH +";
            this.coDiscCashPlus.FieldName = "DISC_CASH_PLUS";
            this.coDiscCashPlus.Name = "coDiscCashPlus";
            // 
            // colDiscCashMinus
            // 
            this.colDiscCashMinus.AreaIndex = 3;
            this.colDiscCashMinus.Caption = "DISC. CASH -";
            this.colDiscCashMinus.FieldName = "DISC_CASH_MINUS";
            this.colDiscCashMinus.Name = "colDiscCashMinus";
            // 
            // colDepositPlus
            // 
            this.colDepositPlus.AreaIndex = 4;
            this.colDepositPlus.Caption = "DEPOSIT +";
            this.colDepositPlus.FieldName = "DEPOSIT_PLUS";
            this.colDepositPlus.Name = "colDepositPlus";
            // 
            // colDepositMinus
            // 
            this.colDepositMinus.AreaIndex = 5;
            this.colDepositMinus.Caption = "DEPOSIT -";
            this.colDepositMinus.FieldName = "DEPOSIT_MINUS";
            this.colDepositMinus.Name = "colDepositMinus";
            // 
            // colCreditPlus
            // 
            this.colCreditPlus.AreaIndex = 6;
            this.colCreditPlus.Caption = "CREDIT +";
            this.colCreditPlus.FieldName = "CREDIT_PLUS";
            this.colCreditPlus.Name = "colCreditPlus";
            // 
            // colCreditMinus
            // 
            this.colCreditMinus.AreaIndex = 7;
            this.colCreditMinus.Caption = "CREDIT -";
            this.colCreditMinus.FieldName = "CREDIT_MINUS";
            this.colCreditMinus.Name = "colCreditMinus";
            // 
            // colExpenses
            // 
            this.colExpenses.AreaIndex = 8;
            this.colExpenses.Caption = "EXPENSES";
            this.colExpenses.FieldName = "EXPENSES";
            this.colExpenses.Name = "colExpenses";
            // 
            // colNETRESULT
            // 
            this.colNETRESULT.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.colNETRESULT.AreaIndex = 3;
            this.colNETRESULT.Caption = "NET RESULT";
            this.colNETRESULT.Name = "colNETRESULT";
            this.colNETRESULT.Options.AllowSortBySummary = DevExpress.Utils.DefaultBoolean.True;
            this.colNETRESULT.Options.ShowUnboundExpressionMenu = true;
            this.colNETRESULT.UnboundExpression = "[ACTUAL_LOSS] + [SACTUAL_LOSS] - [EXPENSES] - ([DISC_CHIPS_PLUS] - [DISC_CHIPS_MI" +
    "NUS]) - ([DISC_CASH_PLUS] - [DISC_CASH_MINUS])";
            this.colNETRESULT.UnboundFieldName = "colNETRESULT";
            this.colNETRESULT.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            // 
            // colCustom
            // 
            this.colCustom.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.colCustom.AreaIndex = 4;
            this.colCustom.Caption = "CUSTOM";
            this.colCustom.Name = "colCustom";
            this.colCustom.Options.ShowInExpressionEditor = false;
            this.colCustom.Options.ShowUnboundExpressionMenu = true;
            this.colCustom.UnboundExpression = "1 + 1 + 1 + 1";
            this.colCustom.UnboundFieldName = "colCustom";
            this.colCustom.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // colPlayTime
            // 
            this.colPlayTime.AreaIndex = 9;
            this.colPlayTime.Caption = "PLAY TIME LG";
            this.colPlayTime.FieldName = "LG_PLAY_TIME";
            this.colPlayTime.Name = "colPlayTime";
            // 
            // FrmPlayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 604);
            this.Controls.Add(this.pivotGridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmPlayers";
            this.Text = "Oyuncu Bazlı Raporlama";
            this.Load += new System.EventHandler(this.frmPlayers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraPivotGrid.PivotGridField colGameDate;
        private DevExpress.XtraPivotGrid.PivotGridField colDropPlq;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private DevExpress.XtraPivotGrid.PivotGridField colActualLoss;
        private DevExpress.XtraPivotGrid.PivotGridField colSlotActualLoss;
        private DevExpress.XtraPivotGrid.PivotGridField colDiscChipsPlus;
        private DevExpress.XtraPivotGrid.PivotGridField colDiscChipMinus;
        private DevExpress.XtraPivotGrid.PivotGridField coDiscCashPlus;
        private DevExpress.XtraPivotGrid.PivotGridField colDiscCashMinus;
        private DevExpress.XtraPivotGrid.PivotGridField colDepositPlus;
        private DevExpress.XtraPivotGrid.PivotGridField colDepositMinus;
        private DevExpress.XtraPivotGrid.PivotGridField colCreditPlus;
        private DevExpress.XtraPivotGrid.PivotGridField colCreditMinus;
        private DevExpress.XtraPivotGrid.PivotGridField colExpenses;
        private DevExpress.XtraPivotGrid.PivotGridField colNETRESULT;
        private DevExpress.XtraPivotGrid.PivotGridField colCustom;
        private DevExpress.XtraPivotGrid.PivotGridField colPlayTime;
    }
}