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
            this.kelolaBarang = new System.Windows.Forms.Button();
            this.permintaanBarang = new System.Windows.Forms.Button();
            this.pengecekanRutin = new System.Windows.Forms.Button();
            this.maintennce = new System.Windows.Forms.Button();
            this.report = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // kelolaBarang
            // 
            this.kelolaBarang.Location = new System.Drawing.Point(57, 102);
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
            this.permintaanBarang.Name = "permintaanBarang";
            this.permintaanBarang.Size = new System.Drawing.Size(180, 50);
            this.permintaanBarang.TabIndex = 1;
            this.permintaanBarang.Text = "Permintaan Barang";
            this.permintaanBarang.UseVisualStyleBackColor = true;
            // 
            // pengecekanRutin
            // 
            this.pengecekanRutin.Location = new System.Drawing.Point(529, 102);
            this.pengecekanRutin.Name = "pengecekanRutin";
            this.pengecekanRutin.Size = new System.Drawing.Size(180, 50);
            this.pengecekanRutin.TabIndex = 2;
            this.pengecekanRutin.Text = "Cek Rutin";
            this.pengecekanRutin.UseVisualStyleBackColor = true;
            // 
            // maintennce
            // 
            this.maintennce.Location = new System.Drawing.Point(157, 242);
            this.maintennce.Name = "maintennce";
            this.maintennce.Size = new System.Drawing.Size(180, 50);
            this.maintennce.TabIndex = 3;
            this.maintennce.Text = "Maintenance";
            this.maintennce.UseVisualStyleBackColor = true;
            // 
            // report
            // 
            this.report.Location = new System.Drawing.Point(412, 242);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(180, 50);
            this.report.TabIndex = 4;
            this.report.Text = "Report";
            this.report.UseVisualStyleBackColor = true;
            // 
            // maintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.report);
            this.Controls.Add(this.maintennce);
            this.Controls.Add(this.pengecekanRutin);
            this.Controls.Add(this.permintaanBarang);
            this.Controls.Add(this.kelolaBarang);
            this.Name = "maintenance";
            this.Text = "Maintenance";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button kelolaBarang;
        private System.Windows.Forms.Button permintaanBarang;
        private System.Windows.Forms.Button pengecekanRutin;
        private System.Windows.Forms.Button maintennce;
        private System.Windows.Forms.Button report;
    }
}

