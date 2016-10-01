namespace Break_List
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
            this.userPermissionsGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserTable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colDepartmentsTable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBreakList = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonnelTable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRoster = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPositions = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVacations = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.userPermissionsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // userPermissionsGridControl
            // 
            this.userPermissionsGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userPermissionsGridControl.Location = new System.Drawing.Point(0, 0);
            this.userPermissionsGridControl.MainView = this.gridView1;
            this.userPermissionsGridControl.Name = "userPermissionsGridControl";
            this.userPermissionsGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.userPermissionsGridControl.Size = new System.Drawing.Size(1087, 570);
            this.userPermissionsGridControl.TabIndex = 2;
            this.userPermissionsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserTable,
            this.colDepartmentsTable,
            this.colBreakList,
            this.colPersonnelTable,
            this.colRoster,
            this.colPositions,
            this.colVacations,
            this.colUserId,
            this.colUserName});
            this.gridView1.GridControl = this.userPermissionsGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // colUserTable
            // 
            this.colUserTable.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colUserTable.FieldName = "User Table";
            this.colUserTable.Name = "colUserTable";
            this.colUserTable.Visible = true;
            this.colUserTable.VisibleIndex = 1;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colDepartmentsTable
            // 
            this.colDepartmentsTable.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colDepartmentsTable.FieldName = "Departments Table";
            this.colDepartmentsTable.Name = "colDepartmentsTable";
            this.colDepartmentsTable.Visible = true;
            this.colDepartmentsTable.VisibleIndex = 2;
            // 
            // colBreakList
            // 
            this.colBreakList.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colBreakList.FieldName = "Break List";
            this.colBreakList.Name = "colBreakList";
            this.colBreakList.Visible = true;
            this.colBreakList.VisibleIndex = 3;
            // 
            // colPersonnelTable
            // 
            this.colPersonnelTable.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colPersonnelTable.FieldName = "Personnel Table";
            this.colPersonnelTable.Name = "colPersonnelTable";
            this.colPersonnelTable.Visible = true;
            this.colPersonnelTable.VisibleIndex = 4;
            // 
            // colRoster
            // 
            this.colRoster.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colRoster.FieldName = "Roster";
            this.colRoster.Name = "colRoster";
            this.colRoster.Visible = true;
            this.colRoster.VisibleIndex = 5;
            // 
            // colPositions
            // 
            this.colPositions.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colPositions.FieldName = "Positions";
            this.colPositions.Name = "colPositions";
            this.colPositions.Visible = true;
            this.colPositions.VisibleIndex = 6;
            // 
            // colVacations
            // 
            this.colVacations.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colVacations.FieldName = "Vacations";
            this.colVacations.Name = "colVacations";
            this.colVacations.Visible = true;
            this.colVacations.VisibleIndex = 7;
            // 
            // colUserId
            // 
            this.colUserId.FieldName = "User Id";
            this.colUserId.Name = "colUserId";
            // 
            // colUserName
            // 
            this.colUserName.FieldName = "User Name";
            this.colUserName.Name = "colUserName";
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 0;
            // 
            // frmPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 570);
            this.Controls.Add(this.userPermissionsGridControl);
            this.Name = "frmPermissions";
            this.Text = "frmPermissions";
            this.Load += new System.EventHandler(this.frmPermissions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userPermissionsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl userPermissionsGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colUserTable;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentsTable;
        private DevExpress.XtraGrid.Columns.GridColumn colBreakList;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonnelTable;
        private DevExpress.XtraGrid.Columns.GridColumn colRoster;
        private DevExpress.XtraGrid.Columns.GridColumn colPositions;
        private DevExpress.XtraGrid.Columns.GridColumn colVacations;
        private DevExpress.XtraGrid.Columns.GridColumn colUserId;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}