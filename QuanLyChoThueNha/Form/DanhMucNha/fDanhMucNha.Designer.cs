namespace QuanLyChoThueNha
{
    partial class fDanhMucNha
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menustripNha = new System.Windows.Forms.ToolStripMenuItem();
            this.menustripThemNha = new System.Windows.Forms.ToolStripMenuItem();
            this.pnContentDMN = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.pnContentDMN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menustripNha,
            this.menustripThemNha});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1400, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menustripNha
            // 
            this.menustripNha.Name = "menustripNha";
            this.menustripNha.Size = new System.Drawing.Size(114, 24);
            this.menustripNha.Text = "Thông tin nhà";
            this.menustripNha.Click += new System.EventHandler(this.menustripNha_Click);
            // 
            // menustripThemNha
            // 
            this.menustripThemNha.Name = "menustripThemNha";
            this.menustripThemNha.Size = new System.Drawing.Size(152, 24);
            this.menustripThemNha.Text = "Thêm thông tin nhà";
            this.menustripThemNha.Click += new System.EventHandler(this.menustripThemNha_Click);
            // 
            // pnContentDMN
            // 
            this.pnContentDMN.Controls.Add(this.pictureBox1);
            this.pnContentDMN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContentDMN.Location = new System.Drawing.Point(0, 28);
            this.pnContentDMN.Margin = new System.Windows.Forms.Padding(4);
            this.pnContentDMN.Name = "pnContentDMN";
            this.pnContentDMN.Size = new System.Drawing.Size(1400, 933);
            this.pnContentDMN.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::QuanLyChoThueNha.Properties.Resources.house1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1400, 933);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // fDanhMucNha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(1400, 961);
            this.Controls.Add(this.pnContentDMN);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "fDanhMucNha";
            this.Text = "fDanhMucNha";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnContentDMN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menustripNha;
        private System.Windows.Forms.ToolStripMenuItem menustripThemNha;
        private System.Windows.Forms.Panel pnContentDMN;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}