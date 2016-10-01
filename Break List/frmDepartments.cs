using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.ComponentModel.DataAnnotations;
using System.IO;
using DevExpress.XtraLayout.Helpers;
using DevExpress.XtraLayout;
using MySql.Data.MySqlClient;
using Break_List.Properties;

namespace Break_List
{
    public partial class frmDepartments : DevExpress.XtraEditors.XtraForm
    {
        private MySqlConnection con = new MySqlConnection(Settings.Default.livegameConnectionString2);
        private MySqlCommand cmd;
        public frmDepartments()
        {
            InitializeComponent();

        }

        void InsertDepartment()
        {
                         con.Open();
                        cmd = new MySqlCommand("INSERT INTO departments(DepartmentName) VALUES(@DepartmentName)", con);
                        cmd.Parameters.Add("@DepartmentName", MySqlDbType.VarChar, 45);
                        cmd.Parameters["@DepartmentName"].Value = this.txtDepartment.Text;
                        cmd.ExecuteNonQuery();
                        con.Close();
        }

        private void windowsUIButtonPanelMain_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Save":
                    InsertDepartment();
                    break;
                case "Save And Close":
                    InsertDepartment();
                    Close();
                    break;
                case "Save And New":
                    InsertDepartment();
                    txtDepartment.Text = "";
                    break;
            }
        }
    }                
}
  