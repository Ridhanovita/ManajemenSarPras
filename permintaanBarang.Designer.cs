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
            this.label1.Location = new System.Drawing.Point(431, 56);
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
            // permintaanBarang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 563);
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
    }
}