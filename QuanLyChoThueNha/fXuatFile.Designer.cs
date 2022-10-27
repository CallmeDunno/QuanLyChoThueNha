namespace QuanLyChoThueNha
{
    partial class fXuatFile
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpXuatExcel = new System.Windows.Forms.TabPage();
            this.tpXuatHopDong = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpXuatExcel);
            this.tabControl1.Controls.Add(this.tpXuatHopDong);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1222, 800);
            this.tabControl1.TabIndex = 0;
            // 
            // tpXuatExcel
            // 
            this.tpXuatExcel.Location = new System.Drawing.Point(4, 29);
            this.tpXuatExcel.Name = "tpXuatExcel";
            this.tpXuatExcel.Padding = new System.Windows.Forms.Padding(3);
            this.tpXuatExcel.Size = new System.Drawing.Size(1214, 767);
            this.tpXuatExcel.TabIndex = 0;
            this.tpXuatExcel.Text = "Excel";
            this.tpXuatExcel.UseVisualStyleBackColor = true;
            // 
            // tpXuatHopDong
            // 
            this.tpXuatHopDong.Location = new System.Drawing.Point(4, 29);
            this.tpXuatHopDong.Name = "tpXuatHopDong";
            this.tpXuatHopDong.Padding = new System.Windows.Forms.Padding(3);
            this.tpXuatHopDong.Size = new System.Drawing.Size(1214, 767);
            this.tpXuatHopDong.TabIndex = 1;
            this.tpXuatHopDong.Text = "Hợp đồng";
            this.tpXuatHopDong.UseVisualStyleBackColor = true;
            // 
            // fXuatFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 800);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fXuatFile";
            this.Text = "Xuất file";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpXuatExcel;
        private System.Windows.Forms.TabPage tpXuatHopDong;
    }
}