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
    public partial class FrmMaasArtisi : XtraForm
    {
        public string PersonelId { get; set; }
        public string UserName { get; set; }
        public string PersonelName{ get; set; }
        private readonly MySqlConnection _con = new MySqlConnection(Settings.Default.livegameConnectionString2);
        private MySqlCommand _cmd;
        private MySqlCommand _cmd2;
        private FileStream _fs;
        private BinaryReader _br;
        public FrmMaasArtisi()
        {
            InitializeComponent();

        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if(comboBoxEdit1.Text == @"Tip")
            {
                try
                {
                    try
                    {
                        if (txtMaas.Text.Length <= 0 || btnSec.Text.Length <= 0)
                        {
                            MessageBox.Show(@"Döküman Eklenmedi", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        else
                        {
                            string fileName = btnSec.Text;
                            _fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                            _br = new BinaryReader(_fs);
                            var imageData = _br.ReadBytes((int)_fs.Length);
                            _br.Close();
                            _fs.Close();
                            
                            _cmd = new MySqlCommand("INSERT INTO maaslar(resourceID, tarih, tip, CreatedBy,Dokuman, Onaylayan, ArtisNedeni, Kategori) VALUES(@resourceID, @tarih, @tip, @CreatedBy, @Dokuman, @Onaylayan, @ArtisNedeni,@Kategori)", _con);
                            _cmd.Parameters.Add("@resourceID", MySqlDbType.VarChar, 45);
                            _cmd.Parameters.Add("@tarih", MySqlDbType.DateTime);
                            _cmd.Parameters.Add("@tip", MySqlDbType.Decimal);
                            _cmd.Parameters.Add("@CreatedBy", MySqlDbType.VarChar, 45);
                            _cmd.Parameters.Add("@Dokuman", MySqlDbType.Blob);
                            _cmd.Parameters.Add("@Onaylayan", MySqlDbType.VarChar, 45);
                            _cmd.Parameters.Add("@ArtisNedeni", MySqlDbType.VarChar, 2000);
                            _cmd.Parameters.Add("@Kategori", MySqlDbType.VarChar, 45);
                            _cmd.Parameters["@resourceID"].Value = PersonelId;
                            _cmd.Parameters["@tarih"].Value = Convert.ToDateTime(dtTarih.EditValue.ToString());
                            _cmd.Parameters["@tip"].Value = Convert.ToDecimal(txtMaas.Text);
                            _cmd.Parameters["@CreatedBy"].Value = labelControl5.Text;
                            _cmd.Parameters["@Dokuman"].Value = imageData;
                            _cmd.Parameters["@Onaylayan"].Value = txtOnay.Text;
                            _cmd.Parameters["@ArtisNedeni"].Value = memoEdit1.Text;
                            _cmd.Parameters["@Kategori"].Value = comboBoxEdit1.EditValue.ToString();
                            _cmd2 = new MySqlCommand("INSERT audit (yapilan, computer, tarih, user) VALUES(@yapilan, @computer, @tarih, @user)", _con);
                            string yapilan = PersonelName + " isimli kişiye " + txtMaas.Text +" oraninda tip artisi yapilmis. ";
                            _cmd2.Parameters.Add(new MySqlParameter("@yapilan", yapilan));
                            _cmd2.Parameters.Add(new MySqlParameter("@computer", Environment.MachineName));
                            _cmd2.Parameters.Add(new MySqlParameter("@tarih", DateTime.Now));
                            _cmd2.Parameters.Add(new MySqlParameter("@user", UserName));
                            _con.Open();
                           
                        }
                        if (_cmd.ExecuteNonQuery() > 0)
                        {
                            _cmd2.ExecuteNonQuery();
                        }
                        _con.Close();

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
                finally
                {
                    if (_con.State == ConnectionState.Open)
                    {
                        _con.Close();
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
                        if ((txtMaas.Text.Length <= 0 || btnSec.Text.Length <= 0))
                        {
                            MessageBox.Show(@"Döküman Eklenmedi", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        else
                        {
                            string fileName = btnSec.Text;
                            _fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                            _br = new BinaryReader(_fs);
                            var imageData = _br.ReadBytes((int)_fs.Length);
                            _br.Close();
                            _fs.Close();
                            
                            _cmd = new MySqlCommand("INSERT INTO maaslar(resourceID, tarih, maas, CreatedBy,Dokuman, Onaylayan, ArtisNedeni, Kategori) VALUES(@resourceID, @tarih, @maas, @CreatedBy, @Dokuman, @Onaylayan, @ArtisNedeni,@Kategori)", _con);
                            _cmd.Parameters.Add("@resourceID", MySqlDbType.VarChar, 45);
                            _cmd.Parameters.Add("@tarih", MySqlDbType.DateTime);
                            _cmd.Parameters.Add("@maas", MySqlDbType.Decimal);
                            _cmd.Parameters.Add("@CreatedBy", MySqlDbType.VarChar, 45);
                            _cmd.Parameters.Add("@Dokuman", MySqlDbType.Blob);
                            _cmd.Parameters.Add("@Onaylayan", MySqlDbType.VarChar, 45);
                            _cmd.Parameters.Add("@ArtisNedeni", MySqlDbType.VarChar, 2000);
                            _cmd.Parameters.Add("@Kategori", MySqlDbType.VarChar, 45);
                            _cmd.Parameters["@resourceID"].Value = PersonelId;
                            _cmd.Parameters["@tarih"].Value = Convert.ToDateTime(dtTarih.EditValue.ToString());
                            _cmd.Parameters["@maas"].Value = Convert.ToDecimal(txtMaas.Text);
                            _cmd.Parameters["@CreatedBy"].Value = labelControl5.Text;
                            _cmd.Parameters["@Dokuman"].Value = imageData;
                            _cmd.Parameters["@Onaylayan"].Value = txtOnay.Text;
                            _cmd.Parameters["@ArtisNedeni"].Value = memoEdit1.Text;
                            _cmd.Parameters["@Kategori"].Value = comboBoxEdit1.EditValue.ToString();

                            _cmd2 = new MySqlCommand("INSERT audit (yapilan, computer, tarih, user) VALUES(@yapilan, @computer, @tarih, @user)", _con);
                            string yapilan = PersonelName + " isimli kişiye " + txtMaas.Text + " oraninda maas artisi yapilmis. ";
                            _cmd2.Parameters.Add(new MySqlParameter("@yapilan", yapilan));
                            _cmd2.Parameters.Add(new MySqlParameter("@computer", Environment.MachineName));
                            _cmd2.Parameters.Add(new MySqlParameter("@tarih", DateTime.Now));
                            _cmd2.Parameters.Add(new MySqlParameter("@user", UserName));
                            _con.Open();

                        }
                        if (_cmd.ExecuteNonQuery() > 0)
                        {
                            _cmd2.ExecuteNonQuery();
                        }
                        _con.Close();

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
                finally
                {
                    if (_con.State == ConnectionState.Open)
                    {
                        _con.Close();
                        Close();
                    }
                }
            }
            
        }

        private void frmMaasArtisi_Load(object sender, EventArgs e)
        {
            labelControl4.Text = PersonelId;
            labelControl5.Text = UserName;
        }
        
        private void textEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Filter = @"Image files | *.jpg"
                };
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;
                btnSec.Text = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}