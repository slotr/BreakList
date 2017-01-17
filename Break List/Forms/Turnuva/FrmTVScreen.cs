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
using MySql.Data.MySqlClient;

namespace Break_List.Forms.Turnuva
{
    public partial class FrmTVScreen : DevExpress.XtraEditors.XtraForm
    {
        public FrmTVScreen()
        {
            InitializeComponent();
        }
        public string TurnuvaAdi { get; set; }
        public int TurnuvaID { get; set; }
        private const string ConString =
            "server=192.168.0.187;user id=hakan;password=26091974;persistsecurityinfo=True;database=livegame";
        private void GetClassification()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cnn = new MySqlConnection(ConString))
            using (MySqlCommand cmd = cnn.CreateCommand())
            {
                cnn.Open();
                cmd.CommandText = "spTurnuva_scoreBoard";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("p_turnuva_adi", TurnuvaAdi));
                
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    gridControl1.DataSource = dt;
                }
            }
          
        }
        private void SetFocusedAppearance(bool isFocused)
        {
            gridView1.OptionsSelection.EnableAppearanceFocusedRow = isFocused;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = isFocused;
        }
        private void GetOdul()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection cnn = new MySqlConnection(ConString))
            using (MySqlCommand cmd = cnn.CreateCommand())
            {
                cnn.Open();
                cmd.CommandText = "spTurnuva_oduller";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("p_turnuva_adi", TurnuvaID));

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    vGridControl1.DataSource = dt;
                }
            }

        }
        private void FrmTVScreen_Load(object sender, EventArgs e)
        {
            labelControl1.Text = TurnuvaAdi;
            GetClassification();
            GetOdul();
            simpleButton1.Focus();
            SetFocusedAppearance(false);
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panelControl1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridControl1_Enter(object sender, EventArgs e)
        {
            SetFocusedAppearance(false);
        }

        private void gridControl1_Leave(object sender, EventArgs e)
        {
            SetFocusedAppearance(false);}
    }
}