using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using Break_List.Properties;

namespace Break_List.Forms.Hatalar
{

    public partial class frmHataEkle : XtraForm
    {
        public string personelID { get; set; }
        private MySqlConnection con = new MySqlConnection(Settings.Default.livegameConnectionString2);
        private MySqlCommand cmd;
        public frmHataEkle()
        {
            InitializeComponent();
        }

        private void frmHataEkle_Load(object sender, EventArgs e)
        {
            labelControl1.Text = personelID; 
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if(dateEdit1.EditValue != null)
            {
                cmd = new MySqlCommand("INSERT INTO lghata(Tarih, OVP,UNP,CRDH,LGE,CLE,WSB,MSD,personelID,aciklama) VALUES(@Tarih, @OVP,@UNP,@CRDH,@LGE,@CLE,@WSB,@MSD,@personelID,@aciklama)", con);

                cmd.Parameters.Add("@Tarih", MySqlDbType.DateTime);
                cmd.Parameters.Add("@OVP", MySqlDbType.TinyText);
                cmd.Parameters.Add("@UNP", MySqlDbType.TinyText);
                cmd.Parameters.Add("@CRDH", MySqlDbType.TinyText);
                cmd.Parameters.Add("@LGE", MySqlDbType.TinyText);
                cmd.Parameters.Add("@CLE", MySqlDbType.TinyText);
                cmd.Parameters.Add("@WSB", MySqlDbType.TinyText);
                cmd.Parameters.Add("@MSD", MySqlDbType.TinyText);
                cmd.Parameters.Add("@personelID", MySqlDbType.VarChar, 45);
                cmd.Parameters.Add("@aciklama", MySqlDbType.VarChar, 500);
                cmd.Parameters["@Tarih"].Value = Convert.ToDateTime(dateEdit1.EditValue.ToString());
                cmd.Parameters["@OVP"].Value = checkEdit1.EditValue.ToString();
                cmd.Parameters["@UNP"].Value = checkEdit2.EditValue.ToString();
                cmd.Parameters["@CRDH"].Value = checkEdit3.EditValue.ToString();
                cmd.Parameters["@LGE"].Value = checkEdit4.EditValue.ToString();
                cmd.Parameters["@CLE"].Value = checkEdit5.EditValue.ToString();
                cmd.Parameters["@WSB"].Value = checkEdit6.EditValue.ToString();
                cmd.Parameters["@MSD"].Value = checkEdit7.EditValue.ToString();
                cmd.Parameters["@personelID"].Value = labelControl1.Text;
                cmd.Parameters["@aciklama"].Value = textEdit1.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                              

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