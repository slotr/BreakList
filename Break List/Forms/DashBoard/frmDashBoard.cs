using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Tile;
using Oracle.ManagedDataAccess.Client;
using Timer = System.Timers.Timer;

namespace Break_List.Forms.DashBoard
{
    public partial class FrmDashBoard : XtraForm
    {
        private readonly DataSet _ds = new DataSet();


        private readonly DataSet _ds1 = new DataSet();
        private readonly DataSet _ds2 = new DataSet();
        private readonly DataSet _slot = new DataSet();

        private string _masaNo;


        private Timer _timer;

        public FrmDashBoard()
        {
            InitializeComponent();
        }

        private void GetTableResults()
        {
            var gameDate = DateTime.Today;
            var now = DateTime.Now;
            //Sql sorgulama
            const string sql =
                @"SELECT CH_TYPE,CH_TBLNO, SUM(DROP_PLAQUES + CASH_CHIPS - CASH_OUT - PLQSOUT_ENTRY) AS LGRESULT, SUM(DROP_PLAQUES) AS LGDROP
                            FROM STARSYNCH.SH_TRAK_DETAIL
                            WHERE END_TIME <= :enddate                            
                            AND GAMEDATE = :gamedate
                            AND TABLE_TYPE IS NOT NULL
                            GROUP BY CH_TYPE,
                                     CH_TBLNO";

            //Connection ve database'i tabloya yukleme methodu
            var con = new OracleConnection(@"DATA SOURCE=(DESCRIPTION =
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

                cmd.Parameters.Add(":enddate", now);
                cmd.Parameters.Add(":gamedate", gameDate);

                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    using (var dataAdapter = new OracleDataAdapter(cmd))
                    {
                        _ds1.Clear();
                        dataAdapter.Fill(_ds1, "sonuc1");
                        //gridControl1.ForceInitialize();
                        gridControl1.DataSource = _ds1.Tables[0];
                    }
                }
                else
                {
                    _ds1.Clear();
                    gridControl1.DataSource = null;
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

        private void GetLgTotalResult()
        {
            var gameDate = DateTime.Today;
            var now = DateTime.Now;
            //Sql sorgulama
            const string sql =
                @"SELECT SUM(DROP_PLAQUES + CASH_CHIPS - CASH_OUT - PLQSOUT_ENTRY) AS LGRESULT, SUM(DROP_PLAQUES) AS LGDROP
                            FROM STARSYNCH.SH_TRAK_DETAIL
                            WHERE END_TIME <= :enddate                            
                            AND GAMEDATE = :gamedate";

            //Connection ve database'i tabloya yukleme methodu
            var con = new OracleConnection(@"DATA SOURCE=(DESCRIPTION =
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

                cmd.Parameters.Add(":enddate", now);
                cmd.Parameters.Add(":gamedate", gameDate);

                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    using (var dataAdapter = new OracleDataAdapter(cmd))
                    {
                        _ds2.Clear();
                        dataAdapter.Fill(_ds2, "sonuc2");
                        //gridControl1.ForceInitialize();
                        gridControl2.DataSource = _ds2.Tables[0];
                    }
                }
                else
                {
                    _ds2.Clear();
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

        private void frmDashBoard_Load(object sender, EventArgs e)
        {
        }

        private void GetSlotResult()
        {
            var gameDate = DateTime.Today;
            var now = DateTime.Now;
            const string src = "SL";
            //Sql sorgulama
            var sql = @"SELECT SUM(COININ_ENTRY-COINOUT_ENTRY) AS SLOTRESULT
                            FROM STARSYNCH.SH_TRAK_DETAIL
                            WHERE END_TIME <= :enddate                            
                            AND GAMEDATE = :gamedate
                            AND ENTRY_SRC= :src";

            //Connection ve database'i tabloya yukleme methodu
            var con = new OracleConnection(@"DATA SOURCE=(DESCRIPTION =
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

                cmd.Parameters.Add(":enddate", now);
                cmd.Parameters.Add(":gamedate", gameDate);
                cmd.Parameters.Add(":src", src);
                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    using (var dataAdapter = new OracleDataAdapter(cmd))
                    {
                        _slot.Clear();
                        dataAdapter.Fill(_slot, "sonuc3");
                        //gridControl1.ForceInitialize();
                        gridControl3.DataSource = _slot.Tables[0];
                    }
                }
                else
                {
                    _slot.Clear();
                    gridControl3.DataSource = null;
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

        private void tileView1_ItemClick(object sender, TileViewItemClickEventArgs e)
        {
        }

        private void tileView1_DoubleClick(object sender, EventArgs e)
        {
            var mouseArgs = e as MouseEventArgs;
            if (mouseArgs == null) return;
            var hitInfo = tileView1.CalcHitInfo(mouseArgs.Location);

            if (!hitInfo.InItem) return;
            var selectedValue = tileView1.GetRowCellValue(hitInfo.RowHandle, "CH_TBLNO");
            _masaNo = Convert.ToString(selectedValue);
            QueryDatabase();
        }

        private void QueryDatabase()
        {
            var gameDate = DateTime.Today;
            var con = new OracleConnection(@"DATA SOURCE=(DESCRIPTION =
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
                cmd.CommandText =
                    @"SELECT A.FIRST_NAME, A.LAST_NAME,B.AVG_BET,B.START_TIME,B.CASH_OUT,B.THEORET_LOSS,B.THEORET_DROP,B.CASH_CHIPS,B.HANDS_PLAYED,B.DROP_PLAQUES,B.PLQSOUT_ENTRY, B.CASH_CHIPS, B.PLAY_TIME 
                            FROM STARSYNCH.SH_TRAK_DETAIL B
                            LEFT JOIN STARSYNCH.SH_PLAYER_MASTER A
                            ON B.MEMB_LINKID = A.LINK_ID
                            WHERE B.CH_TBLNO = :str
                            AND B.GAMEDATE = :gamedate
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
                cmd.Parameters.Add(":str", _masaNo);
                cmd.Parameters.Add(":gamedate", gameDate);


                con.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    using (var dataAdapter = new OracleDataAdapter(cmd))
                    {
                        _ds.Clear();
                        dataAdapter.Fill(_ds, "sonuc");
                        //gridControl1.ForceInitialize();
                        // Create a new form.
                        var form = new XtraForm();
                        var grid = new GridControl
                        {
                            Parent = form,
                            Dock = DockStyle.Fill,
                            DataSource = _ds.Tables[0]
                        };
                        var gridView = new GridView();
                        gridView.OptionsView.ColumnAutoWidth = false;
                        gridView.OptionsView.ShowGroupPanel = false;
                        gridView.OptionsView.RowAutoHeight = true;
                        gridView.OptionsBehavior.Editable = false;
                        grid.ViewCollection.Add(gridView);
                        grid.MainView = gridView;
                        form.Bounds = new Rectangle(100, 100, 800, 600);
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.FormBorderEffect = FormBorderEffect.Shadow;
                        // Display the form.
                        form.ShowDialog();
                        form.Dispose();
                    }
                }
                else
                {
                    _ds.Clear();

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

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn)
            {
                GetTableResults();
                GetLgTotalResult();
                GetSlotResult();

                _timer = new Timer {Interval = Convert.ToInt32(spinEdit1.EditValue) * 60000};
                _timer.Elapsed += TimeElapsed;
                _timer.Enabled = true;
            }
            else
            {
                spinEdit1.Enabled = true;
                _timer.Enabled = false;
            }
        }

        private void TimeElapsed(object sender, ElapsedEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormDescription("Pulling Data....");
            backgroundWorker1.RunWorkerAsync();
        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                splashScreenManager1.CloseWaitForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Bir Hata Olustu");
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                GetTableResults();
                GetLgTotalResult();
                GetSlotResult();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Bir Hata Olustu");
            }
        }

        private void FrmDashBoard_Shown(object sender, EventArgs e)
        {
            //GetTableResults();
            //GetLgTotalResult();
            //GetSlotResult();
        }
    }
}