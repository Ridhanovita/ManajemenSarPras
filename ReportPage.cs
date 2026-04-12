using ClosedXML.Excel;
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

        // ==========================================================
        // 1. REVISI FORM LOAD (URUTAN EKSEKUSI AMAN)
        // ==========================================================
        private void reportPage_Load(object sender, EventArgs e)
        {
            // FASE A: ISI SEMUA DATA KE DALAM COMBOBOX TERLEBIH DAHULU (Tanpa memilih index)

            // Tipe Laporan
            cmbTipe.Items.Clear();
            cmbTipe.Items.Add("-- Pilih Tipe Laporan --");
            cmbTipe.Items.Add("Semester");
            cmbTipe.Items.Add("Bulanan");

            // Nama Bulan
            cmbBulan.Items.Clear();
            cmbBulan.Items.Add("-- Pilih Bulan --");
            string[] bulan = { "Januari", "Februari", "Maret", "April", "Mei", "Juni",
                       "Juli", "Agustus", "September", "Oktober", "November", "Desember" };
            cmbBulan.Items.AddRange(bulan);
            cmbBulan.Enabled = false;

            // Ambil data Semester
            MuatDataSemester();

            // FASE B: SETELAH SEMUA WADAH PENUH, BARU KITA KUNCI INDEX DEFAULT-NYA
            cmbBulan.SelectedIndex = 0; // Aman karena array bulan sudah dimasukkan
            cmbTipe.SelectedIndex = 0;  // Aman karena cmbBulan sudah punya isi saat event terpanggil
        }

        // ==========================================================
        // 2. REVISI EVENT (TAMBAHAN PERISAI PELINDUNG)
        // ==========================================================
        private void cmbTipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            // PERISAI ARSITEK: Jangan lakukan apa-apa jika UI belum siap atau data kosong
            if (cmbTipe.SelectedItem == null || cmbBulan.Items.Count == 0) return;

            string tipeTerpilih = cmbTipe.SelectedItem.ToString().Trim();

            if (tipeTerpilih == "-- Pilih Tipe Laporan --" || tipeTerpilih.ToLower() == "semester")
            {
                cmbBulan.Enabled = false;
                // Sekarang baris di bawah ini 100% aman karena diselamatkan oleh perisai di atas
                cmbBulan.SelectedIndex = 0;
            }
            else if (tipeTerpilih.ToLower() == "bulanan")
            {
                cmbBulan.Enabled = true;
            }
        }

        private void MuatDataSemester()
        {
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return;

                    string query = "SELECT idSemester, tahunAjaran FROM master.semester";
                    using (var cmd = new SqlCommand(query, conn))
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // MANUVER ARSITEK: Menyisipkan baris default ke urutan paling atas (Index 0)
                        DataRow dr = dt.NewRow();
                        dr["idSemester"] = 0; // ID 0 tidak akan pernah ada di database sungguhan
                        dr["tahunAjaran"] = "-- Pilih Semester --";
                        dt.Rows.InsertAt(dr, 0);

                        cmbSemester.DataSource = dt;
                        cmbSemester.DisplayMember = "tahunAjaran";
                        cmbSemester.ValueMember = "idSemester";
                        cmbSemester.SelectedIndex = 0; // Kunci di nilai default
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat semester: " + ex.Message, "System Error");
            }
        }


        // FUNGSI 1: Ambil barang Non-Rutin yang stoknya kritis (< 20)
        private DataTable GetProcurementAlertData()
        {
            DataTable dt = new DataTable();
            using (var conn = DatabaseConfig.GetConnection())
            {
                string query = @"
            SELECT namaBarang AS [Nama Barang], stok AS [Sisa Stok], 'SEGERA BELI' AS [Rekomendasi]
            FROM [master].barang 
            WHERE tipeBarang = 0 AND stok < 20";
                using (var da = new SqlDataAdapter(query, conn)) da.Fill(dt);
            }
            return dt;
        }

        // FUNGSI 2: Ambil barang Rutin yang sering rusak (Threshold: > 2x Rusak dalam history)
        private DataTable GetReplacementAlertData()
        {
            DataTable dt = new DataTable();
            using (var conn = DatabaseConfig.GetConnection())
            {
                string query = @"
            SELECT 
                b.namaBarang AS [Nama Asset], 
                r.namaRuangan AS [Lokasi],
                COUNT(m.idMaintenance) AS [Total Frekuensi Rusak]
            FROM [transaction].maintenance m
            JOIN [transaction].detailBarang db ON m.idDetailBarang = db.idDetailBarang
            JOIN [master].barang b ON db.idBarang = b.idBarang
            JOIN [master].ruangan r ON db.idRuangan = r.idRuangan
            WHERE m.kondisi = 0 -- 0 artinya Rusak
            GROUP BY b.namaBarang, r.namaRuangan
            HAVING COUNT(m.idMaintenance) >= 2"; // Jika sudah 2x rusak atau lebih, layak ganti
                using (var da = new SqlDataAdapter(query, conn)) da.Fill(dt);
            }
            return dt;
        }

        // =========================================================
        // FUNGSI 3: PENARIK DATA UTAMA (YANG HILANG)
        // =========================================================
        private DataTable GetLaporanData(string tipe, int idSemester, int angkaBulan)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return dt;

                    // Query Dasar dengan JOIN untuk mendapatkan nama asli
                    string query = @"
                        SELECT 
                            pb.tglPermintaan AS [Tanggal Transaksi],
                            b.namaBarang AS [Nama Barang],
                            r.namaRuangan AS [Lokasi Ruangan],
                            pb.namaPeminta AS [Nama Peminta],
                            pb.jumlah AS [Jumlah Diberikan]
                        FROM [transaction].permintaanBarang pb
                        JOIN [master].barang b ON pb.idBarang = b.idBarang
                        JOIN [master].ruangan r ON pb.idRuangan = r.idRuangan
                        WHERE pb.idSemester = @idSemester";

                    // Modifikasi query secara dinamis jika user meminta laporan Bulanan
                    if (tipe.ToLower() == "bulanan" && angkaBulan > 0)
                    {
                        query += " AND MONTH(pb.tglPermintaan) = @bulan";
                    }

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        // Proteksi Mutlak SQL Injection
                        cmd.Parameters.AddWithValue("@idSemester", idSemester);

                        if (tipe.ToLower() == "bulanan" && angkaBulan > 0)
                        {
                            cmd.Parameters.AddWithValue("@bulan", angkaBulan);
                        }

                        using (var da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengeksekusi query Laporan Utama: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        private DataTable GetMaintenanceData(string tipe, int idSemester, int angkaBulan)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var conn = DatabaseConfig.GetConnection())
                {
                    if (conn == null) return dt;

                    string query = @"
                SELECT 
                    m.tglCek AS [Tanggal Pengecekan],
                    b.namaBarang AS [Nama Aset],
                    r.namaRuangan AS [Lokasi],
                    k.namaKaryawan AS [Petugas],
                    CASE WHEN m.kondisi = 1 THEN 'BAIK' ELSE 'RUSAK' END AS [Kondisi Akhir],
                    ISNULL(m.kerusakan, '-') AS [Detail Kerusakan],
                    ISNULL(m.tindakLanjut, '-') AS [Tindak Lanjut]
                FROM [transaction].maintenance m
                JOIN [transaction].detailBarang db ON m.idDetailBarang = db.idDetailBarang
                JOIN [master].barang b ON db.idBarang = b.idBarang
                JOIN [master].ruangan r ON db.idRuangan = r.idRuangan
                JOIN [master].karyawan k ON m.idKaryawan = k.idKaryawan
                WHERE m.idSemester = @idSemester";

                    if (tipe.ToLower() == "bulanan" && angkaBulan > 0)
                    {
                        query += " AND MONTH(m.tglCek) = @bulan";
                    }

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idSemester", idSemester);
                        if (tipe.ToLower() == "bulanan") cmd.Parameters.AddWithValue("@bulan", angkaBulan);

                        using (var da = new SqlDataAdapter(cmd)) da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menarik data Maintenance: " + ex.Message, "DB Error");
            }
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ==========================================================
            // FASE 1: VALIDASI KETAT NILAI DEFAULT (THE GATEKEEPER)
            // ==========================================================

            // 1. Cek Dropdown Tipe (Gunakan <= 0 untuk menangkal kondisi belum diklik sama sekali)
            if (cmbTipe.SelectedIndex <= 0)
            {
                MessageBox.Show("Anda belum memilih Tipe Laporan. Silakan pilih 'Semester' atau 'Bulanan'.", "Validasi Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipe.Focus();
                return;
            }

            // 2. Cek Dropdown Semester
            if (cmbSemester.SelectedValue == null) return; // Mencegah NullReferenceException
            int idSemester = Convert.ToInt32(cmbSemester.SelectedValue);

            if (idSemester == 0)
            {
                MessageBox.Show("Anda belum memilih Semester. Silakan pilih tahun ajaran yang tersedia.", "Validasi Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSemester.Focus();
                return;
            }

            // 3. Setup Variabel Logika
            string tipe = cmbTipe.SelectedItem.ToString().Trim();
            int angkaBulan = 0;

            // 4. Cek Khusus Dropdown Bulan (Jika tipe Bulanan)
            if (tipe.ToLower() == "bulanan")
            {
                if (cmbBulan.SelectedIndex <= 0)
                {
                    MessageBox.Show("Untuk laporan Bulanan, Anda wajib memilih Bulan spesifik.", "Validasi Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbBulan.Focus();
                    return;
                }
                angkaBulan = cmbBulan.SelectedIndex; // Index 1 otomatis mewakili Januari
            }

            // ==========================================================
            // FASE 2: PENARIKAN DATA INTELIJEN DARI DATABASE
            // ==========================================================
            DataTable dtPermintaan = GetLaporanData(tipe, idSemester, angkaBulan);
            DataTable dtMaintenance = GetMaintenanceData(tipe, idSemester, angkaBulan);
            DataTable dtStokKritis = GetProcurementAlertData();
            DataTable dtGantiBarang = GetReplacementAlertData();

            // ==========================================================
            // FASE 3: GENERASI DOKUMEN EXCEL (PRESENTATION LAYER)
            // ==========================================================
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                FileName = $"Laporan_Terpadu_Sarpras_{tipe}_{DateTime.Now:yyyyMMdd}.xlsx",
                Title = "Simpan Laporan Intelijen Sarpras"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor; // Ubah kursor jadi ikon loading

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        // ------------------------------------------------------
                        // SHEET 1: LAPORAN AKTIVITAS TERPADU (Dual-Table Layout)
                        // ------------------------------------------------------
                        var ws1 = wb.Worksheets.Add("Laporan Aktivitas");

                        // BAGIAN A: Data Permintaan
                        ws1.Cell(1, 1).Value = "LOG AKTIVITAS PERMINTAAN BARANG";
                        ws1.Cell(1, 1).Style.Font.Bold = true;
                        ws1.Cell(1, 1).Style.Font.FontSize = 14;
                        ws1.Cell(1, 1).Style.Font.FontColor = XLColor.DarkBlue;

                        // Fail-Safe: Cegah error jika tabel kosong
                        if (dtPermintaan.Rows.Count > 0)
                        {
                            ws1.Cell(3, 1).InsertTable(dtPermintaan, "TabelPermintaan", true);
                        }
                        else
                        {
                            ws1.Cell(3, 1).Value = "Tidak ada data permintaan pada periode ini.";
                            ws1.Cell(3, 1).Style.Font.Italic = true;
                        }

                        // Kalkulasi Spasi Dinamis (Dynamic Spacing)
                        int barisPermintaan = dtPermintaan.Rows.Count > 0 ? dtPermintaan.Rows.Count + 1 : 1;
                        int nextStartRow = 3 + barisPermintaan + 4; // Beri jarak estetika 4 baris ke bawah

                        // BAGIAN B: Data Maintenance
                        ws1.Cell(nextStartRow - 2, 1).Value = "LOG PENGECEKAN RUTIN & MAINTENANCE";
                        ws1.Cell(nextStartRow - 2, 1).Style.Font.Bold = true;
                        ws1.Cell(nextStartRow - 2, 1).Style.Font.FontSize = 14;
                        ws1.Cell(nextStartRow - 2, 1).Style.Font.FontColor = XLColor.DarkGreen;

                        if (dtMaintenance.Rows.Count > 0)
                        {
                            ws1.Cell(nextStartRow, 1).InsertTable(dtMaintenance, "TabelMaintenance", true);
                        }
                        else
                        {
                            ws1.Cell(nextStartRow, 1).Value = "Tidak ada riwayat maintenance pada periode ini.";
                            ws1.Cell(nextStartRow, 1).Style.Font.Italic = true;
                        }

                        ws1.Columns().AdjustToContents(); // Auto-fit semua kolom di Sheet 1

                        // ------------------------------------------------------
                        // SHEET 2: RENCANA PEMBELIAN (STOK KRITIS)
                        // ------------------------------------------------------
                        var ws2 = wb.Worksheets.Add(dtStokKritis, "Rencana Pembelian");
                        ws2.TabColor = XLColor.Red;
                        ws2.Columns().AdjustToContents();

                        // ------------------------------------------------------
                        // SHEET 3: REKOMENDASI GANTI BARANG (RUSAK BERULANG)
                        // ------------------------------------------------------
                        var ws3 = wb.Worksheets.Add(dtGantiBarang, "Rekomendasi Ganti");
                        ws3.TabColor = XLColor.Orange;
                        ws3.Columns().AdjustToContents();

                        // EKSEKUSI PENYIMPANAN
                        wb.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Dokumen Laporan Intelijen Terpadu berhasil di-generate dan disimpan dengan aman!", "Operasi Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Penanganan error jika file Excel sedang dibuka oleh user saat aplikasi mencoba menimpanya (Overwrite)
                    MessageBox.Show("Terjadi kegagalan kritis saat menulis file Excel. Pastikan file tidak sedang terbuka oleh aplikasi lain.\n\nDetail Log: " + ex.Message, "File System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default; // Kembalikan kursor ke normal 
                }
            }
        }
    }
}
