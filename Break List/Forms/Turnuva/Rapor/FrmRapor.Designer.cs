namespace Break_List.Forms.Turnuva.Rapor
{
    partial class FrmRapor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRapor));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.tblturnuvakatilimciBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.livegameDataSet1 = new Break_List.livegameDataSet1();
            this.fieldturnuvaadi1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldturnuvaoyuntarihi1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldmusteri1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldrebuy1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldreentry1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldrebuypaidamount1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldreentrypaidamount1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldfinalscore1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.tblturnuva_katilimciTableAdapter = new Break_List.livegameDataSet1TableAdapters.tblturnuva_katilimciTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblturnuvakatilimciBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barButtonItem1});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 2;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbon.Size = new System.Drawing.Size(1028, 83);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Export Rapor";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Turnuvalar";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.DataSource = this.tblturnuvakatilimciBindingSource;
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldturnuvaadi1,
            this.fieldturnuvaoyuntarihi1,
            this.fieldmusteri1,
            this.fieldrebuy1,
            this.fieldreentry1,
            this.fieldrebuypaidamount1,
            this.fieldreentrypaidamount1,
            this.fieldfinalscore1,
            this.pivotGridField1});
            this.pivotGridControl1.Location = new System.Drawing.Point(0, 83);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.Size = new System.Drawing.Size(1028, 579);
            this.pivotGridControl1.TabIndex = 1;
            // 
            // tblturnuvakatilimciBindingSource
            // 
            this.tblturnuvakatilimciBindingSource.DataMember = "tblturnuva_katilimci";
            this.tblturnuvakatilimciBindingSource.DataSource = this.livegameDataSet1;
            // 
            // livegameDataSet1
            // 
            this.livegameDataSet1.DataSetName = "livegameDataSet1";
            this.livegameDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fieldturnuvaadi1
            // 
            this.fieldturnuvaadi1.AreaIndex = 0;
            this.fieldturnuvaadi1.Caption = "Turnuva Adi";
            this.fieldturnuvaadi1.FieldName = "turnuva_adi";
            this.fieldturnuvaadi1.Name = "fieldturnuvaadi1";
            // 
            // fieldturnuvaoyuntarihi1
            // 
            this.fieldturnuvaoyuntarihi1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldturnuvaoyuntarihi1.AreaIndex = 0;
            this.fieldturnuvaoyuntarihi1.Caption = "Date";
            this.fieldturnuvaoyuntarihi1.CellFormat.FormatString = "d";
            this.fieldturnuvaoyuntarihi1.CellFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.fieldturnuvaoyuntarihi1.FieldName = "turnuva_oyun_tarihi";
            this.fieldturnuvaoyuntarihi1.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.Date;
            this.fieldturnuvaoyuntarihi1.Name = "fieldturnuvaoyuntarihi1";
            this.fieldturnuvaoyuntarihi1.UnboundFieldName = "fieldturnuvaoyuntarihi1";
            // 
            // fieldmusteri1
            // 
            this.fieldmusteri1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldmusteri1.AreaIndex = 0;
            this.fieldmusteri1.Caption = "Client";
            this.fieldmusteri1.FieldName = "musteri";
            this.fieldmusteri1.Name = "fieldmusteri1";
            this.fieldmusteri1.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
            this.fieldmusteri1.Width = 258;
            // 
            // fieldrebuy1
            // 
            this.fieldrebuy1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldrebuy1.AreaIndex = 0;
            this.fieldrebuy1.Caption = "Re Buy";
            this.fieldrebuy1.CellFormat.FormatString = "n0";
            this.fieldrebuy1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldrebuy1.EmptyCellText = "N/A";
            this.fieldrebuy1.EmptyValueText = "N/A";
            this.fieldrebuy1.FieldName = "re_buy";
            this.fieldrebuy1.Name = "fieldrebuy1";
            // 
            // fieldreentry1
            // 
            this.fieldreentry1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldreentry1.AreaIndex = 1;
            this.fieldreentry1.Caption = "Re Entry";
            this.fieldreentry1.CellFormat.FormatString = "n0";
            this.fieldreentry1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldreentry1.EmptyCellText = "N/A";
            this.fieldreentry1.EmptyValueText = "N/A";
            this.fieldreentry1.FieldName = "re_entry";
            this.fieldreentry1.Name = "fieldreentry1";
            // 
            // fieldrebuypaidamount1
            // 
            this.fieldrebuypaidamount1.AreaIndex = 1;
            this.fieldrebuypaidamount1.Caption = "Rebuy Paid";
            this.fieldrebuypaidamount1.FieldName = "re_buy_paid_amount";
            this.fieldrebuypaidamount1.Name = "fieldrebuypaidamount1";
            // 
            // fieldreentrypaidamount1
            // 
            this.fieldreentrypaidamount1.AreaIndex = 2;
            this.fieldreentrypaidamount1.Caption = "Reentry Paid";
            this.fieldreentrypaidamount1.FieldName = "re_entry_paid_amount";
            this.fieldreentrypaidamount1.Name = "fieldreentrypaidamount1";
            // 
            // fieldfinalscore1
            // 
            this.fieldfinalscore1.Appearance.Cell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.fieldfinalscore1.Appearance.Cell.BorderColor = System.Drawing.Color.Black;
            this.fieldfinalscore1.Appearance.Cell.Options.UseBackColor = true;
            this.fieldfinalscore1.Appearance.Cell.Options.UseBorderColor = true;
            this.fieldfinalscore1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldfinalscore1.AreaIndex = 2;
            this.fieldfinalscore1.Caption = "Score";
            this.fieldfinalscore1.CellFormat.FormatString = "n0";
            this.fieldfinalscore1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldfinalscore1.EmptyCellText = "N/A";
            this.fieldfinalscore1.EmptyValueText = "N/A";
            this.fieldfinalscore1.FieldName = "final_score";
            this.fieldfinalscore1.Name = "fieldfinalscore1";
            this.fieldfinalscore1.Options.ShowValues = false;
            this.fieldfinalscore1.SortBySummaryInfo.FieldName = "final_score";
            this.fieldfinalscore1.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Descending;
            this.fieldfinalscore1.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max;
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Appearance.Cell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pivotGridField1.Appearance.Cell.BorderColor = System.Drawing.Color.Black;
            this.pivotGridField1.Appearance.Cell.Options.UseBackColor = true;
            this.pivotGridField1.Appearance.Cell.Options.UseBorderColor = true;
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField1.AreaIndex = 3;
            this.pivotGridField1.Caption = "Avg. Rebuy";
            this.pivotGridField1.EmptyCellText = "N/A";
            this.pivotGridField1.EmptyValueText = "N/A";
            this.pivotGridField1.FieldName = "re_buy";
            this.pivotGridField1.Name = "pivotGridField1";
            this.pivotGridField1.Options.ShowValues = false;
            this.pivotGridField1.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average;
            // 
            // tblturnuva_katilimciTableAdapter
            // 
            this.tblturnuva_katilimciTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 662);
            this.Controls.Add(this.pivotGridControl1);
            this.Controls.Add(this.ribbon);
            this.Name = "FrmRapor";
            this.Ribbon = this.ribbon;
            this.Text = "FrmRapor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblturnuvakatilimciBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private livegameDataSet1 livegameDataSet1;
        private System.Windows.Forms.BindingSource tblturnuvakatilimciBindingSource;
        private livegameDataSet1TableAdapters.tblturnuva_katilimciTableAdapter tblturnuva_katilimciTableAdapter;
        private DevExpress.XtraPivotGrid.PivotGridField fieldturnuvaadi1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldturnuvaoyuntarihi1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldmusteri1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldrebuy1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldreentry1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldrebuypaidamount1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldreentrypaidamount1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldfinalscore1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}