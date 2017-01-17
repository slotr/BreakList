namespace Break_List.Forms.BreakList
{
    partial class FrmMasalar
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
            this.tablesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tablesTableAdapter = new Break_List.livegameDataSet1TableAdapters.tablesTableAdapter();
            this.tableAdapterManager = new Break_List.livegameDataSet1TableAdapters.TableAdapterManager();
            this.tablesGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOpen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGame = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablesGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // livegameDataSet1
            // 
            this.livegameDataSet1.DataSetName = "livegameDataSet1";
            this.livegameDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tablesBindingSource
            // 
            this.tablesBindingSource.DataMember = "tables";
            this.tablesBindingSource.DataSource = this.livegameDataSet1;
            // 
            // tablesTableAdapter
            // 
            this.tablesTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.tablesTableAdapter = this.tablesTableAdapter;
            this.tableAdapterManager.tblcalismaizinleriTableAdapter = null;
            this.tableAdapterManager.tblcountTableAdapter = null;
            this.tableAdapterManager.tblegitimlerTableAdapter = null;
            this.tableAdapterManager.tblenvanter_kategoriTableAdapter = null;
            this.tableAdapterManager.tblenvanterTableAdapter = null;
            this.tableAdapterManager.tblpreviouscountTableAdapter = null;
            this.tableAdapterManager.tblrfiddataTableAdapter = null;
            this.tableAdapterManager.tblturnuvaTableAdapter = null;
            this.tableAdapterManager.tiplerTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Break_List.livegameDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.usersTableAdapter = null;
            this.tableAdapterManager.vacationsTableAdapter = null;
            // 
            // tablesGridControl
            // 
            this.tablesGridControl.DataSource = this.tablesBindingSource;
            this.tablesGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablesGridControl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tablesGridControl.Location = new System.Drawing.Point(2, 2);
            this.tablesGridControl.MainView = this.gridView1;
            this.tablesGridControl.Name = "tablesGridControl";
            this.tablesGridControl.Size = new System.Drawing.Size(331, 564);
            this.tablesGridControl.TabIndex = 1;
            this.tablesGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOpen,
            this.colGame,
            this.colNo});
            this.gridView1.GridControl = this.tablesGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Yeni Masa Ekle";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            // 
            // colOpen
            // 
            this.colOpen.Caption = "Aç/Kapa";
            this.colOpen.FieldName = "Open";
            this.colOpen.Name = "colOpen";
            this.colOpen.Visible = true;
            this.colOpen.VisibleIndex = 0;
            // 
            // colGame
            // 
            this.colGame.Caption = "Oyun";
            this.colGame.FieldName = "Game";
            this.colGame.Name = "colGame";
            this.colGame.OptionsColumn.AllowEdit = false;
            this.colGame.OptionsColumn.ReadOnly = true;
            this.colGame.Visible = true;
            this.colGame.VisibleIndex = 1;
            // 
            // colNo
            // 
            this.colNo.Caption = "No";
            this.colNo.FieldName = "No";
            this.colNo.Name = "colNo";
            this.colNo.OptionsColumn.AllowEdit = false;
            this.colNo.OptionsColumn.ReadOnly = true;
            this.colNo.Visible = true;
            this.colNo.VisibleIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(335, 32);
            this.panelControl1.TabIndex = 2;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Image = global::Break_List.Properties.Resources.cards;
            this.simpleButton2.Location = new System.Drawing.Point(13, 3);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(129, 23);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "Yeni Masa Ekle";
            this.simpleButton2.Visible = false;
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButton1.Location = new System.Drawing.Point(248, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.tablesGridControl);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 32);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(335, 568);
            this.panelControl2.TabIndex = 3;
            // 
            // frmMasalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 600);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMasalar";
            this.Text = "Masalar";
            this.Load += new System.EventHandler(this.frmMasalar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablesGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private livegameDataSet1 livegameDataSet1;
        private System.Windows.Forms.BindingSource tablesBindingSource;
        private livegameDataSet1TableAdapters.tablesTableAdapter tablesTableAdapter;
        private livegameDataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl tablesGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colOpen;
        private DevExpress.XtraGrid.Columns.GridColumn colGame;
        private DevExpress.XtraGrid.Columns.GridColumn colNo;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}