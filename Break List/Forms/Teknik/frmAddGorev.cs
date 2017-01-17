using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Windows.Forms;
using Break_List.Properties;
using DevExpress.Xpo.Metadata.Helpers;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;


namespace Break_List.Forms.Teknik
{
    public partial class FrmAddGorev : XtraForm
    {
        public string User { private get; set; }
        public string Departman { private get; set; }
        public bool YeniGorev { private get; set; }
        public int UpdateRowId { get; set; }
        public string Email { get; set; }

        public FrmAddGorev()
        {
            InitializeComponent();
            GetPersonel();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!YeniGorev)
                    {
                        if (!checkEdit1.Checked)
                        {
                            GoreviBitir();
                        }

                        else
                        {
                            if (comboBoxEdit1.Text == @"Kime")
                            {
                                XtraMessageBox.Show("Görevi devredeceğiniz kişiyi seçin");
                            }

                            else
                            {
                                GoreviUpdateEt();
                            }
                        }
                    }


            else
            {
                YeniGorevEkle();
            }
                
        }

        private void GoreviUpdateEt()
        {
            using (var conn = new MySqlConnection(ConString))
            {

                var cmd = new MySqlCommand("spTeknikGoreviUpdateEt;", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new MySqlParameter("rowid", UpdateRowId));
                cmd.Parameters.Add(new MySqlParameter("personel", User));
                cmd.Parameters.Add(new MySqlParameter("paciklama", memoEdit1.Text));
                cmd.Parameters.Add(new MySqlParameter("pkime", comboBoxEdit1.EditValue));
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

        private void GoreviBitir()
        {
            
            using (var conn = new MySqlConnection(ConString))
            {

                var cmd = new MySqlCommand("spTeknikGorevBitir;", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new MySqlParameter("rowid", UpdateRowId));
                cmd.Parameters.Add(new MySqlParameter("personel", User));
                cmd.Parameters.Add(new MySqlParameter("paciklama", memoEdit1.Text));
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

        private const string ConString = "server=192.168.0.187;user id=hakan;password=26091974;persistsecurityinfo=True;database=livegame";
        private void YeniGorevEkle()
        {
            var tarih = DateTime.Now;
            using (var conn = new MySqlConnection(ConString))
            {
                using (var cmd = new MySqlCommand("spTeknikInsertGorev;", conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.Add(new MySqlParameter("puser", User));
                    cmd.Parameters.Add(new MySqlParameter("pbaslangic", tarih));
                    cmd.Parameters.Add(new MySqlParameter("pdepartman", Departman));
                    cmd.Parameters.Add(new MySqlParameter("pgorev", memoEdit1.Text));
                    cmd.Parameters.Add(new MySqlParameter("pkime", comboBoxEdit1.EditValue));
                    cmd.Parameters.Add(new MySqlParameter("pDueDate", dateEdit1.DateTime));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                    Close();
                }
            }
            EmailGonder();
        }

        private void EmailGonder()
        {
            var gorevTarihi = $@"{DateTime.Today:dd/MM/yyyy}";
            var bitisTarihi = $@"{dateEdit1.DateTime:dd/MM/yyyy}";
            var fromAddress = new MailAddress("hkcsmng@gmail.com", "Viva Casino Görev Yöneticisi");
            var toAddress = new MailAddress(Email, comboBoxEdit1.Text);
            const string fromPassword = "26091974-Emre!";
            const string subject = "Yeni Görev ataması";
            var body = @"<html><body style=""color:#34495e"">" + @"<h2 style=""color:#34495e"">" + "Sayın " + comboBoxEdit1.Text + "</h2>" + "<br />"
                + @" <p>Size " + User+ " tarafından bir görev atandı. Atanan görev detayları ve bitirlmesi gereken süre aşağıda görüldüğü gibidir. Lütfen görevi geciktirmeden tamamlayın." + "<br />"+"<hr></hr>"+ "<br />"+
                @"<strong>" + "Görev: " + memoEdit1.Text + "</strong><br />" +
                "Veriliş Tarihi: " + gorevTarihi + "<br />" +
                "<strong>Son süre: " + bitisTarihi + "</strong>"+"<br />" +
                "<br />" + "<br />" +
                "<small>Not: Görevin size ait olmadığını düşünüyorsanız sisteme giriş yapıp değişiklikleri kaydedin.</small>" + "<br />" +
                "<br />" + "<br />" +
                @"<h4>" + User+ "</h2>"+"</body></html>";
            AlternateView htmlView =
            AlternateView.CreateAlternateViewFromString(body,null, MediaTypeNames.Text.Html);
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
                AlternateViews = { htmlView },
                IsBodyHtml = true,
                Body = body,
                Priority = MailPriority.High
               
            })
            {
                smtp.Send(message);
            }
        }

       
        private void GetPersonel() // Yeni Kayit Olusturulurken Aliyor
        {

            var connectionString = Settings.Default.livegameConnectionString2;
            using (var cnn = new MySqlConnection(connectionString))
            using (var cmd = cnn.CreateCommand())
            {
                cnn.Open();
                cmd.CommandText = "Select FullName, email from users";
                cmd.CommandType = CommandType.Text;
                var dt = new DataTable();
                using (var da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {

                        comboBoxEdit1.Properties.Items.Add(row["FullName"]);

                    }

                    comboBoxEdit1.Properties.Sorted = true;


                }
            }

        }
        private void FrmAddGorev_Load(object sender, EventArgs e)
        {
            if (YeniGorev == false)
            {
                labelControl1.Visible = false;
                comboBoxEdit1.Visible = false;
                labelControl3.Visible = false;
                dateEdit1.Visible = false;
                checkEdit1.Visible = true;
                labelControl2.Text = @"Açıklama yapınız";
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                comboBoxEdit1.Visible = true;
                labelControl1.Visible = true;
                labelControl1.Text = @"Görevi Devret";
                labelControl1.Text = @"Görevi Devredeceğiniz kişiyi seçin.";
            }
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (dateEdit1.DateTime < DateTime.Today)
            {
                XtraMessageBox.Show("Vermiş olduğunuz görevin bitiş tarihi bugünün tarihinden küçük olamaz", "Hile Yapma",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateEdit1.DateTime = DateTime.Today;
            }
        }

        private void GetEmail()
        {
            var conn = new MySqlConnection(ConString);
            var command = conn.CreateCommand();
            command.CommandText = $"SELECT email, FullName from users WHERE FullName ='{comboBoxEdit1.Text}'";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"There were an Error", ex.ToString());
            }
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Email = reader["email"].ToString();
                
            }
            conn.Close();
          

        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetEmail();
        }
    }
}