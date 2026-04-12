using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SatprasDesktopApp.Config;

namespace ManajemenSarPras
{
    public partial class formSemester : Form
    {
        public formSemester()
        {
            InitializeComponent();
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            dashboardPage dashboard = new dashboardPage();
            dashboard.Show();
            this.Hide();
        }

        public void displayGridView()
        {
            string Query = "SELECT idSemester as ID, tahunAjaran as [Tahun Ajaran] FROM master.semester";
            try
            {
                using (SqlConnection conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return;
                    using (SqlDataAdapter da = new SqlDataAdapter(Query, conn))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void formSemester_Load(object sender, EventArgs e)
        {
            displayGridView();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtTahunAjaran.Text = row.Cells["Tahun Ajaran"].Value.ToString();
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            string inputTahun = txtTahunAjaran.Text.Trim();

            if (string.IsNullOrEmpty(inputTahun))
            {
                MessageBox.Show("Tahun Ajaran tidak boleh kosong.");
                txtTahunAjaran.Focus();
                return;
            }

            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return;
                    string insertQuery = "INSERT INTO master.semester (tahunAjaran) VALUES (@tahunAjaran)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@tahunAjaran", inputTahun);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil ditambahkan.");
                            displayGridView();
                            txtTahunAjaran.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Gagal menambahkan data.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return;
                    string updateQuery = "UPDATE master.semester SET tahunAjaran = @tahunAjaran WHERE idSemester = @idSemester";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@tahunAjaran", txtTahunAjaran.Text.Trim());
                        cmd.Parameters.AddWithValue("@idSemester", dataGridView1.CurrentRow.Cells["ID"].Value);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil diperbarui.");
                            displayGridView();
                            txtTahunAjaran.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Gagal memperbarui data.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return;
                    string deleteQuery = "DELETE FROM master.semester WHERE idSemester = @idSemester";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@idSemester", dataGridView1.CurrentRow.Cells["ID"].Value);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil dihapus.");
                            displayGridView();
                            txtTahunAjaran.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Gagal menghapus data.");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return;
                    string searchQuery = "SELECT idSemester as ID, tahunAjaran as [Tahun Ajaran] FROM master.semester WHERE tahunAjaran LIKE @searchTerm";
                    using (SqlDataAdapter da = new SqlDataAdapter(searchQuery, conn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + txtCari.Text.Trim() + "%");
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
