using System;
using System.Data;
using Break_List.Class;
using MySql.Data.MySqlClient;

namespace Break_List.Forms.Personel
{
    public partial class FrmEgitimGirisi : DevExpress.XtraEditors.XtraForm
    {
        public int PersonelId { get; set;}
        public FrmEgitimGirisi()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = DbConnection.Con)
            {
                using (MySqlCommand cmd = new MySqlCommand("spInsertEgitim;", con)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    DateTime tarih = Convert.ToDateTime(dateEdit1.EditValue);
                    int personelId = PersonelId;
                    string egitim = textEdit1.Text;
                    string aciklama = memoEdit2.Text;
                    string egitimveren = textEdit2.Text;
                    string sonuc = memoEdit1.Text;
                    cmd.Parameters.Add(new MySqlParameter("tarih", tarih));
                    cmd.Parameters.Add(new MySqlParameter("personelID", personelId));
                    cmd.Parameters.Add(new MySqlParameter("egitim", egitim));
                    cmd.Parameters.Add(new MySqlParameter("aciklama", aciklama));
                    cmd.Parameters.Add(new MySqlParameter("egitimveren", egitimveren));
                    cmd.Parameters.Add(new MySqlParameter("sonuc", sonuc));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                }
            }
        }
    }
}