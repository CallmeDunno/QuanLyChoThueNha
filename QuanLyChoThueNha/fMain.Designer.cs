namespace QuanLyChoThueNha
{
    partial class fMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThue = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnDMN = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnContent = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnXuatFile = new System.Windows.Forms.Button();
            this.btnKhachThueNha = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnContent.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnKhachThueNha);
            this.panel1.Controls.Add(this.btnXuatFile);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnThue);
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.btnDMN);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 805);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 732);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 73);
            this.panel2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "1.0.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý cho thuê nhà";
            // 
            // btnThue
            // 
            this.btnThue.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThue.Location = new System.Drawing.Point(0, 283);
            this.btnThue.Name = "btnThue";
            this.btnThue.Size = new System.Drawing.Size(200, 53);
            this.btnThue.TabIndex = 3;
            this.btnThue.Text = "Thuê nhà";
            this.btnThue.UseVisualStyleBackColor = true;
            this.btnThue.Click += new System.EventHandler(this.btnThue_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTimKiem.Location = new System.Drawing.Point(0, 232);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(200, 51);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnDMN
            // 
            this.btnDMN.BackColor = System.Drawing.Color.Cyan;
            this.btnDMN.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDMN.Location = new System.Drawing.Point(0, 179);
            this.btnDMN.Name = "btnDMN";
            this.btnDMN.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDMN.Size = new System.Drawing.Size(200, 53);
            this.btnDMN.TabIndex = 1;
            this.btnDMN.Text = "Danh mục nhà";
            this.btnDMN.UseVisualStyleBackColor = false;
            this.btnDMN.Click += new System.EventHandler(this.btnDMN_Click);
            this.btnDMN.MouseLeave += new System.EventHandler(this.btnDMN_MouseLeave);
            this.btnDMN.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDMN_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::QuanLyChoThueNha.Properties.Resources.C_;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 179);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pnContent
            // 
            this.pnContent.Controls.Add(this.panel3);
            this.pnContent.Controls.Add(this.pictureBox2);
            this.pnContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContent.Location = new System.Drawing.Point(200, 0);
            this.pnContent.Name = "pnContent";
            this.pnContent.Size = new System.Drawing.Size(1056, 805);
            this.pnContent.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 776);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1056, 29);
            this.panel3.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(0, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Xin chào";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::QuanLyChoThueNha.Properties.Resources.C_;
            this.pictureBox2.Location = new System.Drawing.Point(393, 259);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(240, 209);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // btnXuatFile
            // 
            this.btnXuatFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnXuatFile.Location = new System.Drawing.Point(0, 336);
            this.btnXuatFile.Name = "btnXuatFile";
            this.btnXuatFile.Size = new System.Drawing.Size(200, 50);
            this.btnXuatFile.TabIndex = 5;
            this.btnXuatFile.Text = "Thống kê";
            this.btnXuatFile.UseVisualStyleBackColor = true;
            this.btnXuatFile.Click += new System.EventHandler(this.btnXuatFile_Click);
            // 
            // btnKhachThueNha
            // 
            this.btnKhachThueNha.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhachThueNha.Location = new System.Drawing.Point(0, 386);
            this.btnKhachThueNha.Name = "btnKhachThueNha";
            this.btnKhachThueNha.Size = new System.Drawing.Size(200, 56);
            this.btnKhachThueNha.TabIndex = 6;
            this.btnKhachThueNha.Text = "Khách thuê";
            this.btnKhachThueNha.UseVisualStyleBackColor = true;
            this.btnKhachThueNha.Click += new System.EventHandler(this.btnKhachThueNha_Click);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 805);
            this.Controls.Add(this.pnContent);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý cho thuê nhà";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnContent.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThue;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnDMN;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnContent;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXuatFile;
        private System.Windows.Forms.Button btnKhachThueNha;
    }
}