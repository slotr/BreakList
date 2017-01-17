using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using Break_List.Properties;
using DevComponents.DotNetBar.Keyboard;


namespace Break_List.Forms.Counts
{
    public partial class FrmTableCount : XtraForm
    {
        public FrmTableCount()
        {
            InitializeComponent();
            keyboardControl1.Keyboard = CreateNumericKeyboard();
            keyboardControl1.Invalidate();
        }
        private Keyboard CreateNumericKeyboard()
        {
            var keyboard = new Keyboard();

            var klNumLockOn = new LinearKeyboardLayout();


            klNumLockOn.AddKey("7");
            klNumLockOn.AddKey("8");
            klNumLockOn.AddKey("9");
            klNumLockOn.AddKey("Backspace", "{BACKSPACE}", height: 21);

            klNumLockOn.AddLine();

            klNumLockOn.AddKey("4");
            klNumLockOn.AddKey("5");
            klNumLockOn.AddKey("6");
            klNumLockOn.AddLine();

            klNumLockOn.AddKey("1");
            klNumLockOn.AddKey("2");
            klNumLockOn.AddKey("3");

            klNumLockOn.AddKey("OK", "{ENTER}", style: KeyStyle.Light, height: 21);
            klNumLockOn.AddLine();

            klNumLockOn.AddKey("0", width: 32);
            //klNumLockOn.AddKey(".");


            keyboard.Layouts.Add(klNumLockOn);


            return keyboard;
        } //Keyboard Ends
        private void frmTableCount_Load(object sender, EventArgs e)
        {
            ChechkIfThereIsCount();
            btnSave.Enabled = false;
            GetTotalTables();
            foreach (Control c in panelControl1.Controls)
            {
                if (c is TextEdit)
                {

                    c.Enabled = false;
                }
            }
        }
        private readonly string _str = Settings.Default.livegameConnectionString2;
        private void ChechkIfThereIsCount()
        {
            var con = new MySqlConnection(_str);
            var command1 = con.CreateCommand();
            command1.CommandText =
                "select * from tblcount";
            try
            {
                con.Open();
            }
            catch (Exception ex1)
            {
                MessageBox.Show(@"There were an Error", ex1.ToString());
            }
            var reader1 = command1.ExecuteReader();
            if (reader1.HasRows)
            {
                try
                {
                    mainPanel.Visible = true;
                    BringNonCountedTables();
                    BringCountedTables();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
            else
            {
                mainPanel.Visible = false;
                ShowCountInitiator();
            }
            
        }
        public DateTime CountTarihi;
        private void ShowCountInitiator()
        {
            using (var form = new FrmInitiator())
            {
                var dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                CountTarihi = form.dateEdit1.DateTime;
                mainPanel.Visible = true;
                BringNonCountedTables();
                BringCountedTables();
                
            }
        }

        
        public int Updateid;
        private void SetInsertUpdate()
        {


            try
            {
                using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    MySqlCommand cmd = new MySqlCommand("spInsertUpdateCount;", conn)
                    { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.Add(new MySqlParameter("_click",     txtClick.Text));
                    cmd.Parameters.Add(new MySqlParameter("_return",    txtReturn.Text));
                    cmd.Parameters.Add(new MySqlParameter("_advance",   txtAdvance.Text));
                    cmd.Parameters.Add(new MySqlParameter("_q5000",     txt5000.Text));
                    cmd.Parameters.Add(new MySqlParameter("_q1000",     txt1000.Text));
                    cmd.Parameters.Add(new MySqlParameter("_q500",      txt500.Text));
                    cmd.Parameters.Add(new MySqlParameter("_q100",      txt100.Text));
                    cmd.Parameters.Add(new MySqlParameter("_q25",       txt25.Text));
                    cmd.Parameters.Add(new MySqlParameter("_q5",        txt5.Text));
                    cmd.Parameters.Add(new MySqlParameter("_q1",        txt1.Text));
                    cmd.Parameters.Add(new MySqlParameter("_drop",      txtDrop.Text));
                    cmd.Parameters.Add(new MySqlParameter("_result",    txtResult.Text));
                    cmd.Parameters.Add(new MySqlParameter("updateid", Updateid));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString(), "Bir Hata oluştu");
            }
        }
        void DuzeltmeEgerVarsa()
        {
            using (var mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                var mySqlCommand = new MySqlCommand("spHatalimasa;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };


                mySqlCommand.Parameters.Add(new MySqlParameter("uniqueID", Updateid));
                mySqlConnection.Open();
                var mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                var dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "spHatalimasa");

                 txtClick.Text =dataSet.Tables["spHatalimasa"].Rows[0]["click"].ToString();
                 txtReturn.Text =dataSet.Tables["spHatalimasa"].Rows[0]["return"].ToString();
                 txtAdvance.Text = dataSet.Tables["spHatalimasa"].Rows[0]["advance"].ToString();
                txt5000.Text     = dataSet.Tables["spHatalimasa"].Rows[0]["q5000"].ToString();
                txt1000.Text     = dataSet.Tables["spHatalimasa"].Rows[0]["q1000"].ToString();
                txt500.Text      = dataSet.Tables["spHatalimasa"].Rows[0]["q500"].ToString();
                txt100.Text      = dataSet.Tables["spHatalimasa"].Rows[0]["q100"].ToString();
                txt25.Text       = dataSet.Tables["spHatalimasa"].Rows[0]["q25"].ToString();
                txt5.Text        = dataSet.Tables["spHatalimasa"].Rows[0]["q5"].ToString();
                txt1.Text        = dataSet.Tables["spHatalimasa"].Rows[0]["q1"].ToString();

            }
        }
        private void txtClick_EditValueChanged(object sender, EventArgs e)
        {
            if (txtClick.Text.Trim().Length == 0)
            {
                txtClick.Text = @"0";
                txtClcikTotal.Text = @"0";
            }
            else
            {

                txtClcikTotal.Text = (Convert.ToDouble(txtClick.Text) * 100).ToString(CultureInfo.InvariantCulture);
            }
            Hesapla();
        }
        public double Drop;
        public double Reuslt;
        private void Hesapla()
        {
            Drop = Convert.ToDouble(txt5000Total.Text) +
                Convert.ToDouble(txt1000Total.Text) +
                Convert.ToDouble(txt500Total.Text) +
                Convert.ToDouble(txt100Total.Text) +
                Convert.ToDouble(txt25Total.Text) +
                Convert.ToDouble(txt5Total.Text) +
                Convert.ToDouble(txt1Total.Text);
            txtDrop.Text = Drop.ToString(CultureInfo.InvariantCulture);
            Reuslt = Drop + Convert.ToDouble(txtreturnTotal.Text) -
                     Convert.ToDouble(txtAdvanceTotal.Text);
            txtResult.Text = Reuslt.ToString(CultureInfo.InvariantCulture);
            txtClDrop.Text = (Convert.ToDouble(txtClcikTotal.Text) - Drop).ToString(CultureInfo.InvariantCulture);

        }

        private void txtReturn_EditValueChanged(object sender, EventArgs e)
        {
            if (txtReturn.Text.Trim().Length == 0)
            {
                txtReturn.Text = @"0";
                txtreturnTotal.Text = @"0";
            }
            else
            {

                txtreturnTotal.Text = txtReturn.Text;
            }
            Hesapla();
        }

        private void txtAdvance_EditValueChanged(object sender, EventArgs e)
        {
            if (txtAdvance.Text.Trim().Length == 0)
            {
                txtAdvance.Text = @"0";
                txtAdvanceTotal.Text = @"0";
            }
            else
            {

                txtAdvanceTotal.Text = txtAdvance.Text;
            }
            Hesapla();
        }

        private void txt5000_EditValueChanged(object sender, EventArgs e)
        {
            if (txt5000.Text.Trim().Length == 0)
            {
                txt5000.Text = @"0";
                txt5000Total.Text = @"0";
            }
            else
            {

                txt5000Total.Text = (Convert.ToDouble(txt5000.Text)*5000).ToString(CultureInfo.InvariantCulture);
            }
            Hesapla();
        }

        private void txt1000_EditValueChanged(object sender, EventArgs e)
        {
            if (txt1000.Text.Trim().Length == 0)
            {
                txt1000.Text = @"0";
                txt1000Total.Text = @"0";
            }
            else
            {

                txt1000Total.Text = (Convert.ToDouble(txt1000.Text) * 1000).ToString(CultureInfo.InvariantCulture);
            }
            Hesapla();
        }

        private void txt500_EditValueChanged(object sender, EventArgs e)
        {
            if (txt500.Text.Trim().Length == 0)
            {
                txt500.Text = @"0";
                txt500Total.Text = @"0";
            }
            else
            {

                txt500Total.Text = (Convert.ToDouble(txt500.Text) * 500).ToString(CultureInfo.InvariantCulture);
            }
            Hesapla();
        }

        private void txt100_EditValueChanged(object sender, EventArgs e)
        {
            if (txt100.Text.Trim().Length == 0)
            {
                txt100.Text = @"0";
                txt100Total.Text = @"0";
            }
            else
            {

                txt100Total.Text = (Convert.ToDouble(txt100.Text) * 100).ToString(CultureInfo.InvariantCulture);
            }
            Hesapla();
        }

        private void txt25_EditValueChanged(object sender, EventArgs e)
        {
            if (txt25.Text.Trim().Length == 0)
            {
                txt25.Text = @"0";
                txt25Total.Text = @"0";
            }
            else
            {

                txt25Total.Text = (Convert.ToDouble(txt25.Text) * 25).ToString(CultureInfo.InvariantCulture);
            }
            Hesapla();
        }

        private void txt5_EditValueChanged(object sender, EventArgs e)
        {
            if (txt5.Text.Trim().Length == 0)
            {
                txt5.Text = @"0";
                txt5Total.Text = @"0";
            }
            else
            {

                txt5Total.Text = (Convert.ToDouble(txt5.Text) * 5).ToString(CultureInfo.InvariantCulture);
            }
            Hesapla();
        }

        private void txt1_EditValueChanged(object sender, EventArgs e)
        {
            if (txt1.Text.Trim().Length == 0)
            {
                txt1.Text = @"0";
                txt1Total.Text = @"0";
            }
            else
            {

                txt1Total.Text = txt1.Text;
            }
            Hesapla();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetInsertUpdate();
            BringNonCountedTables();
            BringCountedTables();
            GetTotals();
            GetTotalTables();
            foreach (Control c in panelControl1.Controls)
            {
                if (c is TextEdit)
                {
                    c.Text = @"0";
                    c.Enabled = false;
                }
            }
            btnSave.Enabled = false;
            txtClick.Focus();
            txtClick.SelectAll();
        }

        void GetTotalTables()
        {
            

                 using (MySqlConnection mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                using (MySqlCommand mySqlCommand = new MySqlCommand("spSumCountTables;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    
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

        private void GetTotals()
        {
            using (var mySqlConnection = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                var mySqlCommand = new MySqlCommand("spTotalDropResult;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
               
                mySqlConnection.Open();
                var mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                var dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "spTotalDropResult");
                
                lbltotDrop.Text = dataSet.Tables["spTotalDropResult"].Rows[0]["totaldrop"].ToString();
                lblTotResult.Text = dataSet.Tables["spTotalDropResult"].Rows[0]["totalresult"].ToString();
                mySqlConnection.Close();
            }
        }

        
        private static TileItem GetItem()
        {
            var item = new TileItem();
            return item;
        }
        private void BringCountedTables()
        {
            if (tileSayilanMasalar.Groups.Count == 1)
            {
                tileSayilanMasalar.Groups.RemoveAt(0);
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                    {
                        MySqlCommand cmd = new MySqlCommand("spBringCountetTables;", conn)
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
                                group.Items.Add(item);
                                group.Text = @"Sayılmış Masalar";
                            }

                            tileSayilanMasalar.Groups.Add(group);

                        }
                        conn.Close();

                    }
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.ToString(), "Bir Hata oluştu");
                }
            }
            else
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                    {
                        MySqlCommand cmd = new MySqlCommand("spBringCountetTables;", conn)
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
                                group.Items.Add(item);
                                group.Text = @"Sayılmış Masalar";
                            }

                            tileSayilanMasalar.Groups.Add(group);

                        }
                        conn.Close();

                    }
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.ToString(), "Bir Hata oluştu");
                }
            }
            
        }

        private void BringNonCountedTables()
        {
            if(tileNonCounted.Groups.Count != 0)
            {
                tileNonCounted.Groups.RemoveAt(0);
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                    {
                        MySqlCommand cmd = new MySqlCommand("spBringNonCountetTables;", conn)
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
                                group.Items.Add(item);
                                group.Text = @"Sayılacak Masalar";
                            }
                            tileNonCounted.Groups.Add(group);
                        }
                        conn.Close();

                    }
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.ToString(), "Bir Hata oluştu");
                }
            }
            else
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                    {
                        MySqlCommand cmd = new MySqlCommand("spBringNonCountetTables;", conn)
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
                                group.Items.Add(item);
                                group.Text = @"Sayılacak Masalar";
                            }
                            tileNonCounted.Groups.Add(group);
                        }
                        conn.Close();

                    }
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.ToString(), "Bir Hata oluştu");
                }
            }
            
        }

        private void tileNonCounted_ItemClick(object sender, TileItemEventArgs e)
        {
            Updateid = Convert.ToInt32(e.Item.Tag);
            lblMasa.Text = @"Sayılan Masa No: " + e.Item.Text;
            foreach (Control c in panelControl1.Controls)
            {
                if (c is TextEdit)
                {
                    
                    c.Enabled = true;
                }
            }
            btnSave.Enabled = true;
            txtClick.Focus();
            txtClick.SelectAll();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(@"Eğer varsa sayılmamış masalar da sayılmış" 
                + @"\n" + @"kabul edilecek ve günün countu bitirilecek", @"Emin misiniz?", MessageBoxButtons.YesNo);
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    try
                    {
                        using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                        {
                            var cmd = new MySqlCommand("spFinishCount;", conn)
                                { CommandType = CommandType.StoredProcedure };
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();

                        }
                    }
                    catch (Exception ex)
                    {

                        XtraMessageBox.Show(ex.ToString(), "Bir Hata oluştu");
                    }
                    Close();
                    break;
                case DialogResult.No:

                    break;
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FrmTipCount tip = new FrmTipCount();
            tip.ShowDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var print = new FrmPrintCount {Tarih = CountTarihi};
            print.ShowDialog();
        }

        private void txtClick_Enter(object sender, EventArgs e)
        {
            txtClick.SelectAll();
        }

        private void txtReturn_Enter(object sender, EventArgs e)
        {
            txtReturn.SelectAll();
        }

        private void txtAdvance_Enter(object sender, EventArgs e)
        {
            txtAdvance.SelectAll();
        }

        private void txt5000_Enter(object sender, EventArgs e)
        {
            txt5000.SelectAll();
        }

        private void txt1000_Enter(object sender, EventArgs e)
        {
            txt1000.SelectAll();
        }

        private void txt500_Enter(object sender, EventArgs e)
        {
            txt500.SelectAll();
        }

        private void txt100_Enter(object sender, EventArgs e)
        {
            txt100.SelectAll();
        }

        private void txt25_Enter(object sender, EventArgs e)
        {
            txt25.SelectAll();
        }

        private void txt5_Enter(object sender, EventArgs e)
        {
            txt5.SelectAll();
        }

        private void txt1_Enter(object sender, EventArgs e)
        {
            txt1.SelectAll();
        }

        private void tileSayilanMasalar_ItemClick(object sender, TileItemEventArgs e)
        {
            Updateid = Convert.ToInt32(e.Item.Tag);
            lblMasa.Text = @"Düzeltilecek Masa No: " + e.Item.Text;
            foreach (Control c in panelControl1.Controls)
            {
                if (c is TextEdit)
                {

                    c.Enabled = true;
                }
            }
            btnSave.Enabled = true;
            txtClick.Focus();
            txtClick.SelectAll();
            DuzeltmeEgerVarsa();
        }
    }
}