namespace Break_List.Forms.Prosedur
{
    partial class FrmProsedurler
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
            this.colGoruntule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKonu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYayin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmac = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridControl1.Size = new System.Drawing.Size(965, 721);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colGoruntule,
            this.colNo,
            this.colKonu,
            this.colYayin,
            this.colAmac});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colGoruntule
            // 
            this.colGoruntule.Caption = "Goruntule";
            this.colGoruntule.ColumnEdit = this.repositoryItemButtonEdit1;
            this.colGoruntule.Name = "colGoruntule";
            this.colGoruntule.Visible = true;
            this.colGoruntule.VisibleIndex = 0;
            this.colGoruntule.Width = 37;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // colNo
            // 
            this.colNo.Caption = "No";
            this.colNo.FieldName = "No";
            this.colNo.Name = "colNo";
            this.colNo.Visible = true;
            this.colNo.VisibleIndex = 1;
            this.colNo.Width = 57;
            // 
            // colKonu
            // 
            this.colKonu.Caption = "Konu";
            this.colKonu.FieldName = "Konu";
            this.colKonu.Name = "colKonu";
            this.colKonu.Visible = true;
            this.colKonu.VisibleIndex = 3;
            this.colKonu.Width = 422;
            // 
            // colYayin
            // 
            this.colYayin.Caption = "Yayın Tarihi";
            this.colYayin.FieldName = "Yayin Tarihi";
            this.colYayin.Name = "colYayin";
            this.colYayin.Visible = true;
            this.colYayin.VisibleIndex = 2;
            this.colYayin.Width = 113;
            // 
            // colAmac
            // 
            this.colAmac.Caption = "Amac";
            this.colAmac.FieldName = "Amac";
            this.colAmac.Name = "colAmac";
            this.colAmac.Visible = true;
            this.colAmac.VisibleIndex = 4;
            this.colAmac.Width = 315;
            // 
            // frmProsedurler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 721);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmProsedurler";
            this.Text = "Prosedurler";
            this.Load += new System.EventHandler(this.frmProsedurler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colGoruntule;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colNo;
        private DevExpress.XtraGrid.Columns.GridColumn colKonu;
        private DevExpress.XtraGrid.Columns.GridColumn colYayin;
        private DevExpress.XtraGrid.Columns.GridColumn colAmac;
    }
}