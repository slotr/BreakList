namespace Break_List.Forms.Counts
{
    partial class frmTipCount
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
            this.tileControl1 = new DevExpress.XtraEditors.TileControl();
            this.SuspendLayout();
            // 
            // tileControl1
            // 
            this.tileControl1.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.tileControl1.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tileControl1.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileControl1.AppearanceItem.Normal.Options.UseFont = true;
            this.tileControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileControl1.DragSize = new System.Drawing.Size(0, 0);
            this.tileControl1.ItemSize = 80;
            this.tileControl1.Location = new System.Drawing.Point(0, 0);
            this.tileControl1.Name = "tileControl1";
            this.tileControl1.ShowGroupText = true;
            this.tileControl1.Size = new System.Drawing.Size(776, 625);
            this.tileControl1.TabIndex = 0;
            this.tileControl1.Text = "tileControl1";
            this.tileControl1.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileControl1_ItemClick);
            // 
            // frmTipCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 625);
            this.Controls.Add(this.tileControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTipCount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tip Count";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTipCount_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TileControl tileControl1;
    }
}