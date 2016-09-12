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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.liveGameDataSet = new Break_List.LiveGameDataSet();
            this.resourcesBindingSource = new System.Windows.Forms.BindingSource();
            this.resourcesTableAdapter = new Break_List.LiveGameDataSetTableAdapters.ResourcesTableAdapter();
            this.colUniqueID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResourceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResourceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomField1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.liveGameDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.resourcesBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(760, 599);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUniqueID,
            this.colResourceID,
            this.colResourceName,
            this.colColor,
            this.colImage,
            this.colCustomField1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // liveGameDataSet
            // 
            this.liveGameDataSet.DataSetName = "LiveGameDataSet";
            this.liveGameDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // resourcesBindingSource
            // 
            this.resourcesBindingSource.DataMember = "Resources";
            this.resourcesBindingSource.DataSource = this.liveGameDataSet;
            // 
            // resourcesTableAdapter
            // 
            this.resourcesTableAdapter.ClearBeforeFill = true;
            // 
            // colUniqueID
            // 
            this.colUniqueID.FieldName = "UniqueID";
            this.colUniqueID.Name = "colUniqueID";
            this.colUniqueID.Visible = true;
            this.colUniqueID.VisibleIndex = 0;
            // 
            // colResourceID
            // 
            this.colResourceID.FieldName = "ResourceID";
            this.colResourceID.Name = "colResourceID";
            this.colResourceID.Visible = true;
            this.colResourceID.VisibleIndex = 1;
            // 
            // colResourceName
            // 
            this.colResourceName.FieldName = "ResourceName";
            this.colResourceName.Name = "colResourceName";
            this.colResourceName.Visible = true;
            this.colResourceName.VisibleIndex = 2;
            // 
            // colColor
            // 
            this.colColor.FieldName = "Color";
            this.colColor.Name = "colColor";
            this.colColor.Visible = true;
            this.colColor.VisibleIndex = 3;
            // 
            // colImage
            // 
            this.colImage.FieldName = "Image";
            this.colImage.Name = "colImage";
            this.colImage.Visible = true;
            this.colImage.VisibleIndex = 4;
            // 
            // colCustomField1
            // 
            this.colCustomField1.FieldName = "CustomField1";
            this.colCustomField1.Name = "colCustomField1";
            this.colCustomField1.Visible = true;
            this.colCustomField1.VisibleIndex = 5;
            // 
            // frmPersonel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 599);
            this.Controls.Add(this.gridControl1);
            this.Name = "frmPersonel";
            this.Text = "frmPersonel";
            this.Load += new System.EventHandler(this.frmPersonel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.liveGameDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private LiveGameDataSet liveGameDataSet;
        private System.Windows.Forms.BindingSource resourcesBindingSource;
        private LiveGameDataSetTableAdapters.ResourcesTableAdapter resourcesTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colUniqueID;
        private DevExpress.XtraGrid.Columns.GridColumn colResourceID;
        private DevExpress.XtraGrid.Columns.GridColumn colResourceName;
        private DevExpress.XtraGrid.Columns.GridColumn colColor;
        private DevExpress.XtraGrid.Columns.GridColumn colImage;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomField1;
    }
}