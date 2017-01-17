using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Break_List.Forms.Personel;
using Break_List.Properties;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;

namespace Break_List.Forms.Vacations
{
    public partial class FrmNewVacation : XtraForm
    {
        public string PersonelId { get; set; }
        public string UserName { get; set; }
        public string PersonelName { get; set; }
        private readonly MySqlConnection _con = new MySqlConnection(Settings.Default.livegameConnectionString2);
        private MySqlCommand _cmd;
        private FileStream _fs;
        private BinaryReader _br;
        public FrmNewVacation()
        {
            InitializeComponent();

            
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog()
                {
                    Filter = @"Image files | *.jpg"
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    btnresim.Text = openFileDialog.FileName;
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
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
                    if ((labelControl.Text.Length <= 0 || btnresim.Text.Length <= 0))
                    {
                        MessageBox.Show(@"Döküman Eklenmedi", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        string fileName = btnresim.Text;
                        _fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                        _br = new BinaryReader(_fs);
                        var imageData = _br.ReadBytes((int)_fs.Length);
                        _br.Close();
                        _fs.Close();
                        
                        _cmd = new MySqlCommand("INSERT INTO vacations(ResourceID, StartDate,EndDate,VacationType, Dokuman) VALUES(@ResourceID, @StartDate,@EndDate,@VacationType, @Dokuman)", _con);
                        _cmd.Parameters.Add("@ResourceID", MySqlDbType.VarChar, 45);
                        _cmd.Parameters.Add("@StartDate", MySqlDbType.DateTime);
                        _cmd.Parameters.Add("@EndDate", MySqlDbType.DateTime);
                        _cmd.Parameters.Add("@VacationType", MySqlDbType.VarChar, 45);
                        _cmd.Parameters.Add("@Dokuman", MySqlDbType.Blob);                       
                        _cmd.Parameters["@ResourceID"].Value = PersonelId;
                        _cmd.Parameters["@StartDate"].Value = Convert.ToDateTime(dtStart.EditValue.ToString());
                        _cmd.Parameters["@EndDate"].Value = Convert.ToDateTime(dtEnd.EditValue.ToString());
                        _cmd.Parameters["@VacationType"].Value = cmbTip.EditValue.ToString();
                        _cmd.Parameters["@Dokuman"].Value = imageData;
                        _con.Open();

                    }
                    if (_cmd.ExecuteNonQuery() > 0)
                    {

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

        private void frmNewVacation_Load(object sender, EventArgs e)
        {
            labelControl.Text = PersonelName;
        }

        private void cmbTip_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dtEnd_EditValueChanged(object sender, EventArgs e)
        {
            long istenenSure = FrmPersonelDetails.DateTimeUtil.DateDiff(FrmPersonelDetails.DateInterval.Day, Convert.ToDateTime(dtStart.EditValue), Convert.ToDateTime(dtEnd.EditValue));
            long kalanSure = Convert.ToInt32(lblKalan.Text);
            long verilecekIzinSuresi = istenenSure;
            lblverilecekTotal.Text = verilecekIzinSuresi.ToString();
            if (istenenSure > kalanSure)
            {
                if(cmbTip.Text == @"Ücretli İzin")
                {
                    if (kalanSure == 0)
                    {
                        XtraMessageBox.Show(PersonelName + " isimli kişinin Ücretli İzin hakkı Bulunmamaktadır.", "Yetersiz izin hakkı");
                    }
                    else
                    {

                        DialogResult result = MessageBox.Show(PersonelName + @" isimli kişiye sadece " + kalanSure + @"gün ücretli izin verebilirsiniz." + @"\r\n" + @"Bu kişiye daha fazla izin vermek istiyorsanız" + @"\r\n" + @"Açılacak olan kutudan gerekli bilgileri doldurun.", @"Warning",
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