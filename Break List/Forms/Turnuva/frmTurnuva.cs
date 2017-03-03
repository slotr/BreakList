using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Break_List.Class;
using DevExpress.XtraGrid.Views.Grid;
using MySql.Data.MySqlClient;

namespace Break_List.Forms.Turnuva
{
    public partial class FrmTurnuva : XtraForm
    {
        private readonly ClsTurnuva _turnuva = new ClsTurnuva();
        

        public FrmTurnuva()
        {
            InitializeComponent();
        }

        private void frmTurnuva_Load(object sender, EventArgs e)
        {
            LoadActiveTournament();
            if (TournamentActive)
            {
                btnNewTournament.Text = @"Turnuvayı Bitir";
                labelControl1.Text = _turnuva.TurnuvaAdi;
                GEtTurnuvaTotals();
            }
            else
            {
                btnNewTournament.Text = @"Turnuva YARAT";
            }
        }

        private bool TournamentActive { get; set; }
        private static TileItem GetItem()
        {
            var item = new TileItem();
            return item;
        }

        private void MasalariGetir()
        {
            try
            {
                using (MySqlConnection conn = DbConnection.Con)
                {
                    var cmd = new MySqlCommand("spTurnuva_Masalar;", conn) {CommandType = CommandType.StoredProcedure};
                    cmd.Parameters.Add(new MySqlParameter("p_turnuva_ID", _turnuva.TurnuvaId));

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
                            item.Text = Convert.ToString(t["Masa"]);
                            item.TextAlignment = TileItemContentAlignment.TopCenter;
                            //item.Text3 = Convert.ToString(rows[i]["Guid"]);
                            item.Text2 = Convert.ToString(t["Total Rebuy"]);
                            item.Text2Alignment = TileItemContentAlignment.BottomLeft;
                            group.Items.Add(item);
                        }
                        if (tileControl1.Groups.Count > 0)
                        {
                            tileControl1.Groups.RemoveAt(0);
                            tileControl1.Groups.Add(group);
                        }
                        else
                        {
                            tileControl1.Groups.Add(group);
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void MasalariGetirDate()
        {
            try
            {
                using (var conn = DbConnection.Con)
                {
                    var cmd = new MySqlCommand("spTurnuva_Masalar_Date;", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new MySqlParameter("p_turnuva_ID", _turnuva.TurnuvaId));
                    cmd.Parameters.Add(new MySqlParameter("p_tarih", dtTurnuva.DateTime));
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
                        foreach (var t in rows)
                        {
                            var item = GetItem();
                            item.Text = Convert.ToString(t["Masa"]);
                            item.TextAlignment = TileItemContentAlignment.TopCenter;
                            //item.Text3 = Convert.ToString(rows[i]["Guid"]);
                            item.Text2 = Convert.ToString(t["Total Rebuy"]);
                            item.Text2Alignment = TileItemContentAlignment.BottomLeft;
                            group.Items.Add(item);
                        }
                        if (tileControl1.Groups.Count > 0)
                        {
                            tileControl1.Groups.RemoveAt(0);
                            tileControl1.Groups.Add(group);
                        }
                        else
                        {
                            tileControl1.Groups.Add(group);
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadActiveTournament()
        {
            using (var conn = DbConnection.Con)
            {
                var cmd = new MySqlCommand("spTurnuva_Load_active_tournament;", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();
                var dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    if (dbr.HasRows)
                    {
                        TournamentActive = Convert.ToBoolean(dbr["turnuva_finished"].ToString());
                        _turnuva.TurnuvaId = dbr["turnuva_id"].ToString();
                        _turnuva.TurnuvaTarihi = Convert.ToDateTime(dbr["tarih"].ToString());
                        _turnuva.TurnuvaAdi = dbr["turnuva_name"].ToString();
                        _turnuva.TopDenom1 = dbr["ilk_spin_5K"].ToString();
                        _turnuva.TopDenom2 = dbr["5K"].ToString();
                        _turnuva.TopDenom3 = dbr["10K"].ToString();
                        _turnuva.TopDenom4 = dbr["25K"].ToString();
                        _turnuva.TopDenom5 = dbr["50K"].ToString();
                        _turnuva.TopDenom6 = dbr["100K"].ToString();
                        _turnuva.Rebuy1 = Convert.ToInt32(dbr["rebuy1"].ToString());
                        _turnuva.Rebuy2 = Convert.ToInt32(dbr["rebuy2"].ToString());
                        _turnuva.Rebuy3 = Convert.ToInt32(dbr["rebuy3"].ToString());
                        _turnuva.Rebuy4 = Convert.ToInt32(dbr["rebuy4"].ToString());
                        _turnuva.Rebuy5 = Convert.ToInt32(dbr["rebuy5"].ToString());
                        _turnuva.Rebuy6 = Convert.ToInt32(dbr["rebuy6"].ToString());
                        _turnuva.o1 = Convert.ToInt32(dbr["o1"].ToString());
                        _turnuva.o2 = Convert.ToInt32(dbr["o2"].ToString());
                        _turnuva.o3 = Convert.ToInt32(dbr["o3"].ToString());
                        _turnuva.o4 = Convert.ToInt32(dbr["o4"].ToString());
                        _turnuva.o5 = Convert.ToInt32(dbr["o5"].ToString());
                        _turnuva.o6 = Convert.ToInt32(dbr["o6"].ToString());
                        _turnuva.o7 = Convert.ToInt32(dbr["o7"].ToString());
                        _turnuva.o8 = Convert.ToInt32(dbr["o8"].ToString());
                        _turnuva.o9 = Convert.ToInt32(dbr["o9"].ToString());
                        _turnuva.o10 = Convert.ToInt32(dbr["o10"].ToString());
                        _turnuva.o11 = Convert.ToInt32(dbr["o11"].ToString());
                        _turnuva.o12 = Convert.ToInt32(dbr["o12"].ToString());
                        _turnuva.o13 = Convert.ToInt32(dbr["o13"].ToString());
                        _turnuva.o14 = Convert.ToInt32(dbr["o14"].ToString());
                        _turnuva.o15 = Convert.ToInt32(dbr["o15"].ToString());
                    }
                    else
                    {
                        TournamentActive = false;
                    }
                }
                conn.Close();
            }
        }


        private void GEtTurnuvaTotals()
        {
            using (var mySqlConnection = DbConnection.Con)
            {
                var cmd = new MySqlCommand("spTurnuva_Totals;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new MySqlParameter("p_turnuva_ID", _turnuva.TurnuvaId));
                mySqlConnection.Open();
                var dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    if (dbr.HasRows)
                    {
                        lblReentry.Text = @"Re-Entry Tot: " + dbr["Toplam ReEntry"];
                        lblKatilimci.Text = @"Katilimci: " + dbr["Toplam Katilimci"];
                        lblTurnTotal.Text = @"Re-Buy Tot: " + dbr["Toplam Rebuy"];
                    }
                }
                mySqlConnection.Close();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (btnNewTournament.Text == @"Turnuva YARAT")
            {
                var yeni = new FrmYeniTurnuva {YeniTurnuva = true};
                var dr = yeni.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadActiveTournament();
                    if (TournamentActive)
                    {
                        btnNewTournament.Text = @"Turnuvayı Bitir";
                        labelControl1.Text = _turnuva.TurnuvaAdi;
                        GEtTurnuvaTotals();
                    }
                    else
                    {
                        btnNewTournament.Text = @"Turnuva YARAT";
                    }
                }
            }
            else
            {
                var dr = XtraMessageBox.Show("Turnuvayı Bitireceksiniz", "Emin misiniz?", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                    
                    TurnuvayiBitir();
                    LoadActiveTournament();
                    if (TournamentActive)
                    {
                        btnNewTournament.Text = @"Turnuvayı Bitir";
                        labelControl1.Text = _turnuva.TurnuvaAdi;
                        GEtTurnuvaTotals();
                    }
                    else
                    {
                        btnNewTournament.Text = @"Turnuva YARAT";
                    }
                }
                
            }
        }

        private void TurnuvayiBitir()
        {
            using (var conn = DbConnection.Con)
            {
                var cmd = new MySqlCommand("spTournamant_Finish;", conn) {CommandType = CommandType.StoredProcedure};

                cmd.Parameters.Add(new MySqlParameter("p_trnID", _turnuva.TurnuvaId));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Close();}
            
        }

        private void SelectDistinctClientAll()
        {
            using (var cnn = DbConnection.Con)
            using (var cmd = cnn.CreateCommand())
            {
                cnn.Open();
                cmd.CommandText = "spTurnuva_select_uniqueClient";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("p_turnuva_ID", _turnuva.TurnuvaId));

                DataTable dt = new DataTable();
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    gridClient.DataSource = dt;
                }
            }
        }

       

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (dtTurnuva.EditValue == null)
            {
                XtraMessageBox.Show(@"Turnuva Round Tarihini secin", @"Dikkat");
                dtTurnuva.Focus();
                dtTurnuva.ShowPopup();
            }
            else
            {
                var katilimci = new FrmAddRebuy
                {
                    TurnuvaAdi = _turnuva.TurnuvaAdi,
                    KatilimTarihi = dtTurnuva.DateTime,
                    TurnuvaId = _turnuva.TurnuvaId,
                  
                };
                var dr = katilimci.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    SelectDistinctClientDate();
                }
               
               MasalariGetirDate();
               GEtTurnuvaTotals();
            }
        }

        private string _musteri;
        private string _masa;
        private int Id { get; set; }
        private void gridView2_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            _musteri = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "Katilimci");
            _masa = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "Masa");
            Id = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "id");
            var column = e.Column;

            #region colHareket
            if (column == colHareket)
            {
                if (dtTurnuva.EditValue != null)
                {
                    var yeniGiris = new FrmAddRebuy
                    {
                        Musteri = _musteri,
                        KatilimTarihi = dtTurnuva.DateTime,
                        TopDenom1 = _turnuva.TopDenom1,
                        TopDenom2 = _turnuva.TopDenom2,
                        TopDenom3 = _turnuva.TopDenom3,
                        TopDenom4 = _turnuva.TopDenom4,
                        TopDenom5 = _turnuva.TopDenom5,
                        TopDenom6 = _turnuva.TopDenom6,
                        Rebuy1 = _turnuva.Rebuy1,
                        Rebuy2 = _turnuva.Rebuy2,
                        Rebuy3 = _turnuva.Rebuy3,
                        Rebuy4 = _turnuva.Rebuy4,
                        Rebuy5 = _turnuva.Rebuy5,
                        Rebuy6 = _turnuva.Rebuy6,
                        Masa = _masa,
                        TurnuvaAdi = _turnuva.TurnuvaAdi,
                        NewRecord = true,
                        TurnuvaId = _turnuva.TurnuvaId
                    };
                    var dr = yeniGiris.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        GetMusteriDetay();
                       
                        gridControl1.Refresh();
                        gridClient.Refresh();
                    }
                }
                else
                {
                    XtraMessageBox.Show(@"Turnuva Round Tarihini secin", @"Dikkat");
                    dtTurnuva.Focus();
                    dtTurnuva.ShowPopup();
                }

            }


            #endregion

            if (column == colEdit)
            {
                var editMusteri = new FrmKatilimcics
                {
                    KatilimciId = _musteri,
                    Text = _musteri,
                    simpleButton1 = {Text = @"Update"}
                };
                var dr = editMusteri.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    if (dtTurnuva.EditValue == null)
                    {
                        SelectDistinctClientAll();
                    }
                    else
                    {
                        SelectDistinctClientDate();
                    }
                    
                }
            }
            if (column == colSil)
            {
                var dr = XtraMessageBox.Show("Musteri silinecek. Eğer müşteriye ait kayıt varsa öncelikle bu kayıtları Cancel butonuna basarak silin", "Emin misiniz?", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        using (MySqlConnection conn = DbConnection.Con)
                        {
                            var cmd = new MySqlCommand("spTurnuva_Delete_Katilimci", conn)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd.Parameters.Add(new MySqlParameter("p_id", Id));
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        if (dtTurnuva.EditValue == null)
                        {
                            SelectDistinctClientAll();
                            
                            GEtTurnuvaTotals();
                        }
                        else
                        {
                            SelectDistinctClientDate();
                            
                            GEtTurnuvaTotals();
                        }
                        GetMusteriDetay();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString(),"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    
                }
            }
            else
            {
                
                GetMusteriDetay();
                
                GEtTurnuvaTotals();
            }
        }

        private void GetMusteriDetay()
        {
            lblOyuncu.Text = _musteri;

            using (var conn = DbConnection.Con)
            {
                var cmd = new MySqlCommand("spTurnuva_musteri_toplam_rebuy;", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new MySqlParameter("p_musteri", _musteri));
                conn.Open();
                var dbr = cmd.ExecuteReader();
                while (dbr.Read())
                {
                    if (true)
                    {
                        lblRebuyAlacak.Text = dbr["Alacak"].ToString();
                        lblTotRebuy.Text = dbr["Rebuy"].ToString();
                        lblTotReEntry.Text = dbr["ReEntry"].ToString();
                        lblReentryAlacak.Text = dbr["ReEntry Alacak"].ToString();
                        lblScore.Text = dbr["Score"].ToString();
                    }}
                conn.Close();
            }
            using (MySqlConnection conn = DbConnection.Con)
            {
                var cmd = new MySqlCommand("spTournament_Musteri_hareketleri;", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new MySqlParameter("p_musteri", _musteri));
                cmd.Parameters.Add(new MySqlParameter("p_turnuva_ID", _turnuva.TurnuvaId));
                conn.Open();
                cmd.ExecuteNonQuery();
                using (var adapter = new MySqlDataAdapter())
                {
                    adapter.SelectCommand = cmd;

                    var dt = new DataTable();

                    adapter.Fill(dt);
                    gridControl1.DataSource = dt;
                }
            }
        }

        private void SelectDistinctClientDate()
        {
            using (var cnn = DbConnection.Con)
            using (var cmd = cnn.CreateCommand())
            {
                cnn.Open();
                cmd.CommandText = "spTurnuva_select_uniqueClient_Date";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("p_turnuva_ID", _turnuva.TurnuvaId));
                cmd.Parameters.Add(new MySqlParameter("p_tarih", dtTurnuva.DateTime));
                var dt = new DataTable();
                using (var da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    gridClient.DataSource = dt;
                }
            }
        }



        private void labelControl1_Click(object sender, EventArgs e)
        {
            if (TournamentActive)
            {
                var updateTurnuva = new FrmYeniTurnuva
                {
                    TurnuvaId = _turnuva.TurnuvaId,
                    Text = @"Update Turnuva",
                    YeniTurnuva = false
                };
                var dr = updateTurnuva.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadActiveTournament();
                    
                    labelControl1.Text = _turnuva.TurnuvaAdi;
                }
            }
        }

      

        

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            var tvscreen = new FrmTvScreen
            {
                TurnuvaAdi = _turnuva.TurnuvaAdi,
                TurnuvaId = _turnuva.TurnuvaId
            };
            tvscreen.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SelectDistinctClientAll();
            MasalariGetir();
            GEtTurnuvaTotals();
            tileControl1.Text = @"Turnuva Geneli";
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (dtTurnuva.EditValue == null)
            {
                XtraMessageBox.Show(@"Tarih Seciniz");
                dtTurnuva.Focus();
                dtTurnuva.ShowPopup();
                dtTurnuva.DateTime = DateTime.Today;
            }
            else
            {

                SelectDistinctClientDate();
                MasalariGetirDate();
                GEtTurnuvaTotals();
                tileControl1.Text = @"Secilen Tarihte Masalar";

            }
        }
        
        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            Id = (int)((GridView)sender).GetRowCellValue(e.RowHandle, "id");
            var column = e.Column;
            if (column == colgedit)
            {
                var updateRecord = new FrmAddRebuy
                {
                    
                    KatilimTarihi = dtTurnuva.DateTime,
                    TopDenom1 = _turnuva.TopDenom1,
                    TopDenom2 = _turnuva.TopDenom2,
                    TopDenom3 = _turnuva.TopDenom3,
                    TopDenom4 = _turnuva.TopDenom4,
                    TopDenom5 = _turnuva.TopDenom5,
                    TopDenom6 = _turnuva.TopDenom6,
                    Rebuy1 = _turnuva.Rebuy1,
                    Rebuy2 = _turnuva.Rebuy2,
                    Rebuy3 = _turnuva.Rebuy3,
                    Rebuy4 = _turnuva.Rebuy4,
                    Rebuy5 = _turnuva.Rebuy5,
                    Rebuy6 = _turnuva.Rebuy6,

                    TurnuvaAdi = _turnuva.TurnuvaAdi,
                    RecordID = Id
                };
                updateRecord.btnOK.Text = @"Update";
                var dr = updateRecord.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    GetMusteriDetay();
                    
                    GEtTurnuvaTotals();
                }
            }
            if (column == colgSil)
            {
                var dr = XtraMessageBox.Show("Musteriye ait seçilen kayıt silinecek", "Emin misiniz?", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                    using (var conn = DbConnection.Con)
                    {
                        using (var cmd = new MySqlCommand("Delete from tblturnuva_katilimci where id=" + Id, conn)
                        {
                            CommandType = CommandType.Text
                        })
                        {


                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            conn.Dispose();
                        }
                    }
                    GetMusteriDetay();
                    GEtTurnuvaTotals();}
                   
            }
        }
    }
}