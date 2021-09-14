
namespace BTL.Forms.Main.DatHang
{
    partial class AddDatHangForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTimNCC = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            this.labelSDTNCC = new System.Windows.Forms.Label();
            this.labelDiaChiNCC = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxMaNCC = new System.Windows.Forms.ComboBox();
            this.txtTenNCC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTimCH = new FontAwesome.Sharp.IconButton();
            this.label9 = new System.Windows.Forms.Label();
            this.labelSDTCH = new System.Windows.Forms.Label();
            this.labelDiaChiCH = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxMaCH = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTenCH = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnXoaSP = new FontAwesome.Sharp.IconButton();
            this.btnThemSP = new FontAwesome.Sharp.IconButton();
            this.dgvSPDH = new System.Windows.Forms.DataGridView();
            this.maSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.donGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTongTien = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnTaoPDH = new FontAwesome.Sharp.IconButton();
            this.btnHuy = new FontAwesome.Sharp.IconButton();
            this.label11 = new System.Windows.Forms.Label();
            this.labelMaPDH = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelNgayLap = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.labelNguoiLap = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSPDH)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(386, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lập phiếu đặt hàng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTimNCC);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.labelSDTNCC);
            this.groupBox1.Controls.Add(this.labelDiaChiNCC);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxMaNCC);
            this.groupBox1.Controls.Add(this.txtTenNCC);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(27, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 269);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin nhà cung cấp";
            // 
            // btnTimNCC
            // 
            this.btnTimNCC.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTimNCC.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnTimNCC.IconColor = System.Drawing.Color.Black;
            this.btnTimNCC.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTimNCC.IconSize = 30;
            this.btnTimNCC.Location = new System.Drawing.Point(433, 93);
            this.btnTimNCC.Name = "btnTimNCC";
            this.btnTimNCC.Size = new System.Drawing.Size(48, 35);
            this.btnTimNCC.TabIndex = 69;
            this.btnTimNCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimNCC.UseVisualStyleBackColor = true;
            this.btnTimNCC.Click += new System.EventHandler(this.btnTimNCC_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 28);
            this.label5.TabIndex = 3;
            this.label5.Text = "Số điện thoại:";
            // 
            // labelSDTNCC
            // 
            this.labelSDTNCC.AutoSize = true;
            this.labelSDTNCC.Location = new System.Drawing.Point(191, 195);
            this.labelSDTNCC.Name = "labelSDTNCC";
            this.labelSDTNCC.Size = new System.Drawing.Size(0, 28);
            this.labelSDTNCC.TabIndex = 3;
            // 
            // labelDiaChiNCC
            // 
            this.labelDiaChiNCC.AutoSize = true;
            this.labelDiaChiNCC.Location = new System.Drawing.Point(191, 144);
            this.labelDiaChiNCC.Name = "labelDiaChiNCC";
            this.labelDiaChiNCC.Size = new System.Drawing.Size(0, 28);
            this.labelDiaChiNCC.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "Địa chỉ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên nhà cung cấp:";
            // 
            // comboBoxMaNCC
            // 
            this.comboBoxMaNCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMaNCC.FormattingEnabled = true;
            this.comboBoxMaNCC.Location = new System.Drawing.Point(191, 41);
            this.comboBoxMaNCC.Name = "comboBoxMaNCC";
            this.comboBoxMaNCC.Size = new System.Drawing.Size(228, 36);
            this.comboBoxMaNCC.TabIndex = 2;
            this.comboBoxMaNCC.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaNCC_SelectedIndexChanged);
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Location = new System.Drawing.Point(191, 93);
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.Size = new System.Drawing.Size(228, 34);
            this.txtTenNCC.TabIndex = 1;
            this.txtTenNCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenNCC_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã nhà cung cấp:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTimCH);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.labelSDTCH);
            this.groupBox2.Controls.Add(this.labelDiaChiCH);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.comboBoxMaCH);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtTenCH);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(533, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 269);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin cửa hàng";
            // 
            // btnTimCH
            // 
            this.btnTimCH.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTimCH.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnTimCH.IconColor = System.Drawing.Color.Black;
            this.btnTimCH.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTimCH.IconSize = 30;
            this.btnTimCH.Location = new System.Drawing.Point(433, 96);
            this.btnTimCH.Name = "btnTimCH";
            this.btnTimCH.Size = new System.Drawing.Size(48, 35);
            this.btnTimCH.TabIndex = 69;
            this.btnTimCH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimCH.UseVisualStyleBackColor = true;
            this.btnTimCH.Click += new System.EventHandler(this.btnTimCH_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 196);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 28);
            this.label9.TabIndex = 3;
            this.label9.Text = "Số điện thoại:";
            // 
            // labelSDTCH
            // 
            this.labelSDTCH.AutoSize = true;
            this.labelSDTCH.Location = new System.Drawing.Point(191, 196);
            this.labelSDTCH.Name = "labelSDTCH";
            this.labelSDTCH.Size = new System.Drawing.Size(0, 28);
            this.labelSDTCH.TabIndex = 3;
            // 
            // labelDiaChiCH
            // 
            this.labelDiaChiCH.AutoSize = true;
            this.labelDiaChiCH.Location = new System.Drawing.Point(191, 147);
            this.labelDiaChiCH.Name = "labelDiaChiCH";
            this.labelDiaChiCH.Size = new System.Drawing.Size(0, 28);
            this.labelDiaChiCH.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 28);
            this.label8.TabIndex = 3;
            this.label8.Text = "Địa chỉ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 28);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mã cửa hàng:";
            // 
            // comboBoxMaCH
            // 
            this.comboBoxMaCH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMaCH.FormattingEnabled = true;
            this.comboBoxMaCH.Location = new System.Drawing.Point(191, 43);
            this.comboBoxMaCH.Name = "comboBoxMaCH";
            this.comboBoxMaCH.Size = new System.Drawing.Size(228, 36);
            this.comboBoxMaCH.TabIndex = 2;
            this.comboBoxMaCH.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaCH_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 28);
            this.label7.TabIndex = 3;
            this.label7.Text = "Tên cửa hàng:";
            // 
            // txtTenCH
            // 
            this.txtTenCH.Location = new System.Drawing.Point(191, 96);
            this.txtTenCH.Name = "txtTenCH";
            this.txtTenCH.Size = new System.Drawing.Size(228, 34);
            this.txtTenCH.TabIndex = 1;
            this.txtTenCH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenCH_KeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnXoaSP);
            this.groupBox3.Controls.Add(this.btnThemSP);
            this.groupBox3.Controls.Add(this.dgvSPDH);
            this.groupBox3.Controls.Add(this.labelTongTien);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(33, 403);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(993, 452);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách sản phẩm";
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnXoaSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnXoaSP.ForeColor = System.Drawing.Color.White;
            this.btnXoaSP.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnXoaSP.IconColor = System.Drawing.Color.Black;
            this.btnXoaSP.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXoaSP.Location = new System.Drawing.Point(863, 359);
            this.btnXoaSP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXoaSP.Name = "btnXoaSP";
            this.btnXoaSP.Size = new System.Drawing.Size(113, 53);
            this.btnXoaSP.TabIndex = 24;
            this.btnXoaSP.Text = "XÓA";
            this.btnXoaSP.UseVisualStyleBackColor = false;
            this.btnXoaSP.Click += new System.EventHandler(this.btnXoaSP_Click);
            // 
            // btnThemSP
            // 
            this.btnThemSP.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnThemSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnThemSP.ForeColor = System.Drawing.Color.White;
            this.btnThemSP.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnThemSP.IconColor = System.Drawing.Color.Black;
            this.btnThemSP.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThemSP.Location = new System.Drawing.Point(863, 299);
            this.btnThemSP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Size = new System.Drawing.Size(113, 53);
            this.btnThemSP.TabIndex = 24;
            this.btnThemSP.Text = "THÊM";
            this.btnThemSP.UseVisualStyleBackColor = false;
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // dgvSPDH
            // 
            this.dgvSPDH.AllowUserToAddRows = false;
            this.dgvSPDH.AllowUserToDeleteRows = false;
            this.dgvSPDH.AllowUserToOrderColumns = true;
            this.dgvSPDH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSPDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSPDH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maSP,
            this.tenSanPham,
            this.slDat,
            this.donGia,
            this.thanhTien});
            this.dgvSPDH.Location = new System.Drawing.Point(6, 33);
            this.dgvSPDH.Name = "dgvSPDH";
            this.dgvSPDH.ReadOnly = true;
            this.dgvSPDH.RowHeadersWidth = 51;
            this.dgvSPDH.RowTemplate.Height = 29;
            this.dgvSPDH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSPDH.Size = new System.Drawing.Size(845, 379);
            this.dgvSPDH.TabIndex = 0;
            // 
            // maSP
            // 
            this.maSP.HeaderText = "Mã sản phẩm";
            this.maSP.MinimumWidth = 6;
            this.maSP.Name = "maSP";
            this.maSP.ReadOnly = true;
            // 
            // tenSanPham
            // 
            this.tenSanPham.HeaderText = "Tên sản phẩm";
            this.tenSanPham.MinimumWidth = 6;
            this.tenSanPham.Name = "tenSanPham";
            this.tenSanPham.ReadOnly = true;
            // 
            // slDat
            // 
            this.slDat.HeaderText = "Số lượng đặt";
            this.slDat.MinimumWidth = 6;
            this.slDat.Name = "slDat";
            this.slDat.ReadOnly = true;
            // 
            // donGia
            // 
            this.donGia.HeaderText = "Đơn giá";
            this.donGia.MinimumWidth = 6;
            this.donGia.Name = "donGia";
            this.donGia.ReadOnly = true;
            // 
            // thanhTien
            // 
            this.thanhTien.HeaderText = "Thành tiền";
            this.thanhTien.MinimumWidth = 6;
            this.thanhTien.Name = "thanhTien";
            this.thanhTien.ReadOnly = true;
            // 
            // labelTongTien
            // 
            this.labelTongTien.AutoSize = true;
            this.labelTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTongTien.Location = new System.Drawing.Point(697, 413);
            this.labelTongTien.Name = "labelTongTien";
            this.labelTongTien.Size = new System.Drawing.Size(24, 28);
            this.labelTongTien.TabIndex = 0;
            this.labelTongTien.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(589, 413);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 28);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tổng tiền:";
            // 
            // btnTaoPDH
            // 
            this.btnTaoPDH.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnTaoPDH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaoPDH.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTaoPDH.ForeColor = System.Drawing.Color.White;
            this.btnTaoPDH.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnTaoPDH.IconColor = System.Drawing.Color.Black;
            this.btnTaoPDH.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTaoPDH.Location = new System.Drawing.Point(401, 869);
            this.btnTaoPDH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTaoPDH.Name = "btnTaoPDH";
            this.btnTaoPDH.Size = new System.Drawing.Size(113, 53);
            this.btnTaoPDH.TabIndex = 25;
            this.btnTaoPDH.Text = "TẠO PHIẾU";
            this.btnTaoPDH.UseVisualStyleBackColor = false;
            this.btnTaoPDH.Click += new System.EventHandler(this.btnTaoPDH_Click);
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
            this.btnHuy.Location = new System.Drawing.Point(539, 869);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(113, 53);
            this.btnHuy.TabIndex = 25;
            this.btnHuy.Text = "HỦY";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(27, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(196, 28);
            this.label11.TabIndex = 70;
            this.label11.Text = "Mã phiếu đặt hàng:";
            // 
            // labelMaPDH
            // 
            this.labelMaPDH.AutoSize = true;
            this.labelMaPDH.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelMaPDH.Location = new System.Drawing.Point(230, 77);
            this.labelMaPDH.Name = "labelMaPDH";
            this.labelMaPDH.Size = new System.Drawing.Size(79, 28);
            this.labelMaPDH.TabIndex = 71;
            this.labelMaPDH.Text = "PDH01";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(394, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(162, 28);
            this.label12.TabIndex = 70;
            this.label12.Text = "Ngày lập phiếu:";
            // 
            // labelNgayLap
            // 
            this.labelNgayLap.AutoSize = true;
            this.labelNgayLap.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelNgayLap.Location = new System.Drawing.Point(563, 77);
            this.labelNgayLap.Name = "labelNgayLap";
            this.labelNgayLap.Size = new System.Drawing.Size(102, 28);
            this.labelNgayLap.TabIndex = 71;
            this.labelNgayLap.Text = "1/1/2021";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(759, 77);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 28);
            this.label14.TabIndex = 70;
            this.label14.Text = "Người lập:";
            // 
            // labelNguoiLap
            // 
            this.labelNguoiLap.AutoSize = true;
            this.labelNguoiLap.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelNguoiLap.Location = new System.Drawing.Point(878, 77);
            this.labelNguoiLap.Name = "labelNguoiLap";
            this.labelNguoiLap.Size = new System.Drawing.Size(148, 28);
            this.labelNguoiLap.TabIndex = 71;
            this.labelNguoiLap.Text = "Nguyễn Văn A";
            // 
            // AddDatHangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 952);
            this.Controls.Add(this.labelNguoiLap);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.labelNgayLap);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.labelMaPDH);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnTaoPDH);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddDatHangForm";
            this.Text = "AddDatHangForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AddDatHangForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSPDH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvSPDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn slDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn donGia;
        private System.Windows.Forms.ComboBox comboBoxMaNCC;
        private System.Windows.Forms.TextBox txtTenNCC;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnXoaSP;
        private FontAwesome.Sharp.IconButton btnThemSP;
        private FontAwesome.Sharp.IconButton btnTaoPDH;
        private FontAwesome.Sharp.IconButton btnHuy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxMaCH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTenCH;
        private FontAwesome.Sharp.IconButton btnTimNCC;
        private System.Windows.Forms.Label labelSDTNCC;
        private System.Windows.Forms.Label labelDiaChiNCC;
        private FontAwesome.Sharp.IconButton btnTimCH;
        private System.Windows.Forms.Label labelSDTCH;
        private System.Windows.Forms.Label labelDiaChiCH;
        private System.Windows.Forms.DataGridViewTextBoxColumn thanhTien;
        private System.Windows.Forms.Label labelTongTien;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelMaPDH;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelNgayLap;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelNguoiLap;
    }
}