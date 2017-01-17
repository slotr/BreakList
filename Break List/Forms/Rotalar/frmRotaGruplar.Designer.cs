namespace Break_List.Forms.Rotalar
{
    partial class FrmRotaGruplar
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colResourceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResourceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgrup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gridControl1.Size = new System.Drawing.Size(488, 779);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colResourceID,
            this.colResourceName,
            this.colPosition,
            this.colgrup,
            this.colDeg});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // colResourceID
            // 
            this.colResourceID.Caption = "ResourceID";
            this.colResourceID.FieldName = "ResourceID";
            this.colResourceID.Name = "colResourceID";
            // 
            // colResourceName
            // 
            this.colResourceName.Caption = "Personel";
            this.colResourceName.FieldName = "ResourceName";
            this.colResourceName.Name = "colResourceName";
            this.colResourceName.Visible = true;
            this.colResourceName.VisibleIndex = 1;
            this.colResourceName.Width = 282;
            // 
            // colPosition
            // 
            this.colPosition.Caption = "Görev";
            this.colPosition.FieldName = "Position";
            this.colPosition.Name = "colPosition";
            this.colPosition.Visible = true;
            this.colPosition.VisibleIndex = 2;
            this.colPosition.Width = 94;
            // 
            // colgrup
            // 
            this.colgrup.Caption = "Grup";
            this.colgrup.FieldName = "Grup";
            this.colgrup.Name = "colgrup";
            this.colgrup.Visible = true;
            this.colgrup.VisibleIndex = 3;
            this.colgrup.Width = 41;
            // 
            // colDeg
            // 
            this.colDeg.Caption = "Değiştir";
            this.colDeg.ColumnEdit = this.repositoryItemButtonEdit1;
            this.colDeg.Name = "colDeg";
            this.colDeg.Visible = true;
            this.colDeg.VisibleIndex = 0;
            this.colDeg.Width = 50;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // frmRotaGruplar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 779);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmRotaGruplar";
            this.Text = "Rota Gruplari";
            this.Load += new System.EventHandler(this.frmRotaGruplar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colResourceID;
        private DevExpress.XtraGrid.Columns.GridColumn colResourceName;
        private DevExpress.XtraGrid.Columns.GridColumn colPosition;
        private DevExpress.XtraGrid.Columns.GridColumn colgrup;
        private DevExpress.XtraGrid.Columns.GridColumn colDeg;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
    }
}