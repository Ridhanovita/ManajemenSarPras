namespace ManajemenSarPras
{
    partial class maintenancePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnKembali = new System.Windows.Forms.Button();
            this.labelNamaRuangan = new System.Windows.Forms.Label();
            this.labelNamaBarang = new System.Windows.Forms.Label();
            this.labelTanggal = new System.Windows.Forms.Label();
            this.labelKondisi = new System.Windows.Forms.Label();
            this.labelKerusakan = new System.Windows.Forms.Label();
            this.labelTindakLanjut = new System.Windows.Forms.Label();
            this.labelSemseter = new System.Windows.Forms.Label();
            this.cmbRuangan = new System.Windows.Forms.ComboBox();
            this.cmbDetailBarang = new System.Windows.Forms.ComboBox();
            this.dtpTglCek = new System.Windows.Forms.DateTimePicker();
            this.rbBaik = new System.Windows.Forms.RadioButton();
            this.rbRusak = new System.Windows.Forms.RadioButton();
            this.txtKerusakan = new System.Windows.Forms.TextBox();
            this.txtTindakLanjut = new System.Windows.Forms.TextBox();
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelKaryawan = new System.Windows.Forms.Label();
            this.cmbKaryawan = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHapus = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKembali
            // 
            this.btnKembali.Location = new System.Drawing.Point(32, 32);
            this.btnKembali.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(123, 37);
            this.btnKembali.TabIndex = 0;
            this.btnKembali.Text = "Kembali";
            this.btnKembali.UseVisualStyleBackColor = true;
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click);
            // 
            // labelNamaRuangan
            // 
            this.labelNamaRuangan.AutoSize = true;
            this.labelNamaRuangan.Location = new System.Drawing.Point(47, 179);
            this.labelNamaRuangan.Name = "labelNamaRuangan";
            this.labelNamaRuangan.Size = new System.Drawing.Size(121, 20);
            this.labelNamaRuangan.TabIndex = 1;
            this.labelNamaRuangan.Text = "Nama Ruangan";
            // 
            // labelNamaBarang
            // 
            this.labelNamaBarang.AutoSize = true;
            this.labelNamaBarang.Location = new System.Drawing.Point(47, 132);
            this.labelNamaBarang.Name = "labelNamaBarang";
            this.labelNamaBarang.Size = new System.Drawing.Size(107, 20);
            this.labelNamaBarang.TabIndex = 2;
            this.labelNamaBarang.Text = "Nama Barang";
            // 
            // labelTanggal
            // 
            this.labelTanggal.AutoSize = true;
            this.labelTanggal.Location = new System.Drawing.Point(47, 232);
            this.labelTanggal.Name = "labelTanggal";
            this.labelTanggal.Size = new System.Drawing.Size(66, 20);
            this.labelTanggal.TabIndex = 3;
            this.labelTanggal.Text = "Tanggal";
            // 
            // labelKondisi
            // 
            this.labelKondisi.AutoSize = true;
            this.labelKondisi.Location = new System.Drawing.Point(47, 268);
            this.labelKondisi.Name = "labelKondisi";
            this.labelKondisi.Size = new System.Drawing.Size(60, 20);
            this.labelKondisi.TabIndex = 4;
            this.labelKondisi.Text = "Kondisi";
            // 
            // labelKerusakan
            // 
            this.labelKerusakan.AutoSize = true;
            this.labelKerusakan.Location = new System.Drawing.Point(47, 305);
            this.labelKerusakan.Name = "labelKerusakan";
            this.labelKerusakan.Size = new System.Drawing.Size(85, 20);
            this.labelKerusakan.TabIndex = 5;
            this.labelKerusakan.Text = "Kerusakan";
            // 
            // labelTindakLanjut
            // 
            this.labelTindakLanjut.AutoSize = true;
            this.labelTindakLanjut.Location = new System.Drawing.Point(47, 341);
            this.labelTindakLanjut.Name = "labelTindakLanjut";
            this.labelTindakLanjut.Size = new System.Drawing.Size(104, 20);
            this.labelTindakLanjut.TabIndex = 6;
            this.labelTindakLanjut.Text = "Tindak Lanjut";
            // 
            // labelSemseter
            // 
            this.labelSemseter.AutoSize = true;
            this.labelSemseter.Location = new System.Drawing.Point(47, 423);
            this.labelSemseter.Name = "labelSemseter";
            this.labelSemseter.Size = new System.Drawing.Size(78, 20);
            this.labelSemseter.TabIndex = 7;
            this.labelSemseter.Text = "Semester";
            // 
            // cmbRuangan
            // 
            this.cmbRuangan.FormattingEnabled = true;
            this.cmbRuangan.Location = new System.Drawing.Point(210, 179);
            this.cmbRuangan.Name = "cmbRuangan";
            this.cmbRuangan.Size = new System.Drawing.Size(200, 28);
            this.cmbRuangan.TabIndex = 8;
            // 
            // cmbDetailBarang
            // 
            this.cmbDetailBarang.FormattingEnabled = true;
            this.cmbDetailBarang.Location = new System.Drawing.Point(210, 129);
            this.cmbDetailBarang.Name = "cmbDetailBarang";
            this.cmbDetailBarang.Size = new System.Drawing.Size(200, 28);
            this.cmbDetailBarang.TabIndex = 9;
            // 
            // dtpTglCek
            // 
            this.dtpTglCek.Location = new System.Drawing.Point(210, 230);
            this.dtpTglCek.Name = "dtpTglCek";
            this.dtpTglCek.Size = new System.Drawing.Size(200, 26);
            this.dtpTglCek.TabIndex = 10;
            // 
            // rbBaik
            // 
            this.rbBaik.AutoSize = true;
            this.rbBaik.Location = new System.Drawing.Point(210, 268);
            this.rbBaik.Name = "rbBaik";
            this.rbBaik.Size = new System.Drawing.Size(65, 24);
            this.rbBaik.TabIndex = 11;
            this.rbBaik.TabStop = true;
            this.rbBaik.Text = "Baik";
            this.rbBaik.UseVisualStyleBackColor = true;
            // 
            // rbRusak
            // 
            this.rbRusak.AutoSize = true;
            this.rbRusak.Location = new System.Drawing.Point(330, 268);
            this.rbRusak.Name = "rbRusak";
            this.rbRusak.Size = new System.Drawing.Size(80, 24);
            this.rbRusak.TabIndex = 12;
            this.rbRusak.TabStop = true;
            this.rbRusak.Text = "Rusak";
            this.rbRusak.UseVisualStyleBackColor = true;
            // 
            // txtKerusakan
            // 
            this.txtKerusakan.Location = new System.Drawing.Point(210, 305);
            this.txtKerusakan.Name = "txtKerusakan";
            this.txtKerusakan.Size = new System.Drawing.Size(200, 26);
            this.txtKerusakan.TabIndex = 13;
            // 
            // txtTindakLanjut
            // 
            this.txtTindakLanjut.Location = new System.Drawing.Point(210, 341);
            this.txtTindakLanjut.Name = "txtTindakLanjut";
            this.txtTindakLanjut.Size = new System.Drawing.Size(200, 26);
            this.txtTindakLanjut.TabIndex = 14;
            // 
            // cmbSemester
            // 
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Location = new System.Drawing.Point(210, 415);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.Size = new System.Drawing.Size(200, 28);
            this.cmbSemester.TabIndex = 15;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(51, 466);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(158, 39);
            this.btnSimpan.TabIndex = 16;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(215, 466);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(195, 40);
            this.btnReset.TabIndex = 17;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(51, 705);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(850, 388);
            this.dataGridView1.TabIndex = 18;
            // 
            // labelKaryawan
            // 
            this.labelKaryawan.AutoSize = true;
            this.labelKaryawan.Location = new System.Drawing.Point(47, 379);
            this.labelKaryawan.Name = "labelKaryawan";
            this.labelKaryawan.Size = new System.Drawing.Size(124, 20);
            this.labelKaryawan.TabIndex = 19;
            this.labelKaryawan.Text = "Nama Karyawan";
            // 
            // cmbKaryawan
            // 
            this.cmbKaryawan.FormattingEnabled = true;
            this.cmbKaryawan.Location = new System.Drawing.Point(210, 375);
            this.cmbKaryawan.Name = "cmbKaryawan";
            this.cmbKaryawan.Size = new System.Drawing.Size(200, 28);
            this.cmbKaryawan.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(281, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 38);
            this.label1.TabIndex = 21;
            this.label1.Text = "Maintenance Barang";
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(51, 512);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(359, 38);
            this.btnHapus.TabIndex = 22;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Stencil", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 611);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(497, 38);
            this.label2.TabIndex = 23;
            this.label2.Text = "Riwayat Maintance Barang";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(434, 165);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(467, 385);
            this.dataGridView2.TabIndex = 24;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(568, 129);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(333, 26);
            this.textBox1.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(430, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Cari Data Barang";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(186, 661);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(715, 26);
            this.textBox2.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 664);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Cari Data Riwayat";
            // 
            // maintenancePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 1133);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbKaryawan);
            this.Controls.Add(this.labelKaryawan);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.cmbSemester);
            this.Controls.Add(this.txtTindakLanjut);
            this.Controls.Add(this.txtKerusakan);
            this.Controls.Add(this.rbRusak);
            this.Controls.Add(this.rbBaik);
            this.Controls.Add(this.dtpTglCek);
            this.Controls.Add(this.cmbDetailBarang);
            this.Controls.Add(this.cmbRuangan);
            this.Controls.Add(this.labelSemseter);
            this.Controls.Add(this.labelTindakLanjut);
            this.Controls.Add(this.labelKerusakan);
            this.Controls.Add(this.labelKondisi);
            this.Controls.Add(this.labelTanggal);
            this.Controls.Add(this.labelNamaBarang);
            this.Controls.Add(this.labelNamaRuangan);
            this.Controls.Add(this.btnKembali);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "maintenancePage";
            this.Text = "mntenncePage";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKembali;
        private System.Windows.Forms.Label labelNamaRuangan;
        private System.Windows.Forms.Label labelNamaBarang;
        private System.Windows.Forms.Label labelTanggal;
        private System.Windows.Forms.Label labelKondisi;
        private System.Windows.Forms.Label labelKerusakan;
        private System.Windows.Forms.Label labelTindakLanjut;
        private System.Windows.Forms.Label labelSemseter;
        private System.Windows.Forms.ComboBox cmbRuangan;
        private System.Windows.Forms.ComboBox cmbDetailBarang;
        private System.Windows.Forms.DateTimePicker dtpTglCek;
        private System.Windows.Forms.RadioButton rbBaik;
        private System.Windows.Forms.RadioButton rbRusak;
        private System.Windows.Forms.TextBox txtKerusakan;
        private System.Windows.Forms.TextBox txtTindakLanjut;
        private System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelKaryawan;
        private System.Windows.Forms.ComboBox cmbKaryawan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
    }
}