using System;
using MySql.Data.MySqlClient;
using Break_List.Properties;

namespace Break_List.Forms.Personel
{
    public partial class FrmOffAlacagi : DevExpress.XtraEditors.XtraForm
    {
        public string PersonelId { get; set; }
        public string UserName { get; set; }
        private readonly MySqlConnection _con = new MySqlConnection(Settings.Default.livegameConnectionString2);
        private MySqlCommand _cmd;
        public FrmOffAlacagi()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _cmd = new MySqlCommand("INSERT INTO offalacaklari(ResourceID, Tarih,alacaksayisi,isleyen) VALUES(@ResourceID, @Tarih,@alacaksayisi,@isleyen)", _con);
            _cmd.Parameters.Add("@ResourceID", MySqlDbType.VarChar, 45);
            _cmd.Parameters.Add("@Tarih", MySqlDbType.DateTime);
            _cmd.Parameters.Add("@alacaksayisi", MySqlDbType.Int32);
            _cmd.Parameters.Add("@isleyen", MySqlDbType.VarChar, 45);            
            _cmd.Parameters["@ResourceID"].Value = PersonelId;
            _cmd.Parameters["@Tarih"].Value = Convert.ToDateTime(dateEdit1.EditValue.ToString());
            _cmd.Parameters["@alacaksayisi"].Value = 1;
            _cmd.Parameters["@isleyen"].Value = UserName;
            _con.Open();
            _cmd.ExecuteNonQuery();
            _con.Close();
        }
    }
}