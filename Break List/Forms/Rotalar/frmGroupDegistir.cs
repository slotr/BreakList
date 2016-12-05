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
using Break_List.Properties;

namespace Break_List.Forms.Rotalar
{
    public partial class frmGroupDegistir : XtraForm
    {
        public string rowID { get; set; }
        public frmGroupDegistir()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (var mySqlConnection = new MySqlConnection(conString))
            {
                var mySqlCommand = new MySqlCommand("spRotagrupDegisti;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.Add(new MySqlParameter("rowID", rowID));
                mySqlCommand.Parameters.Add(new MySqlParameter("grup", textEdit1.Text));
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                mySqlConnection.Dispose();
            }
        }
        private const string conString = "server=192.168.0.187;user id=hakan;password=26091974;persistsecurityinfo=True;database=livegame";
        private readonly MySqlConnection con = new MySqlConnection(conString);
        private void frmGroupDegistir_Load(object sender, EventArgs e)
        {
            using (var mySqlConnection = new MySqlConnection(conString))
            {
                var mySqlCommand = new MySqlCommand("spRotagrupDeg;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.Add(new MySqlParameter("rowID", rowID));
                mySqlConnection.Open();
                var mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                var dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "spRotagrupDeg");
                textEdit1.Text = dataSet.Tables["spRotagrupDeg"].Rows[0]["rotagrup"].ToString();
                labelControl1.Text = dataSet.Tables["spRotagrupDeg"].Rows[0]["ResourceName"].ToString();
                
                mySqlConnection.Close();
                mySqlConnection.Dispose();
            }
        }
    }
}