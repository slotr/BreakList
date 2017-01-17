namespace Break_List.Forms.Maas
{
    partial class FrmMaasArtisi
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
            this.dtTarih = new DevExpress.XtraEditors.DateEdit();
            this.txtMaas = new DevExpress.XtraEditors.TextEdit();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.txtOnay = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnSec = new DevExpress.XtraEditors.ButtonEdit();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtTarih.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTarih.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSec.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtTarih
            // 
            this.dtTarih.EditValue = null;
            this.dtTarih.Location = new System.Drawing.Point(140, 12);
            this.dtTarih.Name = "dtTarih";
            this.dtTarih.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTarih.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTarih.Size = new System.Drawing.Size(132, 20);
            this.dtTarih.TabIndex = 0;
            // 
            // txtMaas
            // 
            this.txtMaas.Location = new System.Drawing.Point(139, 64);
            this.txtMaas.Name = "txtMaas";
            this.txtMaas.Properties.DisplayFormat.FormatString = "f1";
            this.txtMaas.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMaas.Properties.EditFormat.FormatString = "f1";
            this.txtMaas.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMaas.Properties.Mask.EditMask = "f1";
            this.txtMaas.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMaas.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMaas.Size = new System.Drawing.Size(132, 20);
            this.txtMaas.TabIndex = 1;
            // 
            // btnKaydet
            // 
            this.btnKaydet.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnKaydet.Location = new System.Drawing.Point(196, 380);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 4;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtOnay
            // 
            this.txtOnay.Location = new System.Drawing.Point(139, 109);
            this.txtOnay.Name = "txtOnay";
            this.txtOnay.Size = new System.Drawing.Size(132, 20);
            this.txtOnay.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Tarih:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(21, 71);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Artiş Miktarı:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(21, 112);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(56, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Onaylayan:";
            // 
            // btnSec
            // 
            this.btnSec.EditValue = "Dokuman Sec";
            this.btnSec.Location = new System.Drawing.Point(278, 383);
            this.btnSec.Name = "btnSec";
            this.btnSec.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnSec.Size = new System.Drawing.Size(289, 20);
            this.btnSec.TabIndex = 3;
            this.btnSec.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.textEdit3_ButtonClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(392, 210);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(63, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "labelControl4";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(392, 260);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(63, 13);
            this.labelControl5.TabIndex = 7;
            this.labelControl5.Text = "labelControl4";
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(21, 153);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(250, 223);
            this.memoEdit1.TabIndex = 8;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(21, 134);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(58, 13);
            this.labelControl6.TabIndex = 9;
            this.labelControl6.Text = "Artis Nedeni";
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(140, 38);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.Items.AddRange(new object[] {
            "Maaş",
            "Tip"});
            this.comboBoxEdit1.Size = new System.Drawing.Size(131, 20);
            this.comboBoxEdit1.TabIndex = 10;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(22, 41);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(63, 13);
            this.labelControl7.TabIndex = 11;
            this.labelControl7.Text = "Artış Yapılan:";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl8.Appearance.Options.UseForeColor = true;
            this.labelControl8.Location = new System.Drawing.Point(24, 90);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(244, 13);
            this.labelControl8.TabIndex = 4;
            this.labelControl8.Text = "Lütfen artış miktarını girin. Örneğin tip artışı 0,5 gibi";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(278, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(289, 365);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // frmMaasArtisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 415);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.comboBoxEdit1);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtOnay);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtMaas);
            this.Controls.Add(this.dtTarih);
            this.Controls.Add(this.btnSec);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Name = "FrmMaasArtisi";
            this.Text = "Maas Artisi";
            this.Load += new System.EventHandler(this.frmMaasArtisi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtTarih.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTarih.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOnay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSec.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dtTarih;
        private DevExpress.XtraEditors.TextEdit txtMaas;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.TextEdit txtOnay;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ButtonEdit btnSec;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
    }
}