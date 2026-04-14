using SatprasDesktopApp.Config; // Pastikan namespace koneksi ini sesuai
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ManajemenSarPras
{
    public partial class formSemester : Form
    {
        // ==========================================================
        // VARIABEL GLOBAL PENGENDALI STATE
        // ==========================================================
        private bool isEditMode = false;
        private string originalIdSemester = "";

        public formSemester()
        {
            InitializeComponent();

            // HARDCODE EVENT BINDING: Membajak fungsi tombol lama tanpa mengubah namanya
            this.Load += new EventHandler(formSemester_Load);
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            this.txtCari.TextChanged += new EventHandler(txtCari_TextChanged);
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            dashboardPage dashboard = new dashboardPage();
            dashboard.Show();
            this.Hide();
        }

        // ==========================================================
        // FASE 1: LOAD DATA & STATE MANAGEMENT
        // ==========================================================
        private void formSemester_Load(object sender, EventArgs e)
        {
            LoadDataSemester();
            ResetForm();
        }

        private void LoadDataSemester(string keyword = "")
        {
            try
            {
                using (SqlConnection conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return;

                    string query = "SELECT idSemester as ID, tahunAjaran as [Tahun Ajaran] FROM master.semester";
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        query += " WHERE tahunAjaran LIKE @kw";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(keyword)) cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                            // Sembunyikan ID agar UI lebih bersih
                            if (dataGridView1.Columns["ID"] != null) dataGridView1.Columns["ID"].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error Load Data: " + ex.Message); }
        }

        private void ResetForm()
        {
            txtTahunAjaran.Clear();

            isEditMode = false;
            originalIdSemester = "";

            // MENGUBAH TEKS TOMBOL SECARA DINAMIS (Tanpa merusak UI Designer)
            btnTambah.Text = "Tambah";
            btnUpdate.Text = "Reset Text";

            btnDelete.Enabled = false; // Matikan tombol hapus saat mode tambah
            txtTahunAjaran.Focus();
        }

        // FUNGSI INI SEKARANG BERTUGAS SEBAGAI TOMBOL RESET
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            LoadDataSemester(txtCari.Text.Trim());
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // BUG FIX DARI KODE LAMA: Menggunakan >= 0 agar semua baris bisa diklik
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                originalIdSemester = row.Cells["ID"].Value.ToString();
                txtTahunAjaran.Text = row.Cells["Tahun Ajaran"].Value.ToString();

                isEditMode = true;

                // MENGUBAH TEKS TOMBOL SECARA DINAMIS
                btnTambah.Text = "Update Data";
                btnDelete.Enabled = true; // Nyalakan tombol hapus
            }
        }

        // ==========================================================
        // FASE 2: MESIN DATABASE (CRUD ROUTER PADA TOMBOL TAMBAH)
        // ==========================================================
        private void btnTambah_Click(object sender, EventArgs e)
        {
            string inputTahun = txtTahunAjaran.Text.Trim();

            if (string.IsNullOrEmpty(inputTahun))
            {
                MessageBox.Show("Tahun Ajaran tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTahunAjaran.Focus();
                return;
            }

            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return;

                    // CEK DUPLIKASI
                    string checkQuery = isEditMode
                        ? "SELECT COUNT(1) FROM master.semester WHERE tahunAjaran = @tahunAjaran AND idSemester != @id"
                        : "SELECT COUNT(1) FROM master.semester WHERE tahunAjaran = @tahunAjaran";

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@tahunAjaran", inputTahun);
                        if (isEditMode) checkCmd.Parameters.AddWithValue("@id", originalIdSemester);

                        if (Convert.ToInt32(checkCmd.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show("Tahun Ajaran ini sudah ada di dalam sistem!", "Duplikasi Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // EKSEKUSI INSERT ATAU UPDATE
                    string query = isEditMode
                        ? "UPDATE master.semester SET tahunAjaran = @tahunAjaran WHERE idSemester = @id"
                        : "INSERT INTO master.semester (tahunAjaran) VALUES (@tahunAjaran)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tahunAjaran", inputTahun);
                        if (isEditMode) cmd.Parameters.AddWithValue("@id", originalIdSemester);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show($"Data semester berhasil {(isEditMode ? "diperbarui" : "ditambahkan")}!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadDataSemester();
                        ResetForm();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(originalIdSemester)) return;

            if (MessageBox.Show($"Yakin ingin menghapus Tahun Ajaran '{txtTahunAjaran.Text}'?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = DatabaseConfig.GetConnection())
                    {
                        if (conn == null) return;
                        string deleteQuery = "DELETE FROM master.semester WHERE idSemester = @id";
                        using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", originalIdSemester);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Data berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataSemester();
                            ResetForm();
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    // PROTEKSI FOREIGN KEY
                    if (sqlEx.Number == 547)
                    {
                        MessageBox.Show("OPERASI DITOLAK!\n\nSemester ini sedang digunakan dalam riwayat Permintaan Barang atau Maintenance. Data yang memiliki sejarah transaksi tidak boleh dihapus.", "Integritas Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show("Error: " + sqlEx.Message);
                }
            }
        }
    }
}