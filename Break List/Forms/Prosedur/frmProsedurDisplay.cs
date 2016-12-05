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

namespace Break_List.Forms.Prosedur
{
    public partial class frmProsedurDisplay : XtraForm
    {
        public string rowid { get; set; }
        public bool goster { get; set; }
        public frmProsedurDisplay()
        {
            InitializeComponent();
        }

        private void frmProsedurDisplay_Load(object sender, EventArgs e)
        {
            if (goster == true)
            {
                getProcedure();
            }
                
        }
        private const string conString = "server=192.168.0.187;user id=hakan;password=26091974;persistsecurityinfo=True;database=livegame";
        private readonly MySqlConnection con = new MySqlConnection(conString);
        void getProcedure()
        {
            using (var mySqlConnection = new MySqlConnection(conString))
            {
                var mySqlCommand = new MySqlCommand("spSingleProcedure;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.Add(new MySqlParameter("rowid", rowid));
                mySqlConnection.Open();
                var mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                var dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "spSingleProcedure");
                txtNo.Text = dataSet.Tables["spSingleProcedure"].Rows[0]["id"].ToString();
                txtKonu.Text = dataSet.Tables["spSingleProcedure"].Rows[0]["konu"].ToString();
                txtYayin.Text = dataSet.Tables["spSingleProcedure"].Rows[0]["yayintarihi"].ToString();
                txtDegisim.Text = dataSet.Tables["spSingleProcedure"].Rows[0]["degisimtarihi"].ToString();
                txtOnay.Text = dataSet.Tables["spSingleProcedure"].Rows[0]["onay"].ToString();
                txtCasino.Text = dataSet.Tables["spSingleProcedure"].Rows[0]["casino"].ToString();
                richEditDetay.RtfText = dataSet.Tables["spSingleProcedure"].Rows[0]["Detay"].ToString();
                memoAmac.Text = dataSet.Tables["spSingleProcedure"].Rows[0]["Amac"].ToString();
                mySqlConnection.Close();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
               
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (goster == true) // Prosedur update ediliyor
            {
                using (var conn = new MySqlConnection(conString))
                {
                    using (var cmd = new MySqlCommand("spUpdateProcedure;", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        cmd.Parameters.Add(new MySqlParameter("casino", txtCasino.Text));
                        cmd.Parameters.Add(new MySqlParameter("konu", txtKonu.Text));
                        cmd.Parameters.Add(new MySqlParameter("yayintarihi", txtYayin.Text));
                        cmd.Parameters.Add(new MySqlParameter("degisimtarihi", txtDegisim.Text));
                        cmd.Parameters.Add(new MySqlParameter("onay", txtOnay.Text));
                        cmd.Parameters.Add(new MySqlParameter("amac", memoAmac.Text));
                        cmd.Parameters.Add(new MySqlParameter("detay", richEditDetay.RtfText));
                        cmd.Parameters.Add(new MySqlParameter("uniqueID", rowid));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        conn.Dispose();
                        Close();
                    }
                }
            }
            else // Yeni Prosedur kaydi yapiliyor.
            {
                using (var conn = new MySqlConnection(conString))
                {
                    using (var cmd = new MySqlCommand("spInsertProcedure;", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        cmd.Parameters.Add(new MySqlParameter("id", txtNo.Text));
                        cmd.Parameters.Add(new MySqlParameter("casino", txtCasino.Text));
                        cmd.Parameters.Add(new MySqlParameter("konu", txtKonu.Text));
                        cmd.Parameters.Add(new MySqlParameter("yayintarihi", txtYayin.Text));
                        cmd.Parameters.Add(new MySqlParameter("degisimtarihi", txtDegisim.Text));
                        cmd.Parameters.Add(new MySqlParameter("onay", txtOnay.Text));
                        cmd.Parameters.Add(new MySqlParameter("amac", memoAmac.Text));
                        cmd.Parameters.Add(new MySqlParameter("detay", richEditDetay.RtfText));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        conn.Dispose();
                        Close();
                    }
                }
            }
        }
    }
}