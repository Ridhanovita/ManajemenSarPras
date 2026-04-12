namespace ManajemenSarPras
{
    partial class reportPage
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
            this.cmbSemester = new System.Windows.Forms.ComboBox();
            this.labelSemester = new System.Windows.Forms.Label();
            this.labelBulan = new System.Windows.Forms.Label();
            this.cmbBulan = new System.Windows.Forms.ComboBox();
            this.labelTipe = new System.Windows.Forms.Label();
            this.cmbTipe = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnKembali
            // 
            this.btnKembali.Location = new System.Drawing.Point(12, 13);
            this.btnKembali.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(110, 41);
            this.btnKembali.TabIndex = 0;
            this.btnKembali.Text = "Kembali";
            this.btnKembali.UseVisualStyleBackColor = true;
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click);
            // 
            // cmbSemester
            // 
            this.cmbSemester.FormattingEnabled = true;
            this.cmbSemester.Location = new System.Drawing.Point(164, 183);
            this.cmbSemester.Name = "cmbSemester";
            this.cmbSemester.Size = new System.Drawing.Size(264, 28);
            this.cmbSemester.TabIndex = 1;
            // 
            // labelSemester
            // 
            this.labelSemester.AutoSize = true;
            this.labelSemester.Location = new System.Drawing.Point(24, 186);
            this.labelSemester.Name = "labelSemester";
            this.labelSemester.Size = new System.Drawing.Size(98, 20);
            this.labelSemester.TabIndex = 3;
            this.labelSemester.Text = "SEMESTER";
            // 
            // labelBulan
            // 
            this.labelBulan.AutoSize = true;
            this.labelBulan.Location = new System.Drawing.Point(24, 235);
            this.labelBulan.Name = "labelBulan";
            this.labelBulan.Size = new System.Drawing.Size(63, 20);
            this.labelBulan.TabIndex = 5;
            this.labelBulan.Text = "BULAN";
            // 
            // cmbBulan
            // 
            this.cmbBulan.FormattingEnabled = true;
            this.cmbBulan.Location = new System.Drawing.Point(164, 232);
            this.cmbBulan.Name = "cmbBulan";
            this.cmbBulan.Size = new System.Drawing.Size(264, 28);
            this.cmbBulan.TabIndex = 4;
            this.cmbBulan.SelectedIndexChanged += new System.EventHandler(this.cmbTipe_SelectedIndexChanged);
            // 
            // labelTipe
            // 
            this.labelTipe.AutoSize = true;
            this.labelTipe.Location = new System.Drawing.Point(24, 136);
            this.labelTipe.Name = "labelTipe";
            this.labelTipe.Size = new System.Drawing.Size(44, 20);
            this.labelTipe.TabIndex = 7;
            this.labelTipe.Text = "TIPE";
            // 
            // cmbTipe
            // 
            this.cmbTipe.FormattingEnabled = true;
            this.cmbTipe.Location = new System.Drawing.Point(164, 133);
            this.cmbTipe.Name = "cmbTipe";
            this.cmbTipe.Size = new System.Drawing.Size(264, 28);
            this.cmbTipe.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(28, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(400, 47);
            this.button1.TabIndex = 8;
            this.button1.Text = "DOWNLOAD";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Stencil", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(157, 64);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(140, 32);
            this.labelTitle.TabIndex = 19;
            this.labelTitle.Text = "LAPORAN";
            // 
            // reportPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 563);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelTipe);
            this.Controls.Add(this.cmbTipe);
            this.Controls.Add(this.labelBulan);
            this.Controls.Add(this.cmbBulan);
            this.Controls.Add(this.labelSemester);
            this.Controls.Add(this.cmbSemester);
            this.Controls.Add(this.btnKembali);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "reportPage";
            this.Text = "ReportPage";
            this.Load += new System.EventHandler(this.FrmReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKembali;
        private System.Windows.Forms.ComboBox cmbSemester;
        private System.Windows.Forms.Label labelSemester;
        private System.Windows.Forms.Label labelBulan;
        private System.Windows.Forms.ComboBox cmbBulan;
        private System.Windows.Forms.Label labelTipe;
        private System.Windows.Forms.ComboBox cmbTipe;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelTitle;
    }
}