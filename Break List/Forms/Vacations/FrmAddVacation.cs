using System;
using System.Data;
using System.Windows.Forms;
using Break_List.Class;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;

namespace Break_List.Forms.Vacations
{
    public partial class FrmAddVacation : XtraForm
    {
        public string PersonelId { get; set; }
        public string PersonelName { get; set; }
        public string KalanIzin { get; set; }
        public FrmAddVacation()
        {
            InitializeComponent();}

        private void FrmAddVacation_Load(object sender, EventArgs e)
        {
            labelControl1.Text = PersonelName;
            labelControl2.Text = KalanIzin;
            spinEdit1.Properties.MaxValue = Convert.ToInt32(KalanIzin);}

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (var conn = DbConnection.Con)
            {
                var cmd = new MySqlCommand("sp_Personel_izin_ekle;", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new MySqlParameter("p_resourseid",  PersonelId));
                cmd.Parameters.Add(new MySqlParameter("p_izinsebebi", comboBoxEdit1.EditValue));
                cmd.Parameters.Add(new MySqlParameter("p_startdate", dateEdit1.EditValue));
                cmd.Parameters.Add(new MySqlParameter("p_enddate", dateEdit2.EditValue));
                cmd.Parameters.Add(new MySqlParameter("p_vacation", spinEdit1.Value));
                cmd.Parameters.Add(new MySqlParameter("p_haftatatili", spinEdit2.Value));
                cmd.Parameters.Add(new MySqlParameter("p_geneltatil", spinEdit3.Value));
                cmd.Parameters.Add(new MySqlParameter("p_ucretlimazeret", spinEdit4.Value));
                cmd.Parameters.Add(new MySqlParameter("p_ucretsiz", spinEdit5.Value));
                cmd.Parameters.Add(new MySqlParameter("p_evlilik", spinEdit6.Value));
                cmd.Parameters.Add(new MySqlParameter("p_dogum", spinEdit7.Value));
                cmd.Parameters.Add(new MySqlParameter("p_olum", spinEdit8.Value));
                cmd.Parameters.Add(new MySqlParameter("p_alacak", spinEdit9.Value));
                cmd.Parameters.Add(new MySqlParameter("p_ssk", spinEdit10.Value));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (spinEdit1.Value > spinEdit1.Properties.MaxValue)
            {
                XtraMessageBox.Show(PersonelName + " izin hakki sadece " + KalanIzin + " gündür.", "Dikkat",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);}
        }
    }
}