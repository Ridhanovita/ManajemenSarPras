using SatprasDesktopApp.Config;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ManajemenSarPras
{
    public partial class permintaanBarang : Form
    {
        private string selectedIdPermintaan = "";
        private int jumlahLama = 0;

        public permintaanBarang()
        {
            InitializeComponent();
            // Menghapus binding otomatis jika ada untuk mencegah double klik
            this.addPeminta.Click -= addPeminta_Click;
            this.addPeminta.Click += addPeminta_Click;

            this.updatePminjam.Click -= updatePminjam_Click;
            this.updatePminjam.Click += updatePminjam_Click;

            this.hpsPermintaan.Click -= hpsPermintaan_Click;
            this.hpsPermintaan.Click += hpsPermintaan_Click;
        }

        private void permintaanBarang_Load(object sender, EventArgs e)
        {
            LoadComboRuangan();
            RefreshSemuaTabel();
            ResetForm();
        }

        private void RefreshSemuaTabel()
        {
            LoadStockBarang();
            LoadDataPermintaan();
        }

        // --- FUNGSI CEK STOK ASLI DARI DATABASE ---
        private int AmbilStokTerbaru(string idBarang)
        {
            int stok = 0;
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    string sql = "SELECT stok FROM [master].[barang] WHERE idBarang = @id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", idBarang);
                    object res = cmd.ExecuteScalar();
                    if (res != null) stok = Convert.ToInt32(res);
                }
            }
            catch { }
            return stok;
        }

        private void addPeminta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdBarang.Text) || string.IsNullOrEmpty(txtJmlh.Text)) return;

            int minta = int.Parse(txtJmlh.Text);
            int stokReal = AmbilStokTerbaru(txtIdBarang.Text);

            // VALIDASI: Jika permintaan lebih besar dari stok
            if (minta > stokReal)
            {
                MessageBox.Show($"Permintaan Gagal! Stok tersedia hanya {stokReal}. Anda meminta {minta}.",
                                "Peringatan Stok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Berhenti di sini, tidak lanjut ke ExecuteQuery
            }

            string q = "INSERT INTO [transaction].[permintaanBarang] (idBarang, idRuangan, namaPeminta, jumlah, tglPermintaan, idSemester) VALUES (@idB, @idR, @nama, @jml, GETDATE(), @smt)";
            ExecuteQuery(q, "Permintaan Berhasil Ditambahkan", "INSERT");
        }

        private void updatePminjam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedIdPermintaan)) return;

            int mintaBaru = int.Parse(txtJmlh.Text);
            int stokReal = AmbilStokTerbaru(txtIdBarang.Text);

            // Validasi Update: Stok sekarang + jumlah yang dipinjam sebelumnya harus cukup untuk jumlah baru
            if ((stokReal + jumlahLama) < mintaBaru)
            {
                MessageBox.Show("Perubahan Gagal! Stok di gudang tidak mencukupi untuk penambahan jumlah ini.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string q = "UPDATE [transaction].[permintaanBarang] SET idBarang=@idB, idRuangan=@idR, namaPeminta=@nama, jumlah=@jml, idSemester=@smt WHERE idPermintaanBarang=@idPB";
            ExecuteQuery(q, "Data Berhasil Diperbarui", "UPDATE");
        }

        private void hpsPermintaan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedIdPermintaan)) return;

            if (MessageBox.Show("Hapus permintaan ini? Stok akan dikembalikan.", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string q = "DELETE FROM [transaction].[permintaanBarang] WHERE idPermintaanBarang=@idPB";
                ExecuteQuery(q, "Data Berhasil Dihapus", "DELETE");
            }
        }

        private void ExecuteQuery(string query, string msg, string type)
        {
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int jmlInput = (type == "DELETE") ? 0 : int.Parse(txtJmlh.Text);

                        cmd.Parameters.AddWithValue("@idB", txtIdBarang.Text);
                        cmd.Parameters.AddWithValue("@idR", cmbRuangan.SelectedValue ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@nama", txtNma.Text);
                        cmd.Parameters.AddWithValue("@jml", jmlInput);
                        cmd.Parameters.AddWithValue("@smt", txtSmt.Text);
                        cmd.Parameters.AddWithValue("@idPB", selectedIdPermintaan);
                        cmd.ExecuteNonQuery();

                        // LOGIKA STOK YANG DIPERBAIKI
                        string sqlStok = "";
                        if (type == "INSERT")
                            sqlStok = "UPDATE [master].[barang] SET stok = stok - @jmlBaru WHERE idBarang = @idB";
                        else if (type == "DELETE")
                            sqlStok = "UPDATE [master].[barang] SET stok = stok + @jmlLama WHERE idBarang = @idB";
                        else if (type == "UPDATE")
                            sqlStok = "UPDATE [master].[barang] SET stok = stok + (@jmlLama - @jmlBaru) WHERE idBarang = @idB";

                        using (SqlCommand cmdStok = new SqlCommand(sqlStok, conn))
                        {
                            cmdStok.Parameters.AddWithValue("@idB", txtIdBarang.Text);
                            cmdStok.Parameters.AddWithValue("@jmlLama", jumlahLama);
                            cmdStok.Parameters.AddWithValue("@jmlBaru", jmlInput);
                            cmdStok.ExecuteNonQuery();
                        }

                        MessageBox.Show(msg, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshSemuaTabel();
                        ResetForm();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Database Error: " + ex.Message); }
        }

        // --- BAGIAN LOAD DATA & UI (TIDAK BERUBAH) ---
        private void LoadComboRuangan()
        {
            try
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
            catch { }
        }

        private void LoadStockBarang()
        {
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    string query = "SELECT idBarang AS [ID], namaBarang AS [Nama], stok AS [Stok] FROM [master].[barang]";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch { }
        }

        private void LoadDataPermintaan()
        {
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    string query = @"SELECT p.idPermintaanBarang AS [ID], p.idBarang AS [ID Barang], b.namaBarang AS [Nama Barang], 
                                     r.namaRuangan AS [Nama Ruangan], p.namaPeminta AS [Peminta], p.jumlah AS [Qty], p.idSemester AS [Smt]
                                     FROM [transaction].[permintaanBarang] p
                                     JOIN [master].[barang] b ON p.idBarang = b.idBarang
                                     JOIN [master].[ruangan] r ON p.idRuangan = r.idRuangan";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable(); da.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
            }
            catch { }
        }

        private void ResetForm()
        {
            txtIdBarang.Clear(); cmbRuangan.SelectedIndex = -1; txtNma.Clear();
            txtJmlh.Clear(); txtSmt.Clear(); selectedIdPermintaan = ""; jumlahLama = 0;
        }

        private void txtNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) txtIdBarang.Text = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
        }

        private void dgvPermintaan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                selectedIdPermintaan = row.Cells["ID"].Value.ToString();
                txtIdBarang.Text = row.Cells["ID Barang"].Value.ToString();
                cmbRuangan.Text = row.Cells["Nama Ruangan"].Value.ToString();
                txtNma.Text = row.Cells["Peminta"].Value.ToString();
                txtJmlh.Text = row.Cells["Qty"].Value.ToString();
                txtSmt.Text = row.Cells["Smt"].Value.ToString();
                jumlahLama = Convert.ToInt32(row.Cells["Qty"].Value);
            }
        }

        private void stockBarang_Click(object sender, EventArgs e) => RefreshSemuaTabel();
        private void btnKembali_Click(object sender, EventArgs e) { new dashboardPage().Show(); this.Hide(); }
    }
}