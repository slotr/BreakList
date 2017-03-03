using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Break_List.Class;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;

namespace Break_List.Forms.Turnuva
{
    public partial class FrmAddRebuy : XtraForm
    {
        public FrmAddRebuy()
        {
            InitializeComponent();
        }
        public DateTime KatilimTarihi { get; set; }
        public string Musteri;
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
        public string Masa;
        public string TurnuvaAdi;
        public string TurnuvaId;
        public int RecordID;
        public bool NewRecord { get; set; }
        private void FrmAddRebuy_Load(object sender, EventArgs e)
        {
            if (btnOK.Text !=@"Update"){
                labelControl1.Text = Musteri;
                txtmasa.Text = Masa;
                txtclient.Text = Musteri;
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
            else
            {
                
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
                GetRecordofClient();

            }
            
        }

        private void GetRecordofClient()
        {
            using (var conn = DbConnection.Con)
            {
                var cmd = new MySqlCommand("Select * from tblturnuva_katilimci where id=" + RecordID, conn)
                {
                    CommandType = CommandType.Text
                };
                conn.Open();
                var dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    labelControl1.Text = dbr["musteri"].ToString();
                    txtmasa.Text = dbr["masa"].ToString();
                    txtclient.Text = dbr["musteri"].ToString();
                    labelControl4.Text = dbr["turnuva_oyun_tarihi"].ToString();
                    txtrebuy.Text = dbr["re_buy"].ToString();
                    txtReEntry.Text = dbr["re_entry"].ToString();
                    txtReentryAlınan.Text = dbr["re_entry_paid_amount"].ToString();
                    txtrbAlınan.Text = dbr["re_buy_paid_amount"].ToString();
                    txtScore.Text = dbr["final_score"].ToString();
                }
                conn.Close();
            }
            
        }

        private void MusteriToplamRebuy()
        {
            using (var conn = DbConnection.Con)
            {
                var cmd = new MySqlCommand("spTurnuva_musteri_toplam_rebuy;", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new MySqlParameter("p_musteri", Musteri));
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
            txtrebuy.Text = lblR1.Text;
            txtrbAlınan.Focus();
            txtrbAlınan.SelectAll();
        }

        private void lblR2_Click(object sender, EventArgs e)
        {
            txtrebuy.Text = lblR2.Text;
            txtrbAlınan.Focus();
            txtrbAlınan.SelectAll();
        }

        private void lblR3_Click(object sender, EventArgs e)
        {
            txtrebuy.Text = lblR3.Text;
            txtrbAlınan.Focus();
            txtrbAlınan.SelectAll();
        }

        private void lblR4_Click(object sender, EventArgs e)
        {
            txtrebuy.Text = lblR4.Text;
            txtrbAlınan.Focus();
            txtrbAlınan.SelectAll();
        }

        private void lblR5_Click(object sender, EventArgs e)
        {
            txtrebuy.Text = lblR5.Text;
            txtrbAlınan.Focus();
            txtrbAlınan.SelectAll();
        }

        private void lblR6_Click(object sender, EventArgs e)
        {
            txtrebuy.Text = lblR5.Text;
            txtrbAlınan.Focus();
            txtrbAlınan.SelectAll();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (btnOK.Text != @"Update")
            {
                KayitGir();
            }
            else
            {
                UpdateRecord();
            }
            
        }

        private void UpdateRecord()
        {
            using (var conn = DbConnection.Con)
            {
                using (var cmd = new MySqlCommand("spTurnuva_Rebuy_update;", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    
                    cmd.Parameters.Add(new MySqlParameter("p_re_buy", txtrebuy.Text));
                    cmd.Parameters.Add(new MySqlParameter("p_re_entry", txtReEntry.Text));
                    cmd.Parameters.Add(new MySqlParameter("p_re_buy_paid_amount", txtrbAlınan.Text));
                    cmd.Parameters.Add(new MySqlParameter("p_re_entry_paid_amount", txtReentryAlınan.Text));
                    cmd.Parameters.Add(new MySqlParameter("p_score", txtScore.Text));
                    cmd.Parameters.Add(new MySqlParameter("p_recordID", RecordID));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                    Close();

                }
            }
        }

        private void KayitGir()
        {
            using (var conn = DbConnection.Con)
            {
                using (var cmd = new MySqlCommand("spTurnuva_new_Rebuy;", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.Add(new MySqlParameter("p_player", txtclient.Text));
                    cmd.Parameters.Add(new MySqlParameter("p_turnuva", TurnuvaAdi));
                    cmd.Parameters.Add(new MySqlParameter("p_masa", txtmasa.Text));
                    cmd.Parameters.Add(new MySqlParameter("p_timestamp", DateTime.Now));
                    cmd.Parameters.Add(new MySqlParameter("p_katilim_tarihi", Convert.ToDateTime(labelControl4.Text)));
                    cmd.Parameters.Add(new MySqlParameter("p_re_buy", txtrebuy.Text));
                    cmd.Parameters.Add(new MySqlParameter("p_re_entry", txtReEntry.Text));
                    cmd.Parameters.Add(new MySqlParameter("p_re_buy_paid_amount", txtrbAlınan.Text));
                    cmd.Parameters.Add(new MySqlParameter("p_re_entry_paid_amount", txtReentryAlınan.Text));
                    cmd.Parameters.Add(new MySqlParameter("p_score", txtScore.Text));
                    cmd.Parameters.Add(new MySqlParameter("p_turnuva_ID", TurnuvaId));
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
                txtrbAlınan.Text = txtrebuy.Text;
            }
            else
            {
                txtrbAlınan.Focus();
                txtrbAlınan.SelectAll();
            }
        }
    }
}