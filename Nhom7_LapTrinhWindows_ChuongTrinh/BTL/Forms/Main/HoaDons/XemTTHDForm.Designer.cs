
namespace BTL.Forms.Main.HoaDons
{
    partial class XemTTHDForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xuatHDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xuatExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelPrint = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.labSdtCh = new System.Windows.Forms.Label();
            this.labDiachich = new System.Windows.Forms.Label();
            this.labTench = new System.Windows.Forms.Label();
            this.dataViewSP = new System.Windows.Forms.DataGridView();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Soluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labNgayThang = new System.Windows.Forms.Label();
            this.labNV = new System.Windows.Forms.Label();
            this.labTD = new System.Windows.Forms.Label();
            this.labSDT = new System.Windows.Forms.Label();
            this.labKH = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labTongTien = new System.Windows.Forms.Label();
            this.labChietKhau = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labMaHD = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panelPrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewSP)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(755, 28);
            this.menuStrip1.TabIndex = 34;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xuatHDToolStripMenuItem,
            this.xuatExcelToolStripMenuItem,
            this.thoatToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // xuatHDToolStripMenuItem
            // 
            this.xuatHDToolStripMenuItem.Name = "xuatHDToolStripMenuItem";
            this.xuatHDToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.xuatHDToolStripMenuItem.Text = "Xuất PDF";
            this.xuatHDToolStripMenuItem.Click += new System.EventHandler(this.xuatHDToolStripMenuItem_Click);
            // 
            // xuatExcelToolStripMenuItem
            // 
            this.xuatExcelToolStripMenuItem.Name = "xuatExcelToolStripMenuItem";
            this.xuatExcelToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.xuatExcelToolStripMenuItem.Text = "Xuất hóa đơn (Excel)";
            this.xuatExcelToolStripMenuItem.Click += new System.EventHandler(this.xuatExcelToolStripMenuItem_Click);
            // 
            // thoatToolStripMenuItem
            // 
            this.thoatToolStripMenuItem.Name = "thoatToolStripMenuItem";
            this.thoatToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.thoatToolStripMenuItem.Text = "Thoát";
            this.thoatToolStripMenuItem.Click += new System.EventHandler(this.thoatToolStripMenuItem_Click);
            // 
            // panelPrint
            // 
            this.panelPrint.Controls.Add(this.label8);
            this.panelPrint.Controls.Add(this.labSdtCh);
            this.panelPrint.Controls.Add(this.labDiachich);
            this.panelPrint.Controls.Add(this.labTench);
            this.panelPrint.Controls.Add(this.dataViewSP);
            this.panelPrint.Controls.Add(this.label6);
            this.panelPrint.Controls.Add(this.label5);
            this.panelPrint.Controls.Add(this.label4);
            this.panelPrint.Controls.Add(this.label3);
            this.panelPrint.Controls.Add(this.label2);
            this.panelPrint.Controls.Add(this.label1);
            this.panelPrint.Controls.Add(this.labNgayThang);
            this.panelPrint.Controls.Add(this.labNV);
            this.panelPrint.Controls.Add(this.labTD);
            this.panelPrint.Controls.Add(this.labSDT);
            this.panelPrint.Controls.Add(this.labKH);
            this.panelPrint.Controls.Add(this.label7);
            this.panelPrint.Controls.Add(this.panel2);
            this.panelPrint.Controls.Add(this.labTongTien);
            this.panelPrint.Controls.Add(this.labChietKhau);
            this.panelPrint.Controls.Add(this.label11);
            this.panelPrint.Controls.Add(this.label10);
            this.panelPrint.Controls.Add(this.labMaHD);
            this.panelPrint.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPrint.Location = new System.Drawing.Point(0, 28);
            this.panelPrint.Name = "panelPrint";
            this.panelPrint.Size = new System.Drawing.Size(755, 840);
            this.panelPrint.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(104, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 25);
            this.label8.TabIndex = 56;
            this.label8.Text = "-";
            // 
            // labSdtCh
            // 
            this.labSdtCh.AutoSize = true;
            this.labSdtCh.Location = new System.Drawing.Point(119, 18);
            this.labSdtCh.Name = "labSdtCh";
            this.labSdtCh.Size = new System.Drawing.Size(82, 25);
            this.labSdtCh.TabIndex = 55;
            this.labSdtCh.Text = "0999999";
            // 
            // labDiachich
            // 
            this.labDiachich.AutoSize = true;
            this.labDiachich.Location = new System.Drawing.Point(12, 42);
            this.labDiachich.Name = "labDiachich";
            this.labDiachich.Size = new System.Drawing.Size(60, 25);
            this.labDiachich.TabIndex = 54;
            this.labDiachich.Text = "Diachi";
            // 
            // labTench
            // 
            this.labTench.AutoSize = true;
            this.labTench.Location = new System.Drawing.Point(12, 17);
            this.labTench.Name = "labTench";
            this.labTench.Size = new System.Drawing.Size(93, 25);
            this.labTench.TabIndex = 53;
            this.labTench.Text = "Cocoshop";
            // 
            // dataViewSP
            // 
            this.dataViewSP.AllowUserToAddRows = false;
            this.dataViewSP.AllowUserToDeleteRows = false;
            this.dataViewSP.AllowUserToOrderColumns = true;
            this.dataViewSP.AllowUserToResizeRows = false;
            this.dataViewSP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataViewSP.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataViewSP.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataViewSP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataViewSP.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 7, 5, 7);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataViewSP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataViewSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataViewSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSP,
            this.TenSP,
            this.Soluong,
            this.DonGia,
            this.ThanhTien});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataViewSP.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataViewSP.GridColor = System.Drawing.Color.DimGray;
            this.dataViewSP.Location = new System.Drawing.Point(12, 374);
            this.dataViewSP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataViewSP.Name = "dataViewSP";
            this.dataViewSP.ReadOnly = true;
            this.dataViewSP.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataViewSP.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataViewSP.RowHeadersVisible = false;
            this.dataViewSP.RowHeadersWidth = 51;
            this.dataViewSP.RowTemplate.Height = 30;
            this.dataViewSP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataViewSP.Size = new System.Drawing.Size(731, 287);
            this.dataViewSP.TabIndex = 41;
            // 
            // MaSP
            // 
            this.MaSP.HeaderText = "Mã sản phẩm";
            this.MaSP.MinimumWidth = 6;
            this.MaSP.Name = "MaSP";
            this.MaSP.ReadOnly = true;
            // 
            // TenSP
            // 
            this.TenSP.HeaderText = "Tên sản phẩm";
            this.TenSP.MinimumWidth = 6;
            this.TenSP.Name = "TenSP";
            this.TenSP.ReadOnly = true;
            // 
            // Soluong
            // 
            this.Soluong.HeaderText = "Số lượng";
            this.Soluong.MinimumWidth = 6;
            this.Soluong.Name = "Soluong";
            this.Soluong.ReadOnly = true;
            // 
            // DonGia
            // 
            this.DonGia.HeaderText = "Đơn Giá";
            this.DonGia.MinimumWidth = 6;
            this.DonGia.Name = "DonGia";
            this.DonGia.ReadOnly = true;
            // 
            // ThanhTien
            // 
            this.ThanhTien.HeaderText = "Thành Tiền";
            this.ThanhTien.MinimumWidth = 6;
            this.ThanhTien.Name = "ThanhTien";
            this.ThanhTien.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(384, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 25);
            this.label6.TabIndex = 40;
            this.label6.Text = "Ngày xuất HD:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(83, 320);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 25);
            this.label5.TabIndex = 39;
            this.label5.Text = "Tích điểm:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(384, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 25);
            this.label4.TabIndex = 38;
            this.label4.Text = "Thu ngân:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 25);
            this.label3.TabIndex = 37;
            this.label3.Text = "Số điện thoại:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 25);
            this.label2.TabIndex = 36;
            this.label2.Text = "Khách hàng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(214, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 41);
            this.label1.TabIndex = 34;
            this.label1.Text = "Hóa Đơn Bán Hàng";
            // 
            // labNgayThang
            // 
            this.labNgayThang.AutoSize = true;
            this.labNgayThang.Location = new System.Drawing.Point(517, 245);
            this.labNgayThang.Name = "labNgayThang";
            this.labNgayThang.Size = new System.Drawing.Size(86, 25);
            this.labNgayThang.TabIndex = 52;
            this.labNgayThang.Text = "7/6/2021";
            // 
            // labNV
            // 
            this.labNV.AutoSize = true;
            this.labNV.Location = new System.Drawing.Point(483, 172);
            this.labNV.Name = "labNV";
            this.labNV.Size = new System.Drawing.Size(40, 25);
            this.labNV.TabIndex = 51;
            this.labNV.Text = "abc";
            // 
            // labTD
            // 
            this.labTD.AutoSize = true;
            this.labTD.Location = new System.Drawing.Point(181, 320);
            this.labTD.Name = "labTD";
            this.labTD.Size = new System.Drawing.Size(22, 25);
            this.labTD.TabIndex = 50;
            this.labTD.Text = "0";
            // 
            // labSDT
            // 
            this.labSDT.AutoSize = true;
            this.labSDT.Location = new System.Drawing.Point(210, 247);
            this.labSDT.Name = "labSDT";
            this.labSDT.Size = new System.Drawing.Size(92, 25);
            this.labSDT.TabIndex = 49;
            this.labSDT.Text = "01111111";
            // 
            // labKH
            // 
            this.labKH.AutoSize = true;
            this.labKH.Location = new System.Drawing.Point(190, 174);
            this.labKH.Name = "labKH";
            this.labKH.Size = new System.Drawing.Size(40, 25);
            this.labKH.TabIndex = 48;
            this.labKH.Text = "abc";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(187, 782);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(369, 28);
            this.label7.TabIndex = 47;
            this.label7.Text = " Cảm ơn Quý Khách. Hẹn gặp lại lần sau";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel2.Location = new System.Drawing.Point(207, 763);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(346, 3);
            this.panel2.TabIndex = 46;
            // 
            // labTongTien
            // 
            this.labTongTien.AutoSize = true;
            this.labTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labTongTien.Location = new System.Drawing.Point(573, 661);
            this.labTongTien.Name = "labTongTien";
            this.labTongTien.Size = new System.Drawing.Size(24, 28);
            this.labTongTien.TabIndex = 45;
            this.labTongTien.Text = "0";
            // 
            // labChietKhau
            // 
            this.labChietKhau.AutoSize = true;
            this.labChietKhau.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labChietKhau.Location = new System.Drawing.Point(573, 713);
            this.labChietKhau.Name = "labChietKhau";
            this.labChietKhau.Size = new System.Drawing.Size(24, 28);
            this.labChietKhau.TabIndex = 44;
            this.labChietKhau.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(437, 661);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 28);
            this.label11.TabIndex = 43;
            this.label11.Text = "Tổng tiền:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(437, 713);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 28);
            this.label10.TabIndex = 42;
            this.label10.Text = "Chiết khấu:";
            // 
            // labMaHD
            // 
            this.labMaHD.AutoSize = true;
            this.labMaHD.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labMaHD.Location = new System.Drawing.Point(309, 101);
            this.labMaHD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labMaHD.Name = "labMaHD";
            this.labMaHD.Size = new System.Drawing.Size(53, 25);
            this.labMaHD.TabIndex = 35;
            this.labMaHD.Text = "[HD]";
            // 
            // XemTTHDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 856);
            this.Controls.Add(this.panelPrint);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XemTTHDForm";
            this.Text = "XemTTHDForm";
            this.Load += new System.EventHandler(this.XemTTHDForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelPrint.ResumeLayout(false);
            this.panelPrint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHd;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xuatHDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xuatExcelToolStripMenuItem;
        private System.Windows.Forms.Panel panelPrint;
        private System.Windows.Forms.DataGridView dataViewSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Soluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labNgayThang;
        private System.Windows.Forms.Label labNV;
        private System.Windows.Forms.Label labTD;
        private System.Windows.Forms.Label labSDT;
        private System.Windows.Forms.Label labKH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labTongTien;
        private System.Windows.Forms.Label labChietKhau;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labMaHD;
        private System.Windows.Forms.Label labSdtCh;
        private System.Windows.Forms.Label labDiachich;
        private System.Windows.Forms.Label labTench;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem thoatToolStripMenuItem;
    }
}