using System;
using System.Data;
using MySql.Data.MySqlClient;
using Break_List.Properties;

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
            using (MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                using (MySqlCommand mySqlCommand = new MySqlCommand("spInsertEgitim;", mySqlConnection)
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
                    mySqlCommand.Parameters.Add(new MySqlParameter("tarih", tarih));
                    mySqlCommand.Parameters.Add(new MySqlParameter("personelID", personelId));
                    mySqlCommand.Parameters.Add(new MySqlParameter("egitim", egitim));
                    mySqlCommand.Parameters.Add(new MySqlParameter("aciklama", aciklama));
                    mySqlCommand.Parameters.Add(new MySqlParameter("egitimveren", egitimveren));
                    mySqlCommand.Parameters.Add(new MySqlParameter("sonuc", sonuc));
                    mySqlConnection.Open();
                    mySqlCommand.ExecuteNonQuery();
                    
                    mySqlConnection.Close();
                }
            }
        }
    }
}