using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using Break_List.Properties;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;

namespace Break_List.Forms.Admin
{
    public partial class FrmChangePassword : XtraForm
    {
        public FrmChangePassword()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textEdit2.Text == textEdit3.Text)
            {
                ChangePassword();
                XtraMessageBox.Show("Sifreniz Degistirildi", "SIfre");
                Close();
            }
            else
            {
                XtraMessageBox.Show("Girdiğiniz şifre tutmadı", "Tekrar Deneyin");
                textEdit2.Focus();
                textEdit2.SelectAll();
            }
        }
        private const string ConString = "server=192.168.0.187;user id=hakan;password=26091974;persistsecurityinfo=True;database=livegame";
        public string UserName { get; set; }
        private void ChangePassword()
        {
            using (var conn = new MySqlConnection(ConString))
            {

                var cmd = new MySqlCommand("newspUserUpdate;", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new MySqlParameter("pwd", textEdit2.Text));
                cmd.Parameters.Add(new MySqlParameter("UserName", UserName));
                
                conn.Open();
                cmd.ExecuteNonQuery();
                try
                {
                    conn.Close();
                }
                catch (DbException dbException)
                {
                    MessageBox.Show(dbException.ToString(), @"Database Problemi");
                }
            }
        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = textEdit2.Text == textEdit3.Text;
        }
    }
}