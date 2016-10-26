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
using System.IO;
using DevExpress.XtraPivotGrid;
using DevExpress.Data.PivotGrid;

namespace Break_List.Forms.Kasa
{
    public partial class frmTipListesi : DevExpress.XtraEditors.XtraForm
    {
        public frmTipListesi()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {         
            
            spTipListesiAllPersonelTableAdapter.Fill(livegameDataSet1.spTipListesiAllPersonel, Convert.ToDateTime(dateEdit1.EditValue.ToString()), Convert.ToDateTime(dateEdit2.EditValue.ToString()));
           
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;
                    DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG;
                    switch (fileExtenstion)
                    {
                        case ".xls":
                            pivotGridControl1.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            pivotGridControl1.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            pivotGridControl1.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            pivotGridControl1.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            pivotGridControl1.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            pivotGridControl1.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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

        private void pivotGridControl1_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void frmTipListesi_Load(object sender, EventArgs e)
        {
            
        }

        
    }
}