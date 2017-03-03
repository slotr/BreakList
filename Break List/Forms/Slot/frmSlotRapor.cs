using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Break_List.Properties;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using MySql.Data.MySqlClient;

namespace Break_List.Forms.Slot
{
    public partial class FrmSlotRapor : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmSlotRapor()
        {
            InitializeComponent();
            
            
        }


        private void InitComboBox()
        {
            object[] values = fieldvendor1.GetUniqueValues();
            foreach (object obj in values)
                repositoryItemComboBox1.Items.Add(obj);
            repositoryItemComboBox1.Sorted = true;
        }

        public bool combohasvalues { get; set; }

        private void GetResults()
        {
            var connectionString = Settings.Default.livegameConnectionString2;
            using (var cnn = new MySqlConnection(connectionString))
            using (var cmd = cnn.CreateCommand())
            {
                cnn.Open();
                cmd.CommandText = "spSlotResults";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("StartDate", tarih1.EditValue));
                cmd.Parameters.Add(new MySqlParameter("EndDate", tarih2.EditValue));
                var dt = new DataTable();
                using (var da = new MySqlDataAdapter(cmd)){
                    da.Fill(dt);
                    pivotGridControl1.DataSource = dt;
                    pivotGridControl1.BestFit();
                }
            }
        }
        private void frmSlotRapor_Load(object sender, EventArgs e)
        {
            if (btnFiltre.EditValue.ToString() != "Marka Seç") return;
            barButtonItem2.Enabled = false;
            
           
        }

        private void CheckMarka()
        {
            if (btnFiltre.EditValue.ToString() != "Marka Seç") return;
            barButtonItem2.Enabled = false;
           
        }

        
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pivotGridControl1.BeginUpdate();
            foreach (PivotGridField field in pivotGridControl1.Fields)
                field.FilterValues.ValuesExcluded = new object[0];
            
            
            btnFiltre.EditValue = "Marka Seç";
            CheckMarka();
            pivotGridControl1.EndUpdate();
            pivotGridControl1.BestFit();
        }

        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {
            if (btnFiltre.EditValue.ToString() == "Marka Seç") return;
            barButtonItem2.Enabled = true;
            pivotGridControl1.BeginUpdate();
            try
            {
                fieldvendor1.FilterValues.Clear();
                fieldvendor1.FilterValues.FilterType = PivotFilterType.Included;

                fieldvendor1.FilterValues.Add(btnFiltre.EditValue);
            }
            finally
            {
                
                pivotGridControl1.EndUpdate();
                pivotGridControl1.BestFit();

            }
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
           
        }

        private void pivotGridControl1_FieldValueDisplayText(object sender, PivotFieldDisplayTextEventArgs e)
        {
            
        }

        
       

        private void btnButunMetreler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var butunMetreler = new FrmAllMeters();
            butunMetreler.Show();}

        private void FrmSlotRapor_Shown(object sender, EventArgs e)
        {
            splitContainerControl2.SplitterPosition = splitContainerControl1.Width / 2;
            splitContainerControl1.SplitterPosition = splitContainerControl1.Height /2;}

        private void pivotGridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button != MouseButtons.Right) return;
            //radialMenu1.ShowPopup(MousePosition);
        }


        private void ExportGenelGorunum()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Slot Reports\";
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {

                    var cl = new CompositeLink(printingSystem1);
                    var pclTo = new PrintableComponentLink(printingSystem1);
                    var pclResult = new PrintableComponentLink(printingSystem1);
                    var pclPivot = new PrintableComponentLink(printingSystem1);

                    pclTo.Component = chartControl1;
                    pclResult.Component = chartControl2;
                    pclPivot.Component = pivotGridControl1;

                    pclTo.PrintingSystem.PageSettings.Landscape = true;
                    pclResult.PrintingSystem.PageSettings.Landscape = true;
                    pclPivot.PrintingSystem.PageSettings.Landscape = true;

                    cl.Links.AddRange(new object[] {pclTo, pclResult, pclPivot});

                    cl.CreateDocument();
                    printingSystem1.Links.Add(cl);
                    printingSystem1.ExportToXlsx(path + "Genel Gorunum.xlsx");
                    printingSystem1.PageSettings.Landscape = true;

                    //cl.ShowPreviewDialog();

                    System.Diagnostics.Process.Start(path + "Genel Gorunum.xlsx");
                }
                else
                {
                    Directory.CreateDirectory(path);
                    var cl = new CompositeLink(printingSystem1);
                    var pclTo = new PrintableComponentLink(printingSystem1);
                    var pclResult = new PrintableComponentLink(printingSystem1);
                    var pclPivot = new PrintableComponentLink(printingSystem1);

                    pclTo.Component = chartControl1;
                    pclResult.Component = chartControl2;
                    pclPivot.Component = pivotGridControl1;

                    pclTo.PrintingSystem.PageSettings.Landscape = true;
                    pclResult.PrintingSystem.PageSettings.Landscape = true;
                    pclPivot.PrintingSystem.PageSettings.Landscape = true;

                    cl.Links.AddRange(new object[] { pclTo, pclResult, pclPivot });

                    cl.CreateDocument();
                    printingSystem1.Links.Add(cl);
                    printingSystem1.ExportToXlsx(path + "Genel Gorunum.xlsx");
                    printingSystem1.PageSettings.Landscape = true;

                    //cl.ShowPreviewDialog();

                    System.Diagnostics.Process.Start(path + "Genel Gorunum.xlsx");
                }
                
               
            }
            catch (Exception e)
            {
                MessageBox.Show(@"The process failed: {0}", e.ToString());
            }
           

            
            
        }

        private void ExportFiltrelenmis()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Slot Reports\";

            var brand = btnFiltre.EditValue.ToString();
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {

                    var cl = new CompositeLink(printingSystem1);
                    var pclDetayChart = new PrintableComponentLink(printingSystem1);
                    var pclPivot = new PrintableComponentLink(printingSystem1);

                    pclDetayChart.Component = chartControl3;
                    pclPivot.Component = pivotGridControl1;


                    pclPivot.PrintingSystem.PageSettings.Landscape = true;
                    pclDetayChart.PrintingSystem.PageSettings.Landscape = true;
                    cl.Links.AddRange(new object[] { pclDetayChart, pclPivot });

                    cl.CreateDocument();
                    printingSystem1.Links.Add(cl);
                    printingSystem1.ExportToXlsx(path + brand + ".xlsx");
                    printingSystem1.PageSettings.Landscape = true;

                    //cl.ShowPreviewDialog();

                    System.Diagnostics.Process.Start(path + brand + ".xlsx");
                }
                else
                {
                    var cl = new CompositeLink(printingSystem1);
                    var pclDetayChart = new PrintableComponentLink(printingSystem1);
                    var pclPivot = new PrintableComponentLink(printingSystem1);

                    pclDetayChart.Component = chartControl3;
                    pclPivot.Component = pivotGridControl1;


                    pclPivot.PrintingSystem.PageSettings.Landscape = true;
                    pclDetayChart.PrintingSystem.PageSettings.Landscape = true;
                    cl.Links.AddRange(new object[] { pclDetayChart, pclPivot });

                    cl.CreateDocument();
                    printingSystem1.Links.Add(cl);
                    printingSystem1.ExportToXlsx(path + brand + ".xlsx");
                    printingSystem1.PageSettings.Landscape = true;

                    //cl.ShowPreviewDialog();

                    System.Diagnostics.Process.Start(path + brand + ".xlsx");
                }


            }
            catch (Exception e)
            {
                MessageBox.Show(@"The process failed: {0}", e.ToString());
            }
            
        }
        private void pivotGridControl1_Click(object sender, EventArgs e)
        {
            //((XYDiagram2DSeriesViewBase)chartControl3.Series[0].View).Indicators.Add(new RegressionLine(ValueLevel.Value));
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var exchangeDuzenle = new FrmAllRates();
            exchangeDuzenle.ShowDialog();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var exchange = new FrmExchaneRates();
            exchange.ShowDialog();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetResults();
            if (combohasvalues == false)
            {
                InitComboBox();
                spSlot_ChartTableAdapter.Fill(livegameDataSet1.spSlot_Chart, Convert.ToDateTime(tarih1.EditValue),
                    Convert.ToDateTime(tarih2.EditValue));
                pivotGridControl1.Fields["vendor"].SortBySummaryInfo.Field =
                    pivotGridControl1.Fields["colDollaravg"];
                pivotGridControl1.BeginUpdate();
                pivotGridControl1.CollapseAll();
                pivotGridControl1.EndUpdate();
                pivotGridControl1.BestFit();
                combohasvalues = true;
            }
            else
            {
                spSlot_ChartTableAdapter.Fill(livegameDataSet1.spSlot_Chart, Convert.ToDateTime(tarih1.EditValue),
                    Convert.ToDateTime(tarih2.EditValue));
                pivotGridControl1.BeginUpdate();
                pivotGridControl1.Fields["vendor"].SortBySummaryInfo.Field =
                    pivotGridControl1.Fields["colDollaravg"];
                pivotGridControl1.CollapseAll();pivotGridControl1.EndUpdate();
                pivotGridControl1.BestFit();
            }
            
           
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportGenelGorunum();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportFiltrelenmis();
        }

        private void btnFiltre_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}