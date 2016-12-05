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
using System.ComponentModel.DataAnnotations;
using System.IO;
using DevExpress.XtraLayout.Helpers;
using DevExpress.XtraLayout;
using MySql.Data.MySqlClient;
using Break_List.Properties;
using static Break_List.Forms.Personel.FrmPersonelDetails;

namespace Break_List
{
    public partial class frmNewVacation : DevExpress.XtraEditors.XtraForm
    {
        public string personelID { get; set; }
        public string UserName { get; set; }
        public string personelName { get; set; }
        private MySqlConnection con = new MySqlConnection(Settings.Default.livegameConnectionString2);
        private MySqlCommand cmd;
        private FileStream fs;
        private BinaryReader br;
        public frmNewVacation()
        {
            InitializeComponent();

            
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Filter = "Image files | *.jpg"
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.btnresim.Text = openFileDialog.FileName.ToString();
                    this.pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if ((labelControl.Text.Length <= 0 ? true : btnresim.Text.Length <= 0))
                    {
                        MessageBox.Show("Döküman Eklenmedi", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        string FileName = btnresim.Text;
                        byte[] ImageData;
                        fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                        br = new BinaryReader(fs);
                        ImageData = br.ReadBytes((int)fs.Length);
                        br.Close();
                        fs.Close();
                        
                        cmd = new MySqlCommand("INSERT INTO vacations(ResourceID, StartDate,EndDate,VacationType, Dokuman) VALUES(@ResourceID, @StartDate,@EndDate,@VacationType, @Dokuman)", con);
                        cmd.Parameters.Add("@ResourceID", MySqlDbType.VarChar, 45);
                        cmd.Parameters.Add("@StartDate", MySqlDbType.DateTime);
                        cmd.Parameters.Add("@EndDate", MySqlDbType.DateTime);
                        cmd.Parameters.Add("@VacationType", MySqlDbType.VarChar, 45);
                        cmd.Parameters.Add("@Dokuman", MySqlDbType.Blob);                       
                        cmd.Parameters["@ResourceID"].Value = personelID;
                        cmd.Parameters["@StartDate"].Value = Convert.ToDateTime(dtStart.EditValue.ToString());
                        cmd.Parameters["@EndDate"].Value = Convert.ToDateTime(dtEnd.EditValue.ToString());
                        cmd.Parameters["@VacationType"].Value = cmbTip.EditValue.ToString();
                        cmd.Parameters["@Dokuman"].Value = ImageData;
                        con.Open();

                    }
                    if (cmd.ExecuteNonQuery() > 0)
                    {

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

        private void frmNewVacation_Load(object sender, EventArgs e)
        {
            labelControl.Text = personelName;
        }

        private void cmbTip_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dtEnd_EditValueChanged(object sender, EventArgs e)
        {
            long istenenSure = Break_List.Forms.Personel.FrmPersonelDetails.DateTimeUtil.DateDiff(DateInterval.Day, Convert.ToDateTime(dtStart.EditValue), Convert.ToDateTime(dtEnd.EditValue));
            long kalanSure = Convert.ToInt32(lblKalan.Text.ToString());
            long verilecekIzinSuresi = istenenSure;
            lblverilecekTotal.Text = verilecekIzinSuresi.ToString();
            if (istenenSure > kalanSure)
            {
                if(cmbTip.Text == "Ücretli İzin")
                {
                    if (kalanSure == 0)
                    {
                        XtraMessageBox.Show(personelName + " isimli kişinin Ücretli İzin hakkı Bulunmamaktadır.", "Yetersiz izin hakkı");
                    }
                    else
                    {

                        DialogResult result = MessageBox.Show(personelName + " isimli kişiye sadece " + kalanSure + "gün ücretli izin verebilirsiniz." + "\r\n" + "Bu kişiye daha fazla izin vermek istiyorsanız" + "\r\n" + "Açılacak olan kutudan gerekli bilgileri doldurun.", "Warning",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            cmbExtraIzinTipi.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                            dtExtraStart.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                            dtExtraEnd.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                            lblExtraIzin.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        }
                        else if (result == DialogResult.No)
                        {
                            //code for No
                        }
                        else if (result == DialogResult.Cancel)
                        {
                            //code for Cancel
                        }
                        
                    }
                }

                else
                {

                }
               
            }
            if(Convert.ToDateTime(dtEnd.EditValue) <= Convert.ToDateTime(dtStart.EditValue))
            {
                XtraMessageBox.Show("İzin bitiş tarihinde hata yaptınız.", "Tarih Hatasi");
            }
        }

        private void dtStart_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}