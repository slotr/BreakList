using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using Break_List.Properties;
using DevExpress.Data.PivotGrid;
using DevExpress.Utils;
using DevExpress.XtraPivotGrid;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;

namespace Break_List.Forms.TopPlayers
{
    public partial class FrmSlotRapor : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmSlotRapor()
        {
            InitializeComponent();
            GetUretici();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flyoutPanel1.ShowPopup();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            flyoutPanel1.HidePopup();
            GetExchangeRatesAverage();
            GetResults();

            var excahngeRate = new PivotGridField("Rate", PivotArea.DataArea)
            {
                UnboundType = DevExpress.Data.UnboundColumnType.Decimal,
                UnboundExpression = Convert.ToString(Rate, CultureInfo.InvariantCulture),
                SummaryType = PivotSummaryType.Average,
                Visible = false
            };
            var exchangeRate = new PivotGridField("Result $", PivotArea.DataArea)
            {
                UnboundType = DevExpress.Data.UnboundColumnType.Decimal,
                UnboundExpression = "[basicsum]/[Rate]",
                CellFormat = { FormatType = FormatType.Custom,FormatString = "{0:$0.00;($0.00)}" },
                

            };
            exchangeRate.Options.ShowUnboundExpressionMenu = true;
            pivotGridControl1.Fields.Add(exchangeRate);
            pivotGridControl1.Fields.Add(excahngeRate);
            // Create column fields and bind them to the 'OrderDate' datasource field.
            var fieldYear = new PivotGridField("date", PivotArea.ColumnArea);
            var fieldMonth = new PivotGridField("date", PivotArea.ColumnArea);
            var fieldDay = new PivotGridField("date", PivotArea.ColumnArea);
            // Add the fields to the field collection.
            pivotGridControl1.Fields.Add(fieldYear);
            pivotGridControl1.Fields.Add(fieldMonth);
            pivotGridControl1.Fields.Add(fieldDay);
            // Set the caption and group mode of the fields.
            fieldYear.GroupInterval = PivotGroupInterval.DateYear;
            fieldYear.Caption = @"Year";
            fieldMonth.GroupInterval = PivotGroupInterval.DateMonth;
            fieldMonth.Caption = @"Month";
            fieldDay.GroupInterval = PivotGroupInterval.DateDay;
            fieldDay.Caption = @"Day";
            pivotGridControl1.BestFit();
        }

        private decimal Rate { get; set; }
        private const string ConString =
            "server=192.168.0.187;user id=hakan;password=26091974;persistsecurityinfo=True;database=livegame";
        private void GetExchangeRatesAverage()
        {

            using (var conn = new MySqlConnection(ConString))
            {
                var cmd = new MySqlCommand("sptblrates;", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                

                cmd.Parameters.Add(new MySqlParameter("StartDate", dateEdit1.EditValue));
                cmd.Parameters.Add(new MySqlParameter("EndDate", dateEdit2.EditValue));
                conn.Open();
                var mySqlDataAdapter = new MySqlDataAdapter(cmd);
                var dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "sptblrates");
                Rate =Convert.ToDecimal(dataSet.Tables["sptblrates"].Rows[0]["rate"].ToString());
                conn.Close();
            }
        }

        private void GetUretici() // 
        {

            var connectionString = Settings.Default.livegameConnectionString2;
            using (var cnn = new MySqlConnection(connectionString))
            using (var cmd = cnn.CreateCommand())
            {
                cnn.Open();
                cmd.CommandText = "spSlotUreticiler";
                cmd.CommandType = CommandType.StoredProcedure;
                var dt = new DataTable();
                using (var da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {

                        repositoryItemComboBox1.Items.Add(row["Uretici"]);

                    }

                    repositoryItemComboBox1.Sorted = true;


                }
            }

        }

        private void GetResults()
        {
            var connectionString = Settings.Default.livegameConnectionString2;
            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = cnn.CreateCommand())
            {
                cnn.Open();
                cmd.CommandText = "spSlotResults";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("StartDate", dateEdit1.DateTime));
                cmd.Parameters.Add(new MySqlParameter("EndDate", dateEdit2.DateTime));
                DataTable dt = new DataTable();
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    pivotGridControl1.DataSource = dt;
                    
                }
            }
        }
        private void frmSlotRapor_Load(object sender, EventArgs e)
        {
            if (barEditItem1.EditValue.ToString() != "Marka Seç") return;
            barButtonItem2.Enabled = false;
            barButtonItem4.Enabled = false;
        }

        void CheckMarka()
        {
            if (barEditItem1.EditValue.ToString() != "Marka Seç") return;
            barButtonItem2.Enabled = false;
            barButtonItem4.Enabled = false;
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pivotGridControl1.BeginUpdate();
            try
            {
                fieldvendor1.FilterValues.Clear();
                fieldvendor1.FilterValues.FilterType = PivotFilterType.Included;

                fieldvendor1.FilterValues.Add(barEditItem1.EditValue);
            }
            finally
            {
                pivotGridControl1.EndUpdate();
                pivotGridControl1.BestFit();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pivotGridControl1.BeginUpdate();
            foreach (PivotGridField field in pivotGridControl1.Fields)
            {
                field.FilterValues.ValuesExcluded = new object[0];
            }
            pivotGridControl1.EndUpdate();
            pivotGridControl1.BestFit();
            barEditItem1.EditValue = "Marka Seç";
            CheckMarka();
        }

        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {
            if (barEditItem1.EditValue.ToString() == "Marka Seç") return;
            barButtonItem2.Enabled = true;
            barButtonItem4.Enabled = true;
        }

       

        private void btnExchange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var exchange = new FrmExchaneRates();
            exchange.ShowDialog();
        }

        private void pivotGridControl1_CustomAppearance(object sender, PivotCustomAppearanceEventArgs e)
        {
            if (e.ColumnValueType == PivotGridValueType.GrandTotal)
                e.Appearance.BackColor = Color.FromArgb(161, 170, 179);

            if (e.RowValueType == PivotGridValueType.Total)
                e.Appearance.BackColor = Color.FromArgb(92, 103, 115);
            else if (e.RowValueType == PivotGridValueType.GrandTotal)
                e.Appearance.BackColor = Color.FromArgb(217, 4, 41);
        }

        private void pivotGridControl1_CustomDrawFieldValue(object sender, PivotCustomDrawFieldValueEventArgs e)
        {
            //if (e.Area == PivotArea.ColumnArea)
            //{
            //    Rectangle rect = e.Bounds;
            //    ControlPaint.DrawBorder3D(e.Graphics, e.Bounds);
            //    Brush brush = e.GraphicsCache.GetSolidBrush(Color.FromArgb(92, 103, 115));
            //    rect.Inflate(-1, -1);
            //    e.Graphics.FillRectangle(brush, rect);
            //    e.Appearance.DrawString(e.GraphicsCache, e.Info.Caption, e.Info.CaptionRect);
            //    e.Painter.DrawIndicator(e.Info);

            //    e.Handled = true;
            //}
           }

        private void pivotGridControl1_CustomGroupInterval(object sender, PivotCustomGroupIntervalEventArgs e)
        {
            if (e.Field.Caption != "Brand") return;

            if (Convert.ToChar(e.Value.ToString()[0]) < 'F')
            {
                e.GroupValue = "A-E";
                return;
            }

            if (Convert.ToChar(e.Value.ToString()[0]) > 'E' &&
            Convert.ToChar(e.Value.ToString()[0]) < 'T')
            {
                e.GroupValue = "F-S";
                return;
            }

            if (Convert.ToChar(e.Value.ToString()[0]) > 'S')
                e.GroupValue = "T-Z";
        }

        private void pivotGridControl1_FieldValueDisplayText(object sender, PivotFieldDisplayTextEventArgs e)
        {
            if (!e.IsColumn)
            {
                List<PivotGridField> fields;
                if (e.Field == null)
                    fields = pivotGridControl1.GetFieldsByArea(PivotArea.RowArea).ToList();
                else
                    fields = pivotGridControl1.GetFieldsByArea(PivotArea.RowArea).Where(field => field.AreaIndex > e.Field.AreaIndex).ToList();
                if (e.ValueType == PivotGridValueType.GrandTotal
                    || e.ValueType == PivotGridValueType.Total
                    || e.IsCollapsed)
                    e.DisplayText += " = " + e.CreateDrillDownDataSource().Cast<PivotDrillDownDataRow>().GroupBy(row => GetUniqueCombinations(row, fields)).Count();
            }
        }
        public string GetUniqueCombinations(PivotDrillDownDataRow row, List<PivotGridField> fields)
        {
            string key = string.Empty;

            foreach (PivotGridField field in fields)
            {
                key += row[field].ToString() + "|";
            }
            return key;
        }}
}