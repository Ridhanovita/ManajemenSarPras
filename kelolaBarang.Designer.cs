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
            this.btnUpdateBarang = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.labelTipeBarang = new System.Windows.Forms.Label();
            this.cmbTipeBarang = new System.Windows.Forms.ComboBox();
            this.labelJumlahBarang = new System.Windows.Forms.Label();
            this.txtJumlahBarang = new System.Windows.Forms.TextBox();
            this.labelCariBarang = new System.Windows.Forms.Label();
            this.btnCariBarang = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKembali
            // 
            this.btnKembali.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKembali.Location = new System.Drawing.Point(21, 13);
            this.btnKembali.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(107, 48);
            this.btnKembali.TabIndex = 0;
            this.btnKembali.Text = "Kembali";
            this.btnKembali.UseVisualStyleBackColor = true;
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(527, 153);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(726, 320);
            this.dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "PENGELOLAAN BARANG";
            // 
            // labelNamaBarang
            // 
            this.labelNamaBarang.AutoSize = true;
            this.labelNamaBarang.Location = new System.Drawing.Point(20, 150);
            this.labelNamaBarang.Name = "labelNamaBarang";
            this.labelNamaBarang.Size = new System.Drawing.Size(128, 20);
            this.labelNamaBarang.TabIndex = 3;
            this.labelNamaBarang.Text = "NAMA BARANG";
            this.labelNamaBarang.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtNamaBarang
            // 
            this.txtNamaBarang.Location = new System.Drawing.Point(184, 147);
            this.txtNamaBarang.Name = "txtNamaBarang";
            this.txtNamaBarang.Size = new System.Drawing.Size(196, 26);
            this.txtNamaBarang.TabIndex = 6;
            // 
            // txtIdBarang
            // 
            this.txtIdBarang.Location = new System.Drawing.Point(184, 100);
            this.txtIdBarang.Name = "txtIdBarang";
            this.txtIdBarang.Size = new System.Drawing.Size(196, 26);
            this.txtIdBarang.TabIndex = 8;
            this.txtIdBarang.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // labelIdBarang
            // 
            this.labelIdBarang.AutoSize = true;
            this.labelIdBarang.Location = new System.Drawing.Point(20, 103);
            this.labelIdBarang.Name = "labelIdBarang";
            this.labelIdBarang.Size = new System.Drawing.Size(99, 20);
            this.labelIdBarang.TabIndex = 7;
            this.labelIdBarang.Text = "ID BARANG";
            this.labelIdBarang.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnTambahBarang
            // 
            this.btnTambahBarang.BackColor = System.Drawing.Color.Lime;
            this.btnTambahBarang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambahBarang.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTambahBarang.Location = new System.Drawing.Point(24, 326);
            this.btnTambahBarang.Name = "btnTambahBarang";
            this.btnTambahBarang.Size = new System.Drawing.Size(104, 34);
            this.btnTambahBarang.TabIndex = 9;
            this.btnTambahBarang.Text = "Tambah Barang";
            this.btnTambahBarang.UseVisualStyleBackColor = false;
            // 
            // btnUpdateBarang
            // 
            this.btnUpdateBarang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateBarang.Location = new System.Drawing.Point(309, 326);
            this.btnUpdateBarang.Name = "btnUpdateBarang";
            this.btnUpdateBarang.Size = new System.Drawing.Size(90, 34);
            this.btnUpdateBarang.TabIndex = 10;
            this.btnUpdateBarang.Text = "Update Barang";
            this.btnUpdateBarang.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(146, 326);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 34);
            this.button2.TabIndex = 11;
            this.button2.Text = "Hapus Barang";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(24, 366);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(449, 34);
            this.button3.TabIndex = 12;
            this.button3.Text = "Detail Barang";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // labelTipeBarang
            // 
            this.labelTipeBarang.AutoSize = true;
            this.labelTipeBarang.Location = new System.Drawing.Point(20, 206);
            this.labelTipeBarang.Name = "labelTipeBarang";
            this.labelTipeBarang.Size = new System.Drawing.Size(117, 20);
            this.labelTipeBarang.TabIndex = 13;
            this.labelTipeBarang.Text = "TIPE BARANG";
            this.labelTipeBarang.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // cmbTipeBarang
            // 
            this.cmbTipeBarang.FormattingEnabled = true;
            this.cmbTipeBarang.Items.AddRange(new object[] {
            "Perlu Pengecekkan Rutin",
            "Tidak Perlu Pengecekkan Rutin"});
            this.cmbTipeBarang.Location = new System.Drawing.Point(184, 206);
            this.cmbTipeBarang.Name = "cmbTipeBarang";
            this.cmbTipeBarang.Size = new System.Drawing.Size(196, 28);
            this.cmbTipeBarang.TabIndex = 14;
            // 
            // labelJumlahBarang
            // 
            this.labelJumlahBarang.AutoSize = true;
            this.labelJumlahBarang.Location = new System.Drawing.Point(20, 259);
            this.labelJumlahBarang.Name = "labelJumlahBarang";
            this.labelJumlahBarang.Size = new System.Drawing.Size(151, 40);
            this.labelJumlahBarang.TabIndex = 15;
            this.labelJumlahBarang.Text = "JUMLAH BARANG \r\nNON-CHECK";
            // 
            // txtJumlahBarang
            // 
            this.txtJumlahBarang.Location = new System.Drawing.Point(184, 268);
            this.txtJumlahBarang.Name = "txtJumlahBarang";
            this.txtJumlahBarang.Size = new System.Drawing.Size(196, 26);
            this.txtJumlahBarang.TabIndex = 16;
            // 
            // labelCariBarang
            // 
            this.labelCariBarang.AutoSize = true;
            this.labelCariBarang.Location = new System.Drawing.Point(523, 109);
            this.labelCariBarang.Name = "labelCariBarang";
            this.labelCariBarang.Size = new System.Drawing.Size(121, 20);
            this.labelCariBarang.TabIndex = 18;
            this.labelCariBarang.Text = "CARI BARANG";
            // 
            // btnCariBarang
            // 
            this.btnCariBarang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCariBarang.Location = new System.Drawing.Point(1117, 103);
            this.btnCariBarang.Name = "btnCariBarang";
            this.btnCariBarang.Size = new System.Drawing.Size(136, 34);
            this.btnCariBarang.TabIndex = 17;
            this.btnCariBarang.Text = "CARI";
            this.btnCariBarang.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(665, 106);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(431, 26);
            this.textBox1.TabIndex = 19;
            // 
            // kelolaBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 563);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelCariBarang);
            this.Controls.Add(this.btnCariBarang);
            this.Controls.Add(this.txtJumlahBarang);
            this.Controls.Add(this.labelJumlahBarang);
            this.Controls.Add(this.cmbTipeBarang);
            this.Controls.Add(this.labelTipeBarang);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnUpdateBarang);
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
        private System.Windows.Forms.Button btnUpdateBarang;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label labelTipeBarang;
        private System.Windows.Forms.ComboBox cmbTipeBarang;
        private System.Windows.Forms.Label labelJumlahBarang;
        private System.Windows.Forms.TextBox txtJumlahBarang;
        private System.Windows.Forms.Label labelCariBarang;
        private System.Windows.Forms.Button btnCariBarang;
        private System.Windows.Forms.TextBox textBox1;
    }
}