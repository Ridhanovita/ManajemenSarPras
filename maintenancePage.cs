using SatprasDesktopApp.Config;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ManajemenSarPras
{
    public partial class maintenancePage : Form
    {
        private string selectedIdMaintenance = "";

        public maintenancePage()
        {
            InitializeComponent();
            this.Load += new EventHandler(maintenancePage_Load);
            this.cmbRuangan.SelectedIndexChanged += new EventHandler(cmbRuangan_SelectedIndexChanged);
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);

            this.btnSimpan.Click += new EventHandler(btnSimpan_Click);
            this.btnUpdate.Click += new EventHandler(btnUpdate_Click);
            this.btnHapus.Click += new EventHandler(btnHapus_Click);
            this.btnReset.Click += new EventHandler(btnReset_Click);
        }

        private void maintenancePage_Load(object sender, EventArgs e)
        {
            LoadComboRuangan();
            LoadComboSemester();
            LoadComboKaryawan();
            RefreshTabel();
            ResetForm();
        }

        // --- LOAD MASTER DATA ---
        private void LoadComboRuangan()
        {
            using (var conn = DatabaseConfig.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT idRuangan, namaRuangan FROM [master].[ruangan]", conn);
                DataTable dt = new DataTable(); da.Fill(dt);
                cmbRuangan.DataSource = dt;
                cmbRuangan.DisplayMember = "namaRuangan";
                cmbRuangan.ValueMember = "idRuangan";
                cmbRuangan.SelectedIndex = -1;
            }
        }

        private void LoadComboKaryawan()
        {
            using (var conn = DatabaseConfig.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT idKaryawan, namaKaryawan FROM [master].[karyawan]", conn);
                DataTable dt = new DataTable(); da.Fill(dt);
                cmbKaryawan.DataSource = dt;
                cmbKaryawan.DisplayMember = "namaKaryawan";
                cmbKaryawan.ValueMember = "idKaryawan";
                cmbKaryawan.SelectedIndex = -1;
            }
        }

        private void LoadComboSemester()
        {
            using (var conn = DatabaseConfig.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT idSemester, tahunAjaran FROM [master].[semester]", conn);
                DataTable dt = new DataTable(); da.Fill(dt);
                cmbSemester.DataSource = dt;
                cmbSemester.DisplayMember = "tahunAjaran";
                cmbSemester.ValueMember = "idSemester";
                cmbSemester.SelectedIndex = -1;
            }
        }

        private void cmbRuangan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRuangan.SelectedValue != null && cmbRuangan.SelectedValue is int)
            {
                LoadDetailBarangByRuangan(cmbRuangan.SelectedValue.ToString());
            }
        }

        private void LoadDetailBarangByRuangan(string idR)
        {
            using (var conn = DatabaseConfig.GetConnection())
            {
                string sql = @"SELECT db.idDetailBarang, b.namaBarang + ' (' + db.spesifikasi + ')' as Item 
                               FROM [transaction].[detailBarang] db 
                               JOIN [master].[barang] b ON db.idBarang = b.idBarang 
                               WHERE db.idRuangan = @idR";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idR", idR);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable(); da.Fill(dt);
                cmbDetailBarang.DataSource = dt;
                cmbDetailBarang.DisplayMember = "Item";
                cmbDetailBarang.ValueMember = "idDetailBarang";
                cmbDetailBarang.SelectedIndex = -1;
            }
        }

        // --- CORE CRUD ---
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (cmbDetailBarang.SelectedValue == null) return;
            string q = @"INSERT INTO [transaction].[maintenance] 
                        (idKaryawan, idDetailBarang, tglCek, kondisi, kerusakan, tindakLanjut, idSemester) 
                        VALUES (@idK, @idD, @tgl, @kon, @ker, @tin, @smt)";
            ExecuteMaintenance(q, "Tambah");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedIdMaintenance)) return;
            string q = @"UPDATE [transaction].[maintenance] SET 
                        idKaryawan=@idK, idDetailBarang=@idD, tglCek=@tgl, 
                        kondisi=@kon, kerusakan=@ker, tindakLanjut=@tin, idSemester=@smt 
                        WHERE idMaintenance=@idM";
            ExecuteMaintenance(q, "Update");
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedIdMaintenance)) return;
            if (MessageBox.Show("Hapus data?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string q = "DELETE FROM [transaction].[maintenance] WHERE idMaintenance=@idM";
                ExecuteMaintenance(q, "Hapus");
            }
        }

        private void ExecuteMaintenance(string query, string type)
        {
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idK", cmbKaryawan.SelectedValue ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@idD", cmbDetailBarang.SelectedValue ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@tgl", dtpTglCek.Value.Date);
                        cmd.Parameters.AddWithValue("@kon", rbBaik.Checked ? 1 : 0);
                        cmd.Parameters.AddWithValue("@ker", rbBaik.Checked ? "-" : txtKerusakan.Text.Trim());
                        cmd.Parameters.AddWithValue("@tin", txtTindakLanjut.Text.Trim());
                        cmd.Parameters.AddWithValue("@smt", cmbSemester.SelectedValue ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@idM", selectedIdMaintenance);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"{type} Berhasil!");
                        RefreshTabel();
                        ResetForm();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        // ==========================================================
        // PERBAIKAN DI SINI: MENAMBAHKAN KOLOM KE GRIDVIEW
        // ==========================================================
        private void RefreshTabel()
        {
            using (var conn = DatabaseConfig.GetConnection())
            {
                // Perhatikan penambahan m.kerusakan dan m.tindakLanjut di query ini
                string sql = @"SELECT m.idMaintenance AS [ID], b.namaBarang AS [Aset], 
                               r.namaRuangan AS [Lokasi], m.tglCek AS [Tgl Cek], 
                               CASE WHEN m.kondisi = 1 THEN 'Baik' ELSE 'Rusak' END AS [Status],
                               m.kerusakan AS [Kerusakan], m.tindakLanjut AS [Tindak Lanjut],
                               k.namaKaryawan AS [Petugas]
                               FROM [transaction].[maintenance] m 
                               JOIN [transaction].[detailBarang] db ON m.idDetailBarang = db.idDetailBarang 
                               JOIN [master].[barang] b ON db.idBarang = b.idBarang
                               JOIN [master].[ruangan] r ON db.idRuangan = r.idRuangan
                               JOIN [master].[karyawan] k ON m.idKaryawan = k.idKaryawan
                               ORDER BY m.idMaintenance DESC";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable(); da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dataGridView1.Rows[e.RowIndex];
                selectedIdMaintenance = r.Cells["ID"].Value.ToString();

                cmbRuangan.Text = r.Cells["Lokasi"].Value.ToString();
                cmbDetailBarang.Text = r.Cells["Aset"].Value.ToString();
                dtpTglCek.Value = Convert.ToDateTime(r.Cells["Tgl Cek"].Value);
                cmbKaryawan.Text = r.Cells["Petugas"].Value.ToString();

                // Menarik kembali data Kerusakan dan Tindak Lanjut ke TextBox saat diklik
                txtKerusakan.Text = r.Cells["Kerusakan"].Value.ToString();
                txtTindakLanjut.Text = r.Cells["Tindak Lanjut"].Value.ToString();

                if (r.Cells["Status"].Value.ToString() == "Baik") rbBaik.Checked = true;
                else rbRusak.Checked = true;

                btnSimpan.Enabled = false;
            }
        }

        private void ResetForm()
        {
            selectedIdMaintenance = "";
            cmbRuangan.SelectedIndex = -1;
            cmbDetailBarang.DataSource = null;
            cmbKaryawan.SelectedIndex = -1;
            txtKerusakan.Clear();
            txtTindakLanjut.Clear();
            rbBaik.Checked = true;
            btnSimpan.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e) { ResetForm(); }
        private void btnKembali_Click(object sender, EventArgs e) { new dashboardPage().Show(); this.Hide(); }
    }
}