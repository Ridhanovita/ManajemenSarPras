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

namespace ManajemenSarPras
{
    public partial class reportPage: Form
    {
        public reportPage()
        {
            InitializeComponent();
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            dashboardPage dashboard = new dashboardPage();
            dashboard.Show();
            this.Hide();
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            // 1. Inisialisasi Tipe Laporan
            cmbTipe.Items.Add("Semester");
            cmbTipe.Items.Add("Bulanan");

            // 2. Inisialisasi Nama Bulan
            string[] bulan = { "Januari", "Februari", "Maret", "April", "Mei", "Juni",
                               "Juli", "Agustus", "September", "Oktober", "November", "Desember" };
            cmbBulan.Items.AddRange(bulan);

            // 3. Ambil data Semester dari Database (Memanggil method yang sudah Anda pelajari)
            MuatDataSemester();

            // Matikan dropdown bulan secara default
            cmbBulan.Enabled = false;
        }

        // =========================================================
        // LOGIKA UX: CASCADING DROPDOWN
        // =========================================================
        private void cmbTipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipe.SelectedItem == null) return;

            string tipeTerpilih = cmbTipe.SelectedItem.ToString();

            if (tipeTerpilih == "Semester")
            {
                cmbBulan.Enabled = false;
                cmbBulan.SelectedIndex = -1; // Kosongkan pilihan bulan
            }
            else if (tipeTerpilih == "Bulanan")
            {
                cmbBulan.Enabled = true; // Hidupkan pilihan bulan
            }
        }

        private void MuatDataSemester()
        {
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return;
                    // Ambil ID dan Tahun Ajaran
                    string query = "SELECT idSemester, tahunAjaran FROM master.semester";
                    using (var cmd = new SqlCommand(query, conn))
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Binding ke ComboBox Semester
                        cmbSemester.DataSource = dt;
                        cmbSemester.DisplayMember = "tahunAjaran"; // Yang dilihat user
                        cmbSemester.ValueMember = "idSemester";    // Nilai di belakang layar
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat semester: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
