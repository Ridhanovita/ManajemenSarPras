using SatprasDesktopApp.Config; // Pastikan namespace koneksi ini sesuai dengan milik Anda
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ManajemenSarPras
{
    public partial class kelolaBarang : Form
    {
        // ==========================================================
        // VARIABEL GLOBAL (STATE MANAGEMENT)
        // ==========================================================
        private bool isEditMode = false;
        private string originalIdBarang = "";

        public kelolaBarang()
        {
            InitializeComponent();

            // MANUVER ARSITEK: Hardcode Event Binding
            this.Load += new EventHandler(kelolaBarang_Load);
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(dgvBarang_CellClick);
            this.txtCari.TextChanged += new EventHandler(txtCari_TextChanged);
            this.txtJumlahBarang.KeyPress += new KeyPressEventHandler(txtStok_KeyPress);
            this.cmbTipeBarang.SelectedIndexChanged += new EventHandler(cmbTipeBarang_SelectedIndexChanged);
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            dashboardPage dashboard = new dashboardPage();
            dashboard.Show();
            this.Hide();
        }

        // ==========================================================
        // FASE 1: INISIALISASI & PENARIKAN DATA
        // ==========================================================
        private void kelolaBarang_Load(object sender, EventArgs e)
        {
            // Setup ComboBox Tipe Barang
            DataTable dtTipe = new DataTable();
            dtTipe.Columns.Add("Value", typeof(int));
            dtTipe.Columns.Add("Display", typeof(string));

            dtTipe.Rows.Add(0, "Barang Habis Pakai (Non-Rutin)");
            dtTipe.Rows.Add(1, "Aset Tetap (Pengecekan Rutin)");

            cmbTipeBarang.DataSource = dtTipe;
            cmbTipeBarang.DisplayMember = "Display";
            cmbTipeBarang.ValueMember = "Value";
            cmbTipeBarang.SelectedIndex = -1; // Kosongkan form saat awal

            LoadDataBarang();
            ResetForm();
        }

        private void LoadDataBarang(string keyword = "")
        {
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return;

                    // TAMBAHAN MERK: Memasukkan kolom merk ke dalam query
                    string query = @"
                        SELECT 
                            idBarang AS [ID/Kode Barang],
                            namaBarang AS [Nama Barang],
                            merk AS [Merk],
                            stok AS [Sisa Stok],
                            CASE WHEN tipeBarang = 1 THEN 'Aset Tetap (Rutin)' ELSE 'Habis Pakai (Non-Rutin)' END AS [Kategori],
                            tipeBarang -- Kolom tersembunyi untuk logika sistem
                        FROM master.barang";

                    // Pencarian sekarang juga mencakup Merk
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        query += " WHERE namaBarang LIKE @keyword OR idBarang LIKE @keyword OR merk LIKE @keyword";
                    }

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(keyword))
                        {
                            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                        }

                        using (var da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;

                            // Sembunyikan kolom sistem dari pandangan user
                            if (dataGridView1.Columns["tipeBarang"] != null)
                                dataGridView1.Columns["tipeBarang"].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error Load Data: " + ex.Message); }
        }

        // ==========================================================
        // FASE 2: DYNAMIC UI & PENGENDALIAN STATE
        // ==========================================================
        private void ResetForm()
        {
            txtIdBarang.Clear();
            txtNamaBarang.Clear();
            txtMerk.Clear(); // TAMBAHAN MERK: Kosongkan text merk
            txtJumlahBarang.Clear();
            cmbTipeBarang.SelectedIndex = -1;

            // Buka semua gembok saat mode Insert
            txtIdBarang.ReadOnly = false;
            txtJumlahBarang.ReadOnly = false;
            txtJumlahBarang.BackColor = SystemColors.Window;

            isEditMode = false;
            originalIdBarang = "";

            btnTambahBarang.Text = "Simpan";
            btnHapus.Enabled = false;
            txtIdBarang.Focus();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        // DYNAMIC UI LOCKING: Aset Tetap vs Barang Habis Pakai
        private void cmbTipeBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipeBarang.SelectedIndex == -1 || cmbTipeBarang.SelectedValue == null) return;

            int tipe;
            if (!int.TryParse(cmbTipeBarang.SelectedValue.ToString(), out tipe)) return;

            if (tipe == 1) // 1 = Aset Tetap (Katalog Mode)
            {
                txtJumlahBarang.Text = "0";
                txtJumlahBarang.ReadOnly = true;
                txtJumlahBarang.BackColor = SystemColors.Control;
            }
            else // 0 = Barang Habis Pakai (Stok Langsung)
            {
                txtJumlahBarang.ReadOnly = false;
                txtJumlahBarang.BackColor = SystemColors.Window;

                if (!isEditMode && txtJumlahBarang.Text == "0")
                {
                    txtJumlahBarang.Clear();
                }
            }
        }

        // Proteksi Keyboard: Blokir input huruf di kotak stok
        private void txtStok_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Real-time Search Engine
        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            LoadDataBarang(txtCari.Text.Trim());
        }

        // Trigger Mode Update dari GridView
        private void dgvBarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                originalIdBarang = row.Cells["ID/Kode Barang"].Value.ToString();
                txtIdBarang.Text = originalIdBarang;
                txtNamaBarang.Text = row.Cells["Nama Barang"].Value.ToString();
                txtMerk.Text = row.Cells["Merk"].Value.ToString(); // TAMBAHAN MERK: Tarik dari grid
                txtJumlahBarang.Text = row.Cells["Sisa Stok"].Value.ToString();

                // Memicu cmbTipeBarang_SelectedIndexChanged secara otomatis
                cmbTipeBarang.SelectedValue = Convert.ToInt32(row.Cells["tipeBarang"].Value);

                // Kunci ID agar tidak dirusak user
                txtIdBarang.ReadOnly = true;
                isEditMode = true;

                btnTambahBarang.Text = "Update";
                btnHapus.Enabled = true;
            }
        }

        // ==========================================================
        // FASE 3: MESIN DATABASE (CRUD ROUTER & SMART VALIDATION)
        // ==========================================================
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // 1. Validasi Input Kosong (TERMASUK MERK)
            if (string.IsNullOrWhiteSpace(txtIdBarang.Text) || string.IsNullOrWhiteSpace(txtNamaBarang.Text) ||
                string.IsNullOrWhiteSpace(txtMerk.Text) || string.IsNullOrWhiteSpace(txtJumlahBarang.Text) || cmbTipeBarang.SelectedValue == null)
            {
                MessageBox.Show("Seluruh form wajib diisi. Tidak boleh ada data yang kosong.", "Validasi Ketat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Smart Validation (Logika Bisnis Aset vs Habis Pakai)
            int tipeInput = Convert.ToInt32(cmbTipeBarang.SelectedValue);
            int stokInput = Convert.ToInt32(txtJumlahBarang.Text.Trim());

            if (tipeInput == 0 && stokInput <= 0 && !isEditMode)
            {
                MessageBox.Show("Logika Bisnis Ditolak:\n\nUntuk mendaftarkan Barang Habis Pakai (Spidol, Kertas, dll), fisik barang harus sudah ada di gudang (Stok harus lebih dari 0).", "Peringatan Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtJumlahBarang.Focus();
                return;
            }

            // 3. Eksekusi Database
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return;

                    string query;
                    if (isEditMode)
                    {
                        // TAMBAHAN MERK: Update Set
                        query = "UPDATE master.barang SET namaBarang = @nama, merk = @merk, stok = @stok, tipeBarang = @tipe WHERE idBarang = @idAsli";
                    }
                    else
                    {
                        // Cegah ID Kembar
                        string checkQuery = "SELECT COUNT(1) FROM master.barang WHERE idBarang = @id";
                        using (var checkCmd = new SqlCommand(checkQuery, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@id", txtIdBarang.Text.Trim());
                            if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                            {
                                MessageBox.Show("Kode/ID Barang tersebut sudah dipakai oleh aset lain. Gunakan ID yang unik.", "Duplikasi Data Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        // TAMBAHAN MERK: Insert
                        query = "INSERT INTO master.barang (idBarang, namaBarang, merk, stok, tipeBarang) VALUES (@id, @nama, @merk, @stok, @tipe)";
                    }

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", txtIdBarang.Text.Trim());
                        cmd.Parameters.AddWithValue("@nama", txtNamaBarang.Text.Trim());
                        cmd.Parameters.AddWithValue("@merk", txtMerk.Text.Trim()); // Binding Merk
                        cmd.Parameters.AddWithValue("@stok", stokInput);
                        cmd.Parameters.AddWithValue("@tipe", tipeInput);

                        if (isEditMode) cmd.Parameters.AddWithValue("@idAsli", originalIdBarang);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show($"Data inventaris berhasil {(isEditMode ? "diperbarui" : "disimpan")}!", "Operasi Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadDataBarang();
                        ResetForm();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Kegagalan Server Database: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(originalIdBarang)) return;

            if (MessageBox.Show($"Apakah Anda yakin ingin memusnahkan '{txtNamaBarang.Text}' dari katalog sarpras?", "Konfirmasi Penghapusan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = DatabaseConfig.GetConnection())
                    {
                        if (conn == null) return;

                        string query = "DELETE FROM master.barang WHERE idBarang = @id";
                        using (var cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", originalIdBarang);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Aset berhasil dihapus dari sistem.", "Penghapusan Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataBarang();
                            ResetForm();
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Number == 547)
                    {
                        MessageBox.Show("OPERASI DITOLAK: Integritas Data!\n\nBarang ini tidak dapat dihapus karena masih terikat dengan data Permintaan, Penempatan Ruangan, atau riwayat Maintenance.", "Proteksi Database Aktif", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show("Database Error: " + sqlEx.Message);
                }
            }
        }

        private void txtReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormDetailBarang form = new FormDetailBarang();
            this.Hide();
            form.Show();
        }
    }
}