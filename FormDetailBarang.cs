using SatprasDesktopApp.Config; // Pastikan namespace ini sesuai dengan milik Anda
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ManajemenSarPras
{
    public partial class FormDetailBarang : Form
    {
        // ==========================================================
        // VARIABEL GLOBAL PENGENDALI STATE
        // ==========================================================
        private bool isEditMode = false;
        private string originalIdDetail = "";
        private string originalIdBarang = "";

        public FormDetailBarang()
        {
            InitializeComponent();

            // HARDCODE EVENT BINDING: Arsitektur anti-error dari UI Designer
            this.Load += new EventHandler(FormDetailBarang_Load);
            this.dgvDetail.CellClick += new DataGridViewCellEventHandler(dgvDetail_CellClick);
            this.txtCari.TextChanged += new EventHandler(txtCari_TextChanged);
            this.cmbGedung.SelectedIndexChanged += new EventHandler(cmbGedung_SelectedIndexChanged);

            // UX Sweeper (Penyapu input fiktif di ComboBox)
            this.cmbBarang.Leave += new EventHandler(cmbBarang_Leave);

            // Binding Tombol Aksi
            this.btnSimpan.Click += new EventHandler(btnSimpan_Click);
            this.btnBatal.Click += new EventHandler(btnBatal_Click);
            this.btnHapus.Click += new EventHandler(btnHapus_Click);
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            kelolaBarang masterForm = new kelolaBarang();
            masterForm.Show();
            this.Hide();
        }

        // ==========================================================
        // FASE 1: INISIALISASI & CASCADING DROPDOWN
        // ==========================================================
        private void FormDetailBarang_Load(object sender, EventArgs e)
        {
            LoadComboBoxBarang();
            LoadComboBoxGedung();
            LoadDataDetail();
            ResetForm();
        }

        private void LoadComboBoxBarang()
        {
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return;

                    // Hanya memuat Aset Tetap (Pengecekan Rutin)
                    string query = "SELECT idBarang, namaBarang FROM master.barang WHERE tipeBarang = 1";
                    using (var da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        DataRow dr = dt.NewRow();
                        dr["idBarang"] = 0;
                        dr["namaBarang"] = "-- Ketik atau Pilih Aset Tetap --";
                        dt.Rows.InsertAt(dr, 0);

                        cmbBarang.DataSource = dt;
                        cmbBarang.DisplayMember = "namaBarang";
                        cmbBarang.ValueMember = "idBarang";

                        // INJEKSI SIHIR AUTOCOMPLETE (SEARCHABLE COMBOBOX)
                        cmbBarang.DropDownStyle = ComboBoxStyle.DropDown; // Mengizinkan user mengetik
                        cmbBarang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        cmbBarang.AutoCompleteSource = AutoCompleteSource.ListItems;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error Load Barang: " + ex.Message); }
        }

        private void LoadComboBoxGedung()
        {
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return;
                    string query = "SELECT idGedung, namaGedung FROM master.gedung";
                    using (var da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        DataRow dr = dt.NewRow();
                        dr["idGedung"] = 0;
                        dr["namaGedung"] = "-- Pilih Gedung --";
                        dt.Rows.InsertAt(dr, 0);

                        cmbGedung.DataSource = dt;
                        cmbGedung.DisplayMember = "namaGedung";
                        cmbGedung.ValueMember = "idGedung";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error Load Gedung: " + ex.Message); }
        }

        // TRIGGER LOKASI: Gedung mengontrol isi Ruangan
        private void cmbGedung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGedung.SelectedIndex <= 0 || cmbGedung.SelectedValue == null)
            {
                cmbRuangan.DataSource = null;
                cmbRuangan.Items.Clear();
                cmbRuangan.Items.Add("-- Pilih Ruangan --");
                cmbRuangan.SelectedIndex = 0;
                cmbRuangan.Enabled = false;
                return;
            }

            try
            {
                int idGedung = Convert.ToInt32(cmbGedung.SelectedValue);
                using (var conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return;
                    string query = "SELECT idRuangan, namaRuangan FROM master.ruangan WHERE idGedung = @idGedung";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idGedung", idGedung);
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            DataRow dr = dt.NewRow();
                            dr["idRuangan"] = 0;
                            dr["namaRuangan"] = "-- Pilih Ruangan --";
                            dt.Rows.InsertAt(dr, 0);

                            cmbRuangan.DataSource = dt;
                            cmbRuangan.DisplayMember = "namaRuangan";
                            cmbRuangan.ValueMember = "idRuangan";
                            cmbRuangan.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error Load Ruangan: " + ex.Message); }
        }

        // ==========================================================
        // FASE 2: GRID, STATE MANAGEMENT & UX SWEEPER
        // ==========================================================

        // UX Sweeper: Cegah input fiktif dari Autocomplete ComboBox
        private void cmbBarang_Leave(object sender, EventArgs e)
        {
            if (cmbBarang.SelectedIndex == -1 && !string.IsNullOrWhiteSpace(cmbBarang.Text))
            {
                MessageBox.Show("Aset tidak ditemukan di dalam Katalog Master. Silakan ketik nama yang valid atau pilih dari daftar.", "Filter Keamanan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBarang.SelectedIndex = 0;
                cmbBarang.Focus();
            }
        }

        private void LoadDataDetail(string keyword = "")
        {
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return;

                    string query = @"
                        SELECT 
                            db.idDetailBarang AS [ID Detail],
                            b.namaBarang AS [Nama Aset],
                            b.merk AS [Merk],
                            db.spesifikasi AS [Spesifikasi],
                            g.namaGedung AS [Gedung],
                            r.namaRuangan AS [Lokasi Ruangan],
                            b.idBarang, g.idGedung, r.idRuangan -- Hidden Columns
                        FROM [transaction].detailBarang db
                        JOIN [master].barang b ON db.idBarang = b.idBarang
                        JOIN [master].ruangan r ON db.idRuangan = r.idRuangan
                        JOIN [master].gedung g ON r.idGedung = g.idGedung";

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        query += " WHERE b.namaBarang LIKE @kw OR db.idDetailBarang LIKE @kw OR db.spesifikasi LIKE @kw OR b.merk LIKE @kw";
                    }

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(keyword)) cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                        using (var da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvDetail.DataSource = dt;

                            // Sembunyikan kolom sistem agar rapi
                            if (dgvDetail.Columns["idBarang"] != null) dgvDetail.Columns["idBarang"].Visible = false;
                            if (dgvDetail.Columns["idGedung"] != null) dgvDetail.Columns["idGedung"].Visible = false;
                            if (dgvDetail.Columns["idRuangan"] != null) dgvDetail.Columns["idRuangan"].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error Load Grid: " + ex.Message); }
        }

        private void ResetForm()
        {
            txtIdDetail.Clear();
            txtSpesifikasi.Clear();

            txtIdDetail.ReadOnly = false;

            // BUKA GEMBOK ASET (Mode Tambah Baru)
            cmbBarang.Enabled = true;
            if (cmbBarang.Items.Count > 0) cmbBarang.SelectedIndex = 0;

            if (cmbGedung.Items.Count > 0) cmbGedung.SelectedIndex = 0;
            cmbRuangan.Enabled = false; // Akan dibuka otomatis oleh trigger gedung

            isEditMode = false;
            originalIdDetail = "";
            originalIdBarang = "";

            btnSimpan.Text = "Tambah Detail Barang";
            btnHapus.Enabled = false;
            txtIdDetail.Focus();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            LoadDataDetail(txtCari.Text.Trim());
        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDetail.Rows[e.RowIndex];

                originalIdDetail = row.Cells["ID Detail"].Value.ToString();
                txtIdDetail.Text = originalIdDetail;
                txtSpesifikasi.Text = row.Cells["Spesifikasi"].Value.ToString();

                originalIdBarang = row.Cells["idBarang"].Value.ToString();
                cmbBarang.SelectedValue = Convert.ToInt32(originalIdBarang);

                cmbGedung.SelectedValue = Convert.ToInt32(row.Cells["idGedung"].Value);
                cmbRuangan.SelectedValue = Convert.ToInt32(row.Cells["idRuangan"].Value);

                txtIdDetail.ReadOnly = true;

                // MANUVER ARSITEK: KUNCI NAMA ASET
                // User tidak boleh menukar identitas aset (misal: AC ditukar jadi Proyektor)
                cmbBarang.Enabled = false;

                isEditMode = true;
                btnSimpan.Text = "Update Data";
                btnHapus.Enabled = true;
            }
        }

        // ==========================================================
        // FASE 3: MESIN TRANSAKSIONAL (ATOMIC CRUD)
        // ==========================================================
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // Validasi Gatekeeper
            if (string.IsNullOrWhiteSpace(txtIdDetail.Text) || string.IsNullOrWhiteSpace(txtSpesifikasi.Text) ||
                cmbBarang.SelectedIndex <= 0 || cmbGedung.SelectedIndex <= 0 || cmbRuangan.SelectedIndex <= 0)
            {
                MessageBox.Show("Lengkapi semua form! Pastikan Aset, Spesifikasi, Gedung, dan Ruangan terisi.", "Validasi Ketat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return;

                    // MEMULAI TRANSAKSI KEUANGAN/ASET (Mencegah Stok Bocor)
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        if (isEditMode)
                        {
                            // MODE UPDATE: Hanya memindahkan lokasi & edit spek. Stok master.barang TIDAK BERUBAH.
                            string qUpdate = "UPDATE [transaction].detailBarang SET idRuangan = @ruang, spesifikasi = @spec WHERE idDetailBarang = @idAsli";
                            using (var cmd = new SqlCommand(qUpdate, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@ruang", Convert.ToInt32(cmbRuangan.SelectedValue));
                                cmd.Parameters.AddWithValue("@spec", txtSpesifikasi.Text.Trim());
                                cmd.Parameters.AddWithValue("@idAsli", originalIdDetail);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // MODE INSERT: Tambah Detail BARU + Naikkan STOK Master (+1)

                            // 1. Cek Duplikasi ID Detail
                            string qCheck = "SELECT COUNT(1) FROM [transaction].detailBarang WHERE idDetailBarang = @id";
                            using (var cmdCheck = new SqlCommand(qCheck, conn, transaction))
                            {
                                cmdCheck.Parameters.AddWithValue("@id", txtIdDetail.Text.Trim());
                                if (Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0)
                                {
                                    throw new Exception("ID Detail ini sudah dipakai. Gunakan Kode/ID unik (Misal: SN-001)!");
                                }
                            }

                            // 2. Insert ke tabel detailBarang
                            string qInsert = "INSERT INTO [transaction].detailBarang (idDetailBarang, idBarang, idRuangan, spesifikasi) VALUES (@id, @barang, @ruang, @spec)";
                            using (var cmdIn = new SqlCommand(qInsert, conn, transaction))
                            {
                                cmdIn.Parameters.AddWithValue("@id", txtIdDetail.Text.Trim());
                                cmdIn.Parameters.AddWithValue("@barang", Convert.ToInt32(cmbBarang.SelectedValue));
                                cmdIn.Parameters.AddWithValue("@ruang", Convert.ToInt32(cmbRuangan.SelectedValue));
                                cmdIn.Parameters.AddWithValue("@spec", txtSpesifikasi.Text.Trim());
                                cmdIn.ExecuteNonQuery();
                            }

                            // 3. Update stok (Sistem Cerdas Penambahan Stok)
                            string qStock = "UPDATE master.barang SET stok = stok + 1 WHERE idBarang = @barang";
                            using (var cmdStok = new SqlCommand(qStock, conn, transaction))
                            {
                                cmdStok.Parameters.AddWithValue("@barang", Convert.ToInt32(cmbBarang.SelectedValue));
                                cmdStok.ExecuteNonQuery();
                            }
                        }

                        // KOMITMEN TRANSAKSI: Semua eksekusi SQL di atas dinyatakan Sah!
                        transaction.Commit();
                        MessageBox.Show($"Registrasi/Update Aset berhasil diproses secara atomik!", "Operasi Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadDataDetail();
                        ResetForm();
                    }
                    catch (Exception ex)
                    {
                        // JIKA GAGAL DI TENGAH JALAN, KEMBALIKAN SEMUA DATA SEPERTI SEMULA (Rollback)
                        transaction.Rollback();
                        MessageBox.Show(ex.Message, "Validasi Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Database Error: " + ex.Message, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(originalIdDetail)) return;

            if (MessageBox.Show("Menghapus data ini akan MENGURANGI STOK di Master Barang secara otomatis.\n\nYakin ingin menghapus?", "Konfirmasi Destruktif", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = DatabaseConfig.GetConnection())
                    {
                        if (conn == null) return;
                        SqlTransaction transaction = conn.BeginTransaction();

                        try
                        {
                            // 1. Kurangi stok di master.barang (-1)
                            string qStock = "UPDATE master.barang SET stok = stok - 1 WHERE idBarang = @barang";
                            using (var cmdStok = new SqlCommand(qStock, conn, transaction))
                            {
                                cmdStok.Parameters.AddWithValue("@barang", originalIdBarang);
                                cmdStok.ExecuteNonQuery();
                            }

                            // 2. Hapus data detailBarang
                            string qDel = "DELETE FROM [transaction].detailBarang WHERE idDetailBarang = @id";
                            using (var cmdDel = new SqlCommand(qDel, conn, transaction))
                            {
                                cmdDel.Parameters.AddWithValue("@id", originalIdDetail);
                                cmdDel.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Aset fisik berhasil dihapus dan jumlah stok master telah disesuaikan.", "Penghapusan Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataDetail();
                            ResetForm();
                        }
                        catch (SqlException sqlEx)
                        {
                            transaction.Rollback();
                            if (sqlEx.Number == 547)
                                MessageBox.Show("OPERASI DITOLAK: Integritas Data!\n\nBarang ini memiliki rekam jejak pada Laporan Maintenance/Pengecekan. Aset yang memiliki sejarah transaksi tidak boleh dihapus.", "Proteksi Database Aktif", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                throw sqlEx;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("System Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
    }
}