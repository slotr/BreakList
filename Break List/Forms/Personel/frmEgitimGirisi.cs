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
    public partial class frmEgitimGirisi : DevExpress.XtraEditors.XtraForm
    {
        public int personelID { get; set;}
        public frmEgitimGirisi()
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
                    int _personelID = personelID;
                    string egitim = textEdit1.Text;
                    string aciklama = memoEdit2.Text;
                    string egitimveren = textEdit2.Text;
                    string sonuc = memoEdit1.Text;
                    mySqlCommand.Parameters.Add(new MySqlParameter("tarih", tarih));
                    mySqlCommand.Parameters.Add(new MySqlParameter("personelID", _personelID));
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