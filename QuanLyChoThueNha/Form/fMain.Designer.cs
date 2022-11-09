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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnTraNha = new System.Windows.Forms.Button();
            this.btnKhachThueNha = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbAboutUs = new System.Windows.Forms.Label();
            this.btnDMN = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnContent = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbTimer = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            this.panel1.Controls.Add(this.btnThongKe);
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.btnTraNha);
            this.panel1.Controls.Add(this.btnKhachThueNha);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnDMN);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 805);
            this.panel1.TabIndex = 0;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongKe.Location = new System.Drawing.Point(0, 385);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(200, 51);
            this.btnThongKe.TabIndex = 5;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTimKiem.Location = new System.Drawing.Point(0, 335);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(200, 50);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnTraNha
            // 
            this.btnTraNha.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTraNha.Location = new System.Drawing.Point(0, 285);
            this.btnTraNha.Name = "btnTraNha";
            this.btnTraNha.Size = new System.Drawing.Size(200, 50);
            this.btnTraNha.TabIndex = 3;
            this.btnTraNha.Text = "Trả nhà";
            this.btnTraNha.UseVisualStyleBackColor = true;
            this.btnTraNha.Click += new System.EventHandler(this.btnTraNha_Click);
            // 
            // btnKhachThueNha
            // 
            this.btnKhachThueNha.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKhachThueNha.Location = new System.Drawing.Point(0, 232);
            this.btnKhachThueNha.Name = "btnKhachThueNha";
            this.btnKhachThueNha.Size = new System.Drawing.Size(200, 53);
            this.btnKhachThueNha.TabIndex = 2;
            this.btnKhachThueNha.Text = "Thông tin khách";
            this.btnKhachThueNha.UseVisualStyleBackColor = true;
            this.btnKhachThueNha.Click += new System.EventHandler(this.btnKhachThueNha_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbAboutUs);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 753);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 52);
            this.panel2.TabIndex = 4;
            // 
            // lbAboutUs
            // 
            this.lbAboutUs.AutoSize = true;
            this.lbAboutUs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAboutUs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAboutUs.Location = new System.Drawing.Point(0, 0);
            this.lbAboutUs.Name = "lbAboutUs";
            this.lbAboutUs.Size = new System.Drawing.Size(223, 50);
            this.lbAboutUs.TabIndex = 0;
            this.lbAboutUs.Text = "     Quản lý cho thuê nhà\r\n     1.0.0";
            this.lbAboutUs.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbAboutUs.Click += new System.EventHandler(this.lbAboutUs_Click);
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
            this.pnContent.AutoSize = true;
            this.pnContent.BackColor = System.Drawing.Color.MediumAquamarine;
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
            this.panel3.BackColor = System.Drawing.Color.Turquoise;
            this.panel3.Controls.Add(this.lbTimer);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 776);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1056, 29);
            this.panel3.TabIndex = 1;
            // 
            // lbTimer
            // 
            this.lbTimer.AutoSize = true;
            this.lbTimer.ForeColor = System.Drawing.Color.Indigo;
            this.lbTimer.Location = new System.Drawing.Point(3, 4);
            this.lbTimer.Name = "lbTimer";
            this.lbTimer.Size = new System.Drawing.Size(74, 20);
            this.lbTimer.TabIndex = 0;
            this.lbTimer.Text = "Xin chào";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(393, 259);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(240, 209);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 35;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Quản lý cho thuê nhà";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnContent.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDMN;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnContent;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbAboutUs;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbTimer;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnTraNha;
        private System.Windows.Forms.Button btnKhachThueNha;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Timer timer1;
    }
}