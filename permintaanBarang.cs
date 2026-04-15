using SatprasDesktopApp.Config;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ManajemenSarPras
{
    public partial class permintaanBarang : Form
    {
        // State Management untuk melacak data sebelum diubah
        private string selectedIdPermintaan = "";
        private string idBarangLama = "";
        private int jumlahLama = 0;

        public permintaanBarang()
        {
            InitializeComponent();

            // Force Binding Events agar tombol berfungsi
            this.Load += new EventHandler(permintaanBarang_Load);
            this.addPeminta.Click += new EventHandler(addPeminta_Click);
            this.updatePminjam.Click += new EventHandler(updatePminjam_Click);
            this.hpsPermintaan.Click += new EventHandler(hpsPermintaan_Click);
            this.stockBarang.Click += new EventHandler(stockBarang_Click);
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            this.dataGridView2.CellClick += new DataGridViewCellEventHandler(dataGridView2_CellClick);
        }

        private void permintaanBarang_Load(object sender, EventArgs e)
        {
            LoadComboRuangan();
            LoadComboSemester();
            RefreshSemuaTabel();
            ResetForm();
        }

        // --- DATA LOADING ---
        private void LoadComboRuangan()
        {
            using (var conn = DatabaseConfig.GetConnection())
            {
                string query = "SELECT idRuangan, namaRuangan FROM [master].[ruangan]";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable(); da.Fill(dt);
                cmbRuangan.DataSource = dt;
                cmbRuangan.DisplayMember = "namaRuangan";
                cmbRuangan.ValueMember = "idRuangan";
                cmbRuangan.SelectedIndex = -1;
            }
        }

        private void LoadComboSemester()
        {
            using (var conn = DatabaseConfig.GetConnection())
            {
                string query = "SELECT idSemester, tahunAjaran FROM [master].[semester]";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable(); da.Fill(dt);
                cmbSemester.DataSource = dt;
                cmbSemester.DisplayMember = "tahunAjaran";
                cmbSemester.ValueMember = "idSemester";
                cmbSemester.SelectedIndex = -1;
            }
        }

        public void RefreshSemuaTabel()
        {
            using (var conn = DatabaseConfig.GetConnection())
            {
                // Refresh Katalog Stok
                SqlDataAdapter da1 = new SqlDataAdapter("SELECT idBarang AS [ID], namaBarang AS [Nama], stok AS [Stok] FROM [master].[barang]", conn);
                DataTable dt1 = new DataTable(); da1.Fill(dt1);
                dataGridView1.DataSource = dt1;

                // Refresh Data Permintaan
                string queryReq = @"SELECT p.idPermintaanBarang AS [ID], p.idBarang AS [ID Barang], b.namaBarang AS [Barang], 
                                     r.namaRuangan AS [Ruangan], p.namaPeminta AS [Peminta], p.jumlah AS [Qty], s.tahunAjaran AS [Semester]
                                     FROM [transaction].[permintaanBarang] p
                                     JOIN [master].[barang] b ON p.idBarang = b.idBarang
                                     JOIN [master].[ruangan] r ON p.idRuangan = r.idRuangan
                                     JOIN [master].[semester] s ON p.idSemester = s.idSemester";
                SqlDataAdapter da2 = new SqlDataAdapter(queryReq, conn);
                DataTable dt2 = new DataTable(); da2.Fill(dt2);
                dataGridView2.DataSource = dt2;
            }
        }

        // --- CRUD ACTIONS ---
        private void addPeminta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdBarang.Text) || string.IsNullOrEmpty(txtJmlh.Text)) return;
            string q = "INSERT INTO [transaction].[permintaanBarang] (idBarang, idRuangan, namaPeminta, jumlah, tglPermintaan, idSemester) VALUES (@idB, @idR, @nama, @jml, GETDATE(), @smt)";
            ExecuteQuery(q, "Tambah", int.Parse(txtJmlh.Text));
        }

        private void updatePminjam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedIdPermintaan)) return;
            string q = "UPDATE [transaction].[permintaanBarang] SET idBarang=@idB, idRuangan=@idR, namaPeminta=@nama, jumlah=@jml, idSemester=@smt WHERE idPermintaanBarang=@idPB";
            ExecuteQuery(q, "Update", int.Parse(txtJmlh.Text));
        }

        private void hpsPermintaan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedIdPermintaan)) return;
            string q = "DELETE FROM [transaction].[permintaanBarang] WHERE idPermintaanBarang=@idPB";
            ExecuteQuery(q, "Hapus", 0);
        }

        // --- CORE DATABASE ENGINE (FIXED STOK LOGIC) ---
        private void ExecuteQuery(string mainQuery, string actionType, int jmlBaru)
        {
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    // 1. Eksekusi Perubahan Data Permintaan
                    using (SqlCommand cmd = new SqlCommand(mainQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@idB", txtIdBarang.Text);
                        cmd.Parameters.AddWithValue("@idR", cmbRuangan.SelectedValue);
                        cmd.Parameters.AddWithValue("@nama", txtNma.Text);
                        cmd.Parameters.AddWithValue("@jml", jmlBaru);
                        cmd.Parameters.AddWithValue("@smt", cmbSemester.SelectedValue);
                        cmd.Parameters.AddWithValue("@idPB", selectedIdPermintaan);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Logika Update Stok Master (Penanganan Ganti Barang)
                    if (actionType == "Tambah")
                    {
                        UpdateStok(conn, txtIdBarang.Text, -jmlBaru); // Kurangi stok barang baru
                    }
                    else if (actionType == "Hapus")
                    {
                        UpdateStok(conn, idBarangLama, jumlahLama); // Kembalikan stok barang lama
                    }
                    else if (actionType == "Update")
                    {
                        if (txtIdBarang.Text == idBarangLama)
                        {
                            // Jika barang sama, update selisihnya
                            UpdateStok(conn, txtIdBarang.Text, (jumlahLama - jmlBaru));
                        }
                        else
                        {
                            // Jika barang diganti: Kembalikan stok lama, kurangi stok baru
                            UpdateStok(conn, idBarangLama, jumlahLama);
                            UpdateStok(conn, txtIdBarang.Text, -jmlBaru);
                        }
                    }

                    MessageBox.Show($"{actionType} Berhasil!", "Sukses");
                    RefreshSemuaTabel();
                    ResetForm();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void UpdateStok(SqlConnection conn, string idBarang, int perubahan)
        {
            string sql = "UPDATE [master].[barang] SET stok = stok + @diff WHERE idBarang = @id";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@diff", perubahan);
                cmd.Parameters.AddWithValue("@id", idBarang);
                cmd.ExecuteNonQuery();
            }
        }

        // --- UI HELPERS ---
        private void ResetForm()
        {
            txtIdBarang.Clear(); cmbRuangan.SelectedIndex = -1; txtNma.Clear();
            txtJmlh.Clear(); cmbSemester.SelectedIndex = -1;
            selectedIdPermintaan = ""; idBarangLama = ""; jumlahLama = 0;
        }

        private void stockBarang_Click(object sender, EventArgs e) => RefreshSemuaTabel();

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) txtIdBarang.Text = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dataGridView2.Rows[e.RowIndex];
                selectedIdPermintaan = r.Cells["ID"].Value.ToString();
                txtIdBarang.Text = r.Cells["ID Barang"].Value.ToString();
                idBarangLama = r.Cells["ID Barang"].Value.ToString(); // Simpan ID Lama
                cmbRuangan.Text = r.Cells["Ruangan"].Value.ToString();
                txtNma.Text = r.Cells["Peminta"].Value.ToString();
                txtJmlh.Text = r.Cells["Qty"].Value.ToString();
                jumlahLama = Convert.ToInt32(r.Cells["Qty"].Value); // Simpan Jumlah Lama
                cmbSemester.Text = r.Cells["Semester"].Value.ToString();
            }
        }

        private void btnKembali_Click(object sender, EventArgs e) { new dashboardPage().Show(); this.Hide(); }
    }
}