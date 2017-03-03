using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Oracle.ManagedDataAccess.Client;
using DevExpress.XtraPivotGrid;

namespace Break_List.Forms.TopPlayers
{
    public partial class FrmPlayers : XtraForm
    {
        private readonly DataSet _ds = new DataSet();
        private readonly string _allviewlayout = Application.StartupPath + "\\frmPlayers_layout.xml";
        private readonly string _netResultLayout = Application.StartupPath + "\\NetResultLayout.xml";
        private readonly string _balanceLayout = Application.StartupPath + "\\BalanceLayout.xml";
        public FrmPlayers()
        {
            InitializeComponent();
        }

        private void QueryDatabase()
        {
            //Sql sorgulama
            string lvSql = @"SELECT 
	                            GAMEDATE,
	                            DROP_PLAQUES,
	                            ACTUAL_LOSS,
	                            SACTUAL_LOSS,
	                            DISC_CHIPS_PLUS,
	                            DISC_CHIPS_MINUS,
	                            DISC_CASH_PLUS,
	                            DISC_CASH_MINUS,
	                            DEPOSITS_PLUS,
	                            DEPOSITS_MINUS,
	                            CREDIT_PLUS,
	                            CREDIT_MINUS,
                                EXPENSES,
	                            LG_THEORET_LOSS,
	                            SL_THEORET_LOSS,
	                            LG_AVG_BET,
	                            SL_AVG_BET,
	                            LG_PLAY_TIME,
	                            SL_PLAY_TIME,
	                            LAST_NAME,
	                            FIRST_NAME,
	                            CASH_OUT,
	                            SDROP,
	                            SCASH_OUT,
                                COMPLEMENTS_PLUS,
                                COMPLEMENTS_MINUS,
                                LG_PLAY_TIME	
	                            
                            FROM
	                            CASINOCRM.ALL_VIEWS
                            WHERE
	                            GAMEDATE BETWEEN : startdate
                            AND : enddate";
            OracleConnection lvOracleConnection = new OracleConnection(@"DATA SOURCE=(DESCRIPTION =
                                                                        (ADDRESS_LIST =
                                                                          (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.106)(PORT = 1521))
                                                                        )
                                                                        (CONNECT_DATA =
                                                                          (SERVICE_NAME = floor)
                                                                        )
                                                                      );PASSWORD=26091974;PERSIST SECURITY INFO=True;USER ID=HAKAN");
            OracleCommand lvOracleCommand = lvOracleConnection.CreateCommand();
            lvOracleCommand.BindByName = true;
            lvOracleCommand.CommandText = lvSql;
            lvOracleCommand.Parameters.Add(":startdate", dateEdit1.DateTime);
            lvOracleCommand.Parameters.Add(":enddate", dateEdit2.DateTime);
            using (OracleDataAdapter lvOracleDataAdapter = new OracleDataAdapter(lvOracleCommand))
            {
                _ds.Clear();
                lvOracleDataAdapter.Fill(_ds, "allviewtable");
            }
            lvOracleConnection.Close();
            lvOracleCommand.Dispose();
            lvOracleConnection.Dispose();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            pivotGridControl1.DataSource = null;
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormDescription("Please wait while report is generating...");
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            QueryDatabase();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           Action a = () =>
            {
                pivotGridControl1.DataSource = _ds.Tables[0];
               // chartControl.DataSource = pivotGridControl;
                splashScreenManager1.CloseWaitForm();
            };
            pivotGridControl1.Invoke(a);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            pivotGridControl1.SaveLayoutToXml(_allviewlayout);
        }

        private void frmPlayers_Load(object sender, EventArgs e)
        {
            //pivotGridControl1.RestoreLayoutFromXml(_allviewlayout);
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(radioGroup1.SelectedIndex == 0)
            {
                colGameDate.GroupInterval = PivotGroupInterval.Default;
            }
            if (radioGroup1.SelectedIndex == 1)
            {
                colGameDate.GroupInterval = PivotGroupInterval.DateMonth;
            }
            if (radioGroup1.SelectedIndex == 2)
            {
                colGameDate.GroupInterval = PivotGroupInterval.DateYear;
            }
          
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            pivotGridControl1.OptionsView.ShowDataHeaders = checkEdit1.Checked;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormDescription("Lütfen Bekleyin... Rapor Hazirlaniyor");

            backgroundWorker2.RunWorkerAsync();

        }

        private string _fileName = "Top Players Export.xls";
        

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            Action a = () =>
            {
                pivotGridControl1.BeginUpdate();
                pivotGridControl1.OptionsPrint.PrintColumnHeaders =
                  DevExpress.Utils.DefaultBoolean.False;
                pivotGridControl1.OptionsPrint.PrintDataHeaders =
                  DevExpress.Utils.DefaultBoolean.False;
                pivotGridControl1.OptionsPrint.PrintFilterHeaders =
                DevExpress.Utils.DefaultBoolean.False;

                PivotGridField fieldExportHeader = pivotGridControl1.Fields.Add();
                fieldExportHeader.Caption = @"Export";
                fieldExportHeader.Name = "fieldExportHeader";
                fieldExportHeader.Area = PivotArea.ColumnArea;
                fieldExportHeader.Visible = true;
                fieldExportHeader.AreaIndex = 0;
                fieldExportHeader.TotalsVisibility = PivotTotalsVisibility.None;
                pivotGridControl1.OptionsView.ShowGrandTotalsForSingleValues = false;
                pivotGridControl1.EndUpdate();
                try
                {
                    pivotGridControl1.ExportToXls(_fileName);
                    System.Diagnostics.Process.Start(_fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    pivotGridControl1.Fields.Remove(fieldExportHeader);
                }

            };
            pivotGridControl1.Invoke(a);
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            splashScreenManager1.CloseWaitForm();
        }

        private void pivotGridControl1_CustomCellDisplayText(object sender, PivotCellDisplayTextEventArgs e)
        {
            if (e.DataField.Caption == @"PLAY TIME LG")
            {
                var val = e.GetCellValue(colPlayTime);
                var timespan = TimeSpan.FromMinutes(Convert.ToDouble(val) * 60);
                var output = timespan.ToString("h\\:mm");
                e.DisplayText = output;
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            pivotGridControl1.SaveLayoutToXml(_netResultLayout);
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            pivotGridControl1.SaveLayoutToXml(_balanceLayout);
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            dateEdit2.Focus();
            dateEdit2.ShowPopup();
            
        }

        private void dateEdit2_EditValueChanged(object sender, EventArgs e)
        {
            if (dateEdit2.DateTime < dateEdit1.DateTime)
            {
                XtraMessageBox.Show("Başlangıç tarihinden küçük olamaz", "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                dateEdit2.Focus();
                dateEdit2.ShowPopup();
            }
            else
            {
                simpleButton5.Enabled = true;
                simpleButton5.Enabled = true;
                simpleButton1.Enabled = true;
            }
            
        }
    }


}