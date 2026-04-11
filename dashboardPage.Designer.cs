namespace ManajemenSarPras
{
    partial class dashboardPage
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
            this.kelolaBarang = new System.Windows.Forms.Button();
            this.permintaanBarang = new System.Windows.Forms.Button();
            this.pengecekanRutin = new System.Windows.Forms.Button();
            this.maintennce = new System.Windows.Forms.Button();
            this.report = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // kelolaBarang
            // 
            this.kelolaBarang.Location = new System.Drawing.Point(57, 102);
            this.kelolaBarang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kelolaBarang.Name = "kelolaBarang";
            this.kelolaBarang.Size = new System.Drawing.Size(180, 50);
            this.kelolaBarang.TabIndex = 0;
            this.kelolaBarang.Text = "Kelola Barang";
            this.kelolaBarang.UseVisualStyleBackColor = true;
            this.kelolaBarang.Click += new System.EventHandler(this.kelolaBarang_Click);
            // 
            // permintaanBarang
            // 
            this.permintaanBarang.Location = new System.Drawing.Point(292, 102);
            this.permintaanBarang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.permintaanBarang.Name = "permintaanBarang";
            this.permintaanBarang.Size = new System.Drawing.Size(180, 50);
            this.permintaanBarang.TabIndex = 1;
            this.permintaanBarang.Text = "Permintaan Barang";
            this.permintaanBarang.UseVisualStyleBackColor = true;
            this.permintaanBarang.Click += new System.EventHandler(this.permintaanBarang_Click);
            // 
            // pengecekanRutin
            // 
            this.pengecekanRutin.Location = new System.Drawing.Point(529, 102);
            this.pengecekanRutin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pengecekanRutin.Name = "pengecekanRutin";
            this.pengecekanRutin.Size = new System.Drawing.Size(180, 50);
            this.pengecekanRutin.TabIndex = 2;
            this.pengecekanRutin.Text = "Cek Rutin";
            this.pengecekanRutin.UseVisualStyleBackColor = true;
            this.pengecekanRutin.Click += new System.EventHandler(this.pengecekanRutin_Click);
            // 
            // maintennce
            // 
            this.maintennce.Location = new System.Drawing.Point(158, 242);
            this.maintennce.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maintennce.Name = "maintennce";
            this.maintennce.Size = new System.Drawing.Size(180, 50);
            this.maintennce.TabIndex = 3;
            this.maintennce.Text = "Maintenance";
            this.maintennce.UseVisualStyleBackColor = true;
            this.maintennce.Click += new System.EventHandler(this.maintennce_Click);
            // 
            // report
            // 
            this.report.Location = new System.Drawing.Point(412, 242);
            this.report.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(180, 50);
            this.report.TabIndex = 4;
            this.report.Text = "Report";
            this.report.UseVisualStyleBackColor = true;
            this.report.Click += new System.EventHandler(this.report_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(215, 38);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(344, 26);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "selamat datang admin, semangat input datanya";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dashboardPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.report);
            this.Controls.Add(this.maintennce);
            this.Controls.Add(this.pengecekanRutin);
            this.Controls.Add(this.permintaanBarang);
            this.Controls.Add(this.kelolaBarang);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "dashboardPage";
            this.Text = "dashboardPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kelolaBarang;
        private System.Windows.Forms.Button permintaanBarang;
        private System.Windows.Forms.Button pengecekanRutin;
        private System.Windows.Forms.Button maintennce;
        private System.Windows.Forms.Button report;
        private System.Windows.Forms.TextBox textBox1;
    }
}

