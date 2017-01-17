using System;
using System.Drawing;
using System.Windows.Forms;
using Break_List.Properties;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using MySql.Data.MySqlClient;

namespace Break_List.Forms.Admin
{
    public partial class FrmPermissions : RibbonForm
    {
        public FrmPermissions()
        {
            InitializeComponent();
            repositoryItemCheckEdit1.ValueChecked = Convert.ToByte(1);
            repositoryItemCheckEdit1.ValueUnchecked = Convert.ToByte(0);
        }

        private void frmPermissions_Load(object sender, EventArgs e)
        {
            permissionsTableAdapter.Fill(livegameDataSet1.permissions);
        }




        private void repositoryItemCheckEdit1_QueryCheckStateByValue(object sender, QueryCheckStateByValueEventArgs e)
        {
            var val = "";

            if (e.Value != null)
            {
                val = e.Value.ToString();
            }

            e.CheckState = val.Equals("1") ? CheckState.Checked : CheckState.Unchecked;

            e.Handled = true;
        }

        private void Kaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            const string caption = "Kullanici haklari yenilenecek";
            const string message = "Kullanıcı haklarını değiştirmek istedişinizden emin misiniz? ";
            var buttons = MessageBoxButtons.YesNo;
            var result = XtraMessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                Validate();
                permissionsBindingSource.EndEdit();
                tableAdapterManager.UpdateAll(livegameDataSet1);

            }
            else
            {
                permissionsBindingSource.CancelEdit();
                permissionsTableAdapter.Fill(livegameDataSet1.permissions);
            }
        }

        private void permissionGrid_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

        }

        public int UserId { get; set; }
        public bool copied = false;
        private void permissionGrid_MouseDown(object sender, MouseEventArgs e)
        {
            GridHitInfo hitInfo = permissionGrid.CalcHitInfo(new Point(e.X, e.Y));
            if (copied)
            {

                if ((e.Button & MouseButtons.Right) != 0 && hitInfo.InRow &&
                    !permissionGrid.IsGroupRow(hitInfo.RowHandle))
                {
                    // switching focus 
                    permissionGrid.FocusedRowHandle = hitInfo.RowHandle;
                    // showing the custom context menu 
                    var rowid = (int) ((GridView) sender).GetRowCellValue(hitInfo.RowHandle, "UserID");
                    UserId = rowid;
                    var menu = new ViewMenu(permissionGrid);
                    var menuItem = new DXMenuItem("Yetkileri Yapistir",
                        PasteRow) {Tag = permissionGrid};
                    menu.Items.Add(menuItem);
                    menu.Show(hitInfo.HitPoint);
                }
            }
            else
            {
                if ((e.Button & MouseButtons.Right) != 0 && hitInfo.InRow &&
                 !permissionGrid.IsGroupRow(hitInfo.RowHandle))
                {
                    // switching focus 
                    permissionGrid.FocusedRowHandle = hitInfo.RowHandle;
                    // showing the custom context menu 
                    var rowid = (int)((GridView)sender).GetRowCellValue(hitInfo.RowHandle, "UserID");
                    UserId = rowid;
                    var menu = new ViewMenu(permissionGrid);
                    var menuItem = new DXMenuItem("Yetkileri Kopyala",
                        CopyRow) {Tag = permissionGrid};
                    menu.Items.Add(menuItem);
                    menu.Show(hitInfo.HitPoint);
                }
            }
            
        }

        private void PasteRow(object sender, EventArgs e)
        {
            copied = false;
            permissionGrid.SetRowCellValue(permissionGrid.FocusedRowHandle,colAppointments, BreakList);
            permissionGrid.SetRowCellValue(permissionGrid.FocusedRowHandle, colRoster, Rota);
            permissionGrid.SetRowCellValue(permissionGrid.FocusedRowHandle, colUsers, Admin);
            permissionGrid.SetRowCellValue(permissionGrid.FocusedRowHandle, colpersonelEkle, AddPersonel);
            permissionGrid.SetRowCellValue(permissionGrid.FocusedRowHandle, colKasa, Kasa);
            permissionGrid.SetRowCellValue(permissionGrid.FocusedRowHandle, colOnay, Onay);
            permissionGrid.SetRowCellValue(permissionGrid.FocusedRowHandle, colRapor, Rapor);
            permissionGrid.SetRowCellValue(permissionGrid.FocusedRowHandle, colResources, Personel);
            permissionGrid.SetRowCellValue(permissionGrid.FocusedRowHandle, colEgitim, Egitim);
            permissionGrid.SetRowCellValue(permissionGrid.FocusedRowHandle, colCount, Count);
            permissionGrid.SetRowCellValue(permissionGrid.FocusedRowHandle, colDashboar, Dashboard);
            permissionGrid.SetRowCellValue(permissionGrid.FocusedRowHandle, colEnvanter, Envanter);
            permissionGrid.SetRowCellValue(permissionGrid.FocusedRowHandle, colTurnuva, Turnuva);
            permissionGrid.SetRowCellValue(permissionGrid.FocusedRowHandle, colSlot, Slot);
            permissionGrid.SetRowCellValue(permissionGrid.FocusedRowHandle, colProsedur, Prosedur);

        }

        private readonly string _str = Settings.Default.livegameConnectionString2;

        public bool BreakList      {get;set;}
        public bool Rota           {get;set;}
        public bool Admin          {get;set;}
        public bool AddPersonel    {get;set;}
        public bool Kasa           {get;set;}
        public bool Onay           {get;set;}
        public bool Rapor          {get;set;}
        public bool Prosedur       {get;set;}
        public bool Personel       {get;set;}
        public bool Egitim         {get;set;}
        public bool Count          {get;set;}
        public bool Dashboard      {get;set;}
        public bool Envanter       {get;set;}
        public bool Turnuva        {get;set;}
        public bool Slot           { get; set; }
        private void CopyRow(object sender, EventArgs e)
        {
            var conn = new MySqlConnection(_str);
            var command = conn.CreateCommand();
            command.CommandText = $"SELECT * from permissions WHERE UserID ='{UserId}'";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"There were an Error", ex.ToString());
            }
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                BreakList = Convert.ToBoolean(reader["Appointments"].ToString());
                Rota = Convert.ToBoolean(reader["Roster"].ToString());
                Admin = Convert.ToBoolean(reader["Users"].ToString());
                AddPersonel = Convert.ToBoolean(reader["personelEkle"].ToString());
                Kasa = Convert.ToBoolean(reader["kasa"].ToString());
                Onay = Convert.ToBoolean(reader["onay"].ToString());
                Rapor = Convert.ToBoolean(reader["rapor"].ToString());
                Prosedur = Convert.ToBoolean(reader["prosedur"].ToString());
                Personel = Convert.ToBoolean(reader["resources"].ToString());
                Egitim = Convert.ToBoolean(reader["egitim"].ToString());
                Count = Convert.ToBoolean(reader["count"].ToString());
                Dashboard = Convert.ToBoolean(reader["dashboard"].ToString());
                Envanter = Convert.ToBoolean(reader["envanter"].ToString());
                Turnuva = Convert.ToBoolean(reader["turnuva"].ToString());
                Slot = Convert.ToBoolean(reader["slot"].ToString());
            }
            conn.Close();
            copied = true;

        }
    }
}