namespace Break_List
{
    partial class frmPersonel
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.resourcesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.liveGameDataSet = new Break_List.LiveGameDataSet();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colResourceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResourceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomField1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.resourcesTableAdapter = new Break_List.LiveGameDataSetTableAdapters.ResourcesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.liveGameDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.resourcesBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(435, 599);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // resourcesBindingSource
            // 
            this.resourcesBindingSource.DataMember = "Resources";
            this.resourcesBindingSource.DataSource = this.liveGameDataSet;
            // 
            // liveGameDataSet
            // 
            this.liveGameDataSet.DataSetName = "LiveGameDataSet";
            this.liveGameDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colResourceID,
            this.colResourceName,
            this.colCustomField1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colResourceID
            // 
            this.colResourceID.Caption = "ID";
            this.colResourceID.FieldName = "ResourceID";
            this.colResourceID.Name = "colResourceID";
            this.colResourceID.Visible = true;
            this.colResourceID.VisibleIndex = 0;
            this.colResourceID.Width = 45;
            // 
            // colResourceName
            // 
            this.colResourceName.Caption = "Personel Adi&Soyadi";
            this.colResourceName.FieldName = "ResourceName";
            this.colResourceName.Name = "colResourceName";
            this.colResourceName.Visible = true;
            this.colResourceName.VisibleIndex = 1;
            this.colResourceName.Width = 217;
            // 
            // colCustomField1
            // 
            this.colCustomField1.Caption = "Pozisyon";
            this.colCustomField1.FieldName = "CustomField1";
            this.colCustomField1.Name = "colCustomField1";
            this.colCustomField1.Visible = true;
            this.colCustomField1.VisibleIndex = 2;
            this.colCustomField1.Width = 155;
            // 
            // resourcesTableAdapter
            // 
            this.resourcesTableAdapter.ClearBeforeFill = true;
            // 
            // frmPersonel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 599);
            this.Controls.Add(this.gridControl1);
            this.Name = "frmPersonel";
            this.Text = "Personel";
            this.Load += new System.EventHandler(this.frmPersonel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.liveGameDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private LiveGameDataSet liveGameDataSet;
        private System.Windows.Forms.BindingSource resourcesBindingSource;
        private LiveGameDataSetTableAdapters.ResourcesTableAdapter resourcesTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colResourceID;
        private DevExpress.XtraGrid.Columns.GridColumn colResourceName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomField1;
    }
}