using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Break_List.Properties;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using MySql.Data.MySqlClient;

namespace Break_List.Forms.Bar.Sigara
{
    public partial class frmDailySigara : XtraForm
    {
        public frmDailySigara()
        {
            InitializeComponent();
            if (textEdit1.Text == "")
            {
                simpleButton1.Enabled =
                false;
            }
        }
        private const string ConString = "server=192.168.0.187;user id=hakan;password=26091974;persistsecurityinfo=True;database=livegame";
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var tarih = DateTime.Now;
            using (var conn = new MySqlConnection(ConString))
            {
                using (var cmd = new MySqlCommand("sp_Bar_Insert_sigara;", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.Add(new MySqlParameter("p_musteri", textEdit1.Text));
                    cmd.Parameters.Add(new MySqlParameter("p_tarih", tarih));
                    cmd.Parameters.Add(new MySqlParameter("p_adet", 1));
                    cmd.Parameters.Add(new MySqlParameter("p_departman", radioGroup2.EditValue.ToString()));
                    cmd.Parameters.Add(new MySqlParameter("p_cesit", radioGroup1.EditValue.ToString()));
                    conn.Open();
                    cmd.ExecuteNonQuery();conn.Close();
                    conn.Dispose();
                    textEdit1.Text = "";
                }
            }
            SigaralariGetir();
        }

        private void SigaralariGetir()
        {
            using (var conn = new MySqlConnection(ConString))
            {
                var cmd = new MySqlCommand("sp_Bar_Sigara_toplami;", conn) { CommandType = CommandType.StoredProcedure };

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

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (textEdit1.Text != "")
            {
                simpleButton1.Enabled = true;
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var column = e.Column;
            if (column != gridColumn3)
            {
                var rowid = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "musteri");
                using (var conn = new MySqlConnection(ConString))
                {
                    var cmd = new MySqlCommand("sp_Bar_Sigara_musteri_detay;", conn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.Add((new MySqlParameter("p_musteri", rowid)));
                    conn.Open();

                    using (var adapter = new MySqlDataAdapter())
                    {
                        var dt = new DataTable();
                        adapter.SelectCommand = cmd;
                        {
                            adapter.Fill(dt);
                            gridControl2.DataSource = dt;
                        }
                    }
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var dr = XtraMessageBox.Show("Yeni Gune Gecilsin mi?", "Soru", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                using (var conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    var cmd = new MySqlCommand("sp_Bar_Sigara_Yeni_gun;", conn) { CommandType = CommandType.StoredProcedure };

                    conn.Open();

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                }
                gridControl1.DataSource = null;
                gridControl1.Refresh();
                gridControl2.DataSource = null;
                gridControl2.Refresh();
            }
            
        }

        private void frmDailySigara_Load(object sender, EventArgs e)
        {
            SigaralariGetir();}
    }
}