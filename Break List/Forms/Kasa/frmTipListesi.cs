using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using MySql.Data.MySqlClient;
using Break_List.Properties;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;


namespace Break_List.Forms.Kasa
{
    public partial class frmTipListesi : XtraForm
    {
        public string userName { get; set; }
        public frmTipListesi()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            tipListesiniGetir();
            
        }

        void tipListesiniGetir()
        {
            if (dateEdit1.EditValue == null || dateEdit2.EditValue == null)
            {
                MessageBox.Show("Tarih Giriniz");
            }
            else
            {
                spTipListesiAllPersonelTableAdapter.Fill(livegameDataSet1.spTipListesiAllPersonel, Convert.ToDateTime(dateEdit1.EditValue.ToString()), Convert.ToDateTime(dateEdit2.EditValue.ToString()));
                var a = bandedGridView1.Columns["Tip Puani"].SummaryItem.SummaryValue;
                var b = bandedGridView1.Columns["gridColumn2"].SummaryItem.SummaryValue;
                txtTotalPuan.EditValue = a;
                txtorgTip.EditValue = b;
                Double totalPuan = Convert.ToDouble(txtTotalPuan.EditValue.ToString());
                Double verilecekpuan = totalPuan - Convert.ToDouble(txtorgTip.EditValue.ToString());
                Double totalTip = Convert.ToDouble(txtToplananTip.EditValue.ToString());
                Double kesintiMiktari = totalTip * 1 / 3;
                Double other = Convert.ToDouble(txtOther.Text);
                Double kalan = Math.Round((totalTip - kesintiMiktari - other), 0);
                Double puanBasi = Math.Round((kalan / verilecekpuan), 0);
                txtpuanBasi.Text = Math.Round(puanBasi, 0).ToString();
                txtKesilen.Text = Math.Round(kesintiMiktari, 0).ToString();
                txtKalan.Text = Math.Round(kalan, 0).ToString();
                txtFinalPuan.Text = Math.Round(verilecekpuan, 0).ToString();
                if (puanBasi > 90)
                {
                    txtSirketYardimi.Text = "0";
                    txtSırketToplam.Text = "0";
                }
                else if (puanBasi < 90)
                {
                    Double sirketYardimi = 90 - puanBasi;
                    txtSirketYardimi.Text = sirketYardimi.ToString();
                    txtSırketToplam.Text = (sirketYardimi * verilecekpuan).ToString();
                }

                txtDagitilacakPuanBasi.Text = Math.Round((puanBasi + Convert.ToDouble(txtSirketYardimi.Text)), 0).ToString();
                txtDagitilacak.Text = (Convert.ToDouble(txtDagitilacakPuanBasi.Text) * verilecekpuan).ToString();
            }
            
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
                            gridControl1.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            gridControl1.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            gridControl1.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            gridControl1.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            gridControl1.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            gridControl1.ExportToMht(exportFilePath);
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





        private void frmTipListesi_Load(object sender, EventArgs e)
        {

        }

        private void gridView1_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {

        }
       
        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridColumn Column = e.Column;
            #region column1
            if (Column == gridColumn1)
            {
                
                int rowid;
                string personelName;
                DateTime StartDate;
                DateTime EndDate;
                rowid = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "Personel No");
                personelName = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "Personel");
                StartDate = (DateTime)Convert.ToDateTime((dateEdit1.EditValue.ToString()));
                EndDate = (DateTime)Convert.ToDateTime((dateEdit2.EditValue.ToString()));  
               
                using (MySqlConnection con = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    using (MySqlCommand cmd = new MySqlCommand("spTipListesiDetay;", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {

                        cmd.Parameters.Add(new MySqlParameter("rowID", rowid));
                        cmd.Parameters.Add(new MySqlParameter("_StartDate", Convert.ToDateTime(dateEdit1.EditValue.ToString())));
                        cmd.Parameters.Add(new MySqlParameter("_EndDate", Convert.ToDateTime(dateEdit2.EditValue.ToString())));
                        con.Open();
                        cmd.ExecuteNonQuery();
                        using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter())
                        {
                            DataSet ds = new DataSet("Detaylar");
                            //DataTable dataTable = new DataTable();
                            mySqlDataAdapter.SelectCommand = cmd;
                            mySqlDataAdapter.Fill(ds);
                            // Create a new form.
                            XtraForm form = new XtraForm();
                            form.Text = personelName + " Detayları";                            
                            GridControl grid = new GridControl();
                            grid.Parent = form;
                            grid.Dock = DockStyle.Fill;  
                            grid.DataSource = ds.Tables[0];
                            GridView gridView = new GridView();
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
                        con.Close();
                    }


                }
            }
            #endregion
            if (Column == tipAvans)
            {
                int rowid;
                string personelName;
                rowid = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "Personel No");
                personelName = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "Personel");

                using (frmAvanslar frmavanslar = new frmAvanslar())
                {
                    
                    frmavanslar.personelID = rowid.ToString();
                    frmavanslar.userName = userName;
                    frmavanslar.avansTipi = "Tip Avansi";
                    frmavanslar.Text = "Tip Avansi";
                    frmavanslar.lblPersonel.Text = personelName + " Tip Avansi";
                    frmavanslar.flag = true;
                                    
                    DialogResult dr = frmavanslar.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        tipListesiniGetir();
                    }

                }

            }
            if (Column == BankayaYatan)
            {
                int rowid;
                string personelName;
                rowid = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "Personel No");
                personelName = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "Personel");

                using (frmAvanslar frmavanslar = new frmAvanslar())
                {

                    frmavanslar.personelID = rowid.ToString();
                    frmavanslar.avansTipi = "Bankaya Yatan";
                    frmavanslar.Text = "Bankaya Yatan";
                    frmavanslar.lblPersonel.Text = personelName + " Bankaya Yatan";
                    frmavanslar.flag = false;
                    frmavanslar.userName = userName;
                    DialogResult dr = frmavanslar.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        tipListesiniGetir();
                    }

                }

            }
        }

       

        private void bandedGridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = (GridView)sender;
            if (e.Column == toplamtip)
                if (e.IsGetData)
                    e.Value = Convert.ToDouble(view.GetListSourceRowCellValue(e.ListSourceRowIndex, colTipPuani)) *
                        Convert.ToDouble(txtDagitilacakPuanBasi.Text.ToString());
        }
        
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            layoutControl1.ShowPrintPreview();
        }
    }
}