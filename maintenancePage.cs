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
<<<<<<< HEAD
    public partial class maintenancePage: Form
    {
        public maintenancePage()
        {
            InitializeComponent();
        }

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

=======
    public partial class mntenncePage: Form
    {
        public mntenncePage()
        {
            InitializeComponent();
        }
>>>>>>> 99874df1cda1c5114fd31cdd8ab7758ba1a6ad75
    }
}
