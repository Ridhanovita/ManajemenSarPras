namespace ManajemenSarPras
{
    partial class karyawan
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.labelIdKaryawan = new System.Windows.Forms.Label();
            this.btnTambahKaryawan = new System.Windows.Forms.Button();
            this.btnUpdateKaryawan = new System.Windows.Forms.Button();
            this.btnDeleteKaryawan = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTambah = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKembali
            // 
            this.btnKembali.Location = new System.Drawing.Point(12, 13);
            this.btnKembali.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(124, 56);
            this.btnKembali.TabIndex = 0;
            this.btnKembali.Text = "Kembali";
            this.btnKembali.UseVisualStyleBackColor = true;
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Stencil", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(313, 58);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(455, 38);
            this.labelTitle.TabIndex = 20;
            this.labelTitle.Text = "PENGELOLAHAN KARYAWAN";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(187, 259);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(234, 43);
            this.richTextBox3.TabIndex = 24;
            this.richTextBox3.Text = "";
            // 
            // labelIdKaryawan
            // 
            this.labelIdKaryawan.AutoSize = true;
            this.labelIdKaryawan.Location = new System.Drawing.Point(60, 262);
            this.labelIdKaryawan.Name = "labelIdKaryawan";
            this.labelIdKaryawan.Size = new System.Drawing.Size(101, 40);
            this.labelIdKaryawan.TabIndex = 23;
            this.labelIdKaryawan.Text = "NAMA\r\nKARYAWAN";
            // 
            // btnTambahKaryawan
            // 
            this.btnTambahKaryawan.Location = new System.Drawing.Point(64, 343);
            this.btnTambahKaryawan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTambahKaryawan.Name = "btnTambahKaryawan";
            this.btnTambahKaryawan.Size = new System.Drawing.Size(174, 56);
            this.btnTambahKaryawan.TabIndex = 25;
            this.btnTambahKaryawan.Text = "TAMBAH";
            this.btnTambahKaryawan.UseVisualStyleBackColor = true;
            // 
            // btnUpdateKaryawan
            // 
            this.btnUpdateKaryawan.Location = new System.Drawing.Point(262, 343);
            this.btnUpdateKaryawan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdateKaryawan.Name = "btnUpdateKaryawan";
            this.btnUpdateKaryawan.Size = new System.Drawing.Size(159, 56);
            this.btnUpdateKaryawan.TabIndex = 26;
            this.btnUpdateKaryawan.Text = "UPDATE";
            this.btnUpdateKaryawan.UseVisualStyleBackColor = true;
            // 
            // btnDeleteKaryawan
            // 
            this.btnDeleteKaryawan.Location = new System.Drawing.Point(64, 414);
            this.btnDeleteKaryawan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteKaryawan.Name = "btnDeleteKaryawan";
            this.btnDeleteKaryawan.Size = new System.Drawing.Size(357, 56);
            this.btnDeleteKaryawan.TabIndex = 27;
            this.btnDeleteKaryawan.Text = "HAPUS";
            this.btnDeleteKaryawan.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(453, 210);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(624, 332);
            this.dataGridView1.TabIndex = 28;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(568, 139);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(509, 56);
            this.richTextBox1.TabIndex = 31;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.txtCari_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(449, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 44);
            this.label1.TabIndex = 30;
            this.label1.Text = "CARI \r\nKARYAWAN";
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnTambah.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambah.Location = new System.Drawing.Point(64, 343);
            this.btnTambah.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(174, 56);
            this.btnTambah.TabIndex = 25;
            this.btnTambah.Text = "TAMBAH";
            this.btnTambah.UseVisualStyleBackColor = false;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(262, 343);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 56);
            this.button2.TabIndex = 26;
            this.button2.Text = "UPDATE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(64, 414);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(357, 56);
            this.button3.TabIndex = 27;
            this.button3.Text = "HAPUS";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // karyawan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 563);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnDeleteKaryawan);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.btnUpdateKaryawan);
            this.Controls.Add(this.btnTambahKaryawan);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.labelIdKaryawan);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.btnKembali);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "karyawan";
            this.Text = "CekRutin";
            this.Load += new System.EventHandler(this.karyawan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKembali;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Label labelIdKaryawan;
        private System.Windows.Forms.Button btnTambahKaryawan;
        private System.Windows.Forms.Button btnUpdateKaryawan;
        private System.Windows.Forms.Button btnDeleteKaryawan;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}