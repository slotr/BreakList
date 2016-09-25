namespace Break_List
{
    partial class frmRota
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRota));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colGorev = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpersonel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colTuesday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWednesday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThursday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFriday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaturday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSunday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnExport = new DevExpress.XtraBars.BarButtonItem();
            this.btnYeniRota = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.livegameDataSet11 = new Break_List.livegameDataSet1();
            this.resourcesTableAdapter1 = new Break_List.livegameDataSet1TableAdapters.resourcesTableAdapter();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataMember = "resources";
            this.gridControl1.DataSource = this.livegameDataSet11;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 77);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemComboBox2});
            this.gridControl1.Size = new System.Drawing.Size(917, 461);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.ColumnPanelRowHeight = 20;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGorev,
            this.colpersonel,
            this.colMonday,
            this.colTuesday,
            this.colWednesday,
            this.colThursday,
            this.colFriday,
            this.colSaturday,
            this.colSunday});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsView.AllowHtmlDrawHeaders = true;
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colGorev, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colGorev
            // 
            this.colGorev.Caption = "Gorev";
            this.colGorev.FieldName = "CustomField1";
            this.colGorev.Name = "colGorev";
            this.colGorev.OptionsColumn.AllowEdit = false;
            this.colGorev.OptionsColumn.ReadOnly = true;
            this.colGorev.Visible = true;
            this.colGorev.VisibleIndex = 0;
            // 
            // colpersonel
            // 
            this.colpersonel.Caption = "Personel";
            this.colpersonel.FieldName = "ResourceName";
            this.colpersonel.Name = "colpersonel";
            this.colpersonel.OptionsColumn.AllowEdit = false;
            this.colpersonel.OptionsColumn.ReadOnly = true;
            this.colpersonel.Visible = true;
            this.colpersonel.VisibleIndex = 0;
            // 
            // colMonday
            // 
            this.colMonday.ColumnEdit = this.repositoryItemComboBox1;
            this.colMonday.FieldName = "Monday";
            this.colMonday.Name = "colMonday";
            this.colMonday.Visible = true;
            this.colMonday.VisibleIndex = 1;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "off",
            "upv",
            "vac",
            "sick",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "1*",
            "2*",
            "3*",
            "4*",
            "5*",
            "6*",
            "7*",
            "8*",
            "16-24"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // colTuesday
            // 
            this.colTuesday.ColumnEdit = this.repositoryItemComboBox1;
            this.colTuesday.FieldName = "Tuesday";
            this.colTuesday.Name = "colTuesday";
            this.colTuesday.Visible = true;
            this.colTuesday.VisibleIndex = 2;
            // 
            // colWednesday
            // 
            this.colWednesday.ColumnEdit = this.repositoryItemComboBox1;
            this.colWednesday.FieldName = "Wednesday";
            this.colWednesday.Name = "colWednesday";
            this.colWednesday.Visible = true;
            this.colWednesday.VisibleIndex = 3;
            // 
            // colThursday
            // 
            this.colThursday.ColumnEdit = this.repositoryItemComboBox1;
            this.colThursday.FieldName = "Thursday";
            this.colThursday.Name = "colThursday";
            this.colThursday.Visible = true;
            this.colThursday.VisibleIndex = 4;
            // 
            // colFriday
            // 
            this.colFriday.ColumnEdit = this.repositoryItemComboBox1;
            this.colFriday.FieldName = "Friday";
            this.colFriday.Name = "colFriday";
            this.colFriday.Visible = true;
            this.colFriday.VisibleIndex = 5;
            // 
            // colSaturday
            // 
            this.colSaturday.ColumnEdit = this.repositoryItemComboBox1;
            this.colSaturday.FieldName = "Saturday";
            this.colSaturday.Name = "colSaturday";
            this.colSaturday.Visible = true;
            this.colSaturday.VisibleIndex = 6;
            // 
            // colSunday
            // 
            this.colSunday.ColumnEdit = this.repositoryItemComboBox1;
            this.colSunday.FieldName = "Sunday";
            this.colSunday.Name = "colSunday";
            this.colSunday.Visible = true;
            this.colSunday.VisibleIndex = 7;
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Items.AddRange(new object[] {
            "Insperctor",
            "Dealer/Inspector",
            "Dealer",
            "Trainiee Dealer"});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnSave,
            this.btnExport,
            this.btnYeniRota});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.TabletOffice;
            this.ribbonControl1.Size = new System.Drawing.Size(917, 77);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Kaydet";
            this.btnSave.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSave.Glyph")));
            this.btnSave.Id = 1;
            this.btnSave.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSave.LargeGlyph")));
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnExport
            // 
            this.btnExport.Caption = "Export";
            this.btnExport.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExport.Glyph")));
            this.btnExport.Id = 2;
            this.btnExport.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExport.LargeGlyph")));
            this.btnExport.Name = "btnExport";
            this.btnExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExport_ItemClick);
            // 
            // btnYeniRota
            // 
            this.btnYeniRota.Caption = "Yeni Rota";
            this.btnYeniRota.Glyph = ((System.Drawing.Image)(resources.GetObject("btnYeniRota.Glyph")));
            this.btnYeniRota.Id = 3;
            this.btnYeniRota.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnYeniRota.LargeGlyph")));
            this.btnYeniRota.Name = "btnYeniRota";
            this.btnYeniRota.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnYeniRota_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Mevcut Rota";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSave);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnExport);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnYeniRota);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // livegameDataSet11
            // 
            this.livegameDataSet11.DataSetName = "livegameDataSet1";
            this.livegameDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // resourcesTableAdapter1
            // 
            this.resourcesTableAdapter1.ClearBeforeFill = true;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "resources";
            this.bindingSource1.DataSource = this.livegameDataSet11;
            // 
            // frmRota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 538);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRota";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Rota";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRota_FormClosed);
            this.Load += new System.EventHandler(this.frmRota_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colpersonel;
        private DevExpress.XtraGrid.Columns.GridColumn colMonday;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn colTuesday;
        private DevExpress.XtraGrid.Columns.GridColumn colWednesday;
        private DevExpress.XtraGrid.Columns.GridColumn colThursday;
        private DevExpress.XtraGrid.Columns.GridColumn colFriday;
        private DevExpress.XtraGrid.Columns.GridColumn colSaturday;
        private DevExpress.XtraGrid.Columns.GridColumn colSunday;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn colGorev;
        private DevExpress.XtraBars.BarButtonItem btnExport;
        private DevExpress.XtraBars.BarButtonItem btnYeniRota;
        private livegameDataSet1 livegameDataSet11;
        private livegameDataSet1TableAdapters.resourcesTableAdapter resourcesTableAdapter1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}