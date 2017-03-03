namespace Break_List.Forms.Personel
{
    partial class FrmPersonelVacations
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
            this.livegameDataSet1 = new Break_List.livegameDataSet1();
            this.sp_Butun_Personel_vacationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_Butun_Personel_vacationTableAdapter = new Break_List.livegameDataSet1TableAdapters.sp_Butun_Personel_vacationTableAdapter();
            this.tableAdapterManager = new Break_List.livegameDataSet1TableAdapters.TableAdapterManager();
            this.sp_Butun_Personel_vacationGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartman = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGorev = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIzinHakki = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKullanilan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKalan = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_Butun_Personel_vacationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_Butun_Personel_vacationGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // livegameDataSet1
            // 
            this.livegameDataSet1.DataSetName = "livegameDataSet1";
            this.livegameDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_Butun_Personel_vacationBindingSource
            // 
            this.sp_Butun_Personel_vacationBindingSource.DataMember = "sp_Butun_Personel_vacation";
            this.sp_Butun_Personel_vacationBindingSource.DataSource = this.livegameDataSet1;
            // 
            // sp_Butun_Personel_vacationTableAdapter
            // 
            this.sp_Butun_Personel_vacationTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.appointmentsTableAdapter = null;
            this.tableAdapterManager.apps_countriesTableAdapter = null;
            this.tableAdapterManager.auditTableAdapter = null;
            this.tableAdapterManager.avanslarTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.barbolgeTableAdapter = null;
            this.tableAdapterManager.bitenshiftlerTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.departmentsTableAdapter = null;
            this.tableAdapterManager.documentsTableAdapter = null;
            this.tableAdapterManager.kesintilerTableAdapter = null;
            this.tableAdapterManager.lghataTableAdapter = null;
            this.tableAdapterManager.loginlogTableAdapter = null;
            this.tableAdapterManager.maaslarTableAdapter = null;
            this.tableAdapterManager.maastipredTableAdapter = null;
            this.tableAdapterManager.offalacaklariTableAdapter = null;
            this.tableAdapterManager.permissionsTableAdapter = null;
            this.tableAdapterManager.positionsTableAdapter = null;
            this.tableAdapterManager.prosedurTableAdapter = null;
            this.tableAdapterManager.resimTableAdapter = null;
            this.tableAdapterManager.resourcesTableAdapter = null;
            this.tableAdapterManager.rolesTableAdapter = null;
            this.tableAdapterManager.rosterTableAdapter = null;
            this.tableAdapterManager.shiftsTableAdapter = null;
            this.tableAdapterManager.tablesTableAdapter = null;
            this.tableAdapterManager.tblcalismaizinleriTableAdapter = null;
            this.tableAdapterManager.tblcountTableAdapter = null;
            this.tableAdapterManager.tblegitimlerTableAdapter = null;
            this.tableAdapterManager.tblenvanter_kategoriTableAdapter = null;
            this.tableAdapterManager.tblenvanterTableAdapter = null;
            this.tableAdapterManager.tblgorevlilerTableAdapter = null;
            this.tableAdapterManager.tblpreviouscountTableAdapter = null;
            this.tableAdapterManager.tblratesTableAdapter = null;
            this.tableAdapterManager.tblrfiddataTableAdapter = null;
            this.tableAdapterManager.tblslotresultsTableAdapter = null;
            this.tableAdapterManager.tbltekniktakipTableAdapter = null;
            this.tableAdapterManager.tblturnuvaTableAdapter = null;
            this.tableAdapterManager.tiplerTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Break_List.livegameDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.usersTableAdapter = null;
            this.tableAdapterManager.vacationsTableAdapter = null;
            // 
            // sp_Butun_Personel_vacationGridControl
            // 
            this.sp_Butun_Personel_vacationGridControl.DataSource = this.sp_Butun_Personel_vacationBindingSource;
            this.sp_Butun_Personel_vacationGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sp_Butun_Personel_vacationGridControl.Location = new System.Drawing.Point(0, 0);
            this.sp_Butun_Personel_vacationGridControl.MainView = this.gridView1;
            this.sp_Butun_Personel_vacationGridControl.Name = "sp_Butun_Personel_vacationGridControl";
            this.sp_Butun_Personel_vacationGridControl.Size = new System.Drawing.Size(964, 527);
            this.sp_Butun_Personel_vacationGridControl.TabIndex = 1;
            this.sp_Butun_Personel_vacationGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colPersonel,
            this.colDepartman,
            this.colGorev,
            this.colIzinHakki,
            this.colKullanilan,
            this.colKalan});
            this.gridView1.GridControl = this.sp_Butun_Personel_vacationGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted;
            this.gridView1.OptionsClipboard.CopyCollapsedData = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDepartman, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colKalan, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colPersonel
            // 
            this.colPersonel.FieldName = "Personel";
            this.colPersonel.Name = "colPersonel";
            this.colPersonel.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colPersonel.Visible = true;
            this.colPersonel.VisibleIndex = 1;
            // 
            // colDepartman
            // 
            this.colDepartman.FieldName = "Departman";
            this.colDepartman.Name = "colDepartman";
            this.colDepartman.Visible = true;
            this.colDepartman.VisibleIndex = 0;
            // 
            // colGorev
            // 
            this.colGorev.FieldName = "Gorev";
            this.colGorev.Name = "colGorev";
            this.colGorev.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colGorev.Visible = true;
            this.colGorev.VisibleIndex = 2;
            // 
            // colIzinHakki
            // 
            this.colIzinHakki.FieldName = "Izin Hakki";
            this.colIzinHakki.Name = "colIzinHakki";
            this.colIzinHakki.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colIzinHakki.Visible = true;
            this.colIzinHakki.VisibleIndex = 3;
            // 
            // colKullanilan
            // 
            this.colKullanilan.FieldName = "Kullanilan";
            this.colKullanilan.Name = "colKullanilan";
            this.colKullanilan.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colKullanilan.Visible = true;
            this.colKullanilan.VisibleIndex = 4;
            // 
            // colKalan
            // 
            this.colKalan.Caption = "Kalan";
            this.colKalan.FieldName = "colKalan";
            this.colKalan.Name = "colKalan";
            this.colKalan.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colKalan.UnboundExpression = "[Izin Hakki] - [Kullanilan]";
            this.colKalan.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colKalan.Visible = true;
            this.colKalan.VisibleIndex = 5;
            // 
            // FrmPersonelVacations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 527);
            this.Controls.Add(this.sp_Butun_Personel_vacationGridControl);
            this.Name = "FrmPersonelVacations";
            this.Text = "Izinler";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPersonelVacations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_Butun_Personel_vacationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_Butun_Personel_vacationGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private livegameDataSet1 livegameDataSet1;
        private System.Windows.Forms.BindingSource sp_Butun_Personel_vacationBindingSource;
        private livegameDataSet1TableAdapters.sp_Butun_Personel_vacationTableAdapter sp_Butun_Personel_vacationTableAdapter;
        private livegameDataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl sp_Butun_Personel_vacationGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonel;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartman;
        private DevExpress.XtraGrid.Columns.GridColumn colGorev;
        private DevExpress.XtraGrid.Columns.GridColumn colIzinHakki;
        private DevExpress.XtraGrid.Columns.GridColumn colKullanilan;
        private DevExpress.XtraGrid.Columns.GridColumn colKalan;
    }
}