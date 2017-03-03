using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Break_List.Class;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Tile;
using MySql.Data.MySqlClient;

namespace Break_List.Forms.Personel
{
    public partial class FrmIstenAyrilmis : XtraForm
    {
        public string DepartmentNameFromMainForm { get; set; }
        public int PersonelId;
        public string UserNameFromMainForm { get; set; }
        public string UserId { get; set; }
        private bool HaspermissionToAllPersonel { get; set; }
        public FrmIstenAyrilmis()
        {
            InitializeComponent();           
            
        }

        private void frmPersonel_Load(object sender, EventArgs e)
        {
            GetNames();
            
            labelControl1.Text = UserId;
        }

        private void GetNames()
        {
            CheckPermissions();
            if(HaspermissionToAllPersonel)
            {
                using (var conn = DbConnection.Con)
                {
                    var command = new MySqlCommand("spPersonelIstenAyrilmisAll", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };



                    conn.Open();

                    using (var adapter = new MySqlDataAdapter())
                    {
                        var dt = new DataTable();
                        adapter.SelectCommand = command;
                        {
                            adapter.Fill(dt);
                            resourcesGridControl.DataSource = dt;
                        }
                    }
                    conn.Close();
                }
            }
            else
            {
                using (var conn = DbConnection.Con)
                {
                    var command = new MySqlCommand("spPersonelIstenAyrilmis;", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    var department = DepartmentNameFromMainForm;
                    command.Parameters.Add(new MySqlParameter("DepartmentName", department));
                    
                    conn.Open();

                    using (var adapter = new MySqlDataAdapter())
                    {
                        var dt = new DataTable();
                        adapter.SelectCommand = command;
                        {
                            adapter.Fill(dt);
                            resourcesGridControl.DataSource = dt;
                        }
                    }
                    conn.Close();
                }
            }
            

        }

        private void CheckPermissions() //Department , Role ve Full adi aliyor.
        {
            var conn = DbConnection.Con;
            var command = conn.CreateCommand();
            command.CommandText = "SELECT * from permissions WHERE UserID ='" + UserId + "'";
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
               HaspermissionToAllPersonel = Convert.ToBoolean(reader["AllPersonel"].ToString());
                

            }
            conn.Close();
        }

        private void SetupView()
        {
            try
            {
                // Setup tiles options
                tileView1.BeginUpdate();
                tileView1.OptionsTiles.RowCount = 6;
                tileView1.OptionsTiles.Padding = new Padding(20);
                tileView1.OptionsTiles.ItemPadding = new Padding(10);
                tileView1.OptionsTiles.IndentBetweenItems = 20;
                tileView1.OptionsTiles.ItemSize = new Size(340, 190);
                tileView1.Appearance.ItemNormal.ForeColor = Color.White;
                tileView1.Appearance.ItemNormal.BorderColor = Color.FromArgb(52, 73, 94);
                //Setup tiles template
                var leftPanel = new TileViewItemElement();
                var splitLine = new TileViewItemElement();
                var nameSurnameCaption = new TileViewItemElement();
                var addressValue = new TileViewItemElement();
                var departmentCaption = new TileViewItemElement();
                var departmentValue = new TileViewItemElement();
                var price = new TileViewItemElement();
                var image = new TileViewItemElement();
                tileView1.TileTemplate.Add(leftPanel);
                tileView1.TileTemplate.Add(splitLine);
                tileView1.TileTemplate.Add(nameSurnameCaption);
                tileView1.TileTemplate.Add(addressValue);
                tileView1.TileTemplate.Add(departmentCaption);
                tileView1.TileTemplate.Add(departmentValue);
                tileView1.TileTemplate.Add(price);
                tileView1.TileTemplate.Add(image);
                //
                leftPanel.StretchVertical = true;
                leftPanel.Width = 122;
                leftPanel.TextLocation = new Point(-10, 0);
                leftPanel.Appearance.Normal.BackColor = Color.FromArgb(192, 57, 43);
                //
                splitLine.StretchVertical = true;
                splitLine.Width = 3;
                splitLine.TextAlignment = TileItemContentAlignment.Manual;
                splitLine.TextLocation = new Point(110, 0);
                splitLine.Appearance.Normal.BackColor = Color.White;
                //
                nameSurnameCaption.Text = @"Name Surname";
                nameSurnameCaption.TextAlignment = TileItemContentAlignment.TopLeft;
                nameSurnameCaption.Appearance.Normal.FontSizeDelta = -1;
                //
                addressValue.Column = tileView1.Columns["FullName"];
                addressValue.AnchorElement = nameSurnameCaption;
                addressValue.AnchorIndent = 2;
                addressValue.MaxWidth = 100;
                addressValue.Appearance.Normal.FontStyleDelta = FontStyle.Bold;
                //
                departmentCaption.Text = @"Department";
                departmentCaption.AnchorElement = addressValue;
                departmentCaption.AnchorIndent = 14;
                departmentCaption.Appearance.Normal.FontSizeDelta = -1;
                //
                departmentValue.Column = tileView1.Columns["Department"];
                departmentValue.AnchorElement = departmentCaption;
                departmentValue.AnchorIndent = 2;
                departmentValue.Appearance.Normal.FontStyleDelta = FontStyle.Bold;
                //
                price.Column = tileView1.Columns["Personel ID"];
                price.TextAlignment = TileItemContentAlignment.BottomLeft;
                price.Appearance.Normal.Font = new Font("Segoe UI Semilight", 25.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
                //
                image.Column = tileView1.Columns["Image"];
                image.ImageSize = new Size(280, 220);
                image.ImageAlignment = TileItemContentAlignment.MiddleRight;
                image.ImageScaleMode = TileItemImageScaleMode.ZoomOutside;
                image.ImageLocation = new Point(10, 10);

            }
            finally
            {
                tileView1.ColumnSet.GroupColumn = tileView1.Columns["Department"];
                tileView1.EndUpdate();
            }
        }

        private void tileView1_ItemClick(object sender, TileViewItemClickEventArgs e)
        {
           
                PersonelId = (int)((TileView)sender).GetRowCellValue(e.Item.RowHandle, "Personel ID");

            var personel = new FrmPersonelDetails
            {
                MdiParent = ParentForm,
                PersonelId = PersonelId.ToString(),
                UserNameFromMainForm = UserNameFromMainForm,
                UserId = labelControl1.Text
              
            };
            personel.Show();
           

        }

        private void FrmIstenAyrilmis_Shown(object sender, EventArgs e)
        {
            SetupView();
        }
    }
}