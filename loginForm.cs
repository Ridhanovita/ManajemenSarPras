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
using SatprasDesktopApp.Config;

namespace ManajemenSarPras
{

    public partial class loginForm: Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // ambil input dari textbox
            string emailUser = txtEmail.Text;
            string passwordUser = txtPassword.Text;

            // validasi input
            if (string.IsNullOrEmpty(emailUser) || string.IsNullOrEmpty(passwordUser))
            {
                MessageBox.Show("Email atau Password diisi yaa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var connection = DatabaseConfig.GetConnection())
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();  
                    }
                    // ambil data di db
                    string query = "SELECT COUNT(1) FROM [master].users WHERE email = @Email AND password = @Password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // parameter untuk mencegah SQL Injection
                        command.Parameters.AddWithValue("@Email", emailUser);
                        command.Parameters.AddWithValue("@Password", passwordUser);

                        // eksekusi query
                        int userCount = (int)command.ExecuteScalar();
                        if (userCount > 0)
                        {
                            MessageBox.Show("Login berhasil!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Lanjutkan ke form utama atau dashboard
                            this.Hide();
                            dashboardPage home = new dashboardPage();
                            home.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Email atau Password salah yaa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
