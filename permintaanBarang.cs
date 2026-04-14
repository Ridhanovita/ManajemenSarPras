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

        public permintaanBarang()
        {
            InitializeComponent();

            this.Load += new EventHandler(permintaanBarang_Load);
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(dgvStock_CellClick);
            this.dataGridView2.CellClick += new DataGridViewCellEventHandler(dgvPermintaan_CellClick);
            this.txtJmlh.KeyPress += new KeyPressEventHandler(txtNumeric_KeyPress);

            this.addPeminta.Click += new EventHandler(addPeminta_Click);
            this.updatePminjam.Click += new EventHandler(updatePminjam_Click);
            this.hpsPermintaan.Click += new EventHandler(hpsPermintaan_Click);
            this.stockBarang.Click += new EventHandler(stockBarang_Click);
            this.btnKembali.Click += new EventHandler(btnKembali_Click);
        }

        private void permintaanBarang_Load(object sender, EventArgs e)
        {
            LoadComboRuangan();
            RefreshSemuaTabel();
            ResetForm();
        }

        private void LoadComboRuangan()
        {
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    string query = "SELECT idRuangan, namaRuangan FROM [master].[ruangan]";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbRuangan.DataSource = dt;
                    cmbRuangan.DisplayMember = "namaRuangan";
                    cmbRuangan.ValueMember = "idRuangan";
                    cmbRuangan.SelectedIndex = -1;
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal load daftar ruangan: " + ex.Message); }
        }

        private void RefreshSemuaTabel()
        {
            LoadStockBarang();
            LoadDataPermintaan();
        }

        private void LoadStockBarang()
        {
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    string query = "SELECT idBarang AS [ID], namaBarang AS [Nama], stok AS [Stok] FROM [master].[barang]";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal load stok: " + ex.Message); }
        }

        private void LoadDataPermintaan()
        {
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    string query = @"
                        SELECT 
                            p.idPermintaanBarang AS [ID],
                            p.idBarang AS [ID Barang],
                            b.namaBarang AS [Nama Barang],
                            r.namaRuangan AS [Nama Ruangan], 
                            p.namaPeminta AS [Peminta],
                            p.jumlah AS [Qty],
                            p.idSemester AS [Smt]
                        FROM [transaction].[permintaanBarang] p
                        JOIN [master].[barang] b ON p.idBarang = b.idBarang
                        JOIN [master].[ruangan] r ON p.idRuangan = r.idRuangan";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal load data: " + ex.Message); }
        }

        private void ResetForm()
        {
            txtIdBarang.Clear();
            cmbRuangan.SelectedIndex = -1;
            txtNma.Clear();
            txtJmlh.Clear();
            txtSmt.Clear();
            selectedIdPermintaan = "";
        }

        private void txtNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                txtIdBarang.Text = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
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
            }
        }

        private void addPeminta_Click(object sender, EventArgs e)
        {
            if (cmbRuangan.SelectedValue == null) { MessageBox.Show("Pilih ruangan!"); return; }

            // Validasi Sederhana: Cek apakah input jumlah tidak kosong
            if (string.IsNullOrEmpty(txtJmlh.Text)) { MessageBox.Show("Masukkan jumlah!"); return; }

            string query = "INSERT INTO [transaction].[permintaanBarang] (idBarang, idRuangan, namaPeminta, jumlah, tglPermintaan, idSemester) VALUES (@idB, @idR, @nama, @jml, GETDATE(), @smt)";
            ExecuteQuery(query, "Berhasil menambah permintaan!");
        }

        private void updatePminjam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedIdPermintaan)) return;
            string query = "UPDATE [transaction].[permintaanBarang] SET idBarang=@idB, idRuangan=@idR, namaPeminta=@nama, jumlah=@jml, idSemester=@smt WHERE idPermintaanBarang=@idPB";
            ExecuteQuery(query, "Berhasil update data!");
        }

        private void hpsPermintaan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedIdPermintaan)) return;
            if (MessageBox.Show("Hapus permintaan ini? Stok akan dikembalikan.", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM [transaction].[permintaanBarang] WHERE idPermintaanBarang=@idPB";
                ExecuteQuery(query, "Permintaan dihapus dan stok dikembalikan!");
            }
        }

        private void stockBarang_Click(object sender, EventArgs e) => RefreshSemuaTabel();

        private void btnKembali_Click(object sender, EventArgs e)
        {
            new dashboardPage().Show();
            this.Hide();
        }

        // ==========================================================
        // LOGIKA UTAMA: Eksekusi SQL + Update Stok Otomatis
        // ==========================================================
        private void ExecuteQuery(string query, string successMessage)
        {
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Mapping parameter dari form ke query
                        cmd.Parameters.AddWithValue("@idB", txtIdBarang.Text.Trim());
                        cmd.Parameters.AddWithValue("@idR", cmbRuangan.SelectedValue ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@nama", txtNma.Text.Trim());
                        cmd.Parameters.AddWithValue("@jml", txtJmlh.Text.Trim());
                        cmd.Parameters.AddWithValue("@smt", txtSmt.Text.Trim());
                        cmd.Parameters.AddWithValue("@idPB", selectedIdPermintaan);

                        // Eksekusi perintah (Trigger SQL akan otomatis jalan di background)
                        cmd.ExecuteNonQuery();

                        MessageBox.Show(successMessage, "Berhasil");

                        // Refresh tampilan agar perubahan stok yang dilakukan Trigger langsung kelihatan
                        RefreshSemuaTabel();
                        ResetForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Kesalahan: " + ex.Message, "Error");
            }
        }
    }
}