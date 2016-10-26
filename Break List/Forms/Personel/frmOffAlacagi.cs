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
using MySql.Data.MySqlClient;
using Break_List.Properties;

namespace Break_List.Forms.Personel
{
    public partial class frmOffAlacagi : DevExpress.XtraEditors.XtraForm
    {
        public string personelID { get; set; }
        public string UserName { get; set; }
        private MySqlConnection con = new MySqlConnection(Settings.Default.livegameConnectionString2);
        private MySqlCommand cmd;
        public frmOffAlacagi()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            cmd = new MySqlCommand("INSERT INTO offalacaklari(ResourceID, Tarih,alacaksayisi,isleyen) VALUES(@ResourceID, @Tarih,@alacaksayisi,@isleyen)", con);
            cmd.Parameters.Add("@ResourceID", MySqlDbType.VarChar, 45);
            cmd.Parameters.Add("@Tarih", MySqlDbType.DateTime);
            cmd.Parameters.Add("@alacaksayisi", MySqlDbType.Int32);
            cmd.Parameters.Add("@isleyen", MySqlDbType.VarChar, 45);            
            cmd.Parameters["@ResourceID"].Value = personelID;
            cmd.Parameters["@Tarih"].Value = Convert.ToDateTime(dateEdit1.EditValue.ToString());
            cmd.Parameters["@alacaksayisi"].Value = 1;
            cmd.Parameters["@isleyen"].Value = UserName;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}