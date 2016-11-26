using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using System.Threading;
using DevExpress.XtraEditors;

namespace Break_List
{
    static class Program
    {
        private static Mutex _m;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
           

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                UserLookAndFeel.Default.SetSkinStyle("Office 2016 Colorful");
                DevExpress.Skins.SkinManager.EnableFormSkins();
                DevExpress.UserSkins.BonusSkins.Register();
                Application.Run(new frmLogin());
                
          




        }

    }
  
}

