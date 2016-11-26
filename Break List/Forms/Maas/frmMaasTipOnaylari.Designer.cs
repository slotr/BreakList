namespace Break_List.Forms.Maas
{
    partial class frmMaasTipOnaylari
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
            this.spMaasTipOnayiGridControl = new DevExpress.XtraGrid.GridControl();
            this.spMaasTipOnayiBindingSource = new System.Windows.Forms.BindingSource();
            this.livegameDataSet1 = new Break_List.livegameDataSet1();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colResourceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colresourceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmaas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnaylayan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArtisNedeni = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKategori = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTip = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spMaasTipOnayiTableAdapter = new Break_List.livegameDataSet1TableAdapters.spMaasTipOnayiTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.spMaasTipOnayiGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMaasTipOnayiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // spMaasTipOnayiGridControl
            // 
            this.spMaasTipOnayiGridControl.DataSource = this.spMaasTipOnayiBindingSource;
            this.spMaasTipOnayiGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spMaasTipOnayiGridControl.Location = new System.Drawing.Point(0, 0);
            this.spMaasTipOnayiGridControl.MainView = this.gridView1;
            this.spMaasTipOnayiGridControl.Name = "spMaasTipOnayiGridControl";
            this.spMaasTipOnayiGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemButtonEdit2});
            this.spMaasTipOnayiGridControl.Size = new System.Drawing.Size(980, 499);
            this.spMaasTipOnayiGridControl.TabIndex = 1;
            this.spMaasTipOnayiGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // spMaasTipOnayiBindingSource
            // 
            this.spMaasTipOnayiBindingSource.DataMember = "spMaasTipOnayi";
            this.spMaasTipOnayiBindingSource.DataSource = this.livegameDataSet1;
            // 
            // livegameDataSet1
            // 
            this.livegameDataSet1.DataSetName = "livegameDataSet1";
            this.livegameDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colResourceName,
            this.colresourceID,
            this.coltarih,
            this.colmaas,
            this.colOnaylayan,
            this.colArtisNedeni,
            this.colKategori,
            this.colTip,
            this.gridColumn1,
            this.gridColumn2,
            this.id});
            this.gridView1.GridControl = this.spMaasTipOnayiGridControl;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colKategori, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // colResourceName
            // 
            this.colResourceName.Caption = "Personel";
            this.colResourceName.FieldName = "ResourceName";
            this.colResourceName.Name = "colResourceName";
            this.colResourceName.Visible = true;
            this.colResourceName.VisibleIndex = 0;
            // 
            // colresourceID
            // 
            this.colresourceID.FieldName = "resourceID";
            this.colresourceID.Name = "colresourceID";
            // 
            // coltarih
            // 
            this.coltarih.Caption = "Tarih";
            this.coltarih.FieldName = "tarih";
            this.coltarih.Name = "coltarih";
            this.coltarih.Visible = true;
            this.coltarih.VisibleIndex = 1;
            // 
            // colmaas
            // 
            this.colmaas.Caption = "Maas";
            this.colmaas.FieldName = "maas";
            this.colmaas.Name = "colmaas";
            this.colmaas.Visible = true;
            this.colmaas.VisibleIndex = 2;
            // 
            // colOnaylayan
            // 
            this.colOnaylayan.Caption = "Onay Isteyen";
            this.colOnaylayan.FieldName = "Onaylayan";
            this.colOnaylayan.Name = "colOnaylayan";
            this.colOnaylayan.Visible = true;
            this.colOnaylayan.VisibleIndex = 3;
            // 
            // colArtisNedeni
            // 
            this.colArtisNedeni.FieldName = "ArtisNedeni";
            this.colArtisNedeni.Name = "colArtisNedeni";
            this.colArtisNedeni.Visible = true;
            this.colArtisNedeni.VisibleIndex = 4;
            // 
            // colKategori
            // 
            this.colKategori.FieldName = "Kategori";
            this.colKategori.Name = "colKategori";
            this.colKategori.Visible = true;
            this.colKategori.VisibleIndex = 5;
            // 
            // colTip
            // 
            this.colTip.FieldName = "Tip";
            this.colTip.Name = "colTip";
            this.colTip.Visible = true;
            this.colTip.VisibleIndex = 5;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Onayla";
            this.gridColumn1.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.OK)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Reddet";
            this.gridColumn2.ColumnEdit = this.repositoryItemButtonEdit2;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.repositoryItemButtonEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit2_ButtonClick);
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.Name = "id";
            // 
            // spMaasTipOnayiTableAdapter
            // 
            this.spMaasTipOnayiTableAdapter.ClearBeforeFill = true;
            // 
            // frmMaasTipOnaylari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 499);
            this.Controls.Add(this.spMaasTipOnayiGridControl);
            this.Name = "frmMaasTipOnaylari";
            this.Text = "Onay Bekleyenler";
            this.Load += new System.EventHandler(this.frmMaasTipOnaylari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spMaasTipOnayiGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMaasTipOnayiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl spMaasTipOnayiGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private livegameDataSet1 livegameDataSet1;
        private System.Windows.Forms.BindingSource spMaasTipOnayiBindingSource;
        private livegameDataSet1TableAdapters.spMaasTipOnayiTableAdapter spMaasTipOnayiTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colresourceID;
        private DevExpress.XtraGrid.Columns.GridColumn coltarih;
        private DevExpress.XtraGrid.Columns.GridColumn colmaas;
        private DevExpress.XtraGrid.Columns.GridColumn colOnaylayan;
        private DevExpress.XtraGrid.Columns.GridColumn colArtisNedeni;
        private DevExpress.XtraGrid.Columns.GridColumn colKategori;
        private DevExpress.XtraGrid.Columns.GridColumn colTip;
        private DevExpress.XtraGrid.Columns.GridColumn colResourceName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn id;
    }
}