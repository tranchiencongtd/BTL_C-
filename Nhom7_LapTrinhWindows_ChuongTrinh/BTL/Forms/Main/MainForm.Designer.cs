
namespace BTL.Forms.Main
{
    partial class MainForm
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
            System.Windows.Forms.Timer timeClock;
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnDatHang = new FontAwesome.Sharp.IconButton();
            this.btnDoiTra = new FontAwesome.Sharp.IconButton();
            this.btnQuanLyTaiKhoan = new FontAwesome.Sharp.IconButton();
            this.btnQuanLyNhapHang = new FontAwesome.Sharp.IconButton();
            this.btnQuanLyKhuyenMai = new FontAwesome.Sharp.IconButton();
            this.btnQuanLyDanhMuc = new FontAwesome.Sharp.IconButton();
            this.btnQuanLyNhaCungCap = new FontAwesome.Sharp.IconButton();
            this.btnQuanLyNhanVien = new FontAwesome.Sharp.IconButton();
            this.btnQuanLyHoaDon = new FontAwesome.Sharp.IconButton();
            this.btnQuanLyKhachHang = new FontAwesome.Sharp.IconButton();
            this.btnQuanLySanPham = new FontAwesome.Sharp.IconButton();
            this.btnThongKe = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.avt = new FontAwesome.Sharp.IconButton();
            this.btnThuNho = new FontAwesome.Sharp.IconPictureBox();
            this.btnPhongTo = new FontAwesome.Sharp.IconPictureBox();
            this.btnDong = new FontAwesome.Sharp.IconPictureBox();
            this.labelCurrentForm = new System.Windows.Forms.Label();
            this.iconCurrentForm = new FontAwesome.Sharp.IconPictureBox();
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panelView = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panelDropMenu = new System.Windows.Forms.Panel();
            this.btnDangXuat = new FontAwesome.Sharp.IconButton();
            this.btnDoiMatKhau = new FontAwesome.Sharp.IconButton();
            this.btnXemInfo = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTimeSs = new System.Windows.Forms.Label();
            this.labelTimeHhMm = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelHiTen = new System.Windows.Forms.Label();
            timeClock = new System.Windows.Forms.Timer(this.components);
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnThuNho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPhongTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentForm)).BeginInit();
            this.panelView.SuspendLayout();
            this.panelDropMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeClock
            // 
            timeClock.Enabled = true;
            timeClock.Interval = 1000;
            timeClock.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.DodgerBlue;
            this.panelMenu.Controls.Add(this.btnDatHang);
            this.panelMenu.Controls.Add(this.btnDoiTra);
            this.panelMenu.Controls.Add(this.btnQuanLyTaiKhoan);
            this.panelMenu.Controls.Add(this.btnQuanLyNhapHang);
            this.panelMenu.Controls.Add(this.btnQuanLyKhuyenMai);
            this.panelMenu.Controls.Add(this.btnQuanLyDanhMuc);
            this.panelMenu.Controls.Add(this.btnQuanLyNhaCungCap);
            this.panelMenu.Controls.Add(this.btnQuanLyNhanVien);
            this.panelMenu.Controls.Add(this.btnQuanLyHoaDon);
            this.panelMenu.Controls.Add(this.btnQuanLyKhachHang);
            this.panelMenu.Controls.Add(this.btnQuanLySanPham);
            this.panelMenu.Controls.Add(this.btnThongKe);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 730);
            this.panelMenu.TabIndex = 0;
            // 
            // btnDatHang
            // 
            this.btnDatHang.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDatHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDatHang.FlatAppearance.BorderSize = 0;
            this.btnDatHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatHang.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDatHang.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDatHang.IconChar = FontAwesome.Sharp.IconChar.Phone;
            this.btnDatHang.IconColor = System.Drawing.Color.WhiteSmoke;
            this.btnDatHang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDatHang.IconSize = 32;
            this.btnDatHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatHang.Location = new System.Drawing.Point(0, 659);
            this.btnDatHang.Name = "btnDatHang";
            this.btnDatHang.Size = new System.Drawing.Size(220, 50);
            this.btnDatHang.TabIndex = 12;
            this.btnDatHang.Text = "Quản lý đặt hàng";
            this.btnDatHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatHang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDatHang.UseVisualStyleBackColor = true;
            this.btnDatHang.Click += new System.EventHandler(this.btnDatHang_Click);
            // 
            // btnDoiTra
            // 
            this.btnDoiTra.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDoiTra.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDoiTra.FlatAppearance.BorderSize = 0;
            this.btnDoiTra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoiTra.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDoiTra.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDoiTra.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.btnDoiTra.IconColor = System.Drawing.Color.WhiteSmoke;
            this.btnDoiTra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDoiTra.IconSize = 32;
            this.btnDoiTra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoiTra.Location = new System.Drawing.Point(0, 609);
            this.btnDoiTra.Name = "btnDoiTra";
            this.btnDoiTra.Size = new System.Drawing.Size(220, 50);
            this.btnDoiTra.TabIndex = 11;
            this.btnDoiTra.Text = "Quản lý đổi trả";
            this.btnDoiTra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoiTra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDoiTra.UseVisualStyleBackColor = true;
            this.btnDoiTra.Click += new System.EventHandler(this.btnDoiTra_Click);
            // 
            // btnQuanLyTaiKhoan
            // 
            this.btnQuanLyTaiKhoan.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnQuanLyTaiKhoan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyTaiKhoan.FlatAppearance.BorderSize = 0;
            this.btnQuanLyTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnQuanLyTaiKhoan.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuanLyTaiKhoan.IconChar = FontAwesome.Sharp.IconChar.UnlockAlt;
            this.btnQuanLyTaiKhoan.IconColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuanLyTaiKhoan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQuanLyTaiKhoan.IconSize = 32;
            this.btnQuanLyTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyTaiKhoan.Location = new System.Drawing.Point(0, 559);
            this.btnQuanLyTaiKhoan.Name = "btnQuanLyTaiKhoan";
            this.btnQuanLyTaiKhoan.Size = new System.Drawing.Size(220, 50);
            this.btnQuanLyTaiKhoan.TabIndex = 10;
            this.btnQuanLyTaiKhoan.Text = "Quản lý tài khoản";
            this.btnQuanLyTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyTaiKhoan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanLyTaiKhoan.UseVisualStyleBackColor = true;
            this.btnQuanLyTaiKhoan.Click += new System.EventHandler(this.btnQuanLyTaiKhoan_Click);
            // 
            // btnQuanLyNhapHang
            // 
            this.btnQuanLyNhapHang.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnQuanLyNhapHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyNhapHang.FlatAppearance.BorderSize = 0;
            this.btnQuanLyNhapHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyNhapHang.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnQuanLyNhapHang.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuanLyNhapHang.IconChar = FontAwesome.Sharp.IconChar.Warehouse;
            this.btnQuanLyNhapHang.IconColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuanLyNhapHang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQuanLyNhapHang.IconSize = 32;
            this.btnQuanLyNhapHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyNhapHang.Location = new System.Drawing.Point(0, 509);
            this.btnQuanLyNhapHang.Name = "btnQuanLyNhapHang";
            this.btnQuanLyNhapHang.Size = new System.Drawing.Size(220, 50);
            this.btnQuanLyNhapHang.TabIndex = 9;
            this.btnQuanLyNhapHang.Text = "Quản lý nhập hàng";
            this.btnQuanLyNhapHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyNhapHang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanLyNhapHang.UseVisualStyleBackColor = true;
            this.btnQuanLyNhapHang.Click += new System.EventHandler(this.btnQuanLyNhapHang_Click);
            // 
            // btnQuanLyKhuyenMai
            // 
            this.btnQuanLyKhuyenMai.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnQuanLyKhuyenMai.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyKhuyenMai.FlatAppearance.BorderSize = 0;
            this.btnQuanLyKhuyenMai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyKhuyenMai.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnQuanLyKhuyenMai.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuanLyKhuyenMai.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.btnQuanLyKhuyenMai.IconColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuanLyKhuyenMai.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQuanLyKhuyenMai.IconSize = 32;
            this.btnQuanLyKhuyenMai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyKhuyenMai.Location = new System.Drawing.Point(0, 459);
            this.btnQuanLyKhuyenMai.Name = "btnQuanLyKhuyenMai";
            this.btnQuanLyKhuyenMai.Size = new System.Drawing.Size(220, 50);
            this.btnQuanLyKhuyenMai.TabIndex = 8;
            this.btnQuanLyKhuyenMai.Text = "Quản lý khuyến mãi";
            this.btnQuanLyKhuyenMai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyKhuyenMai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanLyKhuyenMai.UseVisualStyleBackColor = true;
            this.btnQuanLyKhuyenMai.Click += new System.EventHandler(this.btnQuanLyKhuyenMai_Click);
            // 
            // btnQuanLyDanhMuc
            // 
            this.btnQuanLyDanhMuc.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnQuanLyDanhMuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyDanhMuc.FlatAppearance.BorderSize = 0;
            this.btnQuanLyDanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyDanhMuc.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnQuanLyDanhMuc.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuanLyDanhMuc.IconChar = FontAwesome.Sharp.IconChar.Bars;
            this.btnQuanLyDanhMuc.IconColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuanLyDanhMuc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQuanLyDanhMuc.IconSize = 32;
            this.btnQuanLyDanhMuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyDanhMuc.Location = new System.Drawing.Point(0, 409);
            this.btnQuanLyDanhMuc.Name = "btnQuanLyDanhMuc";
            this.btnQuanLyDanhMuc.Size = new System.Drawing.Size(220, 50);
            this.btnQuanLyDanhMuc.TabIndex = 7;
            this.btnQuanLyDanhMuc.Text = "Quản lý danh mục";
            this.btnQuanLyDanhMuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyDanhMuc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanLyDanhMuc.UseVisualStyleBackColor = true;
            this.btnQuanLyDanhMuc.Click += new System.EventHandler(this.btnQuanLyDanhMuc_Click);
            // 
            // btnQuanLyNhaCungCap
            // 
            this.btnQuanLyNhaCungCap.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnQuanLyNhaCungCap.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyNhaCungCap.FlatAppearance.BorderSize = 0;
            this.btnQuanLyNhaCungCap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnQuanLyNhaCungCap.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuanLyNhaCungCap.IconChar = FontAwesome.Sharp.IconChar.ShippingFast;
            this.btnQuanLyNhaCungCap.IconColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuanLyNhaCungCap.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQuanLyNhaCungCap.IconSize = 32;
            this.btnQuanLyNhaCungCap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyNhaCungCap.Location = new System.Drawing.Point(0, 359);
            this.btnQuanLyNhaCungCap.Name = "btnQuanLyNhaCungCap";
            this.btnQuanLyNhaCungCap.Size = new System.Drawing.Size(220, 50);
            this.btnQuanLyNhaCungCap.TabIndex = 6;
            this.btnQuanLyNhaCungCap.Text = "Quản lý nhà cung cấp";
            this.btnQuanLyNhaCungCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyNhaCungCap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanLyNhaCungCap.UseVisualStyleBackColor = true;
            this.btnQuanLyNhaCungCap.Click += new System.EventHandler(this.btnQuanLyNhaCungCap_Click);
            // 
            // btnQuanLyNhanVien
            // 
            this.btnQuanLyNhanVien.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnQuanLyNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyNhanVien.FlatAppearance.BorderSize = 0;
            this.btnQuanLyNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyNhanVien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnQuanLyNhanVien.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuanLyNhanVien.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnQuanLyNhanVien.IconColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuanLyNhanVien.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQuanLyNhanVien.IconSize = 32;
            this.btnQuanLyNhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyNhanVien.Location = new System.Drawing.Point(0, 309);
            this.btnQuanLyNhanVien.Name = "btnQuanLyNhanVien";
            this.btnQuanLyNhanVien.Size = new System.Drawing.Size(220, 50);
            this.btnQuanLyNhanVien.TabIndex = 5;
            this.btnQuanLyNhanVien.Text = "Quản lý nhân viên";
            this.btnQuanLyNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyNhanVien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanLyNhanVien.UseVisualStyleBackColor = true;
            this.btnQuanLyNhanVien.Click += new System.EventHandler(this.btnQuanLyNhanVien_Click);
            // 
            // btnQuanLyHoaDon
            // 
            this.btnQuanLyHoaDon.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnQuanLyHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyHoaDon.FlatAppearance.BorderSize = 0;
            this.btnQuanLyHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyHoaDon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnQuanLyHoaDon.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuanLyHoaDon.IconChar = FontAwesome.Sharp.IconChar.ShoppingBag;
            this.btnQuanLyHoaDon.IconColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuanLyHoaDon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQuanLyHoaDon.IconSize = 32;
            this.btnQuanLyHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyHoaDon.Location = new System.Drawing.Point(0, 259);
            this.btnQuanLyHoaDon.Name = "btnQuanLyHoaDon";
            this.btnQuanLyHoaDon.Size = new System.Drawing.Size(220, 50);
            this.btnQuanLyHoaDon.TabIndex = 4;
            this.btnQuanLyHoaDon.Text = "Quản lý hóa đơn";
            this.btnQuanLyHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyHoaDon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanLyHoaDon.UseVisualStyleBackColor = true;
            this.btnQuanLyHoaDon.Click += new System.EventHandler(this.btnQuanLyHoaDon_Click);
            // 
            // btnQuanLyKhachHang
            // 
            this.btnQuanLyKhachHang.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnQuanLyKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyKhachHang.FlatAppearance.BorderSize = 0;
            this.btnQuanLyKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyKhachHang.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnQuanLyKhachHang.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuanLyKhachHang.IconChar = FontAwesome.Sharp.IconChar.Child;
            this.btnQuanLyKhachHang.IconColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuanLyKhachHang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQuanLyKhachHang.IconSize = 32;
            this.btnQuanLyKhachHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyKhachHang.Location = new System.Drawing.Point(0, 204);
            this.btnQuanLyKhachHang.Name = "btnQuanLyKhachHang";
            this.btnQuanLyKhachHang.Size = new System.Drawing.Size(220, 55);
            this.btnQuanLyKhachHang.TabIndex = 3;
            this.btnQuanLyKhachHang.Text = "Quản lý khách hàng";
            this.btnQuanLyKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyKhachHang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanLyKhachHang.UseVisualStyleBackColor = true;
            this.btnQuanLyKhachHang.Click += new System.EventHandler(this.btnQuanLyKhachHang_Click);
            // 
            // btnQuanLySanPham
            // 
            this.btnQuanLySanPham.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnQuanLySanPham.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLySanPham.FlatAppearance.BorderSize = 0;
            this.btnQuanLySanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLySanPham.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnQuanLySanPham.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuanLySanPham.IconChar = FontAwesome.Sharp.IconChar.DiceD6;
            this.btnQuanLySanPham.IconColor = System.Drawing.Color.WhiteSmoke;
            this.btnQuanLySanPham.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQuanLySanPham.IconSize = 32;
            this.btnQuanLySanPham.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLySanPham.Location = new System.Drawing.Point(0, 149);
            this.btnQuanLySanPham.Name = "btnQuanLySanPham";
            this.btnQuanLySanPham.Size = new System.Drawing.Size(220, 55);
            this.btnQuanLySanPham.TabIndex = 2;
            this.btnQuanLySanPham.Text = "Quản lý sản phẩm";
            this.btnQuanLySanPham.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLySanPham.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanLySanPham.UseVisualStyleBackColor = true;
            this.btnQuanLySanPham.Click += new System.EventHandler(this.btnQuanLySanPham_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongKe.FlatAppearance.BorderSize = 0;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThongKe.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnThongKe.IconChar = FontAwesome.Sharp.IconChar.TachometerAlt;
            this.btnThongKe.IconColor = System.Drawing.Color.WhiteSmoke;
            this.btnThongKe.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThongKe.IconSize = 32;
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.Location = new System.Drawing.Point(0, 94);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(220, 55);
            this.btnThongKe.TabIndex = 1;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.DodgerBlue;
            this.panelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelLogo.Controls.Add(this.btnHome);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 94);
            this.panelLogo.TabIndex = 0;
            this.panelLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLogo_Paint);
            // 
            // btnHome
            // 
            this.btnHome.Image = global::BTL.Properties.Resources.logofooter_min_1;
            this.btnHome.Location = new System.Drawing.Point(43, 20);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(126, 60);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnHome.TabIndex = 0;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click_1);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.Transparent;
            this.panelTitleBar.Controls.Add(this.avt);
            this.panelTitleBar.Controls.Add(this.btnThuNho);
            this.panelTitleBar.Controls.Add(this.btnPhongTo);
            this.panelTitleBar.Controls.Add(this.btnDong);
            this.panelTitleBar.Controls.Add(this.labelCurrentForm);
            this.panelTitleBar.Controls.Add(this.iconCurrentForm);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1071, 74);
            this.panelTitleBar.TabIndex = 2;
            this.panelTitleBar.Tag = "";
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // avt
            // 
            this.avt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.avt.BackColor = System.Drawing.Color.Transparent;
            this.avt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.avt.FlatAppearance.BorderSize = 0;
            this.avt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.avt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.avt.ForeColor = System.Drawing.Color.MidnightBlue;
            this.avt.IconChar = FontAwesome.Sharp.IconChar.CaretDown;
            this.avt.IconColor = System.Drawing.Color.MidnightBlue;
            this.avt.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.avt.IconSize = 25;
            this.avt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.avt.Location = new System.Drawing.Point(906, 30);
            this.avt.Name = "avt";
            this.avt.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.avt.Size = new System.Drawing.Size(164, 43);
            this.avt.TabIndex = 5;
            this.avt.Text = "Trần Chiến Công";
            this.avt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.avt.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.avt.UseVisualStyleBackColor = false;
            this.avt.Click += new System.EventHandler(this.avt_Click);
            // 
            // btnThuNho
            // 
            this.btnThuNho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThuNho.BackColor = System.Drawing.Color.Transparent;
            this.btnThuNho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThuNho.ForeColor = System.Drawing.Color.Gray;
            this.btnThuNho.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btnThuNho.IconColor = System.Drawing.Color.Gray;
            this.btnThuNho.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThuNho.IconSize = 25;
            this.btnThuNho.Location = new System.Drawing.Point(990, 2);
            this.btnThuNho.Name = "btnThuNho";
            this.btnThuNho.Size = new System.Drawing.Size(25, 25);
            this.btnThuNho.TabIndex = 4;
            this.btnThuNho.TabStop = false;
            this.btnThuNho.Click += new System.EventHandler(this.btnThuNho_Click);
            this.btnThuNho.MouseLeave += new System.EventHandler(this.btnThuNho_MouseLeave);
            this.btnThuNho.MouseHover += new System.EventHandler(this.btnThuNho_MouseHover);
            // 
            // btnPhongTo
            // 
            this.btnPhongTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPhongTo.BackColor = System.Drawing.Color.Transparent;
            this.btnPhongTo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPhongTo.ForeColor = System.Drawing.Color.Gray;
            this.btnPhongTo.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
            this.btnPhongTo.IconColor = System.Drawing.Color.Gray;
            this.btnPhongTo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPhongTo.IconSize = 25;
            this.btnPhongTo.Location = new System.Drawing.Point(1017, 2);
            this.btnPhongTo.Margin = new System.Windows.Forms.Padding(0);
            this.btnPhongTo.Name = "btnPhongTo";
            this.btnPhongTo.Size = new System.Drawing.Size(25, 25);
            this.btnPhongTo.TabIndex = 3;
            this.btnPhongTo.TabStop = false;
            this.btnPhongTo.Click += new System.EventHandler(this.btnPhongTo_Click);
            this.btnPhongTo.MouseLeave += new System.EventHandler(this.btnPhongTo_MouseLeave);
            this.btnPhongTo.MouseHover += new System.EventHandler(this.btnPhongTo_MouseHover);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.BackColor = System.Drawing.Color.Transparent;
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.ForeColor = System.Drawing.Color.Gray;
            this.btnDong.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnDong.IconColor = System.Drawing.Color.Gray;
            this.btnDong.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDong.IconSize = 25;
            this.btnDong.Location = new System.Drawing.Point(1043, 2);
            this.btnDong.Margin = new System.Windows.Forms.Padding(0);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(25, 25);
            this.btnDong.TabIndex = 2;
            this.btnDong.TabStop = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.btnDong.MouseLeave += new System.EventHandler(this.btnDong_MouseLeave);
            this.btnDong.MouseHover += new System.EventHandler(this.btnDong_MouseHover);
            // 
            // labelCurrentForm
            // 
            this.labelCurrentForm.AutoSize = true;
            this.labelCurrentForm.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCurrentForm.ForeColor = System.Drawing.Color.MidnightBlue;
            this.labelCurrentForm.Location = new System.Drawing.Point(46, 45);
            this.labelCurrentForm.Name = "labelCurrentForm";
            this.labelCurrentForm.Size = new System.Drawing.Size(51, 20);
            this.labelCurrentForm.TabIndex = 1;
            this.labelCurrentForm.Text = "Home";
            // 
            // iconCurrentForm
            // 
            this.iconCurrentForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(255)))));
            this.iconCurrentForm.ForeColor = System.Drawing.Color.MidnightBlue;
            this.iconCurrentForm.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.iconCurrentForm.IconColor = System.Drawing.Color.MidnightBlue;
            this.iconCurrentForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentForm.IconSize = 35;
            this.iconCurrentForm.Location = new System.Drawing.Point(14, 37);
            this.iconCurrentForm.Name = "iconCurrentForm";
            this.iconCurrentForm.Size = new System.Drawing.Size(35, 35);
            this.iconCurrentForm.TabIndex = 0;
            this.iconCurrentForm.TabStop = false;
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.Color.Gainsboro;
            this.panelShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow.Location = new System.Drawing.Point(220, 74);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(1071, 5);
            this.panelShadow.TabIndex = 3;
            // 
            // panelView
            // 
            this.panelView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panelView.BackColor = System.Drawing.SystemColors.Control;
            this.panelView.Controls.Add(this.textBox1);
            this.panelView.Controls.Add(this.panelDropMenu);
            this.panelView.Controls.Add(this.label5);
            this.panelView.Controls.Add(this.panel1);
            this.panelView.Location = new System.Drawing.Point(220, 79);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(1071, 651);
            this.panelView.TabIndex = 4;
            this.panelView.Paint += new System.Windows.Forms.PaintEventHandler(this.panelView_Paint);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textBox1.Location = new System.Drawing.Point(88, 580);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(898, 45);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "Chúc bạn một ngày vui vẻ";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelDropMenu
            // 
            this.panelDropMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDropMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.panelDropMenu.Controls.Add(this.btnDangXuat);
            this.panelDropMenu.Controls.Add(this.btnDoiMatKhau);
            this.panelDropMenu.Controls.Add(this.btnXemInfo);
            this.panelDropMenu.Location = new System.Drawing.Point(906, 0);
            this.panelDropMenu.Name = "panelDropMenu";
            this.panelDropMenu.Size = new System.Drawing.Size(164, 173);
            this.panelDropMenu.TabIndex = 7;
            this.panelDropMenu.Visible = false;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDangXuat.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnDangXuat.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btnDangXuat.IconColor = System.Drawing.Color.DarkCyan;
            this.btnDangXuat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDangXuat.IconSize = 25;
            this.btnDangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.Location = new System.Drawing.Point(0, 88);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDangXuat.Size = new System.Drawing.Size(164, 44);
            this.btnDangXuat.TabIndex = 2;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDoiMatKhau.FlatAppearance.BorderSize = 0;
            this.btnDoiMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoiMatKhau.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDoiMatKhau.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnDoiMatKhau.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.btnDoiMatKhau.IconColor = System.Drawing.Color.DarkCyan;
            this.btnDoiMatKhau.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDoiMatKhau.IconSize = 25;
            this.btnDoiMatKhau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoiMatKhau.Location = new System.Drawing.Point(0, 44);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDoiMatKhau.Size = new System.Drawing.Size(164, 44);
            this.btnDoiMatKhau.TabIndex = 1;
            this.btnDoiMatKhau.Text = "Đổi mật khẩu";
            this.btnDoiMatKhau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoiMatKhau.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDoiMatKhau.UseVisualStyleBackColor = true;
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // btnXemInfo
            // 
            this.btnXemInfo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnXemInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnXemInfo.FlatAppearance.BorderSize = 0;
            this.btnXemInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnXemInfo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnXemInfo.IconChar = FontAwesome.Sharp.IconChar.User;
            this.btnXemInfo.IconColor = System.Drawing.Color.DarkCyan;
            this.btnXemInfo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXemInfo.IconSize = 25;
            this.btnXemInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemInfo.Location = new System.Drawing.Point(0, 0);
            this.btnXemInfo.Name = "btnXemInfo";
            this.btnXemInfo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnXemInfo.Size = new System.Drawing.Size(164, 44);
            this.btnXemInfo.TabIndex = 0;
            this.btnXemInfo.Text = "Thông tin cá nhân";
            this.btnXemInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXemInfo.UseVisualStyleBackColor = true;
            this.btnXemInfo.Click += new System.EventHandler(this.btnXemInfo_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(911, 631);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Bản quyền thuộc về nhóm 7";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.labelTimeSs);
            this.panel1.Controls.Add(this.labelTimeHhMm);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelHiTen);
            this.panel1.Location = new System.Drawing.Point(241, 152);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 252);
            this.panel1.TabIndex = 6;
            // 
            // labelTimeSs
            // 
            this.labelTimeSs.AutoSize = true;
            this.labelTimeSs.BackColor = System.Drawing.Color.Transparent;
            this.labelTimeSs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTimeSs.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTimeSs.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelTimeSs.Location = new System.Drawing.Point(406, 49);
            this.labelTimeSs.Margin = new System.Windows.Forms.Padding(0);
            this.labelTimeSs.Name = "labelTimeSs";
            this.labelTimeSs.Size = new System.Drawing.Size(49, 37);
            this.labelTimeSs.TabIndex = 5;
            this.labelTimeSs.Text = "15";
            // 
            // labelTimeHhMm
            // 
            this.labelTimeHhMm.AutoSize = true;
            this.labelTimeHhMm.BackColor = System.Drawing.Color.Transparent;
            this.labelTimeHhMm.Font = new System.Drawing.Font("Segoe UI", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTimeHhMm.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelTimeHhMm.Location = new System.Drawing.Point(163, 43);
            this.labelTimeHhMm.Name = "labelTimeHhMm";
            this.labelTimeHhMm.Size = new System.Drawing.Size(251, 106);
            this.labelTimeHhMm.TabIndex = 4;
            this.labelTimeHhMm.Text = "16:29";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(87, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hi,";
            // 
            // labelHiTen
            // 
            this.labelHiTen.AutoSize = true;
            this.labelHiTen.BackColor = System.Drawing.Color.Transparent;
            this.labelHiTen.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelHiTen.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelHiTen.Location = new System.Drawing.Point(155, 148);
            this.labelHiTen.Name = "labelHiTen";
            this.labelHiTen.Size = new System.Drawing.Size(331, 54);
            this.labelHiTen.TabIndex = 3;
            this.labelHiTen.Text = "Trần Chiến Công";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 730);
            this.Controls.Add(this.panelView);
            this.Controls.Add(this.panelShadow);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnThuNho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPhongTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentForm)).EndInit();
            this.panelView.ResumeLayout(false);
            this.panelView.PerformLayout();
            this.panelDropMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private FontAwesome.Sharp.IconButton btnThongKe;
        private FontAwesome.Sharp.IconButton btnQuanLyTaiKhoan;
        private FontAwesome.Sharp.IconButton btnQuanLyNhapHang;
        private FontAwesome.Sharp.IconButton btnQuanLyKhuyenMai;
        private FontAwesome.Sharp.IconButton btnQuanLyDanhMuc;
        private FontAwesome.Sharp.IconButton btnQuanLyNhaCungCap;
        private FontAwesome.Sharp.IconButton btnQuanLyNhanVien;
        private FontAwesome.Sharp.IconButton btnQuanLyHoaDon;
        private FontAwesome.Sharp.IconButton btnQuanLyKhachHang;
        private FontAwesome.Sharp.IconButton btnQuanLySanPham;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label labelCurrentForm;
        private FontAwesome.Sharp.IconPictureBox iconCurrentForm;
        private System.Windows.Forms.Panel panelShadow;
        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.Label labelTimeHhMm;
        private System.Windows.Forms.Label labelHiTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconPictureBox btnThuNho;
        private FontAwesome.Sharp.IconPictureBox btnPhongTo;
        private FontAwesome.Sharp.IconPictureBox btnDong;
        private FontAwesome.Sharp.IconButton avt;
        private System.Windows.Forms.Panel panelDropMenu;
        private FontAwesome.Sharp.IconButton btnDangXuat;
        private FontAwesome.Sharp.IconButton btnDoiMatKhau;
        private FontAwesome.Sharp.IconButton btnXemInfo;
        private System.Windows.Forms.Timer timeClock;
        private System.Windows.Forms.Label labelTimeSs;
        private System.Windows.Forms.TextBox textBox1;
        private FontAwesome.Sharp.IconButton btnDatHang;
        private FontAwesome.Sharp.IconButton btnDoiTra;
    }
}