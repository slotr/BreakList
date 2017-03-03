using System;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using Break_List.Forms;
using Break_List.Forms.Bar.Sigara;
using Break_List.Forms.Raporlar;
using Break_List.Forms.Turnuva;

namespace Break_List
{
    internal static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                UserLookAndFeel.Default.SetSkinStyle("Office 2016 Colorful");
                DevExpress.Skins.SkinManager.EnableFormSkins();
                DevExpress.UserSkins.BonusSkins.Register();
                Application.Run(new FrmLogin());}

    }
  
}

