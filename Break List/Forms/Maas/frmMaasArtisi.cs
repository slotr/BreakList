using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using MySql.Data.MySqlClient;
using Break_List.Properties;

namespace Break_List.Forms.Maas
{
    public partial class frmMaasArtisi : XtraForm
    {
        public string personelID { get; set; }
        public string UserName { get; set; }
        public string personelName{ get; set; }
        private MySqlConnection con = new MySqlConnection(Settings.Default.livegameConnectionString2);
        private MySqlCommand cmd;
        private MySqlCommand cmd2;
        private FileStream fs;
        private BinaryReader br;
        public frmMaasArtisi()
        {
            InitializeComponent();

        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if(comboBoxEdit1.Text == "Tip")
            {
                try
                {
                    try
                    {
                        if ((txtMaas.Text.Length <= 0 ? true : btnSec.Text.Length <= 0))
                        {
                            MessageBox.Show("Döküman Eklenmedi", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        else
                        {
                            string FileName = btnSec.Text;
                            byte[] ImageData;
                            fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                            br = new BinaryReader(fs);
                            ImageData = br.ReadBytes((int)fs.Length);
                            br.Close();
                            fs.Close();
                            
                            cmd = new MySqlCommand("INSERT INTO maaslar(resourceID, tarih, tip, CreatedBy,Dokuman, Onaylayan, ArtisNedeni, Kategori) VALUES(@resourceID, @tarih, @tip, @CreatedBy, @Dokuman, @Onaylayan, @ArtisNedeni,@Kategori)", con);
                            cmd.Parameters.Add("@resourceID", MySqlDbType.VarChar, 45);
                            cmd.Parameters.Add("@tarih", MySqlDbType.DateTime);
                            cmd.Parameters.Add("@tip", MySqlDbType.Decimal);
                            cmd.Parameters.Add("@CreatedBy", MySqlDbType.VarChar, 45);
                            cmd.Parameters.Add("@Dokuman", MySqlDbType.Blob);
                            cmd.Parameters.Add("@Onaylayan", MySqlDbType.VarChar, 45);
                            cmd.Parameters.Add("@ArtisNedeni", MySqlDbType.VarChar, 2000);
                            cmd.Parameters.Add("@Kategori", MySqlDbType.VarChar, 45);
                            cmd.Parameters["@resourceID"].Value = personelID;
                            cmd.Parameters["@tarih"].Value = Convert.ToDateTime(dtTarih.EditValue.ToString());
                            cmd.Parameters["@tip"].Value = Convert.ToDecimal(txtMaas.Text.ToString());
                            cmd.Parameters["@CreatedBy"].Value = labelControl5.Text;
                            cmd.Parameters["@Dokuman"].Value = ImageData;
                            cmd.Parameters["@Onaylayan"].Value = txtOnay.Text;
                            cmd.Parameters["@ArtisNedeni"].Value = memoEdit1.Text;
                            cmd.Parameters["@Kategori"].Value = comboBoxEdit1.EditValue.ToString();
                            cmd2 = new MySqlCommand("INSERT audit (yapilan, computer, tarih, user) VALUES(@yapilan, @computer, @tarih, @user)", con);
                            string yapilan = personelName + " isimli kişiye " + txtMaas.Text +" oraninda tip artisi yapilmis. ";
                            cmd2.Parameters.Add(new MySqlParameter("@yapilan", yapilan));
                            cmd2.Parameters.Add(new MySqlParameter("@computer", Environment.MachineName));
                            cmd2.Parameters.Add(new MySqlParameter("@tarih", DateTime.Now));
                            cmd2.Parameters.Add(new MySqlParameter("@user", UserName));
                            con.Open();
                           
                        }
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            cmd2.ExecuteNonQuery();
                        }
                        con.Close();

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                        Close();
                    }
                }
            }
            else
            {
                try
                {
                    try
                    {
                        if ((txtMaas.Text.Length <= 0 ? true : btnSec.Text.Length <= 0))
                        {
                            MessageBox.Show("Döküman Eklenmedi", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        else
                        {
                            string FileName = btnSec.Text;
                            byte[] ImageData;
                            fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                            br = new BinaryReader(fs);
                            ImageData = br.ReadBytes((int)fs.Length);
                            br.Close();
                            fs.Close();
                            
                            cmd = new MySqlCommand("INSERT INTO maaslar(resourceID, tarih, maas, CreatedBy,Dokuman, Onaylayan, ArtisNedeni, Kategori) VALUES(@resourceID, @tarih, @maas, @CreatedBy, @Dokuman, @Onaylayan, @ArtisNedeni,@Kategori)", con);
                            cmd.Parameters.Add("@resourceID", MySqlDbType.VarChar, 45);
                            cmd.Parameters.Add("@tarih", MySqlDbType.DateTime);
                            cmd.Parameters.Add("@maas", MySqlDbType.Decimal);
                            cmd.Parameters.Add("@CreatedBy", MySqlDbType.VarChar, 45);
                            cmd.Parameters.Add("@Dokuman", MySqlDbType.Blob);
                            cmd.Parameters.Add("@Onaylayan", MySqlDbType.VarChar, 45);
                            cmd.Parameters.Add("@ArtisNedeni", MySqlDbType.VarChar, 2000);
                            cmd.Parameters.Add("@Kategori", MySqlDbType.VarChar, 45);
                            cmd.Parameters["@resourceID"].Value = personelID;
                            cmd.Parameters["@tarih"].Value = Convert.ToDateTime(dtTarih.EditValue.ToString());
                            cmd.Parameters["@maas"].Value = Convert.ToDecimal(txtMaas.Text.ToString());
                            cmd.Parameters["@CreatedBy"].Value = labelControl5.Text;
                            cmd.Parameters["@Dokuman"].Value = ImageData;
                            cmd.Parameters["@Onaylayan"].Value = txtOnay.Text;
                            cmd.Parameters["@ArtisNedeni"].Value = memoEdit1.Text;
                            cmd.Parameters["@Kategori"].Value = comboBoxEdit1.EditValue.ToString();

                            cmd2 = new MySqlCommand("INSERT audit (yapilan, computer, tarih, user) VALUES(@yapilan, @computer, @tarih, @user)", con);
                            string yapilan = personelName + " isimli kişiye " + txtMaas.Text + " oraninda maas artisi yapilmis. ";
                            cmd2.Parameters.Add(new MySqlParameter("@yapilan", yapilan));
                            cmd2.Parameters.Add(new MySqlParameter("@computer", Environment.MachineName));
                            cmd2.Parameters.Add(new MySqlParameter("@tarih", DateTime.Now));
                            cmd2.Parameters.Add(new MySqlParameter("@user", UserName));
                            con.Open();

                        }
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            cmd2.ExecuteNonQuery();
                        }
                        con.Close();

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                        Close();
                    }
                }
            }
            
        }

        private void frmMaasArtisi_Load(object sender, EventArgs e)
        {
            labelControl4.Text = personelID;
            labelControl5.Text = UserName;
        }
        
        private void textEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Filter = "Image files | *.jpg"
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.btnSec.Text = openFileDialog.FileName.ToString();
                    this.pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}