using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using Break_List.Properties;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace Break_List.Forms.Raporlar
{
    public partial class FrmCcalismaSaatleriByManager : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmCcalismaSaatleriByManager()
        {
            InitializeComponent();
        }

        private void frmCcalismaSaatleriByManager_Load(object sender, EventArgs e)
        {
            GetDepartments();
        }
        private void GetTimes()
        {
            using (var mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                using (var mySqlCommand = new MySqlCommand("spCalismaSaatleriAll;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    
                    mySqlCommand.Parameters.Add(new MySqlParameter("StartDate", dateEdit.EditValue));
                    //mySqlCommand.Parameters.Add(new MySqlParameter("EndDate", dateEdit2.EditValue));
                    mySqlCommand.Parameters.Add(new MySqlParameter("DepartmentName", DptcomboBox.EditValue));
                    mySqlConnection.Open();
                    mySqlCommand.ExecuteNonQuery();
                    using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter())
                    {
                        DataTable dataTable = new DataTable();
                        mySqlDataAdapter.SelectCommand = mySqlCommand;
                        mySqlDataAdapter.Fill(dataTable);
                        gridControl1.DataSource = dataTable;
                        
                    }
                    mySqlConnection.Close();
                }
            }
        }
       
        void GetDepartments() // Yeni Kayit Olusturulurken Aliyor
        {

            var connectionString = Settings.Default.livegameConnectionString2;
            using (MySqlConnection cnn = new MySqlConnection(connectionString))
            using (MySqlCommand cmd = cnn.CreateCommand())
            {
                cnn.Open();
                cmd.CommandText = "spDepartment";
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {

                        repositoryItemComboBox1.Items.Add(row["DepartmentName"]);

                    }

                    repositoryItemComboBox1.Sorted = true;


                }
            }

        }

        private void frmCcalismaSaatleriByManager_Shown(object sender, EventArgs e)
        {
            if (File.Exists("calismasaatleriFormview.xml"))
            {
                gridView1.RestoreLayoutFromXml("calismasaatleriFormview.xml", DevExpress.Utils.OptionsLayoutBase.FullLayout);
            }
        }

        private void frmCcalismaSaatleriByManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            gridView1.SaveLayoutToXml("calismasaatleriFormview.xml", DevExpress.Utils.OptionsLayoutBase.FullLayout);
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            var column = e.Column;
            if (column != colID)
            {
                var personel = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "ID");
                var personelNAme = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "Personel");
                using (var conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    var cmd = new MySqlCommand("spCalismaSaatleriDetay;", conn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.Add(new MySqlParameter("personelID", personel));
                    cmd.Parameters.Add(new MySqlParameter("tarih", dateEdit.EditValue));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    using (var mySqlDataAdapter = new MySqlDataAdapter())
                    {
                        var ds = new DataSet("Detaylar");
                        //DataTable dataTable = new DataTable();
                        mySqlDataAdapter.SelectCommand = cmd;
                        mySqlDataAdapter.Fill(ds);
                        // Create a new form.
                        var form = new XtraForm();
                        var grid = new GridControl
                        {
                            Parent = form,
                            Dock = DockStyle.Fill,
                            DataSource = ds.Tables[0]
                        };

                        var gridView = new GridView();
                        gridView.OptionsView.ColumnAutoWidth = false;
                        gridView.OptionsView.ShowGroupPanel = true;
                        gridView.OptionsView.RowAutoHeight = true;
                        gridView.OptionsBehavior.Editable = false;
                        grid.ViewCollection.Add(gridView);
                        grid.MainView = gridView;
                        gridView.OptionsBehavior.AutoExpandAllGroups = true;
                        gridView.Columns[2].GroupIndex = 0;
                        form.Bounds = new Rectangle(100, 100, 800, 600);
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.FormBorderEffect = FormBorderEffect.Shadow;
                        form.Text = personelNAme;
                        // Display the form.
                        form.ShowDialog();
                        form.Dispose();
                    }
                    conn.Close();
                    conn.Dispose();
                }
            }
            
        }

        private void btnGoster_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetTimes();
        }

        private void btnYazdır_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }
    }
}