namespace Break_List.Forms.Raporlar
{
    partial class FrmDailySms
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.calendarControl1 = new DevExpress.XtraEditors.Controls.CalendarControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSurname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMusteri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDrop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collgResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colslREsult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
            ((System.ComponentModel.ISupportInitialize)(this.calendarControl1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // calendarControl1
            // 
            this.calendarControl1.AllowAnimatedContentChange = true;
            this.calendarControl1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.calendarControl1.Location = new System.Drawing.Point(12, 12);
            this.calendarControl1.Name = "calendarControl1";
            this.calendarControl1.Size = new System.Drawing.Size(239, 227);
            this.calendarControl1.TabIndex = 6;
            this.calendarControl1.DateTimeChanged += new System.EventHandler(this.calendarControl1_DateTimeChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(176, 245);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 27);
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "Send";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(417, 148);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(289, 76);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colSurname,
            this.colMusteri,
            this.colDrop,
            this.collgResult,
            this.colslREsult,
            this.colTot});
            gridFormatRule1.Column = this.colTot;
            gridFormatRule1.ColumnApplyTo = this.colTot;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Less;
            formatConditionRuleValue1.Value1 = 0;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.AllowHtmlFormat = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.AllowRtfFormat = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTot, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "NAME";
            this.colName.Name = "colName";
            // 
            // colSurname
            // 
            this.colSurname.Caption = "Surname";
            this.colSurname.FieldName = "SURNAME";
            this.colSurname.Name = "colSurname";
            // 
            // colMusteri
            // 
            this.colMusteri.Caption = "CL";
            this.colMusteri.DisplayFormat.FormatString = "N0";
            this.colMusteri.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMusteri.FieldName = "colMusteri";
            this.colMusteri.Name = "colMusteri";
            this.colMusteri.UnboundExpression = "[NAME] + \' \' + [SURNAME]";
            this.colMusteri.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colMusteri.Visible = true;
            this.colMusteri.VisibleIndex = 0;
            this.colMusteri.Width = 303;
            // 
            // colDrop
            // 
            this.colDrop.Caption = "LG DROP";
            this.colDrop.DisplayFormat.FormatString = "N0";
            this.colDrop.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDrop.FieldName = "LG_DROP";
            this.colDrop.Name = "colDrop";
            this.colDrop.Width = 173;
            // 
            // collgResult
            // 
            this.collgResult.Caption = "LG RESULT";
            this.collgResult.DisplayFormat.FormatString = "N0";
            this.collgResult.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.collgResult.FieldName = "LG_RESULT";
            this.collgResult.Name = "collgResult";
            this.collgResult.Width = 195;
            // 
            // colslREsult
            // 
            this.colslREsult.Caption = "SL RESULT";
            this.colslREsult.DisplayFormat.FormatString = "N0";
            this.colslREsult.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colslREsult.FieldName = "SL_RESULT";
            this.colslREsult.Name = "colslREsult";
            this.colslREsult.Width = 195;
            // 
            // colTot
            // 
            this.colTot.Caption = "RES";
            this.colTot.DisplayFormat.FormatString = "#;(#);";
            this.colTot.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTot.FieldName = "colTot";
            this.colTot.Name = "colTot";
            this.colTot.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.colTot.UnboundExpression = "[LG_RESULT] + [SL_RESULT]";
            this.colTot.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colTot.Visible = true;
            this.colTot.VisibleIndex = 1;
            this.colTot.Width = 200;
            // 
            // richEditControl1
            // 
            this.richEditControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richEditControl1.Location = new System.Drawing.Point(268, 12);
            this.richEditControl1.Name = "richEditControl1";
            this.richEditControl1.Size = new System.Drawing.Size(831, 673);
            this.richEditControl1.TabIndex = 10;
            // 
            // FrmDailySms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 711);
            this.Controls.Add(this.richEditControl1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.calendarControl1);
            this.Name = "FrmDailySms";
            this.Text = "Daıly Results To Bosses";
            ((System.ComponentModel.ISupportInitialize)(this.calendarControl1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.Controls.CalendarControl calendarControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraRichEdit.RichEditControl richEditControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colSurname;
        private DevExpress.XtraGrid.Columns.GridColumn colMusteri;
        private DevExpress.XtraGrid.Columns.GridColumn colDrop;
        private DevExpress.XtraGrid.Columns.GridColumn collgResult;
        private DevExpress.XtraGrid.Columns.GridColumn colslREsult;
        private DevExpress.XtraGrid.Columns.GridColumn colTot;
    }
}