using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ManajemenSarPras
{
    public partial class loginPage: Form
    {
        string connectionString = "Data Source=tomiskibidi\\TAMA;Initial Catalog=satprasDB;Integrated Security=True";
        public loginPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Ambil input username dan password dari textbox
            string emailUser = txtEmail.Text;
            string passUser = txtPassword.Text;

            // validasi
            if (string.IsNullOrEmpty(emailUser) || string.IsNullOrEmpty(passUser))
            {
                MessageBox.Show("email atau password jangan kosong yaaw", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // ambil data di db
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM [master].users WHERE email = @Email AND password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // parameterized query untuk mencegah SQL injection
                        cmd.Parameters.AddWithValue("@Email", emailUser);
                        cmd.Parameters.AddWithValue("@Password", passUser);

                        // eksekusi query dan cek hasilnya
                        int userCount = (int)cmd.ExecuteScalar();
                        if (userCount > 0)
                        {
                            MessageBox.Show("Login berhasil!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Buka form utama atau dashboard di sini
                            this.Hide();
                            dashboardPage dashboard = new dashboardPage();
                            dashboard.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("email atau password salah yaaw", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
