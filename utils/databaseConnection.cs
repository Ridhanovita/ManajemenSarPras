using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;


namespace SatprasDesktopApp.Config // Sesuaikan dengan nama namespace project Anda
{
    public static class DatabaseConfig
    {
        // Mengambil connection string dari App.config
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["SatprasDbConnection"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                // Kita tes buka sebentar untuk memastikan tidak ada error jaringan/server
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fatal Error: Gagal terhubung ke Database satprasDB.\n" + ex.Message,
                                "Koneksi Terputus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}