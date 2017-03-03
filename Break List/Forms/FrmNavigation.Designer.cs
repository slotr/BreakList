namespace Break_List.Forms
{
    partial class FrmNavigation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNavigation));
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            this.tileNavPane1 = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.catHome = new DevExpress.XtraBars.Navigation.NavButton();
            this.catPersonel = new DevExpress.XtraBars.Navigation.TileNavCategory();
            this.navPersonel = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.navAyrılanlar = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.catRota = new DevExpress.XtraBars.Navigation.TileNavCategory();
            this.itemBreak = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.tileNavItem1 = new DevExpress.XtraBars.Navigation.TileNavItem();
            this.tileNavSubItem1 = new DevExpress.XtraBars.Navigation.TileNavSubItem();
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane1)).BeginInit();
            this.SuspendLayout();
            // 
            // tileNavPane1
            // 
            this.tileNavPane1.ButtonPadding = new System.Windows.Forms.Padding(12);
            this.tileNavPane1.Buttons.Add(this.catHome);
            this.tileNavPane1.Categories.AddRange(new DevExpress.XtraBars.Navigation.TileNavCategory[] {
            this.catPersonel,
            this.catRota});
            // 
            // tileNavCategory1
            // 
            this.tileNavPane1.DefaultCategory.Items.AddRange(new DevExpress.XtraBars.Navigation.TileNavItem[] {
            this.tileNavItem1});
            this.tileNavPane1.DefaultCategory.Name = "tileNavCategory1";
            this.tileNavPane1.DefaultCategory.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane1.DefaultCategory.OwnerCollection = null;
            // 
            // 
            // 
            this.tileNavPane1.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileNavPane1.DefaultCategory.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tileNavPane1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileNavPane1.Location = new System.Drawing.Point(0, 0);
            this.tileNavPane1.Name = "tileNavPane1";
            this.tileNavPane1.OptionsPrimaryDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane1.OptionsSecondaryDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavPane1.Size = new System.Drawing.Size(1413, 40);
            this.tileNavPane1.TabIndex = 0;
            this.tileNavPane1.Text = "tileNavPane1";
            this.tileNavPane1.TileClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.tileNavPane1_TileClick);
            this.tileNavPane1.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.tileNavPane1_ElementClick);
            // 
            // catHome
            // 
            this.catHome.Caption = "Home";
            this.catHome.Glyph = ((System.Drawing.Image)(resources.GetObject("catHome.Glyph")));
            this.catHome.IsMain = true;
            this.catHome.Name = "catHome";
            // 
            // catPersonel
            // 
            this.catPersonel.Caption = "Personel";
            this.catPersonel.Items.AddRange(new DevExpress.XtraBars.Navigation.TileNavItem[] {
            this.navPersonel,
            this.navAyrılanlar});
            this.catPersonel.Name = "catPersonel";
            this.catPersonel.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.catPersonel.OwnerCollection = this.tileNavPane1.Categories;
            // 
            // 
            // 
            this.catPersonel.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement3.Text = "Personel";
            tileItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleRight;
            this.catPersonel.Tile.Elements.Add(tileItemElement3);
            this.catPersonel.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.catPersonel.Tile.Name = "tileBarItem4";
            // 
            // navPersonel
            // 
            this.navPersonel.Caption = "Personel Listesi";
            this.navPersonel.Name = "navPersonel";
            this.navPersonel.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.navPersonel.OwnerCollection = this.catPersonel.Items;
            // 
            // 
            // 
            this.navPersonel.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement1.Text = "Personel Listesi";
            this.navPersonel.Tile.Elements.Add(tileItemElement1);
            this.navPersonel.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.navPersonel.Tile.Name = "tileBarItem2";
            // 
            // navAyrılanlar
            // 
            this.navAyrılanlar.Caption = "Ayrılanlar";
            this.navAyrılanlar.Name = "navAyrılanlar";
            this.navAyrılanlar.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.navAyrılanlar.OwnerCollection = this.catPersonel.Items;
            // 
            // 
            // 
            this.navAyrılanlar.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement2.Text = "Ayrılanlar";
            this.navAyrılanlar.Tile.Elements.Add(tileItemElement2);
            this.navAyrılanlar.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.navAyrılanlar.Tile.Name = "tileBarItem5";
            // 
            // catRota
            // 
            this.catRota.Caption = "Rota ve Break";
            // 
            // itemBreak
            // 
            this.itemBreak.Caption = "Break List";
            this.itemBreak.Name = "itemBreak";
            this.itemBreak.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.itemBreak.OwnerCollection = this.catRota.Items;
            // 
            // 
            // 
            this.itemBreak.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement4.Text = "Break List";
            this.itemBreak.Tile.Elements.Add(tileItemElement4);
            this.itemBreak.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.itemBreak.Tile.Name = "tileBarItem6";
            this.catRota.Items.AddRange(new DevExpress.XtraBars.Navigation.TileNavItem[] {
            this.itemBreak});
            this.catRota.Name = "catRota";
            this.catRota.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.catRota.OwnerCollection = this.tileNavPane1.Categories;
            // 
            // 
            // 
            this.catRota.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement5.Text = "Rota ve Break";
            tileItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleRight;
            this.catRota.Tile.Elements.Add(tileItemElement5);
            this.catRota.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.catRota.Tile.Name = "tileBarItem7";
            // 
            // tileNavItem1
            // 
            this.tileNavItem1.Caption = "tileNavItem1";
            this.tileNavItem1.Name = "tileNavItem1";
            this.tileNavItem1.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            this.tileNavItem1.OwnerCollection = this.tileNavPane1.DefaultCategory.Items;
            this.tileNavItem1.SubItems.AddRange(new DevExpress.XtraBars.Navigation.TileNavSubItem[] {
            this.tileNavSubItem1});
            // 
            // 
            // 
            this.tileNavItem1.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement7.Text = "tileNavItem1";
            this.tileNavItem1.Tile.Elements.Add(tileItemElement7);
            this.tileNavItem1.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tileNavItem1.Tile.Name = "tileBarItem1";
            // 
            // tileNavSubItem1
            // 
            this.tileNavSubItem1.Caption = "tileNavSubItem1";
            this.tileNavSubItem1.Name = "tileNavSubItem1";
            this.tileNavSubItem1.OptionsDropDown.BackColor = System.Drawing.Color.Empty;
            // 
            // 
            // 
            this.tileNavSubItem1.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement6.Text = "tileNavSubItem1";
            this.tileNavSubItem1.Tile.Elements.Add(tileItemElement6);
            this.tileNavSubItem1.Tile.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Default;
            this.tileNavSubItem1.Tile.Name = "tileBarItem3";
            // 
            // FrmNavigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 596);
            this.Controls.Add(this.tileNavPane1);
            this.IsMdiContainer = true;
            this.Name = "FrmNavigation";
            this.Text = "FrmNavigation";
            ((System.ComponentModel.ISupportInitialize)(this.tileNavPane1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TileNavPane tileNavPane1;
        private DevExpress.XtraBars.Navigation.NavButton catHome;
        private DevExpress.XtraBars.Navigation.TileNavItem tileNavItem1;
        private DevExpress.XtraBars.Navigation.TileNavSubItem tileNavSubItem1;
        private DevExpress.XtraBars.Navigation.TileNavCategory catPersonel;
        private DevExpress.XtraBars.Navigation.TileNavItem navAyrılanlar;
        private DevExpress.XtraBars.Navigation.TileNavCategory catRota;
        private DevExpress.XtraBars.Navigation.TileNavItem navPersonel;
        private DevExpress.XtraBars.Navigation.TileNavItem itemBreak;
    }
}