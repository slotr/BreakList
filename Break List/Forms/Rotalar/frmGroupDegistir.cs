using System;
using System.Data;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;

namespace Break_List.Forms.Rotalar
{
    public partial class FrmGroupDegistir : XtraForm
    {
        public string RowId { get; set; }
        public FrmGroupDegistir()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (var mySqlConnection = new MySqlConnection(ConString))
            {
                var mySqlCommand = new MySqlCommand("spRotagrupDegisti;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.Add(new MySqlParameter("rowID", RowId));
                mySqlCommand.Parameters.Add(new MySqlParameter("grup", textEdit1.Text));
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                mySqlConnection.Dispose();
            }
        }
        private const string ConString = "server=192.168.0.187;user id=hakan;password=26091974;persistsecurityinfo=True;database=livegame";
        
        private void frmGroupDegistir_Load(object sender, EventArgs e)
        {
            using (var mySqlConnection = new MySqlConnection(ConString))
            {
                var mySqlCommand = new MySqlCommand("spRotagrupDeg;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.Add(new MySqlParameter("rowID", RowId));
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