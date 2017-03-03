using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Break_List.Class;
using Break_List.Forms.Personel;
using Break_List.Properties;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;

namespace Break_List.Forms
{
    public partial class FrmNavigation : DevExpress.XtraEditors.XtraForm
    {
        public FrmNavigation()
        {
            InitializeComponent();
            navAyrılanlar.Visible = false;
        }

        private readonly CustomProperties _prop = new CustomProperties();
        private readonly ClsPermissions _p = new ClsPermissions();
        private readonly string _str = Settings.Default.livegameConnectionString2;
        public string UserNameFromLogin { get; set; }

        private void tileNavPane1_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {

        }

        private void SelectHomePath()
        {
            tileNavPane1.SelectedElement = catHome;
        }

        private void tileNavPane1_TileClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            var item = e.Element as TileNavItem;
            if (item != null && item.Caption == "Personel Listesi")
            {
                var addpersonel = new FrmPersonelDetails
                {
                    MdiParent = this,
                };

                addpersonel.Show();
                tileNavPane1.HideDropDownWindow();
            }
            if (item != null && item.Caption == "Home")
            {
                SelectHomePath();}
        }
    }
}