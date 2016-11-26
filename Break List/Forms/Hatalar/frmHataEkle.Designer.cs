namespace Break_List.Forms.Hatalar
{
    partial class frmHataEkle
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
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                if (con != null)
                {
                    con.Dispose();
                    con = null;
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
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
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit3 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit4 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit5 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit6 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit7 = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(13, 29);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(156, 20);
            this.dateEdit1.TabIndex = 0;
            this.dateEdit1.EditValueChanged += new System.EventHandler(this.dateEdit1_EditValueChanged);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(13, 92);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.checkEdit1.Properties.Caption = "OVP";
            this.checkEdit1.Properties.ValueChecked = 1;
            this.checkEdit1.Size = new System.Drawing.Size(53, 19);
            this.checkEdit1.TabIndex = 1;
            // 
            // checkEdit2
            // 
            this.checkEdit2.Location = new System.Drawing.Point(94, 92);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.checkEdit2.Properties.Caption = "UNP";
            this.checkEdit2.Properties.ValueChecked = 1;
            this.checkEdit2.Size = new System.Drawing.Size(59, 19);
            this.checkEdit2.TabIndex = 1;
            // 
            // checkEdit3
            // 
            this.checkEdit3.Location = new System.Drawing.Point(159, 92);
            this.checkEdit3.Name = "checkEdit3";
            this.checkEdit3.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.checkEdit3.Properties.Caption = "CRDH";
            this.checkEdit3.Properties.ValueChecked = 1;
            this.checkEdit3.Size = new System.Drawing.Size(60, 19);
            this.checkEdit3.TabIndex = 1;
            // 
            // checkEdit4
            // 
            this.checkEdit4.Location = new System.Drawing.Point(225, 92);
            this.checkEdit4.Name = "checkEdit4";
            this.checkEdit4.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.checkEdit4.Properties.Caption = "LGE";
            this.checkEdit4.Properties.ValueChecked = 1;
            this.checkEdit4.Size = new System.Drawing.Size(59, 19);
            this.checkEdit4.TabIndex = 1;
            // 
            // checkEdit5
            // 
            this.checkEdit5.Location = new System.Drawing.Point(306, 92);
            this.checkEdit5.Name = "checkEdit5";
            this.checkEdit5.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.checkEdit5.Properties.Caption = "CLE";
            this.checkEdit5.Properties.ValueChecked = 1;
            this.checkEdit5.Size = new System.Drawing.Size(45, 19);
            this.checkEdit5.TabIndex = 1;
            // 
            // checkEdit6
            // 
            this.checkEdit6.Location = new System.Drawing.Point(387, 92);
            this.checkEdit6.Name = "checkEdit6";
            this.checkEdit6.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.checkEdit6.Properties.Caption = "WSB";
            this.checkEdit6.Properties.ValueChecked = 1;
            this.checkEdit6.Size = new System.Drawing.Size(59, 19);
            this.checkEdit6.TabIndex = 1;
            // 
            // checkEdit7
            // 
            this.checkEdit7.Location = new System.Drawing.Point(468, 92);
            this.checkEdit7.Name = "checkEdit7";
            this.checkEdit7.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.checkEdit7.Properties.Caption = "MSD";
            this.checkEdit7.Properties.ValueChecked = 1;
            this.checkEdit7.Size = new System.Drawing.Size(40, 19);
            this.checkEdit7.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(468, 290);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "KAYDET";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(26, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "labelControl1";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(188, 32);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Hata Tarihi";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(13, 141);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(530, 143);
            this.textEdit1.TabIndex = 5;
            // 
            // frmHataEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 325);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.checkEdit7);
            this.Controls.Add(this.checkEdit6);
            this.Controls.Add(this.checkEdit5);
            this.Controls.Add(this.checkEdit4);
            this.Controls.Add(this.checkEdit3);
            this.Controls.Add(this.checkEdit2);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textEdit1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.Name = "frmHataEkle";
            this.Text = "Hata Ekle";
            this.Load += new System.EventHandler(this.frmHataEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        private DevExpress.XtraEditors.CheckEdit checkEdit3;
        private DevExpress.XtraEditors.CheckEdit checkEdit4;
        private DevExpress.XtraEditors.CheckEdit checkEdit5;
        private DevExpress.XtraEditors.CheckEdit checkEdit6;
        private DevExpress.XtraEditors.CheckEdit checkEdit7;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit textEdit1;
    }
}