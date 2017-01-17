using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net.Mail;
using System.Net;
using Break_List.Properties;
using MySql.Data.MySqlClient;

namespace Break_List.Forms
{
    public partial class FrmLostPassword : XtraForm
    {
        public FrmLostPassword()
        {
            InitializeComponent();
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Isim { get; set; }
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if(textEdit1.Text == "")
            {
                XtraMessageBox.Show("Email adresinizi giriniz");
                simpleButton1.DialogResult = DialogResult.None;
                textEdit1.Focus();
            }
            else
            {
                Email = textEdit1.Text;

                var str = Settings.Default.livegameConnectionString2;
                var query =
                    $"select * from users where email = '{textEdit1.Text}'";
                var con = new MySqlConnection(str);
                var cmd = new MySqlCommand(query, con);
                con.Open();
                var dbr = cmd.ExecuteReader();
                var count = 0;
                while ((dbr != null) && dbr.Read())
                    count = count + 1;
                switch (count)
                {
                    case 1:
                        if (dbr != null)
                        {
                            Password = dbr["Password"].ToString();
                            Isim = dbr["FullName"].ToString();
                        }
                        var fromAddress = new MailAddress("hkcsmng@gmail.com", "Viva Casino Management Programı");
                        var toAddress = new MailAddress(Email, Isim);
                        const string fromPassword = "26091974-Emre!";
                        const string subject = "Şifrenizi bir yere not edin";
                        string body = "Sayın " + Isim + " şifreniz: " + Password;

                        var smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                        };
                        using (var message = new MailMessage(fromAddress, toAddress)
                        {
                            Subject = subject,
                            Body = body
                        })
                        {
                            smtp.Send(message);
                        }

                        simpleButton1.DialogResult = DialogResult.OK;
                        break;
                    case 0:
                        XtraMessageBox.Show(@"Böyle bir hesaba rastlanamadı. Email adresini kontrol et.", @"Oooopppsss");
                        break;
                }
            }
            
            
        }

       
    }
}