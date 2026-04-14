namespace ManajemenSarPras
{
    partial class permintaanBarang
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
            this.label1 = new System.Windows.Forms.Label();
            this.idBarang = new System.Windows.Forms.Label();
            this.idRuangan = new System.Windows.Forms.Label();
            this.namaPeminta = new System.Windows.Forms.Label();
            this.jml = new System.Windows.Forms.Label();
            this.idSmt = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.stockBarang = new System.Windows.Forms.Button();
            this.addPeminta = new System.Windows.Forms.Button();
            this.updatePminjam = new System.Windows.Forms.Button();
            this.hpsPermintaan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKembali
            // 
            this.btnKembali.Location = new System.Drawing.Point(35, 27);
            this.btnKembali.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(120, 42);
            this.btnKembali.TabIndex = 0;
            this.btnKembali.Text = "Kembali";
            this.btnKembali.UseVisualStyleBackColor = true;
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(335, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Permintaan Barang";
            // 
            // idBarang
            // 
            this.idBarang.AutoSize = true;
            this.idBarang.Location = new System.Drawing.Point(31, 129);
            this.idBarang.Name = "idBarang";
            this.idBarang.Size = new System.Drawing.Size(82, 20);
            this.idBarang.TabIndex = 2;
            this.idBarang.Text = "ID Barang";
            // 
            // idRuangan
            // 
            this.idRuangan.AutoSize = true;
            this.idRuangan.Location = new System.Drawing.Point(31, 181);
            this.idRuangan.Name = "idRuangan";
            this.idRuangan.Size = new System.Drawing.Size(96, 20);
            this.idRuangan.TabIndex = 3;
            this.idRuangan.Text = "ID Ruangan";
            // 
            // namaPeminta
            // 
            this.namaPeminta.AutoSize = true;
            this.namaPeminta.Location = new System.Drawing.Point(31, 232);
            this.namaPeminta.Name = "namaPeminta";
            this.namaPeminta.Size = new System.Drawing.Size(113, 20);
            this.namaPeminta.TabIndex = 4;
            this.namaPeminta.Text = "Nama Peminta";
            // 
            // jml
            // 
            this.jml.AutoSize = true;
            this.jml.Location = new System.Drawing.Point(31, 283);
            this.jml.Name = "jml";
            this.jml.Size = new System.Drawing.Size(60, 20);
            this.jml.TabIndex = 5;
            this.jml.Text = "Jumlah";
            // 
            // idSmt
            // 
            this.idSmt.AutoSize = true;
            this.idSmt.Location = new System.Drawing.Point(31, 330);
            this.idSmt.Name = "idSmt";
            this.idSmt.Size = new System.Drawing.Size(78, 20);
            this.idSmt.TabIndex = 6;
            this.idSmt.Text = "Semester";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(232, 122);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(156, 26);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(232, 181);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(156, 26);
            this.textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(232, 232);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(274, 26);
            this.textBox3.TabIndex = 9;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(232, 283);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(156, 26);
            this.textBox4.TabIndex = 10;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(232, 330);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(156, 26);
            this.textBox5.TabIndex = 11;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(35, 375);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(850, 184);
            this.dataGridView1.TabIndex = 12;
            // 
            // stockBarang
            // 
            this.stockBarang.Location = new System.Drawing.Point(729, 108);
            this.stockBarang.Name = "stockBarang";
            this.stockBarang.Size = new System.Drawing.Size(144, 54);
            this.stockBarang.TabIndex = 13;
            this.stockBarang.Text = "Tampilkan Stock";
            this.stockBarang.UseVisualStyleBackColor = true;
            // 
            // addPeminta
            // 
            this.addPeminta.Location = new System.Drawing.Point(729, 168);
            this.addPeminta.Name = "addPeminta";
            this.addPeminta.Size = new System.Drawing.Size(144, 54);
            this.addPeminta.TabIndex = 14;
            this.addPeminta.Text = "Tambah Permintaan";
            this.addPeminta.UseVisualStyleBackColor = true;
            // 
            // updatePminjam
            // 
            this.updatePminjam.Location = new System.Drawing.Point(729, 232);
            this.updatePminjam.Name = "updatePminjam";
            this.updatePminjam.Size = new System.Drawing.Size(144, 54);
            this.updatePminjam.TabIndex = 15;
            this.updatePminjam.Text = "Update Permintaan";
            this.updatePminjam.UseVisualStyleBackColor = true;
            // 
            // hpsPermintaan
            // 
            this.hpsPermintaan.Location = new System.Drawing.Point(729, 297);
            this.hpsPermintaan.Name = "hpsPermintaan";
            this.hpsPermintaan.Size = new System.Drawing.Size(144, 54);
            this.hpsPermintaan.TabIndex = 16;
            this.hpsPermintaan.Text = "Hapus Permintaan";
            this.hpsPermintaan.UseVisualStyleBackColor = true;
            // 
            // permintaanBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 563);
            this.Controls.Add(this.hpsPermintaan);
            this.Controls.Add(this.updatePminjam);
            this.Controls.Add(this.addPeminta);
            this.Controls.Add(this.stockBarang);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.idSmt);
            this.Controls.Add(this.jml);
            this.Controls.Add(this.namaPeminta);
            this.Controls.Add(this.idRuangan);
            this.Controls.Add(this.idBarang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKembali);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "permintaanBarang";
            this.Text = "PermintaanBarang";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKembali;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label idBarang;
        private System.Windows.Forms.Label idRuangan;
        private System.Windows.Forms.Label namaPeminta;
        private System.Windows.Forms.Label jml;
        private System.Windows.Forms.Label idSmt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button stockBarang;
        private System.Windows.Forms.Button addPeminta;
        private System.Windows.Forms.Button updatePminjam;
        private System.Windows.Forms.Button hpsPermintaan;
    }
}