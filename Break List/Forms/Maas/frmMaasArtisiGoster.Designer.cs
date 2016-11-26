namespace Break_List.Forms.Maas
{
    partial class frmMaasArtisiGoster
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
            System.Windows.Forms.Label dokumanLabel;
            System.Windows.Forms.Label artisNedeniLabel;
            System.Windows.Forms.Label kategoriLabel;
            System.Windows.Forms.Label maasLabel;
            System.Windows.Forms.Label tipLabel;
            System.Windows.Forms.Label onaylayanLabel;
            System.Windows.Forms.Label tarihLabel;
            dokumanPictureEdit = new DevExpress.XtraEditors.PictureEdit();
            artisNedeniLinkLabel = new System.Windows.Forms.LinkLabel();
            kategoriLabel1 = new System.Windows.Forms.Label();
            maasLabel1 = new System.Windows.Forms.Label();
            tipLabel1 = new System.Windows.Forms.Label();
            onaylayanLabel1 = new System.Windows.Forms.Label();
            spMaasartisiniGosterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            livegameDataSet1 = new livegameDataSet1();
            spMaasartisiniGosterTableAdapter = new livegameDataSet1TableAdapters.spMaasartisiniGosterTableAdapter();
            tableAdapterManager = new livegameDataSet1TableAdapters.TableAdapterManager();
            tarihLabel1 = new System.Windows.Forms.Label();
            dokumanLabel = new System.Windows.Forms.Label();
            artisNedeniLabel = new System.Windows.Forms.Label();
            kategoriLabel = new System.Windows.Forms.Label();
            maasLabel = new System.Windows.Forms.Label();
            tipLabel = new System.Windows.Forms.Label();
            onaylayanLabel = new System.Windows.Forms.Label();
            tarihLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dokumanPictureEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMaasartisiniGosterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dokumanLabel
            // 
            dokumanLabel.AutoSize = true;
            dokumanLabel.Location = new System.Drawing.Point(642, 37);
            dokumanLabel.Name = "dokumanLabel";
            dokumanLabel.Size = new System.Drawing.Size(55, 13);
            dokumanLabel.TabIndex = 2;
            dokumanLabel.Text = "Dokuman:";
            // 
            // dokumanPictureEdit
            // 
            this.dokumanPictureEdit.Cursor = System.Windows.Forms.Cursors.Default;
            this.dokumanPictureEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.spMaasartisiniGosterBindingSource, "Dokuman", true));
            this.dokumanPictureEdit.Location = new System.Drawing.Point(288, 53);
            this.dokumanPictureEdit.Name = "dokumanPictureEdit";
            this.dokumanPictureEdit.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.dokumanPictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.dokumanPictureEdit.Properties.ZoomAccelerationFactor = 1D;
            this.dokumanPictureEdit.Size = new System.Drawing.Size(409, 563);
            this.dokumanPictureEdit.TabIndex = 3;
            // 
            // artisNedeniLabel
            // 
            artisNedeniLabel.AutoSize = true;
            artisNedeniLabel.Location = new System.Drawing.Point(66, 643);
            artisNedeniLabel.Name = "artisNedeniLabel";
            artisNedeniLabel.Size = new System.Drawing.Size(69, 13);
            artisNedeniLabel.TabIndex = 4;
            artisNedeniLabel.Text = "Artis Nedeni:";
            // 
            // artisNedeniLinkLabel
            // 
            this.artisNedeniLinkLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.spMaasartisiniGosterBindingSource, "ArtisNedeni", true));
            this.artisNedeniLinkLabel.Location = new System.Drawing.Point(141, 643);
            this.artisNedeniLinkLabel.Name = "artisNedeniLinkLabel";
            this.artisNedeniLinkLabel.Size = new System.Drawing.Size(556, 111);
            this.artisNedeniLinkLabel.TabIndex = 5;
            this.artisNedeniLinkLabel.TabStop = true;
            this.artisNedeniLinkLabel.Text = "linkLabel1";
            // 
            // kategoriLabel
            // 
            kategoriLabel.AutoSize = true;
            kategoriLabel.Location = new System.Drawing.Point(85, 93);
            kategoriLabel.Name = "kategoriLabel";
            kategoriLabel.Size = new System.Drawing.Size(70, 13);
            kategoriLabel.TabIndex = 6;
            kategoriLabel.Text = "Artış Yapılan:";
            // 
            // kategoriLabel1
            // 
            this.kategoriLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.spMaasartisiniGosterBindingSource, "Kategori", true));
            this.kategoriLabel1.Location = new System.Drawing.Point(182, 93);
            this.kategoriLabel1.Name = "kategoriLabel1";
            this.kategoriLabel1.Size = new System.Drawing.Size(100, 23);
            this.kategoriLabel1.TabIndex = 7;
            this.kategoriLabel1.Text = "label1";
            // 
            // maasLabel
            // 
            maasLabel.AutoSize = true;
            maasLabel.Location = new System.Drawing.Point(92, 131);
            maasLabel.Name = "maasLabel";
            maasLabel.Size = new System.Drawing.Size(63, 13);
            maasLabel.TabIndex = 8;
            maasLabel.Text = "Maaş Artışı:";
            // 
            // maasLabel1
            // 
            this.maasLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.spMaasartisiniGosterBindingSource, "maas", true));
            this.maasLabel1.Location = new System.Drawing.Point(182, 131);
            this.maasLabel1.Name = "maasLabel1";
            this.maasLabel1.Size = new System.Drawing.Size(100, 23);
            this.maasLabel1.TabIndex = 9;
            this.maasLabel1.Text = "label1";
            // 
            // tipLabel
            // 
            tipLabel.AutoSize = true;
            tipLabel.Location = new System.Drawing.Point(103, 164);
            tipLabel.Name = "tipLabel";
            tipLabel.Size = new System.Drawing.Size(52, 13);
            tipLabel.TabIndex = 10;
            tipLabel.Text = "Tip Artışı:";
            // 
            // tipLabel1
            // 
            this.tipLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.spMaasartisiniGosterBindingSource, "Tip", true));
            this.tipLabel1.Location = new System.Drawing.Point(182, 164);
            this.tipLabel1.Name = "tipLabel1";
            this.tipLabel1.Size = new System.Drawing.Size(100, 23);
            this.tipLabel1.TabIndex = 11;
            this.tipLabel1.Text = "label1";
            // 
            // onaylayanLabel
            // 
            onaylayanLabel.AutoSize = true;
            onaylayanLabel.Location = new System.Drawing.Point(92, 196);
            onaylayanLabel.Name = "onaylayanLabel";
            onaylayanLabel.Size = new System.Drawing.Size(63, 13);
            onaylayanLabel.TabIndex = 12;
            onaylayanLabel.Text = "Onaylayan:";
            // 
            // onaylayanLabel1
            // 
            this.onaylayanLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.spMaasartisiniGosterBindingSource, "Onaylayan", true));
            this.onaylayanLabel1.Location = new System.Drawing.Point(182, 196);
            this.onaylayanLabel1.Name = "onaylayanLabel1";
            this.onaylayanLabel1.Size = new System.Drawing.Size(100, 23);
            this.onaylayanLabel1.TabIndex = 13;
            this.onaylayanLabel1.Text = "label1";
            // 
            // spMaasartisiniGosterBindingSource
            // 
            this.spMaasartisiniGosterBindingSource.DataMember = "spMaasartisiniGoster";
            this.spMaasartisiniGosterBindingSource.DataSource = this.livegameDataSet1;
            // 
            // livegameDataSet1
            // 
            this.livegameDataSet1.DataSetName = "livegameDataSet1";
            this.livegameDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spMaasartisiniGosterTableAdapter
            // 
            this.spMaasartisiniGosterTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            tableAdapterManager.appointmentsTableAdapter = null;
            tableAdapterManager.apps_countriesTableAdapter = null;
            tableAdapterManager.avanslarTableAdapter = null;
            tableAdapterManager.BackupDataSetBeforeUpdate = false;
            tableAdapterManager.Connection = null;
            tableAdapterManager.departmentsTableAdapter = null;
            tableAdapterManager.documentsTableAdapter = null;
            tableAdapterManager.kesintilerTableAdapter = null;
            tableAdapterManager.lghataTableAdapter = null;
            tableAdapterManager.maaslarTableAdapter = null;
            tableAdapterManager.offalacaklariTableAdapter = null;
            tableAdapterManager.permissionsTableAdapter = null;
            tableAdapterManager.positionsTableAdapter = null;
            tableAdapterManager.resourcesTableAdapter = null;
            tableAdapterManager.rolesTableAdapter = null;
            tableAdapterManager.roster1TableAdapter = null;
            tableAdapterManager.shiftsTableAdapter = null;
            tableAdapterManager.tablesTableAdapter = null;
            tableAdapterManager.tblcalismaizinleriTableAdapter = null;
            tableAdapterManager.tiplerTableAdapter = null;
            tableAdapterManager.UpdateOrder = livegameDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            
            this.tableAdapterManager.usersTableAdapter = null;
            this.tableAdapterManager.vacationsTableAdapter = null;
            // 
            // tarihLabel
            // 
            tarihLabel.AutoSize = true;
            tarihLabel.Location = new System.Drawing.Point(92, 53);
            tarihLabel.Name = "tarihLabel";
            tarihLabel.Size = new System.Drawing.Size(62, 13);
            tarihLabel.TabIndex = 13;
            tarihLabel.Text = "Artış Tarihi:";
            // 
            // tarihLabel1
            // 
            this.tarihLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.spMaasartisiniGosterBindingSource, "tarih", true));
            this.tarihLabel1.Location = new System.Drawing.Point(182, 53);
            this.tarihLabel1.Name = "tarihLabel1";
            this.tarihLabel1.Size = new System.Drawing.Size(100, 23);
            this.tarihLabel1.TabIndex = 14;
            this.tarihLabel1.Text = "label1";
            // 
            // frmMaasArtisiGoster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 787);
            this.Controls.Add(tarihLabel);
            this.Controls.Add(this.tarihLabel1);
            this.Controls.Add(onaylayanLabel);
            this.Controls.Add(this.onaylayanLabel1);
            this.Controls.Add(tipLabel);
            this.Controls.Add(this.tipLabel1);
            this.Controls.Add(maasLabel);
            this.Controls.Add(this.maasLabel1);
            this.Controls.Add(kategoriLabel);
            this.Controls.Add(this.kategoriLabel1);
            this.Controls.Add(artisNedeniLabel);
            this.Controls.Add(this.artisNedeniLinkLabel);
            this.Controls.Add(dokumanLabel);
            this.Controls.Add(this.dokumanPictureEdit);
            this.Name = "frmMaasArtisiGoster";
            this.Text = "frmMaasArtisiGoster";
            this.Load += new System.EventHandler(this.frmMaasArtisiGoster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dokumanPictureEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMaasartisiniGosterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.livegameDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private livegameDataSet1 livegameDataSet1;
        private System.Windows.Forms.BindingSource spMaasartisiniGosterBindingSource;
        private livegameDataSet1TableAdapters.spMaasartisiniGosterTableAdapter spMaasartisiniGosterTableAdapter;
        private livegameDataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraEditors.PictureEdit dokumanPictureEdit;
        private System.Windows.Forms.LinkLabel artisNedeniLinkLabel;
        private System.Windows.Forms.Label kategoriLabel1;
        private System.Windows.Forms.Label maasLabel1;
        private System.Windows.Forms.Label tipLabel1;
        private System.Windows.Forms.Label onaylayanLabel1;
        private System.Windows.Forms.Label tarihLabel1;
    }
}