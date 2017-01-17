using System;
using System.Windows.Forms;
using Break_List.Class;
using Break_List.Properties;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;

namespace Break_List.Forms
{
    public partial class FrmLogin : XtraForm
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Department { get; set; }

        private static CustomProperties GetProp()
        {
            var prop = new CustomProperties();
            return prop;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DoLogin();
        }

        private void DoLogin()
        {
            try
            {
                if (textEdit1.Text != string.Empty)
                    if (textEdit2.Text != string.Empty)
                    {
                        var str = Settings.Default.livegameConnectionString2;
                        var query =
                            $"select * from users where UserName = '{textEdit1.Text}'and Password = '{textEdit2.Text}'";
                        var con = new MySqlConnection(str);
                        var cmd = new MySqlCommand(query, con);
                        con.Open();
                        var dbr = cmd.ExecuteReader();
                        var count = 0;
                        while ((dbr != null) && dbr.Read())
                            count = count + 1;
                        if (count == 1)
                        {
                            var prop = GetProp();
                            prop.UserName = textEdit1.Text;
                            prop.Logedin = true;
                            prop.ComputerName = Environment.MachineName;
                            var mainform = new FrmMdiMain
                            {
                                UserNameFromLogin = prop.UserName
                            };
                            mainform.Show();
                            Hide();
                            con.Close();
                            con.Dispose();
                            var str2 = Settings.Default.livegameConnectionString2;
                            var insertquery =
                                "insert into loginlog (user,loggedinat, computer) values(@user, @time,@comp)";
                            var con1 = new MySqlConnection(str2);
                            var cmdinsert = new MySqlCommand(insertquery, con1);
                            cmdinsert.Parameters.Add(new MySqlParameter("@user", textEdit1.Text));
                            cmdinsert.Parameters.Add(new MySqlParameter("@time", DateTime.Now));
                            cmdinsert.Parameters.Add(new MySqlParameter("@comp", prop.ComputerName));
                            con1.Open();
                            cmdinsert.ExecuteNonQuery();
                            con1.Close();
                            con1.Dispose();
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

                else
                    XtraMessageBox.Show(@" username empty", @"Warning");
            }
            catch (Exception es)
            {
                XtraMessageBox.Show(es.Message);
            }
        }

        private void textEdit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                DoLogin();
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            FrmLostPassword lostPassword = new FrmLostPassword();
            lostPassword.ShowDialog();
        }
    }
}