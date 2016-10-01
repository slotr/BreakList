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

namespace Break_List
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textEdit1.Text != string.Empty)
                {
                    if (textEdit2.Text != string.Empty)
                    {
                        var str = Settings.Default.livegameConnectionString2;
                        var query = string.Format("select * from users where UserName = '{0}'and Password = '{1}'",
                            textEdit1.Text, textEdit2.Text);
                        var con = new MySqlConnection(str);
                        var cmd = new MySqlCommand(query, con);
                        con.Open();
                        var dbr = cmd.ExecuteReader();
                        var count = 0;
                        while (dbr != null && dbr.Read())
                        {
                            
                            count = count + 1;
                        }
                        if (count == 1)
                        {

                            var mainform = new frmMDIMain
                            {
                                _userNameFromLogin = textEdit1.Text
                            };
                            mainform.Show();
                            Hide();



                            con.Close();
                        }
                        else if (count > 1)
                        {
                            XtraMessageBox.Show(@"Duplicate username and password", @"Warning");
                        }
                        else
                        {
                            XtraMessageBox.Show(@" username and password incorrect", @"Warning");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(@" password empty", @"Warning");
                    }
                }

                else
                {
                    XtraMessageBox.Show(@" username empty", @"Warning");
                }


            }
            catch (Exception es)
            {
                XtraMessageBox.Show(es.Message);

            }
        }
    }
}