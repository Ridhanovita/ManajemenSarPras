using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManajemenSarPras
{
    public partial class dashboardPage: Form
    {
        public dashboardPage()
        {
            InitializeComponent();
        }

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
            pengecekanRutin cekRutin = new pengecekanRutin();
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
    }
}
