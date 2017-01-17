using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Break_List.Class;
using Break_List.Forms.Prosedur;
using Break_List.Properties;
using DevExpress.XtraGrid.Views.Grid;
using MySql.Data.MySqlClient;

namespace Break_List.Forms.Turnuva
{
    public partial class FrmTurnuva : XtraForm
    {
        private readonly ClsTurnuva _turnuva = new ClsTurnuva();

        private const string ConString =
            "server=192.168.0.187;user id=hakan;password=26091974;persistsecurityinfo=True;database=livegame";

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
                GetClassification();
            }
            else
            {
                btnNewTournament.Text = @"Turnuva YARAT";
            }
        }

        private bool TournamentActive { get; set; }
        private int TurnuvaId { get; set; }
        private DateTime TurnuvaTarihi { get; set; }

        

        private static TileItem GetItem()
        {
            var item = new TileItem();
            return item;
        }

        private void MasalariGetir()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    var cmd = new MySqlCommand("spTurnuva_Masalar;", conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("p_turnuvaID", _turnuva.TurnuvaAdi));

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
                using (var conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
                {
                    var cmd = new MySqlCommand("spTurnuva_Masalar_Date;", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new MySqlParameter("p_turnuvaID", _turnuva.TurnuvaAdi));
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
            using (var conn = new MySqlConnection(ConString))
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
                        _turnuva.TurnuvaID = Convert.ToInt32(dbr["turnuva_id"].ToString());
                        TurnuvaTarihi = Convert.ToDateTime(dbr["tarih"].ToString());
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
            using (var mySqlConnection = new MySqlConnection(ConString))
            {
                var cmd = new MySqlCommand("spTurnuva_Totals;", mySqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new MySqlParameter("p_turnuvaadi", _turnuva.TurnuvaAdi));
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
                var yeni = new FrmYeniTurnuva();
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

        private void TurnuvayiBitir()
        {
            using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                var cmd = new MySqlCommand("spTournamant_Finish;", conn) {CommandType = CommandType.StoredProcedure};

                cmd.Parameters.Add(new MySqlParameter("p_trnID", TurnuvaId));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void SelectDistinctClientAll()
        {
            using (MySqlConnection cnn = new MySqlConnection(ConString))
            using (MySqlCommand cmd = cnn.CreateCommand())
            {
                cnn.Open();
                cmd.CommandText = "spTurnuva_select_uniqueClient";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("p_turnuva_adi", _turnuva.TurnuvaAdi));

                DataTable dt = new DataTable();
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    gridClient.DataSource = dt;
                }
            }
        }

        private void GetClassification()
        {
            using (MySqlConnection cnn = new MySqlConnection(ConString))
            using (MySqlCommand cmd = cnn.CreateCommand())
            {
                cnn.Open();
                cmd.CommandText = "spTurnuva_scoreBoard";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("p_turnuva_adi", _turnuva.TurnuvaAdi));

                DataTable dt = new DataTable();
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                    gridTop.DataSource = dt;
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
                var katilimci = new FrmKatilimcics
                {
                    TurnuvaAdi = _turnuva.TurnuvaAdi,
                    KatilimTarihi = dtTurnuva.DateTime
                };
                var dr = katilimci.ShowDialog();
                if (dr != DialogResult.OK) return;
                if (checkButton1.Checked)
                {
                    SelectDistinctClientAll();
                }
                else
                {
                    SelectDistinctClientDate();
                }
            }
        }

        private string _musteri;
        private string _masa;

        private void gridView2_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            var column = e.Column;
            if (column == colHareket)
            {
                _musteri = (string) ((GridView) sender).GetRowCellValue(e.RowHandle, "Katilimci");
                _masa = (string) ((GridView) sender).GetRowCellValue(e.RowHandle, "Masa");
                var yeniGiris = new FrmAddRebuy
                {
                    musteri = _musteri,
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
                    masa = _masa,
                    TurnuvaAdi = _turnuva.TurnuvaAdi,
                };
                var dr = yeniGiris.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    GetMusteriDetay();
                    GetClassification();
                }
            }
            else
            {
                _musteri = (string) ((GridView) sender).GetRowCellValue(e.RowHandle, "Katilimci");
                GetMusteriDetay();
            }
        }

        private void GetMusteriDetay()
        {
            lblOyuncu.Text = _musteri;

            using (var conn = new MySqlConnection(ConString))
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
            using (MySqlConnection conn = new MySqlConnection(Settings.Default.livegameConnectionString2))
            {
                var cmd = new MySqlCommand("spTournament_Musteri_hareketleri;", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("p_musteri", _musteri));
                cmd.Parameters.Add(new MySqlParameter("p_turnuva", _turnuva.TurnuvaAdi));
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
            using (var cnn = new MySqlConnection(ConString))
            using (var cmd = cnn.CreateCommand())
            {
                cnn.Open();
                cmd.CommandText = "spTurnuva_select_uniqueClient_Date";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("p_turnuva_adi", _turnuva.TurnuvaAdi));
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
                    TurnuvaID = _turnuva.TurnuvaID,
                    Text = @"Update Turnuva",
                    YeniTurnuva = false
                };
                var dr = updateTurnuva.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadActiveTournament();
                    GetClassification();
                }
            }
        }

        private void checkButton1_Click(object sender, EventArgs e)
        {
            if (checkButton1.Text == @"Turnuva Genelini Göster")
            {
                SelectDistinctClientAll();
                MasalariGetir();
                tileControl1.Text = @"Turnuva Geneli Masalar";
                checkButton1.Text = @"Tarihe Göre Göster";
                checkButton1.Appearance.BackColor = Color.Crimson;
            }
            else
            {
                if (dtTurnuva.EditValue == null & checkButton1.Text == @"Tarihe Göre Göster")
                {
                    XtraMessageBox.Show(@"Tarih Seciniz");
                    dtTurnuva.Focus();
                    dtTurnuva.ShowPopup();
                    dtTurnuva.DateTime = DateTime.Today;}
                else
                {
                    
                    SelectDistinctClientDate();
                    MasalariGetirDate();
                    tileControl1.Text = @"Secilen Tarihte Masalar";
                    checkButton1.Text = @"Turnuva Genelini Göster";
                    checkButton1.Appearance.BackColor = Color.RoyalBlue;
                }

            }
        }

        private void checkButton1_CheckedChanged_1(object sender, EventArgs e)
        {
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            var tvscreen = new FrmTVScreen
            {
                TurnuvaAdi = _turnuva.TurnuvaAdi,
                TurnuvaID = _turnuva.TurnuvaID
            };
            tvscreen.ShowDialog();
        }
    }
}