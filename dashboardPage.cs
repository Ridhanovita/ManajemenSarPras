using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
<<<<<<< HEAD
using System.Data.SqlClient;
using SatprasDesktopApp.Config;

namespace ManajemenSarPras
{
    public partial class dashboardPage: Form
    {
        
        public dashboardPage()
=======

namespace ManajemenSarPras
{
    public partial class maintenancePage: Form
    {
        public maintenancePage()
>>>>>>> 99874df1cda1c5114fd31cdd8ab7758ba1a6ad75
        {
            InitializeComponent();
        }

<<<<<<< HEAD
        private void kelolaBarang_Click(object sender, EventArgs e)
        {
            kelolaBarang kelolaBarang = new kelolaBarang();
            kelolaBarang.Show();
            this.Hide();
        }

        private void permintaanBarang_Click(object sender, EventArgs e)
        {
            permintaanBarang mintaBarang = new permintaanBarang();
            mintaBarang.Show();
            this.Hide();
        }

        private void pengecekanRutin_Click(object sender, EventArgs e)
        {
            karyawan cekRutin = new karyawan();
            cekRutin.Show();
            this.Hide();
        }

        private void maintennce_Click(object sender, EventArgs e)
        {
            maintenancePage maintennce = new maintenancePage();
            maintennce.Show();
            this.Hide();
        }

        private void report_Click(object sender, EventArgs e)
        {
            reportPage report = new reportPage();
            report.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNavigasiSemester_Click(object sender, EventArgs e)
        {
            formSemester semester = new formSemester();
            semester.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DatabaseConfig.GetConnection())
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    MessageBox.Show("Koneksi berhasil!");
                }
            }
        }

        private void dashboardPage_Load(object sender, EventArgs e)
        {

        }
=======
        private void btnKembali_Click(object sender, EventArgs e)
        {
<<<<<<<< HEAD:maintenancePage.cs
            dashboardPage dashboard = new dashboardPage();
            dashboard.Show();
            this.Hide();
========
            kelolaBarang kelolaBarang = new kelolaBarang();
            kelolaBarang.Show();
>>>>>>>> 99874df1cda1c5114fd31cdd8ab7758ba1a6ad75:dashboardPage.cs
        }

>>>>>>> 99874df1cda1c5114fd31cdd8ab7758ba1a6ad75
    }
}
