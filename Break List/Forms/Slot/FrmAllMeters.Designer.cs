namespace Break_List.Forms.Slot
{
    partial class FrmAllMeters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAllMeters));
            this.livegameDataSet1 = new Break_List.livegameDataSet1();
            this.tblslotresultsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblslotresultsTableAdapter = new Break_List.livegameDataSet1TableAdapters.tblslotresultsTableAdapter();
            this.tableAdapterManager = new Break_List.livegameDataSet1TableAdapters.TableAdapterManager();
            this.tblslotresultsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.tblslotresultsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.tblslotresultsGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colvendor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcabinet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsoftware = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldenom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbasicsum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbill = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colturnover = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltotalwin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colavgbet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldaysworked = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblslotresultsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblslotresultsBindingNavigator)).BeginInit();
            this.tblslotresultsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblslotresultsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // livegameDataSet1
            // 
            this.livegameDataSet1.DataSetName = "livegameDataSet1";
            this.livegameDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblslotresultsBindingSource
            // 
            this.tblslotresultsBindingSource.DataMember = "tblslotresults";
            this.tblslotresultsBindingSource.DataSource = this.livegameDataSet1;
            // 
            // tblslotresultsTableAdapter
            // 
            this.tblslotresultsTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.tblpreviouscountTableAdapter = null;
            this.tableAdapterManager.tblratesTableAdapter = null;
            this.tableAdapterManager.tblrfiddataTableAdapter = null;
            this.tableAdapterManager.tblslotresultsTableAdapter = this.tblslotresultsTableAdapter;
            this.tableAdapterManager.tbltekniktakipTableAdapter = null;
            this.tableAdapterManager.tblturnuvaTableAdapter = null;
            this.tableAdapterManager.tiplerTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Break_List.livegameDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.usersTableAdapter = null;
            this.tableAdapterManager.vacationsTableAdapter = null;
            // 
            // tblslotresultsBindingNavigator
            // 
            this.tblslotresultsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.tblslotresultsBindingNavigator.BindingSource = this.tblslotresultsBindingSource;
            this.tblslotresultsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tblslotresultsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.tblslotresultsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.tblslotresultsBindingNavigatorSaveItem});
            this.tblslotresultsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.tblslotresultsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tblslotresultsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tblslotresultsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tblslotresultsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tblslotresultsBindingNavigator.Name = "tblslotresultsBindingNavigator";
            this.tblslotresultsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tblslotresultsBindingNavigator.Size = new System.Drawing.Size(1139, 25);
            this.tblslotresultsBindingNavigator.TabIndex = 0;
            this.tblslotresultsBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 15);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // tblslotresultsBindingNavigatorSaveItem
            // 
            this.tblslotresultsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tblslotresultsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("tblslotresultsBindingNavigatorSaveItem.Image")));
            this.tblslotresultsBindingNavigatorSaveItem.Name = "tblslotresultsBindingNavigatorSaveItem";
            this.tblslotresultsBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 23);
            this.tblslotresultsBindingNavigatorSaveItem.Text = "Save Data";
            this.tblslotresultsBindingNavigatorSaveItem.Click += new System.EventHandler(this.tblslotresultsBindingNavigatorSaveItem_Click);
            // 
            // tblslotresultsGridControl
            // 
            this.tblslotresultsGridControl.DataSource = this.tblslotresultsBindingSource;
            this.tblslotresultsGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblslotresultsGridControl.Location = new System.Drawing.Point(0, 25);
            this.tblslotresultsGridControl.MainView = this.gridView1;
            this.tblslotresultsGridControl.Name = "tblslotresultsGridControl";
            this.tblslotresultsGridControl.Size = new System.Drawing.Size(1139, 590);
            this.tblslotresultsGridControl.TabIndex = 1;
            this.tblslotresultsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colno,
            this.colvendor,
            this.colcabinet,
            this.colsoftware,
            this.coldenom,
            this.colbasicsum,
            this.colbill,
            this.colturnover,
            this.coltotalwin,
            this.colgames,
            this.colavgbet,
            this.coldate,
            this.coldaysworked});
            this.gridView1.GridControl = this.tblslotresultsGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colno
            // 
            this.colno.FieldName = "no";
            this.colno.Name = "colno";
            this.colno.Visible = true;
            this.colno.VisibleIndex = 0;
            // 
            // colvendor
            // 
            this.colvendor.FieldName = "vendor";
            this.colvendor.Name = "colvendor";
            this.colvendor.Visible = true;
            this.colvendor.VisibleIndex = 1;
            // 
            // colcabinet
            // 
            this.colcabinet.FieldName = "cabinet";
            this.colcabinet.Name = "colcabinet";
            this.colcabinet.Visible = true;
            this.colcabinet.VisibleIndex = 2;
            // 
            // colsoftware
            // 
            this.colsoftware.FieldName = "software";
            this.colsoftware.Name = "colsoftware";
            this.colsoftware.Visible = true;
            this.colsoftware.VisibleIndex = 3;
            // 
            // coldenom
            // 
            this.coldenom.FieldName = "denom";
            this.coldenom.Name = "coldenom";
            this.coldenom.Visible = true;
            this.coldenom.VisibleIndex = 4;
            // 
            // colbasicsum
            // 
            this.colbasicsum.FieldName = "basicsum";
            this.colbasicsum.Name = "colbasicsum";
            this.colbasicsum.Visible = true;
            this.colbasicsum.VisibleIndex = 5;
            // 
            // colbill
            // 
            this.colbill.FieldName = "bill";
            this.colbill.Name = "colbill";
            this.colbill.Visible = true;
            this.colbill.VisibleIndex = 6;
            // 
            // colturnover
            // 
            this.colturnover.FieldName = "turnover";
            this.colturnover.Name = "colturnover";
            this.colturnover.Visible = true;
            this.colturnover.VisibleIndex = 7;
            // 
            // coltotalwin
            // 
            this.coltotalwin.FieldName = "totalwin";
            this.coltotalwin.Name = "coltotalwin";
            this.coltotalwin.Visible = true;
            this.coltotalwin.VisibleIndex = 8;
            // 
            // colgames
            // 
            this.colgames.FieldName = "games";
            this.colgames.Name = "colgames";
            this.colgames.Visible = true;
            this.colgames.VisibleIndex = 9;
            // 
            // colavgbet
            // 
            this.colavgbet.FieldName = "avgbet";
            this.colavgbet.Name = "colavgbet";
            this.colavgbet.Visible = true;
            this.colavgbet.VisibleIndex = 10;
            // 
            // coldate
            // 
            this.coldate.FieldName = "date";
            this.coldate.Name = "coldate";
            this.coldate.Visible = true;
            this.coldate.VisibleIndex = 11;
            // 
            // coldaysworked
            // 
            this.coldaysworked.FieldName = "daysworked";
            this.coldaysworked.Name = "coldaysworked";
            this.coldaysworked.Visible = true;
            this.coldaysworked.VisibleIndex = 12;
            // 
            // FrmAllMeters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 615);
            this.Controls.Add(this.tblslotresultsGridControl);
            this.Controls.Add(this.tblslotresultsBindingNavigator);
            this.Name = "FrmAllMeters";
            this.Text = "FrmAllMeters";
            this.Load += new System.EventHandler(this.FrmAllMeters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblslotresultsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblslotresultsBindingNavigator)).EndInit();
            this.tblslotresultsBindingNavigator.ResumeLayout(false);
            this.tblslotresultsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblslotresultsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private livegameDataSet1 livegameDataSet1;
        private System.Windows.Forms.BindingSource tblslotresultsBindingSource;
        private livegameDataSet1TableAdapters.tblslotresultsTableAdapter tblslotresultsTableAdapter;
        private livegameDataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator tblslotresultsBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton tblslotresultsBindingNavigatorSaveItem;
        private DevExpress.XtraGrid.GridControl tblslotresultsGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colno;
        private DevExpress.XtraGrid.Columns.GridColumn colvendor;
        private DevExpress.XtraGrid.Columns.GridColumn colcabinet;
        private DevExpress.XtraGrid.Columns.GridColumn colsoftware;
        private DevExpress.XtraGrid.Columns.GridColumn coldenom;
        private DevExpress.XtraGrid.Columns.GridColumn colbasicsum;
        private DevExpress.XtraGrid.Columns.GridColumn colbill;
        private DevExpress.XtraGrid.Columns.GridColumn colturnover;
        private DevExpress.XtraGrid.Columns.GridColumn coltotalwin;
        private DevExpress.XtraGrid.Columns.GridColumn colgames;
        private DevExpress.XtraGrid.Columns.GridColumn colavgbet;
        private DevExpress.XtraGrid.Columns.GridColumn coldate;
        private DevExpress.XtraGrid.Columns.GridColumn coldaysworked;
    }
}