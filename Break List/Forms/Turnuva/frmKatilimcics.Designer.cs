namespace Break_List.Forms.Turnuva
{
    partial class FrmKatilimcics
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
            this.txtMasa = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPlayer = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtMasa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlayer.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMasa
            // 
            this.txtMasa.Location = new System.Drawing.Point(85, 118);
            this.txtMasa.Name = "txtMasa";
            this.txtMasa.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMasa.Properties.Appearance.Options.UseFont = true;
            this.txtMasa.Size = new System.Drawing.Size(294, 32);
            this.txtMasa.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(16, 69);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Katılımcı";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(16, 131);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(25, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Masa";
            // 
            // txtPlayer
            // 
            this.txtPlayer.Location = new System.Drawing.Point(85, 56);
            this.txtPlayer.Name = "txtPlayer";
            this.txtPlayer.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPlayer.Properties.Appearance.Options.UseFont = true;
            this.txtPlayer.Size = new System.Drawing.Size(294, 32);
            this.txtPlayer.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButton1.Location = new System.Drawing.Point(304, 156);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 59);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "OK";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // FrmKatilimcics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 227);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtPlayer);
            this.Controls.Add(this.txtMasa);
            this.Name = "FrmKatilimcics";
            this.Text = "Katilimci";
            this.Load += new System.EventHandler(this.frmKatilimcics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtMasa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlayer.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtMasa;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtPlayer;
        public DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}