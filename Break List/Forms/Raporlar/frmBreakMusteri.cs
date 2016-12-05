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
using DevExpress.XtraGrid.Views.Grid;
using System.Globalization;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using DevExpress.Utils;
using DevExpress.XtraPivotGrid;

namespace Break_List.Forms.Raporlar
{
    public partial class frmBreakMusteri : XtraForm
    {
        public frmBreakMusteri()
        {
            InitializeComponent();
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            

        }

       
        public string gameDate { get; set; }
        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            gridControl1.Enabled = false;
            var Column = e.Column;
            if (Column == colIncele)
            {
                string saatString = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "Saat");
                string masa = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "Masa");
                DateTime Saat = DateTime.ParseExact(saatString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                StatTime = Saat;
                EndTime = Saat.AddMinutes(20);
                masaFinal = masa;
                
                gameDate = dateEdit1.DateTime.ToString();
                try
                {

                    getTableResult();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    splashScreenManager1.ShowWaitForm();
                    splashScreenManager1.SetWaitFormDescription("Rapor Hazırlanıyor....");

                    backgroundWorker1.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show("Mercek İşaretine bir kere basınca rapor verir", @"Bir Hata Oluştu.");
                gridControl1.Enabled = true;
            }
           

            
            
        }
        private DataSet ds = new DataSet();
        private DataSet ds1 = new DataSet();
        public DateTime StatTime { get; set; }
        public DateTime EndTime { get; set; }
        public string masaFinal { get; set; }
        void QueryDatabase()
        {
            //Sql sorgulama
            string sql = @"SELECT A.FIRST_NAME, A.LAST_NAME,B.AVG_BET,B.START_TIME,B.CASH_OUT,B.THEORET_LOSS,B.THEORET_DROP,B.CASH_CHIPS,B.HANDS_PLAYED,B.DROP_PLAQUES,B.PLQSOUT_ENTRY, B.CASH_CHIPS, B.PLAY_TIME 
                            FROM STARSYNCH.SH_TRAK_DETAIL B
                            LEFT JOIN STARSYNCH.SH_PLAYER_MASTER A
                            ON B.MEMB_LINKID = A.LINK_ID
                            WHERE B.START_TIME BETWEEN :startdate AND :enddate
                            AND B.CH_TBLNO = :str
                            GROUP BY 
                            A.FIRST_NAME,
                            A.LAST_NAME,
                            B.AVG_BET,
                            B.START_TIME,
                            B.CASH_OUT,
                            B.THEORET_LOSS,
                            B.THEORET_DROP,
                            B.CASH_CHIPS,
                            B.HANDS_PLAYED,
                            B.DROP_PLAQUES,
                            B.PLQSOUT_ENTRY,
                            B.CASH_CHIPS,
                            B.PLAY_TIME";

            //Connection ve database'i tabloya yukleme methodu
            OracleConnection con = new OracleConnection(@"DATA SOURCE=(DESCRIPTION =
                                                                        (ADDRESS_LIST =
                                                                          (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.106)(PORT = 1521))
                                                                        )
                                                                        (CONNECT_DATA =
                                                                          (SERVICE_NAME = floor)
                                                                        )
                                                                      );PASSWORD=26091974;PERSIST SECURITY INFO=True;USER ID=HAKAN");
            OracleCommand cmd = con.CreateCommand();
            OracleDataReader reader;
            try
            {
                cmd.BindByName = true;
                cmd.CommandText = sql;
                cmd.Parameters.Add(":startdate", StatTime);
                cmd.Parameters.Add(":enddate", EndTime);
                cmd.Parameters.Add(":str", masaFinal);
                
                con.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    using (OracleDataAdapter dataAdapter = new OracleDataAdapter(cmd))
                    {
                        
                        ds.Clear();
                        dataAdapter.Fill(ds, "sonuc");
                        //gridControl1.ForceInitialize();
                        pivotGridControl1.DataSource = ds.Tables[0];
                        
                    }
                }
                else
                {
                    
                        ds.Clear();
                        pivotGridControl1.DataSource = null;
                    XtraMessageBox.Show("No Game");
                }
                
                
            }
           
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString(), "Bir Hata oluştu");
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                con.Dispose();
                
            }
            
            
        }
        void getTableResult()
        {
            //Sql sorgulama
            string sql = @"SELECT SUM(DROP_PLAQUES + CASH_CHIPS - CASH_OUT - PLQSOUT_ENTRY) AS RESULT
                            FROM STARSYNCH.SH_TRAK_DETAIL
                            WHERE END_TIME <= :enddate                            
                            AND GAMEDATE = :gamedate
                            AND CH_TBLNO = :str";

            //Connection ve database'i tabloya yukleme methodu
            OracleConnection con = new OracleConnection(@"DATA SOURCE=(DESCRIPTION =
                                                                        (ADDRESS_LIST =
                                                                          (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.106)(PORT = 1521))
                                                                        )
                                                                        (CONNECT_DATA =
                                                                          (SERVICE_NAME = floor)
                                                                        )
                                                                      );PASSWORD=26091974;PERSIST SECURITY INFO=True;USER ID=HAKAN");
            OracleCommand cmd = con.CreateCommand();
            OracleDataReader reader;
            try
            {
                cmd.BindByName = true;
                cmd.CommandText = sql;
                cmd.Parameters.Add(":startdate", StatTime);
                cmd.Parameters.Add(":enddate", EndTime);
                cmd.Parameters.Add(":gamedate", dateEdit1.DateTime);                
                cmd.Parameters.Add(":str", masaFinal);
                con.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    using (OracleDataAdapter dataAdapter = new OracleDataAdapter(cmd))
                    {

                        ds1.Clear();
                        dataAdapter.Fill(ds1, "sonuc1");
                        //gridControl1.ForceInitialize();
                        gridControl2.DataSource = ds1.Tables[0];
                    }
                }
                else
                {

                    ds1.Clear();
                    gridControl2.DataSource = null;
                    
                }


            }

            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString(), "Bir Hata oluştu");
            }
            finally
            {
                con.Close();
                cmd.Dispose();
                con.Dispose();
            }


        }
        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            QueryDatabase();
            
        }
       
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Action a = () =>
            {
                try
                {
                    splashScreenManager1.CloseWaitForm();
                    gridControl1.Enabled = true;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString(), "Bir Hata Olustu");
                }
                    
            };
            try
            {
                pivotGridControl1.Invoke(a);
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Bir Hata Olustu");
            }
            
        }

        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            
            if (e.Column.FieldName == "ColRes")
            {
                e.DisplayText = "Masa Result: ";
            }
        }

        private void pivotGridControl1_CellDoubleClick(object sender, DevExpress.XtraPivotGrid.PivotCellEventArgs e)
        {
            // Create a new form.
            Form form = new Form();
            form.Text = "Records";
            // Place a DataGrid control on the form.
            DataGrid grid = new DataGrid();
            grid.Parent = form;
            grid.Dock = DockStyle.Fill;
            // Get the recrd set associated with the current cell and bind it to the grid.
            grid.DataSource = e.CreateDrillDownDataSource();
            form.Bounds = new Rectangle(100, 100, 500, 400);
            // Display the form.
            form.ShowDialog();
            form.Dispose();
        }
        
        private void pivotGridControl1_CustomCellDisplayText(object sender, DevExpress.XtraPivotGrid.PivotCellDisplayTextEventArgs e)
        {
            
        }

        private void pivotGridControl1_CustomCellValue(object sender, PivotCellValueEventArgs e)
        {
            
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    MySqlCommand cmd = new MySqlCommand("spBreakRapor;", conn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.Add(new MySqlParameter("ShiftDate", dateEdit1.DateTime));
                    cmd.Parameters.Add(new MySqlParameter("DepartmentName", "Live Game"));
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows){
                        conn.Close();
                        conn.Open();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                        {
                            DataTable dt = new DataTable();
                            adapter.SelectCommand = cmd;
                            {
                                adapter.Fill(dt);
                                gridControl1.DataSource = dt;

                            }

                        }
                        conn.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bu Gune ait bir veri yok", "Oooppppss");
                    }

                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString(), "Bir Hata oluştu");
            }
        }

        private void pivotGridControl1_CustomCellDisplayText_1(object sender, PivotCellDisplayTextEventArgs e)
        {
            if (e.DataField.Caption == "Σ Play Time")
            {
                var val = e.GetCellValue(colPlyTime);
                TimeSpan timespan = TimeSpan.FromMinutes(Convert.ToDouble(val));
                string output = timespan.ToString("h\\:mm");
                e.DisplayText = output;
            }
        }

        private void pivotGridControl1_CustomDrawFieldValue(object sender, PivotCustomDrawFieldValueEventArgs e)
        {
            

        }
    }
}
