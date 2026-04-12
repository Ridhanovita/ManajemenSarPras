namespace ManajemenSarPras
{
    partial class FormDetailBarang
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
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.labelNamaBarang = new System.Windows.Forms.Label();
            this.txtSpesifikasi = new System.Windows.Forms.RichTextBox();
            this.labelGedung = new System.Windows.Forms.Label();
            this.txtIdDetail = new System.Windows.Forms.RichTextBox();
            this.labelIdDetailBarang = new System.Windows.Forms.Label();
            this.cmbRuangan = new System.Windows.Forms.ComboBox();
            this.cmbGedung = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKembali = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.txtCari = new System.Windows.Forms.RichTextBox();
            this.labelCariDetailBarang = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBarang = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Location = new System.Drawing.Point(379, 170);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersWidth = 62;
            this.dgvDetail.RowTemplate.Height = 28;
            this.dgvDetail.Size = new System.Drawing.Size(548, 371);
            this.dgvDetail.TabIndex = 0;
            // 
            // labelNamaBarang
            // 
            this.labelNamaBarang.AutoSize = true;
            this.labelNamaBarang.Location = new System.Drawing.Point(17, 263);
            this.labelNamaBarang.Name = "labelNamaBarang";
            this.labelNamaBarang.Size = new System.Drawing.Size(109, 20);
            this.labelNamaBarang.TabIndex = 1;
            this.labelNamaBarang.Text = "SPESIFIKASI";
            // 
            // txtSpesifikasi
            // 
            this.txtSpesifikasi.Location = new System.Drawing.Point(132, 251);
            this.txtSpesifikasi.Name = "txtSpesifikasi";
            this.txtSpesifikasi.Size = new System.Drawing.Size(219, 43);
            this.txtSpesifikasi.TabIndex = 3;
            this.txtSpesifikasi.Text = "";
            // 
            // labelGedung
            // 
            this.labelGedung.AutoSize = true;
            this.labelGedung.Location = new System.Drawing.Point(17, 323);
            this.labelGedung.Name = "labelGedung";
            this.labelGedung.Size = new System.Drawing.Size(81, 20);
            this.labelGedung.TabIndex = 4;
            this.labelGedung.Text = "GEDUNG";
            // 
            // txtIdDetail
            // 
            this.txtIdDetail.Location = new System.Drawing.Point(132, 188);
            this.txtIdDetail.Name = "txtIdDetail";
            this.txtIdDetail.Size = new System.Drawing.Size(219, 43);
            this.txtIdDetail.TabIndex = 7;
            this.txtIdDetail.Text = "";
            // 
            // labelIdDetailBarang
            // 
            this.labelIdDetailBarang.AutoSize = true;
            this.labelIdDetailBarang.Location = new System.Drawing.Point(17, 191);
            this.labelIdDetailBarang.Name = "labelIdDetailBarang";
            this.labelIdDetailBarang.Size = new System.Drawing.Size(87, 40);
            this.labelIdDetailBarang.TabIndex = 6;
            this.labelIdDetailBarang.Text = "ID DETAIL\r\nBARANG";
            // 
            // cmbRuangan
            // 
            this.cmbRuangan.FormattingEnabled = true;
            this.cmbRuangan.Location = new System.Drawing.Point(132, 370);
            this.cmbRuangan.Name = "cmbRuangan";
            this.cmbRuangan.Size = new System.Drawing.Size(219, 28);
            this.cmbRuangan.TabIndex = 8;
            // 
            // cmbGedung
            // 
            this.cmbGedung.FormattingEnabled = true;
            this.cmbGedung.Location = new System.Drawing.Point(132, 320);
            this.cmbGedung.Name = "cmbGedung";
            this.cmbGedung.Size = new System.Drawing.Size(219, 28);
            this.cmbGedung.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "RUANGAN";
            // 
            // btnKembali
            // 
            this.btnKembali.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKembali.Location = new System.Drawing.Point(23, 12);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(103, 44);
            this.btnKembali.TabIndex = 11;
            this.btnKembali.Text = "Kembali";
            this.btnKembali.UseVisualStyleBackColor = true;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.Location = new System.Drawing.Point(21, 426);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(163, 55);
            this.btnSimpan.TabIndex = 12;
            this.btnSimpan.Text = "Tambah Detail \r\nBarang";
            this.btnSimpan.UseVisualStyleBackColor = true;
            // 
            // btnBatal
            // 
            this.btnBatal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatal.Location = new System.Drawing.Point(190, 426);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(161, 55);
            this.btnBatal.TabIndex = 13;
            this.btnBatal.Text = "Reset Text";
            this.btnBatal.UseVisualStyleBackColor = true;
            // 
            // btnHapus
            // 
            this.btnHapus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapus.Location = new System.Drawing.Point(107, 489);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(161, 55);
            this.btnHapus.TabIndex = 14;
            this.btnHapus.Text = "Hapus Detail\r\nBarang";
            this.btnHapus.UseVisualStyleBackColor = true;
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(494, 115);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(433, 43);
            this.txtCari.TabIndex = 15;
            this.txtCari.Text = "";
            // 
            // labelCariDetailBarang
            // 
            this.labelCariDetailBarang.AutoSize = true;
            this.labelCariDetailBarang.Location = new System.Drawing.Point(380, 118);
            this.labelCariDetailBarang.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.labelCariDetailBarang.Name = "labelCariDetailBarang";
            this.labelCariDetailBarang.Size = new System.Drawing.Size(113, 40);
            this.labelCariDetailBarang.TabIndex = 16;
            this.labelCariDetailBarang.Text = "CARI DETAIL \r\nBARANG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Stencil", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(268, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(379, 26);
            this.label2.TabIndex = 18;
            this.label2.Text = "PENGELOLAHAN DETAIL BARANG";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 40);
            this.label3.TabIndex = 19;
            this.label3.Text = "NAMA\r\nBARANG";
            // 
            // cmbBarang
            // 
            this.cmbBarang.FormattingEnabled = true;
            this.cmbBarang.Location = new System.Drawing.Point(132, 127);
            this.cmbBarang.Name = "cmbBarang";
            this.cmbBarang.Size = new System.Drawing.Size(219, 28);
            this.cmbBarang.TabIndex = 20;
            // 
            // FormDetailBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 563);
            this.Controls.Add(this.cmbBarang);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelCariDetailBarang);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnKembali);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbGedung);
            this.Controls.Add(this.cmbRuangan);
            this.Controls.Add(this.txtIdDetail);
            this.Controls.Add(this.labelIdDetailBarang);
            this.Controls.Add(this.labelGedung);
            this.Controls.Add(this.txtSpesifikasi);
            this.Controls.Add(this.labelNamaBarang);
            this.Controls.Add(this.dgvDetail);
            this.Name = "FormDetailBarang";
            this.Text = "FormDetailBarang";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Label labelNamaBarang;
        private System.Windows.Forms.RichTextBox txtSpesifikasi;
        private System.Windows.Forms.Label labelGedung;
        private System.Windows.Forms.RichTextBox txtIdDetail;
        private System.Windows.Forms.Label labelIdDetailBarang;
        private System.Windows.Forms.ComboBox cmbRuangan;
        private System.Windows.Forms.ComboBox cmbGedung;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKembali;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.RichTextBox txtCari;
        private System.Windows.Forms.Label labelCariDetailBarang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBarang;
    }
}