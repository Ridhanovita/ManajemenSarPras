using SatprasDesktopApp.Config;
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
using System.Data.SqlClient;

namespace ManajemenSarPras
{
    public partial class karyawan: Form
    {
        public karyawan()
        {
            InitializeComponent();
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            dashboardPage dashboard = new dashboardPage();
            dashboard.Show();
            this.Hide();
        }

        public void displayGridView()
        {
            string Query = "SELECT idKaryawan as ID, namaKaryawan as [Nama Karyawan] FROM master.karyawan";
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

        private void karyawan_Load(object sender, EventArgs e)
        {
            displayGridView();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                richTextBox3.Text = row.Cells["Nama Karyawan"].Value.ToString();
            }
        }


        private void btnTambah_Click(object sender, EventArgs e)
        {
            string inputKaryawan = richTextBox3.Text.Trim();

            if (string.IsNullOrEmpty(inputKaryawan))
            {
                MessageBox.Show("Nama Karyawan tidak boleh kosong.");
                richTextBox3.Focus();
                return;
            }

            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return;
                    string insertQuery = "INSERT INTO master.karyawan (namaKaryawan) VALUES (@namaKaryawan)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@namaKaryawan", inputKaryawan);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil ditambahkan.");
                            displayGridView();
                            richTextBox3.Clear();
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
                    string updateQuery = "UPDATE master.karyawan SET namaKaryawan = @namaKaryawan WHERE idKaryawan = @idKaryawan";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@namaKaryawan", richTextBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@idKaryawan", dataGridView1.CurrentRow.Cells["ID"].Value);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil diperbarui.");
                            displayGridView();
                            richTextBox3.Clear();
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
                    string deleteQuery = "DELETE FROM master.karyawan WHERE idKaryawan = @idKaryawan";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@idKaryawan", dataGridView1.CurrentRow.Cells["ID"].Value);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil dihapus.");
                            displayGridView();
                            richTextBox3.Clear();
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
                    string searchQuery = "SELECT idKaryawan as ID, namaKaryawan as [Nama Karyawan] FROM master.karyawan WHERE namaKaryawan LIKE @searchTerm";
                    using (SqlDataAdapter da = new SqlDataAdapter(searchQuery, conn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + richTextBox1.Text.Trim() + "%");
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
