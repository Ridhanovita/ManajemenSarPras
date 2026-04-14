namespace ManajemenSarPras
{
    partial class kelolaBarang
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
            this.components = new System.ComponentModel.Container();
            this.btnKembali = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNamaBarang = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtNamaBarang = new System.Windows.Forms.TextBox();
            this.txtIdBarang = new System.Windows.Forms.TextBox();
            this.labelIdBarang = new System.Windows.Forms.Label();
            this.btnTambahBarang = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.labelTipeBarang = new System.Windows.Forms.Label();
            this.cmbTipeBarang = new System.Windows.Forms.ComboBox();
            this.labelJumlahBarang = new System.Windows.Forms.Label();
            this.txtJumlahBarang = new System.Windows.Forms.TextBox();
            this.labelCariBarang = new System.Windows.Forms.Label();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.txtReset = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMerk = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKembali
            // 
            this.btnKembali.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKembali.Location = new System.Drawing.Point(21, 13);
            this.btnKembali.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(107, 31);
            this.btnKembali.TabIndex = 0;
            this.btnKembali.Text = "Kembali";
            this.btnKembali.UseVisualStyleBackColor = true;
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(419, 153);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(508, 390);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(256, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(566, 57);
            this.label1.TabIndex = 2;
            this.label1.Text = "PENGELOLAAN BARANG";
            // 
            // labelNamaBarang
            // 
            this.labelNamaBarang.AutoSize = true;
            this.labelNamaBarang.Location = new System.Drawing.Point(15, 198);
            this.labelNamaBarang.Name = "labelNamaBarang";
            this.labelNamaBarang.Size = new System.Drawing.Size(128, 20);
            this.labelNamaBarang.TabIndex = 3;
            this.labelNamaBarang.Text = "NAMA BARANG";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 4;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtNamaBarang
            // 
            this.txtNamaBarang.Location = new System.Drawing.Point(179, 195);
            this.txtNamaBarang.Name = "txtNamaBarang";
            this.txtNamaBarang.Size = new System.Drawing.Size(215, 26);
            this.txtNamaBarang.TabIndex = 6;
            this.txtNamaBarang.TextChanged += new System.EventHandler(this.txtNamaBarang_TextChanged);
            // 
            // txtIdBarang
            // 
            this.txtIdBarang.Location = new System.Drawing.Point(179, 153);
            this.txtIdBarang.Name = "txtIdBarang";
            this.txtIdBarang.Size = new System.Drawing.Size(215, 26);
            this.txtIdBarang.TabIndex = 8;
            // 
            // labelIdBarang
            // 
            this.labelIdBarang.AutoSize = true;
            this.labelIdBarang.Location = new System.Drawing.Point(15, 156);
            this.labelIdBarang.Name = "labelIdBarang";
            this.labelIdBarang.Size = new System.Drawing.Size(99, 20);
            this.labelIdBarang.TabIndex = 7;
            this.labelIdBarang.Text = "ID BARANG";
            // 
            // btnTambahBarang
            // 
            this.btnTambahBarang.BackColor = System.Drawing.Color.Lime;
            this.btnTambahBarang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambahBarang.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTambahBarang.Location = new System.Drawing.Point(19, 396);
            this.btnTambahBarang.Name = "btnTambahBarang";
            this.btnTambahBarang.Size = new System.Drawing.Size(124, 34);
            this.btnTambahBarang.TabIndex = 9;
            this.btnTambahBarang.Text = "Tambah Barang";
            this.btnTambahBarang.UseVisualStyleBackColor = false;
            this.btnTambahBarang.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.Red;
            this.btnHapus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHapus.Location = new System.Drawing.Point(156, 396);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(110, 34);
            this.btnHapus.TabIndex = 11;
            this.btnHapus.Text = "Hapus Barang";
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(19, 436);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(375, 34);
            this.button3.TabIndex = 12;
            this.button3.Text = "Detail Barang";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // labelTipeBarang
            // 
            this.labelTipeBarang.AutoSize = true;
            this.labelTipeBarang.Location = new System.Drawing.Point(15, 243);
            this.labelTipeBarang.Name = "labelTipeBarang";
            this.labelTipeBarang.Size = new System.Drawing.Size(117, 20);
            this.labelTipeBarang.TabIndex = 13;
            this.labelTipeBarang.Text = "TIPE BARANG";
            // 
            // cmbTipeBarang
            // 
            this.cmbTipeBarang.FormattingEnabled = true;
            this.cmbTipeBarang.Items.AddRange(new object[] {
            "Perlu Pengecekkan Rutin",
            "Tidak Perlu Pengecekkan Rutin"});
            this.cmbTipeBarang.Location = new System.Drawing.Point(179, 243);
            this.cmbTipeBarang.Name = "cmbTipeBarang";
            this.cmbTipeBarang.Size = new System.Drawing.Size(215, 28);
            this.cmbTipeBarang.TabIndex = 14;
            this.cmbTipeBarang.SelectedIndexChanged += new System.EventHandler(this.cmbTipeBarang_SelectedIndexChanged);
            // 
            // labelJumlahBarang
            // 
            this.labelJumlahBarang.AutoSize = true;
            this.labelJumlahBarang.Location = new System.Drawing.Point(15, 329);
            this.labelJumlahBarang.Name = "labelJumlahBarang";
            this.labelJumlahBarang.Size = new System.Drawing.Size(151, 40);
            this.labelJumlahBarang.TabIndex = 15;
            this.labelJumlahBarang.Text = "JUMLAH BARANG \r\nNON-CHECK";
            this.labelJumlahBarang.Click += new System.EventHandler(this.labelJumlahBarang_Click);
            // 
            // txtJumlahBarang
            // 
            this.txtJumlahBarang.Location = new System.Drawing.Point(179, 338);
            this.txtJumlahBarang.Name = "txtJumlahBarang";
            this.txtJumlahBarang.Size = new System.Drawing.Size(215, 26);
            this.txtJumlahBarang.TabIndex = 16;
            this.txtJumlahBarang.TextChanged += new System.EventHandler(this.txtJumlahBarang_TextChanged);
            // 
            // labelCariBarang
            // 
            this.labelCariBarang.AutoSize = true;
            this.labelCariBarang.Location = new System.Drawing.Point(415, 103);
            this.labelCariBarang.Name = "labelCariBarang";
            this.labelCariBarang.Size = new System.Drawing.Size(121, 20);
            this.labelCariBarang.TabIndex = 18;
            this.labelCariBarang.Text = "CARI BARANG";
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(542, 100);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(385, 26);
            this.txtCari.TabIndex = 19;
            // 
            // txtReset
            // 
            this.txtReset.BackColor = System.Drawing.Color.Yellow;
            this.txtReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReset.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtReset.Location = new System.Drawing.Point(284, 396);
            this.txtReset.Name = "txtReset";
            this.txtReset.Size = new System.Drawing.Size(110, 34);
            this.txtReset.TabIndex = 20;
            this.txtReset.Text = "Reset Text";
            this.txtReset.UseVisualStyleBackColor = false;
            this.txtReset.Click += new System.EventHandler(this.txtReset_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "MERK";
            // 
            // cmbMerk
            // 
            this.cmbMerk.FormattingEnabled = true;
            this.cmbMerk.Location = new System.Drawing.Point(179, 291);
            this.cmbMerk.Name = "cmbMerk";
            this.cmbMerk.Size = new System.Drawing.Size(215, 28);
            this.cmbMerk.TabIndex = 27;
            // 
            // kelolaBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 563);
            this.Controls.Add(this.cmbMerk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtReset);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.labelCariBarang);
            this.Controls.Add(this.txtJumlahBarang);
            this.Controls.Add(this.labelJumlahBarang);
            this.Controls.Add(this.cmbTipeBarang);
            this.Controls.Add(this.labelTipeBarang);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnTambahBarang);
            this.Controls.Add(this.txtIdBarang);
            this.Controls.Add(this.labelIdBarang);
            this.Controls.Add(this.txtNamaBarang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelNamaBarang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnKembali);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "kelolaBarang";
            this.Text = "kelolaBarang";
            this.Load += new System.EventHandler(this.kelolaBarang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKembali;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNamaBarang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtNamaBarang;
        private System.Windows.Forms.TextBox txtIdBarang;
        private System.Windows.Forms.Label labelIdBarang;
        private System.Windows.Forms.Button btnTambahBarang;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label labelTipeBarang;
        private System.Windows.Forms.ComboBox cmbTipeBarang;
        private System.Windows.Forms.Label labelJumlahBarang;
        private System.Windows.Forms.TextBox txtJumlahBarang;
        private System.Windows.Forms.Label labelCariBarang;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Button txtReset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbMerk;
    }
}