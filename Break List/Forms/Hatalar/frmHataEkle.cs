using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using Break_List.Properties;

namespace Break_List.Forms.Hatalar
{

    public partial class FrmHataEkle : XtraForm
    {
        public string PersonelId { get; set; }
        private MySqlConnection _con = new MySqlConnection(Settings.Default.livegameConnectionString2);
        private MySqlCommand _cmd;
        public FrmHataEkle()
        {
            InitializeComponent();
        }

        private void frmHataEkle_Load(object sender, EventArgs e)
        {
            labelControl1.Text = PersonelId; 
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if(dateEdit1.EditValue != null)
            {
                _cmd = new MySqlCommand("INSERT INTO lghata(Tarih, OVP,UNP,CRDH,LGE,CLE,WSB,MSD,personelID,aciklama) VALUES(@Tarih, @OVP,@UNP,@CRDH,@LGE,@CLE,@WSB,@MSD,@personelID,@aciklama)", _con);

                _cmd.Parameters.Add("@Tarih", MySqlDbType.DateTime);
                _cmd.Parameters.Add("@OVP", MySqlDbType.TinyText);
                _cmd.Parameters.Add("@UNP", MySqlDbType.TinyText);
                _cmd.Parameters.Add("@CRDH", MySqlDbType.TinyText);
                _cmd.Parameters.Add("@LGE", MySqlDbType.TinyText);
                _cmd.Parameters.Add("@CLE", MySqlDbType.TinyText);
                _cmd.Parameters.Add("@WSB", MySqlDbType.TinyText);
                _cmd.Parameters.Add("@MSD", MySqlDbType.TinyText);
                _cmd.Parameters.Add("@personelID", MySqlDbType.VarChar, 45);
                _cmd.Parameters.Add("@aciklama", MySqlDbType.VarChar, 500);
                _cmd.Parameters["@Tarih"].Value = Convert.ToDateTime(dateEdit1.EditValue.ToString());
                _cmd.Parameters["@OVP"].Value = checkEdit1.EditValue.ToString();
                _cmd.Parameters["@UNP"].Value = checkEdit2.EditValue.ToString();
                _cmd.Parameters["@CRDH"].Value = checkEdit3.EditValue.ToString();
                _cmd.Parameters["@LGE"].Value = checkEdit4.EditValue.ToString();
                _cmd.Parameters["@CLE"].Value = checkEdit5.EditValue.ToString();
                _cmd.Parameters["@WSB"].Value = checkEdit6.EditValue.ToString();
                _cmd.Parameters["@MSD"].Value = checkEdit7.EditValue.ToString();
                _cmd.Parameters["@personelID"].Value = labelControl1.Text;
                _cmd.Parameters["@aciklama"].Value = textEdit1.Text;
                _con.Open();
                _cmd.ExecuteNonQuery();
                _con.Close();
                              

            }
            
           
            else
            {
                const string caption = "Hata Yaptınız";
                const string message = "Tarih girmeden hata raporu gıremezsiniz!!! ";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.OK)
                {
                    dateEdit1.Focus();

                }
            }
            
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (dateEdit1.EditValue != null)
            {
                simpleButton1.DialogResult = DialogResult.OK;
            }
        }
    }
}