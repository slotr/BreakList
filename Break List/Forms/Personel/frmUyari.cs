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

namespace Break_List.Forms.Personel
{
    public partial class frmUyari : DevExpress.XtraEditors.XtraForm
    {
        public string PersonelID { get; set; }
        public frmUyari()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = DbConnection.Con)
            {
                using (MySqlCommand cmd = new MySqlCommand("spInsertUyari;", con)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    DateTime tarih = Convert.ToDateTime(dateEdit1.EditValue);
                    string personelId = PersonelID;
                    string statu = textEdit1.Text;
                    string aciklama = memoEdit1.Text;
                    cmd.Parameters.Add(new MySqlParameter("tarih", tarih));
                    cmd.Parameters.Add(new MySqlParameter("personelID", personelId));
                    cmd.Parameters.Add(new MySqlParameter("statu", statu));
                    cmd.Parameters.Add(new MySqlParameter("aciklama", aciklama));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Dispose();
                }
            }
        }
    }
}