using System;
using System.Data;
using System.Drawing;
using System.Globalization;
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
    public partial class FrmTipListesi : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string UserName { get; set; }
        public FrmTipListesi()
        {
            InitializeComponent();
        }

       

        private void TipListesiniGetir()
        {
            if (barEditItem2.EditValue != null && barEditItem1.EditValue != null)
            {
                spTipListesiAllPersonelTableAdapter.Fill(livegameDataSet1.spTipListesiAllPersonel, Convert.ToDateTime(barEditItem2.EditValue.ToString()), Convert.ToDateTime(barEditItem1.EditValue.ToString()));
                var a = bandedGridView1.Columns["Tip Puani"].SummaryItem.SummaryValue;
                var b = bandedGridView1.Columns["gridColumn2"].SummaryItem.SummaryValue;
                txtTotalPuan.EditValue = a;
                txtorgTip.EditValue = b;
                var totalPuan = Convert.ToDouble(txtTotalPuan.EditValue.ToString());
                var verilecekpuan = totalPuan - Convert.ToDouble(txtorgTip.EditValue.ToString());
                var totalTip = Convert.ToDouble(txtToplananTip.EditValue.ToString());
                var kesintiMiktari = totalTip * 1 / 3;
                var other = Convert.ToDouble(txtOther.Text);
                var kalan = Math.Round(totalTip - kesintiMiktari - other, 0);
                var puanBasi = Math.Round((kalan / verilecekpuan), 0);
                txtpuanBasi.Text = Math.Round(puanBasi, 0).ToString(CultureInfo.InvariantCulture);
                txtKesilen.Text = Math.Round(kesintiMiktari, 0).ToString(CultureInfo.InvariantCulture);
                txtKalan.Text = Math.Round(kalan, 0).ToString(CultureInfo.InvariantCulture);
                txtFinalPuan.Text = Math.Round(verilecekpuan, 0).ToString(CultureInfo.InvariantCulture);
                if (puanBasi > 90)
                {
                    txtSirketYardimi.Text = @"0";
                    txtSırketToplam.Text = @"0";
                }
                else
                {
                    if (puanBasi < 90)
                    {
                        var sirketYardimi = 90 - puanBasi;
                        txtSirketYardimi.Text = sirketYardimi.ToString(CultureInfo.InvariantCulture);
                        txtSırketToplam.Text = (sirketYardimi * verilecekpuan).ToString(CultureInfo.InvariantCulture);
                    }
                }
                txtDagitilacakPuanBasi.Text = Math.Round(puanBasi + Convert.ToDouble(txtSirketYardimi.Text), 0).ToString(CultureInfo.InvariantCulture);
                txtDagitilacak.Text = (Convert.ToDouble(txtDagitilacakPuanBasi.Text) * verilecekpuan).ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                MessageBox.Show(@"Personel Bilgisi Update edildi");
            }
        }

      




        private void frmTipListesi_Load(object sender, EventArgs e)
        {
            
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridColumn column = e.Column;
            #region column1
            if (column == gridColumn1)
            {
                var rowid = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "Personel No");
                var personelName = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "Personel");

                MySqlConnection con = new MySqlConnection(Settings.Default.livegameConnectionString2);
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("spTipListesiDetay;", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {

                        cmd.Parameters.Add(new MySqlParameter("rowID", rowid));
                        cmd.Parameters.Add(new MySqlParameter("_StartDate", Convert.ToDateTime(barEditItem2.EditValue.ToString())));
                        cmd.Parameters.Add(new MySqlParameter("_EndDate", Convert.ToDateTime(barEditItem1.EditValue.ToString())));
                        con.Open();
                        cmd.ExecuteNonQuery();
                        using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter())
                        {
                            DataSet ds = new DataSet("Detaylar");
                            //DataTable dataTable = new DataTable();
                            mySqlDataAdapter.SelectCommand = cmd;
                            mySqlDataAdapter.Fill(ds);
                            // Create a new form.
                            var form = new XtraForm {Text = personelName + @" Devam Detayları"};
                            var grid = new GridControl
                            {
                                Parent = form,
                                Dock = DockStyle.Fill,
                                DataSource = ds.Tables[0]
                            };
                            var gridView = new GridView();
                            gridView.OptionsView.ColumnAutoWidth = false;
                            gridView.OptionsView.ShowGroupPanel = false;
                            gridView.OptionsView.RowAutoHeight = true;
                            gridView.OptionsBehavior.Editable = false;
                            grid.ViewCollection.Add(gridView);
                            grid.MainView = gridView;
                            gridView.OptionsMenu.ShowConditionalFormattingItem = true;
                            if (File.Exists("view.xml"))
                            {
                                gridView.RestoreLayoutFromXml("view.xml", DevExpress.Utils.OptionsLayoutBase.FullLayout);
                            }
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
                finally
                {
                    con.Dispose();
                }
            }
            #endregion

            if (column == tipAvans)
            {
                int rowid = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "Personel No");
                string personelName = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "Personel");

                using (var frmavanslar = new FrmAvanslar())
                {
                    frmavanslar.PersonelId = rowid.ToString();
                    frmavanslar.UserName = UserName;
                    frmavanslar.AvansTipi = "Tip Avansi";
                    frmavanslar.Text = @"Tip Avansi";
                    frmavanslar.lblPersonel.Text = personelName + @" Tip Avansi";
                    frmavanslar.Flag = true;

                    var dr = frmavanslar.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        TipListesiniGetir();
                    }
                }
            }
            if (column == BankayaYatan)
            {
                int rowid = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "Personel No");
                string personelName = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "Personel");

                using (var frmavanslar = new FrmAvanslar())
                {
                    frmavanslar.PersonelId = rowid.ToString();
                    frmavanslar.UserName = UserName;
                    frmavanslar.AvansTipi = "Bankaya Yatan";
                    frmavanslar.Text = @"Bankaya Yatan";
                    frmavanslar.lblPersonel.Text = personelName + @" Bankaya Yatan";
                    frmavanslar.Flag = false;
                    var dr = frmavanslar.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        TipListesiniGetir();
                    }
                }
            }
            if (column == colTipAvansi)
            {
                var rowid = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "Personel No");
                var personelName = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "Personel");

                MySqlConnection con = new MySqlConnection(Settings.Default.livegameConnectionString2);
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("spAvanslariGoster;", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {

                        cmd.Parameters.Add(new MySqlParameter("rowID", rowid));
                        cmd.Parameters.Add(new MySqlParameter("StartDate", Convert.ToDateTime(barEditItem2.EditValue.ToString())));
                        cmd.Parameters.Add(new MySqlParameter("EndDate", Convert.ToDateTime(barEditItem1.EditValue.ToString())));
                        con.Open();
                        cmd.ExecuteNonQuery();
                        using (var mySqlDataAdapter = new MySqlDataAdapter())
                        {
                            var ds = new DataSet("Detaylar");
                            //DataTable dataTable = new DataTable();
                            mySqlDataAdapter.SelectCommand = cmd;
                            mySqlDataAdapter.Fill(ds);
                            // Create a new form.
                            var form = new XtraForm {Text = personelName + @" Avans Detayları"};
                            var grid = new GridControl
                            {
                                Parent = form,
                                Dock = DockStyle.Fill,
                                DataSource = ds.Tables[0]
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
                        con.Close();
                    }
                }
                finally
                {
                    con.Dispose();
                }
            }
        }



        private void bandedGridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            var view = (GridView)sender;
            if (e.Column != toplamtip) return;
            if (e.IsGetData)
            {
                e.Value = Convert.ToDouble(view.GetListSourceRowCellValue(e.ListSourceRowIndex, colTipPuani)) *
                          Convert.ToDouble(txtDagitilacakPuanBasi.Text);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            layoutControl1.ShowPrintPreview();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void frmTipListesi_FormClosing(object sender, FormClosingEventArgs e)
        {
            bandedGridView1.SaveLayoutToXml("tipFormview.xml", DevExpress.Utils.OptionsLayoutBase.FullLayout);
        }

        private void frmTipListesi_Shown(object sender, EventArgs e)
        {
            if (File.Exists("tipFormview.xml"))
            {
                bandedGridView1.RestoreLayoutFromXml("tipFormview.xml", DevExpress.Utils.OptionsLayoutBase.FullLayout);
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TipListesiniGetir();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            try
            {
                saveDialog.Filter = @"Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    var exportFilePath = saveDialog.FileName;
                    var fileExtenstion = new FileInfo(exportFilePath).Extension;
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
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            var msg =
                                $"The file could not be opened.{Environment.NewLine}{Environment.NewLine}Path: {exportFilePath}";
                            MessageBox.Show(msg, @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        var msg =
                            $"The file could not be saved.{Environment.NewLine}{Environment.NewLine}Path: {exportFilePath}";
                        MessageBox.Show(msg, @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            finally
            {
                saveDialog.Dispose();
            }
        }
    }
}
