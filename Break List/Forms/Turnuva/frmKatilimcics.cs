using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;

namespace Break_List.Forms.Turnuva
{
    public partial class FrmKatilimcics : XtraForm
    {
        public FrmKatilimcics()
        {
            InitializeComponent();
        }
        public DateTime KatilimTarihi { get; set; }
        private void frmKatilimcics_Load(object sender, EventArgs e)
        {
            
        }
        public string TurnuvaAdi { get; set; }
        private const string ConString = "server=192.168.0.187;user id=hakan;password=26091974;persistsecurityinfo=True;database=livegame";
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (var conn = new MySqlConnection(ConString))
            {
                using (var cmd = new MySqlCommand("spTurnuva_new_player;", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.Add(new MySqlParameter("p_player", txtPlayer.Text));
                    cmd.Parameters.Add(new MySqlParameter("p_turnuva", TurnuvaAdi));
                    cmd.Parameters.Add(new MySqlParameter("p_masa", txtMasa.Text));
                    cmd.Parameters.Add(new MySqlParameter("p_timestamp", DateTime.Now));
                    cmd.Parameters.Add(new MySqlParameter("p_katilim_tarihi", KatilimTarihi));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                    Close();
                }
            }
        }
    }
}