using System;
using Break_List.Properties;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Break_List.Forms.Teknik
{
    public partial class FrmTeknikTakip : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string Department;
        public string User { private get; set; }
        public FrmTeknikTakip()
        {
            InitializeComponent();
            biten.PageVisible = false;
            GetDepartments();
        }
        private void Gorevler() // Aktıf gorevler
        {
            using (var conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                var cmd = new MySqlCommand("spTeknikGorevler;", conn) { CommandType = CommandType.StoredProcedure };
               
                conn.Open();

                using (var adapter = new MySqlDataAdapter())
                {
                    var dt = new DataTable();
                    adapter.SelectCommand = cmd;
                    {
                        adapter.Fill(dt);
                        gridControl1.DataSource = dt;
                    }
                }
                conn.Close();
                conn.Dispose();
            }
        }
        private void Tamamlanan() // tamamlanan gorevler
        {
            using (var conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                var cmd = new MySqlCommand("spTeknikBitenGorevler;", conn) { CommandType = CommandType.StoredProcedure };
                

                conn.Open();

                using (var adapter = new MySqlDataAdapter())
                {
                    var dt = new DataTable();
                    adapter.SelectCommand = cmd;
                    {
                        adapter.Fill(dt);
                        gridControl2.DataSource = dt;
                    }
                }
                conn.Close();
                conn.Dispose();
            }
        }

        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            popupMenu1.ShowPopup(MousePosition);
        }

        private void btntamam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            biten.PageVisible = true;
            bekleyen.PageVisible = false;
            biten.Show();
            Tamamlanan();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bekleyen.PageVisible = true;
            biten.PageVisible = false;
            bekleyen.Show();
            Gorevler();
        }


        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            var column = e.Column;
            if (column != colBitir) return;
            var rowid = (int) ((GridView) sender).GetRowCellValue(e.RowHandle, "id");

            var dialogResult = XtraMessageBox.Show("Seçilen Görev tamamlanmış sayılacak", "Dikkat",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult != DialogResult.Yes) return;

            var yeniGorev = new FrmAddGorev
            {
                User = User,
                UpdateRowId = rowid,
                Departman = Department,
                YeniGorev = false

            };
            var dr = yeniGorev.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Gorevler();
            }
            else
            {
                Gorevler();
            }

            
        }

        private void gridControl2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
               popupMenu1.ShowPopup(MousePosition);
            }
               
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var yeniGorev = new FrmAddGorev
            {
                User = User,
                Departman = Department,
                YeniGorev = true
            };
            var dr = yeniGorev.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Gorevler();
            }
        }

        private void FrmTeknikTakip_Load(object sender, System.EventArgs e)
        {
            Gorevler();
        }

        private void barEditItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void GetDepartments() // Yeni Kayit Olusturulurken Aliyor
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

        private void btnFiltre_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var value = combo.EditValue;
            if (biten.PageVisible)
            {
                gridView2.SetRowCellValue(GridControl.AutoFilterRowHandle, gridView1.Columns["Departman"], value);
            }
            if (bekleyen.PageVisible)
            {
                gridView1.SetRowCellValue(GridControl.AutoFilterRowHandle, gridView1.Columns["Departman"], value);
            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "colGecikme":
                    if (Convert.ToDecimal(e.Value) <= 0) e.DisplayText = "YOK";
                    break;
            }
        }

        private void gridView2_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "colGecikme":
                    if (Convert.ToDecimal(e.Value) <= 0) e.DisplayText = "YOK";
                    break;
            }
        }
    }
}