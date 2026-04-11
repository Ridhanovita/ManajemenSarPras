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
            this.labelKaryawan = new System.Windows.Forms.Button();
            this.maintennce = new System.Windows.Forms.Button();
            this.report = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // kelolaBarang
            // 
            this.kelolaBarang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kelolaBarang.Location = new System.Drawing.Point(115, 179);
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
            this.permintaanBarang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.permintaanBarang.Location = new System.Drawing.Point(115, 303);
            this.permintaanBarang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.permintaanBarang.Name = "permintaanBarang";
            this.permintaanBarang.Size = new System.Drawing.Size(180, 50);
            this.permintaanBarang.TabIndex = 1;
            this.permintaanBarang.Text = "Permintaan Barang";
            this.permintaanBarang.UseVisualStyleBackColor = true;
            this.permintaanBarang.Click += new System.EventHandler(this.permintaanBarang_Click);
            // 
            // labelKaryawan
            // 
            this.labelKaryawan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKaryawan.Location = new System.Drawing.Point(325, 179);
            this.labelKaryawan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelKaryawan.Name = "labelKaryawan";
            this.labelKaryawan.Size = new System.Drawing.Size(180, 50);
            this.labelKaryawan.TabIndex = 2;
            this.labelKaryawan.Text = "Karyawan";
            this.labelKaryawan.UseVisualStyleBackColor = true;
            this.labelKaryawan.Click += new System.EventHandler(this.pengecekanRutin_Click);
            // 
            // maintennce
            // 
            this.maintennce.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maintennce.Location = new System.Drawing.Point(115, 242);
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
            this.report.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.report.Location = new System.Drawing.Point(325, 242);
            this.report.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(180, 50);
            this.report.TabIndex = 4;
            this.report.Text = "Report";
            this.report.UseVisualStyleBackColor = true;
            this.report.Click += new System.EventHandler(this.report_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(609, 57);
            this.label1.TabIndex = 5;
            this.label1.Text = "SELAMAT DATANG ADMIN";
            // 
            // dashboardPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 441);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.report);
            this.Controls.Add(this.maintennce);
            this.Controls.Add(this.labelKaryawan);
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
        private System.Windows.Forms.Button labelKaryawan;
        private System.Windows.Forms.Button maintennce;
        private System.Windows.Forms.Button report;
        private System.Windows.Forms.Label label1;
    }
}

