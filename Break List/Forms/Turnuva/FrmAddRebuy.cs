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

namespace Break_List.Forms.Turnuva
{
    public partial class FrmAddRebuy : DevExpress.XtraEditors.XtraForm
    {
        public FrmAddRebuy()
        {
            InitializeComponent();
        }
        public DateTime KatilimTarihi { get; set; }
        public string musteri { get; set; }
        public string TopDenom1;
        public string TopDenom2;
        public string TopDenom3;
        public string TopDenom4;
        public string TopDenom5;
        public string TopDenom6;
        public int Rebuy1;
        public int Rebuy2;
        public int Rebuy3;
        public int Rebuy4;
        public int Rebuy5;
        public int Rebuy6;
        public string masa;
        public string TurnuvaAdi;
        private void FrmAddRebuy_Load(object sender, EventArgs e)
        {
            labelControl1.Text = musteri;
            lblR1.Text = Rebuy1.ToString();
            lblR2.Text = Rebuy2.ToString();
            lblR3.Text = Rebuy3.ToString();
            lblR4.Text = Rebuy4.ToString();
            lblR5.Text = Rebuy5.ToString();
            lblR6.Text = Rebuy6.ToString();
            lblT1.Text = TopDenom1;
            lblT2.Text = TopDenom2;
            lblT3.Text = TopDenom3;
            lblT4.Text = TopDenom4;
            lblT5.Text = TopDenom5;
            lblT6.Text = TopDenom6;
            labelControl4.Text = KatilimTarihi.ToString("d");
            MusteriToplamRebuy();
        }
        private const string ConString =
            "server=192.168.0.187;user id=hakan;password=26091974;persistsecurityinfo=True;database=livegame";
        private void MusteriToplamRebuy()
        {
            using (var conn = new MySqlConnection(ConString))
            {
                var cmd = new MySqlCommand("spTurnuva_musteri_toplam_rebuy;", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new MySqlParameter("p_musteri", musteri));
                conn.Open();
                var dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                 lblAlacak.Text = @"Toplam Alacak: "+dbr["Alacak"];
                 lblToplamRebuy.Text = @"Toplam Rebuy: " + dbr["Rebuy"];
                }
                conn.Close();
            }
        }

        private void lblR1_Click(object sender, EventArgs e)
        {
            rebuy.Text = lblR1.Text;
            rbAlınan.Focus();
            rbAlınan.SelectAll();
        }

        private void lblR2_Click(object sender, EventArgs e)
        {
            rebuy.Text = lblR2.Text;
            rbAlınan.Focus();
            rbAlınan.SelectAll();
        }

        private void lblR3_Click(object sender, EventArgs e)
        {
            rebuy.Text = lblR3.Text;
            rbAlınan.Focus();
            rbAlınan.SelectAll();
        }

        private void lblR4_Click(object sender, EventArgs e)
        {
            rebuy.Text = lblR4.Text;
            rbAlınan.Focus();
            rbAlınan.SelectAll();
        }

        private void lblR5_Click(object sender, EventArgs e)
        {
            rebuy.Text = lblR5.Text;
            rbAlınan.Focus();
            rbAlınan.SelectAll();
        }

        private void lblR6_Click(object sender, EventArgs e)
        {
            rebuy.Text = lblR5.Text;
            rbAlınan.Focus();
            rbAlınan.SelectAll();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            KayitGir();
        }

        private void KayitGir()
        {
            using (var conn = new MySqlConnection(ConString))
            {
                using (var cmd = new MySqlCommand("spTurnuva_new_Rebuy;", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.Add(new MySqlParameter("p_player", musteri));
                    cmd.Parameters.Add(new MySqlParameter("p_turnuva", TurnuvaAdi));
                    cmd.Parameters.Add(new MySqlParameter("p_masa", masa));
                    cmd.Parameters.Add(new MySqlParameter("p_timestamp", DateTime.Now));
                    cmd.Parameters.Add(new MySqlParameter("p_katilim_tarihi", Convert.ToDateTime(labelControl4.Text)));
                    cmd.Parameters.Add(new MySqlParameter("p_re_buy", rebuy.Text));
                    cmd.Parameters.Add(new MySqlParameter("p_re_entry", txtReEntry.Text));
                    cmd.Parameters.Add(new MySqlParameter("p_re_buy_paid_amount", rbAlınan.Text));
                    cmd.Parameters.Add(new MySqlParameter("p_re_entry_paid_amount", txtReentryAlınan.Text));
                    cmd.Parameters.Add(new MySqlParameter("p_score", txtScore.Text));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                    Close();
                    
                }
            }
        }

        private void checkButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkButton2.Checked)
            {
                txtReentryAlınan.Text = txtReEntry.Text;
            }
            else
            {
                txtReentryAlınan.Focus();
                txtReentryAlınan.SelectAll();
            }
        }

        private void checkButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkButton1.Checked)
            {
                rbAlınan.Text = rebuy.Text;
            }
            else
            {
                rbAlınan.Focus();
                rbAlınan.SelectAll();
            }
        }
    }
}