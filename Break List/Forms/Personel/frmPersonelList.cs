using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using DevExpress.XtraGrid.Views.Tile;
using Break_List.Properties;

namespace Break_List.Forms.Personel
{
    public partial class FrmPersonelList : XtraForm
    {
        public string DepartmentNameFromMainForm { get; set; }
        public int PersonelId;
        public string UserNameFromMainForm { get; set; }
        public string UserId { get; set; }
        Boolean HaspermissionToAllPersonel { get; set; }
        public string PersonelName;
        public FrmPersonelList()
        {
            InitializeComponent();           
            
        }

        private void frmPersonel_Load(object sender, EventArgs e)
        {
            
            GetNames();            
            SetupView();
            labelControl1.Text = UserId;
        }

        void GetNames()
        {
            CheckPermissions();
            if (HaspermissionToAllPersonel)
            {
                using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    MySqlCommand cmd = new MySqlCommand("spPersonelallActive;", conn) { CommandType = CommandType.StoredProcedure };


                    conn.Open();

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                    {
                        DataTable dt = new DataTable();
                        adapter.SelectCommand = cmd;
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
                using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    MySqlCommand cmd = new MySqlCommand("spPersonel;", conn) { CommandType = CommandType.StoredProcedure };
                    string department = DepartmentNameFromMainForm;
                    cmd.Parameters.Add(new MySqlParameter("DepartmentName", department));

                    conn.Open();

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                    {
                        DataTable dt = new DataTable();
                        adapter.SelectCommand = cmd;
                        {
                            adapter.Fill(dt);
                            resourcesGridControl.DataSource = dt;
                        }
                    }
                    conn.Close();
                }
            }


        }

        void CheckPermissions() //Department , Role ve Full adi aliyor.
        {
            MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2);
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = $"SELECT * from permissions WHERE UserID ='{UserId}'";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"There were an Error", ex.ToString());
            }
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
               HaspermissionToAllPersonel = Convert.ToBoolean(reader["AllPersonel"].ToString());
                

            }
            conn.Close();
        }

        void SetupView()
        {
            try
            {
                // Setup tiles options
                tileView1.BeginUpdate();
                tileView1.OptionsTiles.RowCount = 6;
                tileView1.OptionsTiles.Padding = new Padding(20);
                tileView1.OptionsTiles.ItemPadding = new Padding(10);
                tileView1.OptionsTiles.IndentBetweenItems = 20;
                tileView1.OptionsTiles.ItemSize = new Size(280, 190);
                tileView1.Appearance.ItemNormal.ForeColor = Color.White;
                tileView1.Appearance.ItemNormal.BorderColor = Color.FromArgb(52, 73, 94);
                //Setup tiles template
                TileViewItemElement leftPanel = new TileViewItemElement();
                TileViewItemElement splitLine = new TileViewItemElement();
                TileViewItemElement nameSurnameCaption = new TileViewItemElement();
                TileViewItemElement addressValue = new TileViewItemElement();
                TileViewItemElement departmentCaption = new TileViewItemElement();
                TileViewItemElement departmentValue = new TileViewItemElement();
                TileViewItemElement price = new TileViewItemElement();
                TileViewItemElement image = new TileViewItemElement();
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
                leftPanel.Appearance.Normal.BackColor = Color.FromArgb(52, 73, 94);
                //
                splitLine.StretchVertical = true;
                splitLine.Width = 3;
                splitLine.TextAlignment = TileItemContentAlignment.Manual;
                splitLine.TextLocation = new Point(110, 0);
                splitLine.Appearance.Normal.BackColor = Color.White;
                //
                nameSurnameCaption.Text = @"Adı Soyadı";
                nameSurnameCaption.TextAlignment = TileItemContentAlignment.TopLeft;
                nameSurnameCaption.Appearance.Normal.FontSizeDelta = -1;
                //
                addressValue.Column = tileView1.Columns["FullName"];
                addressValue.AnchorElement = nameSurnameCaption;
                addressValue.AnchorIndent = 2;
                addressValue.MaxWidth = 100;
                addressValue.Appearance.Normal.FontStyleDelta = FontStyle.Bold;
                //
                departmentCaption.Text = @"Departman";
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
                price.Appearance.Normal.Font = new Font("Segoe UI Semilight", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
                //
                image.Column = tileView1.Columns["Image"];
                image.ImageSize = new Size(220, 220);
                image.ImageAlignment = TileItemContentAlignment.MiddleRight;
                image.ImageScaleMode = TileItemImageScaleMode.ZoomInside;
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
            PersonelName = (string)((TileView)sender).GetRowCellValue(e.Item.RowHandle, "FullName");
            var personel = new FrmPersonelDetails
            {
                //MdiParent = ParentForm,
                PersonelId = PersonelId.ToString(),
                UserNameFromMainForm = UserNameFromMainForm,
                UserId = labelControl1.Text,
                PersonelName = PersonelName

            };

            var dr = personel.ShowDialog();
            if (dr == DialogResult.OK)
            {
                GetNames();
            }
            else
            {
                GetNames();}


        }


    }
}