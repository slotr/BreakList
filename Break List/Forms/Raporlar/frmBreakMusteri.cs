using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using DevExpress.XtraGrid.Views.Grid;
using System.Globalization;
using Break_List.Class;
using Oracle.ManagedDataAccess.Client;
using DevExpress.XtraPivotGrid;

namespace Break_List.Forms.Raporlar
{
    public partial class FrmBreakMusteri : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmBreakMusteri()
        {
            InitializeComponent();
           
        }


        private string GameDate { get; set; }
        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            gridControl1.Enabled = false;
            var column = e.Column;
            if (column == colIncele)
            {
                string saatString = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "Saat");
                string masa = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "Masa");
                DateTime saat = DateTime.ParseExact(saatString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                StatTime = saat;
                EndTime = saat.AddMinutes(20);
                MasaFinal = masa;
                
                GameDate = barEditItem1.EditValue.ToString();
                try
                {

                    GetTableResult();

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
                
                MessageBox.Show(@"Mercek İşaretine bir kere basınca rapor verir", @"Bir Hata Oluştu.");
                gridControl1.Enabled = true;
            }
           

            
            
        }
        private readonly DataSet _ds = new DataSet();
        private readonly DataSet _ds1 = new DataSet();
        public DateTime StatTime { get; set; }
        public DateTime EndTime { get; set; }
        public string MasaFinal { get; set; }

        private void QueryDatabase()
        {
            //Sql sorgulama
            const string sql = @"SELECT A.FIRST_NAME, A.LAST_NAME,B.AVG_BET,B.START_TIME,B.CASH_OUT,B.THEORET_LOSS,B.THEORET_DROP,B.CASH_CHIPS,B.HANDS_PLAYED,B.DROP_PLAQUES,B.PLQSOUT_ENTRY, B.CASH_CHIPS, B.PLAY_TIME 
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
            var con = new OracleConnection(@"DATA SOURCE=(DESCRIPTION =
                                                                        (ADDRESS_LIST =
                                                                          (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.106)(PORT = 1521))
                                                                        )
                                                                        (CONNECT_DATA =
                                                                          (SERVICE_NAME = floor)
                                                                        )
                                                                      );PASSWORD=26091974;PERSIST SECURITY INFO=True;USER ID=HAKAN");
            OracleCommand cmd = con.CreateCommand();
            try
            {
                cmd.BindByName = true;
                cmd.CommandText = sql;
                cmd.Parameters.Add(":startdate", StatTime);
                cmd.Parameters.Add(":enddate", EndTime);
                cmd.Parameters.Add(":str", MasaFinal);
                
                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    using (var dataAdapter = new OracleDataAdapter(cmd))
                    {
                        
                        _ds.Clear();
                        dataAdapter.Fill(_ds, "sonuc");
                        //gridControl1.ForceInitialize();
                        pivotGridControl1.DataSource = _ds.Tables[0];
                        
                    }
                }
                else
                {
                    
                        _ds.Clear();
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

        private void GetTableResult()
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
            var cmd = con.CreateCommand();
            try
            {
                cmd.BindByName = true;
                cmd.CommandText = sql;
                cmd.Parameters.Add(":startdate", StatTime);
                cmd.Parameters.Add(":enddate", EndTime);
                cmd.Parameters.Add(":gamedate", barEditItem1.EditValue);                
                cmd.Parameters.Add(":str", MasaFinal);
                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    using (var dataAdapter = new OracleDataAdapter(cmd))
                    {

                        _ds1.Clear();
                        dataAdapter.Fill(_ds1, "sonuc1");
                        //gridControl1.ForceInitialize();
                        gridControl2.DataSource = _ds1.Tables[0];
                    }
                }
                else
                {

                    _ds1.Clear();
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

        private void pivotGridControl1_CellDoubleClick(object sender, PivotCellEventArgs e)
        {
            // Create a new form.
            var form = new Form {Text = @"Records"};
            // Place a DataGrid control on the form.
            var grid = new DataGrid
            {
                Parent = form,
                Dock = DockStyle.Fill,
                DataSource = e.CreateDrillDownDataSource()
            };
            // Get the recrd set associated with the current cell and bind it to the grid.
            form.Bounds = new Rectangle(100, 100, 500, 400);
            // Display the form.
            form.ShowDialog();
            form.Dispose();
        }

        private void pivotGridControl1_CustomCellDisplayText_1(object sender, PivotCellDisplayTextEventArgs e)
        {
            if (e.DataField.Caption == @"Σ Play Time")
            {
                var val = e.GetCellValue(colPlyTime);
                var timespan = TimeSpan.FromMinutes(Convert.ToDouble(val)*60);
                var output = timespan.ToString("h\\:mm");
                e.DisplayText = output;
            }
        }

        private void pivotGridControl1_CustomDrawFieldValue(object sender, PivotCustomDrawFieldValueEventArgs e)
        {
            

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                using (MySqlConnection conn = DbConnection.Con)
                {
                    MySqlCommand cmd = new MySqlCommand("spBreakRapor;", conn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.Add(new MySqlParameter("ShiftDate", barEditItem1.EditValue));
                    cmd.Parameters.Add(new MySqlParameter("DepartmentName", "Live Game"));
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
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
    }
}
