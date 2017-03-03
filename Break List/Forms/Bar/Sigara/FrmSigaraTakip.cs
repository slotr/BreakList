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

namespace Break_List.Forms.Bar.Sigara
{
    public partial class FrmSigaraTakip : XtraForm
    {
        public FrmSigaraTakip()
        {
            InitializeComponent();
            
        }
        private const string ConString = "server=192.168.0.187;user id=hakan;password=26091974;persistsecurityinfo=True;database=livegame";
        private void FrmSigaraTakip_Load(object sender, EventArgs e)
        {
            using (var conn = new MySqlConnection(ConString))
            {
                var cmd = new MySqlCommand("sp_Bar_Sigara_toplami_rapor;", conn) { CommandType = CommandType.StoredProcedure };
                
                conn.Open();

                using (var adapter = new MySqlDataAdapter())
                {
                    var dt = new DataTable();
                    adapter.SelectCommand = cmd;
                    {
                        adapter.Fill(dt);
                        gridControl1.DataSource = dt;
                    }
                }
                conn.Close();
                conn.Dispose();
            }
            timer1.Interval = 60000*5;//10 saniye

            timer1.Tick += (timer1_Tick);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            using (var conn = new MySqlConnection(ConString))
            {
                var cmd = new MySqlCommand("sp_Bar_Sigara_toplami_rapor;", conn) { CommandType = CommandType.StoredProcedure };

                conn.Open();

                using (var adapter = new MySqlDataAdapter())
                {
                    var dt = new DataTable();
                    adapter.SelectCommand = cmd;
                    {
                        adapter.Fill(dt);
                        gridControl1.DataSource = dt;
                    }
                }
                conn.Close();
                conn.Dispose();
            }
        }
    }
}