using System;
using System.Data;
using Break_List.Class;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;

namespace Break_List.Forms.Turnuva
{
    public partial class FrmKatilimcics : XtraForm
    {
        public FrmKatilimcics()
        {
            InitializeComponent();
        }
        public DateTime KatilimTarihi { get; set; }
        public string KatilimciId;
        private void frmKatilimcics_Load(object sender, EventArgs e)
        {
            
        }
        public string TurnuvaAdi { get; set; }
        public string TurnuvaId { get; set; }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (simpleButton1.Text == @"OK")
            {
                using (var conn = DbConnection.Con)
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
                        cmd.Parameters.Add(new MySqlParameter("p_turnuva_ID", TurnuvaId));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        conn.Dispose();
                        Close();
                    }
                }
            }
            else
            {
                UpdateClient();
            }
        }

        private void UpdateClient()
        {
            using (var conn = DbConnection.Con)
            {
                using (var cmd = new MySqlCommand("spTurnuva_Player_Update;", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.Add(new MySqlParameter("p_adi", txtPlayer.Text));
                    cmd.Parameters.Add(new MySqlParameter("p_masa", txtMasa.Text));
                    cmd.Parameters.Add(new MySqlParameter("p_player_id", KatilimciId));
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