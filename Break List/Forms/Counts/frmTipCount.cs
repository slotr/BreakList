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
using MySql.Data.MySqlClient;
using Break_List.Properties;

namespace Break_List.Forms.Counts
{
    public partial class frmTipCount : DevExpress.XtraEditors.XtraForm
    {
        public frmTipCount()
        {
            InitializeComponent();
        }
        private static TileItem GetItem()
        {
            var item = new TileItem();
            return item;
        }

        public int rowid { get; set; }
        private void frmTipCount_Load(object sender, EventArgs e)
        {
           
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                    {
                        MySqlCommand cmd = new MySqlCommand("spBringNonCountetTablesTip;", conn)
                        { CommandType = CommandType.StoredProcedure };
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        using (var adapter = new MySqlDataAdapter())
                        {
                            adapter.SelectCommand = cmd;

                            var dt = new DataTable();

                            adapter.Fill(dt);
                            var rows = dt.Select();
                            var group = new TileGroup();
                            // Print the value one column of each DataRow. 
                            foreach (DataRow t in rows)
                            {
                                var item = GetItem();
                                item.Text = Convert.ToString(t["masa"]);
                                //item.Text3 = Convert.ToString(rows[i]["Guid"]);
                                item.Tag = Convert.ToString(t["id"]);
                                @group.Items.Add(item);
                            }
                            tileControl1.Groups.Add(group);
                        }
                        conn.Close();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            GetTotals();
        }

        private void tileControl1_ItemClick(object sender, TileItemEventArgs e)
        {
            rowid = Convert.ToInt32(e.Item.Tag.ToString());
            
            using (var form = new frmTipAdd())
            {
                form.rowID = rowid;
                form.labelControl2.Text = e.Item.Text;
                var dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                    e.Item.AppearanceItem.Normal.BackColor = Color.OrangeRed;
                GetTotals();
            }
        }

        private void GetTotals()
        {
            using (var mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                var mySqlCommand = new MySqlCommand("Select SUM(tip) as TotalTip from tblcount", mySqlConnection)
                {
                    CommandType = CommandType.Text
                };

                mySqlConnection.Open();
                var mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                var dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "spTotalDropResult");

                tileControl1.Groups[0].Text = "Sayilan Toplam Tip: "+ dataSet.Tables["spTotalDropResult"].Rows[0]["TotalTip"].ToString();
                
                mySqlConnection.Close();
            }
        }
    }
}