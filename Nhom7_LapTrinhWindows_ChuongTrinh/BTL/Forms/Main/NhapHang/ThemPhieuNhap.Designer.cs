
namespace BTL.Forms.Main.NhapHang
{
    partial class ThemPhieuNhap
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.masanpham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tensanpham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sldat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slnhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gianhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.MaSP = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaPhieuDat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnsuasln = new System.Windows.Forms.Button();
            this.cbthanhtoan = new System.Windows.Forms.ComboBox();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.dgvDatHang = new System.Windows.Forms.DataGridView();
            this.maDatHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new FontAwesome.Sharp.IconButton();
            this.btnHuy = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatHang)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.masanpham,
            this.tensanpham,
            this.sldat,
            this.slnhap,
            this.gianhap});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(513, 384);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(681, 325);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // masanpham
            // 
            this.masanpham.HeaderText = "Mã sản phẩm";
            this.masanpham.MinimumWidth = 6;
            this.masanpham.Name = "masanpham";
            this.masanpham.ReadOnly = true;
            this.masanpham.Width = 125;
            // 
            // tensanpham
            // 
            this.tensanpham.HeaderText = "Tên sản phẩm";
            this.tensanpham.MinimumWidth = 6;
            this.tensanpham.Name = "tensanpham";
            this.tensanpham.ReadOnly = true;
            this.tensanpham.Width = 125;
            // 
            // sldat
            // 
            this.sldat.HeaderText = "Số lượng đặt";
            this.sldat.MinimumWidth = 6;
            this.sldat.Name = "sldat";
            this.sldat.ReadOnly = true;
            this.sldat.Width = 125;
            // 
            // slnhap
            // 
            this.slnhap.HeaderText = "Số lượng nhập";
            this.slnhap.MinimumWidth = 6;
            this.slnhap.Name = "slnhap";
            this.slnhap.Width = 125;
            // 
            // gianhap
            // 
            this.gianhap.HeaderText = "Giá nhập";
            this.gianhap.MinimumWidth = 6;
            this.gianhap.Name = "gianhap";
            this.gianhap.ReadOnly = true;
            this.gianhap.Width = 125;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số lượng nhập";
            // 
            // MaSP
            // 
            this.MaSP.AutoSize = true;
            this.MaSP.Location = new System.Drawing.Point(24, 147);
            this.MaSP.Name = "MaSP";
            this.MaSP.Size = new System.Drawing.Size(99, 20);
            this.MaSP.TabIndex = 2;
            this.MaSP.Text = "Mã Sản Phẩm";
            this.MaSP.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thanh toán";
            // 
            // txtMaPhieuDat
            // 
            this.txtMaPhieuDat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaPhieuDat.BackColor = System.Drawing.Color.White;
            this.txtMaPhieuDat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaPhieuDat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMaPhieuDat.Location = new System.Drawing.Point(155, 56);
            this.txtMaPhieuDat.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtMaPhieuDat.Name = "txtMaPhieuDat";
            this.txtMaPhieuDat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMaPhieuDat.Size = new System.Drawing.Size(137, 26);
            this.txtMaPhieuDat.TabIndex = 8;
            this.txtMaPhieuDat.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã phiếu đặt";
            // 
            // txtSL
            // 
            this.txtSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSL.BackColor = System.Drawing.Color.White;
            this.txtSL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSL.Location = new System.Drawing.Point(155, 189);
            this.txtSL.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtSL.Name = "txtSL";
            this.txtSL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSL.Size = new System.Drawing.Size(137, 26);
            this.txtSL.TabIndex = 14;
            this.txtSL.TextChanged += new System.EventHandler(this.txtSL_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnsuasln);
            this.groupBox1.Controls.Add(this.cbthanhtoan);
            this.groupBox1.Controls.Add(this.txtMaSP);
            this.groupBox1.Controls.Add(this.txtSL);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMaPhieuDat);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.MaSP);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(11, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 340);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // btnsuasln
            // 
            this.btnsuasln.Location = new System.Drawing.Point(155, 265);
            this.btnsuasln.Name = "btnsuasln";
            this.btnsuasln.Size = new System.Drawing.Size(100, 51);
            this.btnsuasln.TabIndex = 26;
            this.btnsuasln.Text = "Nhập SLN";
            this.btnsuasln.UseVisualStyleBackColor = true;
            this.btnsuasln.Click += new System.EventHandler(this.btnsuasln_Click);
            // 
            // cbthanhtoan
            // 
            this.cbthanhtoan.FormattingEnabled = true;
            this.cbthanhtoan.Items.AddRange(new object[] {
            "Đã Thanh Toán",
            "Chưa Thanh Toán"});
            this.cbthanhtoan.Location = new System.Drawing.Point(155, 105);
            this.cbthanhtoan.Name = "cbthanhtoan";
            this.cbthanhtoan.Size = new System.Drawing.Size(137, 28);
            this.cbthanhtoan.TabIndex = 18;
            // 
            // txtMaSP
            // 
            this.txtMaSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaSP.BackColor = System.Drawing.Color.White;
            this.txtMaSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMaSP.Location = new System.Drawing.Point(155, 145);
            this.txtMaSP.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMaSP.Size = new System.Drawing.Size(137, 26);
            this.txtMaSP.TabIndex = 17;
            // 
            // dgvDatHang
            // 
            this.dgvDatHang.AllowUserToAddRows = false;
            this.dgvDatHang.AllowUserToDeleteRows = false;
            this.dgvDatHang.AllowUserToOrderColumns = true;
            this.dgvDatHang.AllowUserToResizeRows = false;
            this.dgvDatHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDatHang.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDatHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvDatHang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDatHang.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvDatHang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightPink;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightPink;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maDatHang,
            this.ngayDat,
            this.tenNhanVien,
            this.tenNCC});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 7, 5, 7);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(226)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatHang.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDatHang.EnableHeadersVisualStyles = false;
            this.dgvDatHang.GridColor = System.Drawing.Color.DimGray;
            this.dgvDatHang.Location = new System.Drawing.Point(513, 28);
            this.dgvDatHang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvDatHang.Name = "dgvDatHang";
            this.dgvDatHang.ReadOnly = true;
            this.dgvDatHang.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatHang.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDatHang.RowHeadersVisible = false;
            this.dgvDatHang.RowHeadersWidth = 51;
            this.dgvDatHang.RowTemplate.Height = 30;
            this.dgvDatHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatHang.Size = new System.Drawing.Size(681, 327);
            this.dgvDatHang.TabIndex = 25;
            this.dgvDatHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatHang_CellClick);
            this.dgvDatHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatHang_CellContentClick);
            // 
            // maDatHang
            // 
            this.maDatHang.HeaderText = "Mã phiếu đặt hàng";
            this.maDatHang.MinimumWidth = 6;
            this.maDatHang.Name = "maDatHang";
            this.maDatHang.ReadOnly = true;
            // 
            // ngayDat
            // 
            this.ngayDat.HeaderText = "Ngày lập";
            this.ngayDat.MinimumWidth = 6;
            this.ngayDat.Name = "ngayDat";
            this.ngayDat.ReadOnly = true;
            // 
            // tenNhanVien
            // 
            this.tenNhanVien.HeaderText = "Tên nhân viên";
            this.tenNhanVien.MinimumWidth = 6;
            this.tenNhanVien.Name = "tenNhanVien";
            this.tenNhanVien.ReadOnly = true;
            // 
            // tenNCC
            // 
            this.tenNCC.HeaderText = "Nhà cung cấp";
            this.tenNCC.MinimumWidth = 6;
            this.tenNCC.Name = "tenNCC";
            this.tenNCC.ReadOnly = true;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnThem.IconColor = System.Drawing.Color.Black;
            this.btnThem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThem.Location = new System.Drawing.Point(103, 516);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(113, 53);
            this.btnThem.TabIndex = 26;
            this.btnThem.Text = "Tạo Phiếu";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnHuy.IconColor = System.Drawing.Color.Black;
            this.btnHuy.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHuy.Location = new System.Drawing.Point(308, 516);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(113, 53);
            this.btnHuy.TabIndex = 27;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click_1);
            // 
            // ThemPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 731);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvDatHang);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ThemPhieuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThemPhieuNhap";
            this.Load += new System.EventHandler(this.ThemPhieuNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label MaSP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaPhieuDat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.DataGridView dgvDatHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn maDatHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenNCC;
        private System.Windows.Forms.ComboBox cbthanhtoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn masanpham;
        private System.Windows.Forms.DataGridViewTextBoxColumn tensanpham;
        private System.Windows.Forms.DataGridViewTextBoxColumn sldat;
        private System.Windows.Forms.DataGridViewTextBoxColumn slnhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn gianhap;
        private System.Windows.Forms.Button btnsuasln;
        private FontAwesome.Sharp.IconButton btnThem;
        private FontAwesome.Sharp.IconButton btnHuy;
    }
}