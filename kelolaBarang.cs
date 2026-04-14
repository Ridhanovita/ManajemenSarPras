using SatprasDesktopApp.Config; // Pastikan namespace ini sesuai
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
            cmbTipeBarang.SelectedIndex = -1;

            LoadComboBoxMerk();
            LoadAutoCompleteNamaBarang(); // Memuat memori nama barang sebelumnya
            LoadDataBarang();
            ResetForm();
        }

        private void LoadComboBoxMerk()
        {
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return;
                    string query = "SELECT idMerk, namaMerk FROM master.merk";
                    using (var da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbMerk.DataSource = dt;
                        cmbMerk.DisplayMember = "namaMerk";
                        cmbMerk.ValueMember = "idMerk";

                        // SIHIR UX: Mengizinkan user mengetik merk baru langsung di ComboBox
                        cmbMerk.DropDownStyle = ComboBoxStyle.DropDown;
                        cmbMerk.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        cmbMerk.AutoCompleteSource = AutoCompleteSource.ListItems;
                        cmbMerk.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error Load Merk: " + ex.Message); }
        }

        private void LoadAutoCompleteNamaBarang()
        {
            // SIHIR UX 2: Menyuntikkan AutoComplete ke TextBox Nama Barang agar seragam
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return;
                    string query = "SELECT DISTINCT namaBarang FROM master.barang";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
                            while (reader.Read())
                            {
                                source.Add(reader["namaBarang"].ToString());
                            }
                            txtNamaBarang.AutoCompleteCustomSource = source;
                            txtNamaBarang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            txtNamaBarang.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        }
                    }
                }
            }
            catch (Exception) { /* Abaikan jika gagal memuat autocomplete */ }
        }

        private void LoadDataBarang(string keyword = "")
        {
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return;

                    // QUERY BARU: Menarik data Merk dari relasi tabel master.merk
                    string query = @"
                        SELECT 
                            b.idBarang AS [ID/Kode Barang],
                            b.namaBarang AS [Nama Barang],
                            m.namaMerk AS [Merk],
                            b.stok AS [Sisa Stok],
                            CASE WHEN b.tipeBarang = 1 THEN 'Aset Tetap (Rutin)' ELSE 'Habis Pakai (Non-Rutin)' END AS [Kategori],
                            b.tipeBarang,
                            b.idMerk -- Hidden Column
                        FROM master.barang b
                        LEFT JOIN master.merk m ON b.idMerk = m.idMerk";

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        query += " WHERE b.namaBarang LIKE @keyword OR b.idBarang LIKE @keyword OR m.namaMerk LIKE @keyword";
                    }

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(keyword)) cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                        using (var da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;

                            if (dataGridView1.Columns["tipeBarang"] != null) dataGridView1.Columns["tipeBarang"].Visible = false;
                            if (dataGridView1.Columns["idMerk"] != null) dataGridView1.Columns["idMerk"].Visible = false;
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
            cmbMerk.SelectedIndex = -1;
            cmbMerk.Text = ""; // Pastikan teks merk kosong
            txtJumlahBarang.Clear();
            cmbTipeBarang.SelectedIndex = -1;

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

        private void cmbTipeBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipeBarang.SelectedIndex == -1 || cmbTipeBarang.SelectedValue == null) return;
            int tipe;
            if (!int.TryParse(cmbTipeBarang.SelectedValue.ToString(), out tipe)) return;

            if (tipe == 1) // Aset Tetap
            {
                txtJumlahBarang.Text = "0";
                txtJumlahBarang.ReadOnly = true;
                txtJumlahBarang.BackColor = SystemColors.Control;
            }
            else // Habis Pakai
            {
                txtJumlahBarang.ReadOnly = false;
                txtJumlahBarang.BackColor = SystemColors.Window;
                if (!isEditMode && txtJumlahBarang.Text == "0") txtJumlahBarang.Clear();
            }
        }

        private void txtStok_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            LoadDataBarang(txtCari.Text.Trim());
        }

        private void dgvBarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                originalIdBarang = row.Cells["ID/Kode Barang"].Value.ToString();
                txtIdBarang.Text = originalIdBarang;
                txtNamaBarang.Text = row.Cells["Nama Barang"].Value.ToString();
                cmbMerk.Text = row.Cells["Merk"].Value.ToString(); // Set text merk
                txtJumlahBarang.Text = row.Cells["Sisa Stok"].Value.ToString();
                cmbTipeBarang.SelectedValue = Convert.ToInt32(row.Cells["tipeBarang"].Value);

                txtIdBarang.ReadOnly = true;
                isEditMode = true;

                btnTambahBarang.Text = "Update";
                btnHapus.Enabled = true;
            }
        }

        // ==========================================================
        // FASE 3: MESIN TRANSAKSI & LAZY CREATION
        // ==========================================================

        // FUNGSI PINTAR: Cek merk, kalau belum ada otomatis buat baru
        private int GetOrCreateMerk(string namaMerk, SqlConnection conn, SqlTransaction trans)
        {
            namaMerk = namaMerk.Trim();

            // 1. Cek Case-Insensitive apakah merk sudah ada
            string checkQ = "SELECT idMerk FROM master.merk WHERE namaMerk = @nama";
            using (var cmd = new SqlCommand(checkQ, conn, trans))
            {
                cmd.Parameters.AddWithValue("@nama", namaMerk);
                object result = cmd.ExecuteScalar();
                if (result != null) return Convert.ToInt32(result); // Ketemu, gunakan ID lama
            }

            // 2. Jika tidak ketemu, buat baru di tabel master.merk
            string insertQ = "INSERT INTO master.merk (namaMerk) OUTPUT INSERTED.idMerk VALUES (@nama)";
            using (var cmd = new SqlCommand(insertQ, conn, trans))
            {
                cmd.Parameters.AddWithValue("@nama", namaMerk);
                return (int)cmd.ExecuteScalar(); // Kembalikan ID yang baru terbuat
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdBarang.Text) || string.IsNullOrWhiteSpace(txtNamaBarang.Text) ||
                string.IsNullOrWhiteSpace(cmbMerk.Text) || string.IsNullOrWhiteSpace(txtJumlahBarang.Text) || cmbTipeBarang.SelectedValue == null)
            {
                MessageBox.Show("Seluruh form wajib diisi.", "Validasi Ketat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tipeInput = Convert.ToInt32(cmbTipeBarang.SelectedValue);
            int stokInput = Convert.ToInt32(txtJumlahBarang.Text.Trim());

            if (tipeInput == 0 && stokInput <= 0 && !isEditMode)
            {
                MessageBox.Show("Barang Habis Pakai harus memiliki stok awal lebih dari 0.", "Peringatan Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return;

                    // MULAI TRANSAKSI (Mencegah Merk terbuat tapi Barang gagal tersimpan)
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // 1. Eksekusi Lazy Creation untuk Merk
                        int resolvedIdMerk = GetOrCreateMerk(cmbMerk.Text, conn, transaction);

                        string query;
                        if (isEditMode)
                        {
                            query = "UPDATE master.barang SET namaBarang = @nama, idMerk = @idMerk, stok = @stok, tipeBarang = @tipe WHERE idBarang = @idAsli";
                        }
                        else
                        {
                            string checkQuery = "SELECT COUNT(1) FROM master.barang WHERE idBarang = @id";
                            using (var checkCmd = new SqlCommand(checkQuery, conn, transaction))
                            {
                                checkCmd.Parameters.AddWithValue("@id", txtIdBarang.Text.Trim());
                                if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                                {
                                    throw new Exception("Kode/ID Barang tersebut sudah terpakai.");
                                }
                            }
                            // Insert dengan idMerk
                            query = "INSERT INTO master.barang (idBarang, namaBarang, idMerk, stok, tipeBarang) VALUES (@id, @nama, @idMerk, @stok, @tipe)";
                        }

                        // 2. Eksekusi Simpan Barang
                        using (var cmd = new SqlCommand(query, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", txtIdBarang.Text.Trim());
                            // Trim nama barang agar rapi
                            cmd.Parameters.AddWithValue("@nama", txtNamaBarang.Text.Trim());
                            cmd.Parameters.AddWithValue("@idMerk", resolvedIdMerk);
                            cmd.Parameters.AddWithValue("@stok", stokInput);
                            cmd.Parameters.AddWithValue("@tipe", tipeInput);

                            if (isEditMode) cmd.Parameters.AddWithValue("@idAsli", originalIdBarang);

                            cmd.ExecuteNonQuery();
                        }

                        // JIKA SEMUA SUKSES, SIMPAN PERMANEN
                        transaction.Commit();

                        MessageBox.Show($"Data inventaris berhasil {(isEditMode ? "diperbarui" : "disimpan")}!", "Operasi Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reload data untuk memperbarui Autocomplete & ComboBox
                        LoadComboBoxMerk();
                        LoadAutoCompleteNamaBarang();
                        LoadDataBarang();
                        ResetForm();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show(ex.Message, "Proses Dibatalkan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                            LoadAutoCompleteNamaBarang(); // Refresh autocomplete
                            LoadDataBarang();
                            ResetForm();
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    if (sqlEx.Number == 547)
                        MessageBox.Show("OPERASI DITOLAK: Integritas Data!\n\nBarang ini tidak dapat dihapus karena masih terikat dengan data Permintaan, Penempatan Ruangan, atau riwayat Maintenance.", "Proteksi Database Aktif", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Database Error: " + sqlEx.Message);
                }
            }
        }

        private void txtReset_Click(object sender, EventArgs e) { ResetForm(); }

        private void button3_Click(object sender, EventArgs e)
        {
            FormDetailBarang form = new FormDetailBarang();
            this.Hide();
            form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void kelolaBarang_Load(object sender, EventArgs e)
        {

        }

        private void txtNamaBarang_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void txtJumlahBarang_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateBarang_Click(object sender, EventArgs e)
        {

        }

        private void cmbTipeBarang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelJumlahBarang_Click(object sender, EventArgs e)
        {

        }

        private void btnTambahBarang_Click(object sender, EventArgs e)
        {

        }
    }
}