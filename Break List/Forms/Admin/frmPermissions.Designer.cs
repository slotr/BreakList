using System;

namespace Break_List.Forms
{
    partial class frmPermissions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPermissions));
            this.livegameDataSet1 = new Break_List.livegameDataSet1();
            this.permissionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.permissionsTableAdapter = new Break_List.livegameDataSet1TableAdapters.permissionsTableAdapter();
            this.tableAdapterManager = new Break_List.livegameDataSet1TableAdapters.TableAdapterManager();
            this.permissionsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.permissionsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.permissionsGridControl = new DevExpress.XtraGrid.GridControl();
            this.permissionGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colidpermissions = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsers = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserDepartments = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAppointments = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResources = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRoster = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPositions = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVacations = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRapor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaasArtisi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDokumanlar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUyarilar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYorumlar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEgitimler = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCalismaIznleri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpersonelEkle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKasa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEgitim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCount = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.permissionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.permissionsBindingNavigator)).BeginInit();
            this.permissionsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.permissionsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.permissionGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // livegameDataSet1
            // 
            this.livegameDataSet1.DataSetName = "livegameDataSet1";
            this.livegameDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // permissionsBindingSource
            // 
            this.permissionsBindingSource.DataMember = "permissions";
            this.permissionsBindingSource.DataSource = this.livegameDataSet1;
            // 
            // permissionsTableAdapter
            // 
            this.permissionsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.appointmentsTableAdapter = null;
            this.tableAdapterManager.apps_countriesTableAdapter = null;
            this.tableAdapterManager.avanslarTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.departmentsTableAdapter = null;
            this.tableAdapterManager.documentsTableAdapter = null;
            this.tableAdapterManager.kesintilerTableAdapter = null;
            this.tableAdapterManager.lghataTableAdapter = null;
            this.tableAdapterManager.maaslarTableAdapter = null;
            this.tableAdapterManager.offalacaklariTableAdapter = null;
            this.tableAdapterManager.permissionsTableAdapter = this.permissionsTableAdapter;
            this.tableAdapterManager.positionsTableAdapter = null;
            this.tableAdapterManager.resourcesTableAdapter = null;
            this.tableAdapterManager.rolesTableAdapter = null;
            this.tableAdapterManager.roster1TableAdapter = null;
            this.tableAdapterManager.shiftsTableAdapter = null;
            this.tableAdapterManager.tablesTableAdapter = null;
            this.tableAdapterManager.tblcalismaizinleriTableAdapter = null;
            this.tableAdapterManager.tiplerTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Break_List.livegameDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.usersTableAdapter = null;
            this.tableAdapterManager.vacationsTableAdapter = null;
            // 
            // permissionsBindingNavigator
            // 
            this.permissionsBindingNavigator.AddNewItem = null;
            this.permissionsBindingNavigator.BindingSource = this.permissionsBindingSource;
            this.permissionsBindingNavigator.CountItem = null;
            this.permissionsBindingNavigator.DeleteItem = null;
            this.permissionsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.permissionsBindingNavigatorSaveItem});
            this.permissionsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.permissionsBindingNavigator.MoveFirstItem = null;
            this.permissionsBindingNavigator.MoveLastItem = null;
            this.permissionsBindingNavigator.MoveNextItem = null;
            this.permissionsBindingNavigator.MovePreviousItem = null;
            this.permissionsBindingNavigator.Name = "permissionsBindingNavigator";
            this.permissionsBindingNavigator.PositionItem = null;
            this.permissionsBindingNavigator.Size = new System.Drawing.Size(1086, 25);
            this.permissionsBindingNavigator.TabIndex = 0;
            this.permissionsBindingNavigator.Text = "bindingNavigator1";
            // 
            // permissionsBindingNavigatorSaveItem
            // 
            this.permissionsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.permissionsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("permissionsBindingNavigatorSaveItem.Image")));
            this.permissionsBindingNavigatorSaveItem.Name = "permissionsBindingNavigatorSaveItem";
            this.permissionsBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.permissionsBindingNavigatorSaveItem.Text = "Save Data";
            this.permissionsBindingNavigatorSaveItem.Click += new System.EventHandler(this.permissionsBindingNavigatorSaveItem_Click_1);
            // 
            // permissionsGridControl
            // 
            this.permissionsGridControl.DataSource = this.permissionsBindingSource;
            this.permissionsGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.permissionsGridControl.Location = new System.Drawing.Point(0, 25);
            this.permissionsGridControl.MainView = this.permissionGrid;
            this.permissionsGridControl.Name = "permissionsGridControl";
            this.permissionsGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.permissionsGridControl.Size = new System.Drawing.Size(1086, 508);
            this.permissionsGridControl.TabIndex = 1;
            this.permissionsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.permissionGrid});
            // 
            // permissionGrid
            // 
            this.permissionGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colidpermissions,
            this.colUsers,
            this.gridColumn1,
            this.colUserDepartments,
            this.colAppointments,
            this.colResources,
            this.colRoster,
            this.colPositions,
            this.colUserID,
            this.colVacations,
            this.colUserName,
            this.colRapor,
            this.colMaasArtisi,
            this.gridColumn2,
            this.colDokumanlar,
            this.colUyarilar,
            this.colYorumlar,
            this.colEgitimler,
            this.colCalismaIznleri,
            this.colpersonelEkle,
            this.colDepartment,
            this.colKasa,
            this.colOnay,
            this.colEgitim,
            this.colCount});
            this.permissionGrid.GridControl = this.permissionsGridControl;
            this.permissionGrid.GroupCount = 1;
            this.permissionGrid.Name = "permissionGrid";
            this.permissionGrid.OptionsBehavior.AutoExpandAllGroups = true;
            this.permissionGrid.OptionsEditForm.EditFormColumnCount = 6;
            this.permissionGrid.OptionsView.ShowGroupPanel = false;
            this.permissionGrid.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDepartment, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colidpermissions
            // 
            this.colidpermissions.FieldName = "idpermissions";
            this.colidpermissions.Name = "colidpermissions";
            // 
            // colUsers
            // 
            this.colUsers.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colUsers.FieldName = "Users";
            this.colUsers.Name = "colUsers";
            this.colUsers.Visible = true;
            this.colUsers.VisibleIndex = 1;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.QueryCheckStateByValue += new DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventHandler(this.repositoryItemCheckEdit1_QueryCheckStateByValue);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "All Personel";
            this.gridColumn1.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn1.FieldName = "AllPersonel";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            // 
            // colUserDepartments
            // 
            this.colUserDepartments.Caption = "Departments";
            this.colUserDepartments.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colUserDepartments.FieldName = "UserDepartments";
            this.colUserDepartments.Name = "colUserDepartments";
            this.colUserDepartments.Visible = true;
            this.colUserDepartments.VisibleIndex = 3;
            // 
            // colAppointments
            // 
            this.colAppointments.Caption = "Break List";
            this.colAppointments.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colAppointments.FieldName = "Appointments";
            this.colAppointments.Name = "colAppointments";
            this.colAppointments.Visible = true;
            this.colAppointments.VisibleIndex = 4;
            // 
            // colResources
            // 
            this.colResources.Caption = "Personel";
            this.colResources.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colResources.FieldName = "Resources";
            this.colResources.Name = "colResources";
            this.colResources.Visible = true;
            this.colResources.VisibleIndex = 5;
            // 
            // colRoster
            // 
            this.colRoster.Caption = "Rota";
            this.colRoster.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colRoster.FieldName = "Roster";
            this.colRoster.Name = "colRoster";
            this.colRoster.Visible = true;
            this.colRoster.VisibleIndex = 6;
            // 
            // colPositions
            // 
            this.colPositions.Caption = "Pozisyonlar";
            this.colPositions.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colPositions.FieldName = "Positions";
            this.colPositions.Name = "colPositions";
            this.colPositions.Visible = true;
            this.colPositions.VisibleIndex = 7;
            // 
            // colUserID
            // 
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            // 
            // colVacations
            // 
            this.colVacations.Caption = "Izinler";
            this.colVacations.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colVacations.FieldName = "Vacations";
            this.colVacations.Name = "colVacations";
            this.colVacations.Visible = true;
            this.colVacations.VisibleIndex = 8;
            // 
            // colUserName
            // 
            this.colUserName.Caption = "Personel";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 0;
            // 
            // colRapor
            // 
            this.colRapor.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colRapor.FieldName = "Rapor";
            this.colRapor.Name = "colRapor";
            this.colRapor.Visible = true;
            this.colRapor.VisibleIndex = 9;
            // 
            // colMaasArtisi
            // 
            this.colMaasArtisi.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colMaasArtisi.FieldName = "MaasArtisi";
            this.colMaasArtisi.Name = "colMaasArtisi";
            this.colMaasArtisi.Visible = true;
            this.colMaasArtisi.VisibleIndex = 10;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Maas Edit";
            this.gridColumn2.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn2.FieldName = "maasedit";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 11;
            // 
            // colDokumanlar
            // 
            this.colDokumanlar.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colDokumanlar.FieldName = "Dokumanlar";
            this.colDokumanlar.Name = "colDokumanlar";
            this.colDokumanlar.Visible = true;
            this.colDokumanlar.VisibleIndex = 12;
            // 
            // colUyarilar
            // 
            this.colUyarilar.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colUyarilar.FieldName = "Uyarilar";
            this.colUyarilar.Name = "colUyarilar";
            this.colUyarilar.Visible = true;
            this.colUyarilar.VisibleIndex = 13;
            // 
            // colYorumlar
            // 
            this.colYorumlar.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colYorumlar.FieldName = "Yorumlar";
            this.colYorumlar.Name = "colYorumlar";
            this.colYorumlar.Visible = true;
            this.colYorumlar.VisibleIndex = 14;
            // 
            // colEgitimler
            // 
            this.colEgitimler.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colEgitimler.FieldName = "Egitimler";
            this.colEgitimler.Name = "colEgitimler";
            // 
            // colCalismaIznleri
            // 
            this.colCalismaIznleri.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colCalismaIznleri.FieldName = "CalismaIznleri";
            this.colCalismaIznleri.Name = "colCalismaIznleri";
            this.colCalismaIznleri.Visible = true;
            this.colCalismaIznleri.VisibleIndex = 15;
            // 
            // colpersonelEkle
            // 
            this.colpersonelEkle.Caption = "Peronel Edit";
            this.colpersonelEkle.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colpersonelEkle.FieldName = "personelEkle";
            this.colpersonelEkle.Name = "colpersonelEkle";
            this.colpersonelEkle.Visible = true;
            this.colpersonelEkle.VisibleIndex = 16;
            // 
            // colDepartment
            // 
            this.colDepartment.FieldName = "Department";
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.Visible = true;
            this.colDepartment.VisibleIndex = 18;
            // 
            // colKasa
            // 
            this.colKasa.Caption = "Kasa";
            this.colKasa.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colKasa.FieldName = "kasa";
            this.colKasa.Name = "colKasa";
            this.colKasa.Visible = true;
            this.colKasa.VisibleIndex = 17;
            // 
            // colOnay
            // 
            this.colOnay.Caption = "Onay GM";
            this.colOnay.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colOnay.FieldName = "onay";
            this.colOnay.Name = "colOnay";
            this.colOnay.Visible = true;
            this.colOnay.VisibleIndex = 18;
            // 
            // colEgitim
            // 
            this.colEgitim.Caption = "Egitim";
            this.colEgitim.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colEgitim.FieldName = "egitim";
            this.colEgitim.Name = "colEgitim";
            this.colEgitim.Visible = true;
            this.colEgitim.VisibleIndex = 19;
            // 
            // colCount
            // 
            this.colCount.Caption = "Count";
            this.colCount.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colCount.FieldName = "count";
            this.colCount.Name = "colCount";
            this.colCount.Visible = true;
            this.colCount.VisibleIndex = 20;
            // 
            // frmPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 533);
            this.Controls.Add(this.permissionsGridControl);
            this.Controls.Add(this.permissionsBindingNavigator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPermissions";
            this.Text = "Kullanici Haklari";
            this.Load += new System.EventHandler(this.frmPermissions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.permissionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.permissionsBindingNavigator)).EndInit();
            this.permissionsBindingNavigator.ResumeLayout(false);
            this.permissionsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.permissionsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.permissionGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private livegameDataSet1 livegameDataSet1;
        private System.Windows.Forms.BindingSource permissionsBindingSource;
        private livegameDataSet1TableAdapters.permissionsTableAdapter permissionsTableAdapter;
        private livegameDataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator permissionsBindingNavigator;
        private System.Windows.Forms.ToolStripButton permissionsBindingNavigatorSaveItem;
        private DevExpress.XtraGrid.GridControl permissionsGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView permissionGrid;
        private DevExpress.XtraGrid.Columns.GridColumn colidpermissions;
        private DevExpress.XtraGrid.Columns.GridColumn colUsers;
        private DevExpress.XtraGrid.Columns.GridColumn colUserDepartments;
        private DevExpress.XtraGrid.Columns.GridColumn colAppointments;
        private DevExpress.XtraGrid.Columns.GridColumn colResources;
        private DevExpress.XtraGrid.Columns.GridColumn colRoster;
        private DevExpress.XtraGrid.Columns.GridColumn colPositions;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colVacations;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colRapor;
        private DevExpress.XtraGrid.Columns.GridColumn colMaasArtisi;
        private DevExpress.XtraGrid.Columns.GridColumn colDokumanlar;
        private DevExpress.XtraGrid.Columns.GridColumn colUyarilar;
        private DevExpress.XtraGrid.Columns.GridColumn colYorumlar;
        private DevExpress.XtraGrid.Columns.GridColumn colEgitimler;
        private DevExpress.XtraGrid.Columns.GridColumn colCalismaIznleri;
        private DevExpress.XtraGrid.Columns.GridColumn colpersonelEkle;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartment;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colKasa;
        private DevExpress.XtraGrid.Columns.GridColumn colOnay;
        private DevExpress.XtraGrid.Columns.GridColumn colEgitim;
        private DevExpress.XtraGrid.Columns.GridColumn colCount;
    }
}