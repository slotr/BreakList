namespace Break_List
{
    partial class frmPositions
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
        ///
        private void InitializeComponent()
        {
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.cmDepartment = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtPosition = new DevExpress.XtraLayout.LayoutControlItem();
            this.windowsUIButtonPanelMain = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.labelControl = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.AllowCustomization = false;
            this.dataLayoutControl1.Controls.Add(this.textEdit1);
            this.dataLayoutControl1.Controls.Add(this.comboBoxEdit1);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 30);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(269, 70);
            this.dataLayoutControl1.TabIndex = 0;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(108, 36);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(149, 20);
            this.textEdit1.StyleController = this.dataLayoutControl1;
            this.textEdit1.TabIndex = 5;
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(108, 12);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.comboBoxEdit1.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.comboBoxEdit1_Properties_ButtonClick);
            this.comboBoxEdit1.Size = new System.Drawing.Size(149, 20);
            this.comboBoxEdit1.StyleController = this.dataLayoutControl1;
            this.comboBoxEdit1.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.cmDepartment,
            this.txtPosition});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(269, 70);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // cmDepartment
            // 
            this.cmDepartment.Control = this.comboBoxEdit1;
            this.cmDepartment.Location = new System.Drawing.Point(0, 0);
            this.cmDepartment.Name = "cmDepartment";
            this.cmDepartment.Size = new System.Drawing.Size(249, 24);
            this.cmDepartment.Text = "Select Department:";
            this.cmDepartment.TextSize = new System.Drawing.Size(93, 13);
            // 
            // txtPosition
            // 
            this.txtPosition.Control = this.textEdit1;
            this.txtPosition.Location = new System.Drawing.Point(0, 24);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(249, 26);
            this.txtPosition.Text = "Position:";
            this.txtPosition.TextSize = new System.Drawing.Size(93, 13);
            // 
            // windowsUIButtonPanelMain
            // 
            this.windowsUIButtonPanelMain.AppearanceButton.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.windowsUIButtonPanelMain.AppearanceButton.Hovered.FontSizeDelta = -1;
            this.windowsUIButtonPanelMain.AppearanceButton.Hovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.windowsUIButtonPanelMain.AppearanceButton.Hovered.Options.UseBackColor = true;
            this.windowsUIButtonPanelMain.AppearanceButton.Hovered.Options.UseFont = true;
            this.windowsUIButtonPanelMain.AppearanceButton.Hovered.Options.UseForeColor = true;
            this.windowsUIButtonPanelMain.AppearanceButton.Normal.FontSizeDelta = -1;
            this.windowsUIButtonPanelMain.AppearanceButton.Normal.Options.UseFont = true;
            this.windowsUIButtonPanelMain.AppearanceButton.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.windowsUIButtonPanelMain.AppearanceButton.Pressed.FontSizeDelta = -1;
            this.windowsUIButtonPanelMain.AppearanceButton.Pressed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.windowsUIButtonPanelMain.AppearanceButton.Pressed.Options.UseBackColor = true;
            this.windowsUIButtonPanelMain.AppearanceButton.Pressed.Options.UseFont = true;
            this.windowsUIButtonPanelMain.AppearanceButton.Pressed.Options.UseForeColor = true;
            this.windowsUIButtonPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.windowsUIButtonPanelMain.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Save", null, "Save;Size32x32;GrayScaled"),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Save And Close", null, "SaveAndClose;Size32x32;GrayScaled"),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Save And New", null, "SaveAndNew;Size32x32;GrayScaled")});
            this.windowsUIButtonPanelMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowsUIButtonPanelMain.EnableImageTransparency = true;
            this.windowsUIButtonPanelMain.ForeColor = System.Drawing.Color.White;
            this.windowsUIButtonPanelMain.Location = new System.Drawing.Point(0, 100);
            this.windowsUIButtonPanelMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.windowsUIButtonPanelMain.MaximumSize = new System.Drawing.Size(0, 60);
            this.windowsUIButtonPanelMain.MinimumSize = new System.Drawing.Size(60, 60);
            this.windowsUIButtonPanelMain.Name = "windowsUIButtonPanelMain";
            this.windowsUIButtonPanelMain.Size = new System.Drawing.Size(269, 60);
            this.windowsUIButtonPanelMain.TabIndex = 3;
            this.windowsUIButtonPanelMain.Text = "windowsUIButtonPanelMain";
            this.windowsUIButtonPanelMain.UseButtonBackgroundImages = false;
            this.windowsUIButtonPanelMain.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.windowsUIButtonPanelMain_ButtonClick);
            // 
            // labelControl
            // 
            this.labelControl.AllowHtmlString = true;
            this.labelControl.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.labelControl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl.Location = new System.Drawing.Point(0, 0);
            this.labelControl.Name = "labelControl";
            this.labelControl.Padding = new System.Windows.Forms.Padding(10, 5, 0, 0);
            this.labelControl.Size = new System.Drawing.Size(269, 30);
            this.labelControl.TabIndex = 1;
            this.labelControl.Text = "Positions";
            // 
            // frmPositions
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(269, 160);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.labelControl);
            this.Controls.Add(this.windowsUIButtonPanelMain);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPositions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanelMain;
        private DevExpress.XtraEditors.LabelControl labelControl;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraLayout.LayoutControlItem cmDepartment;
        private DevExpress.XtraLayout.LayoutControlItem txtPosition;
    }

}