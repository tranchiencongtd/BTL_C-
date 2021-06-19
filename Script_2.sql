/*
Created		6/16/2021
Modified		6/17/2021
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2005 
*/


Create table [CuaHang]
(
	[MaCuaHang] Varchar(20) NOT NULL,
	[TenCuaHang] Nvarchar(100) NOT NULL,
	[DiaChi] Nvarchar(100) NOT NULL,
	[DienThoai] Varchar(11) NOT NULL,
Primary Key ([MaCuaHang])
) 
go

Create table [HoaDon]
(
	[MaHD] Integer Identity NOT NULL,
	[NgayLap] Datetime NOT NULL,
	[SDT] Varchar(11) NOT NULL,
	[MaNV] Varchar(20) NOT NULL,
Primary Key ([MaHD])
) 
go

Create table [KhachHang]
(
	[TenKH] Nvarchar(100) NULL,
	[SDT] Varchar(11) NOT NULL,
	[TichDiem] Integer NULL,
Primary Key ([SDT])
) 
go

Create table [SanPham]
(
	[MaSP] Integer Identity NOT NULL,
	[TenSP] Nvarchar(100) NOT NULL,
	[SLTon] Integer NOT NULL,
	[DonGia] Money NOT NULL,
	[XuatXu] Varchar(100) NOT NULL,
	[ThuongHieu] Varchar(100) NOT NULL,
	[MaDM] Varchar(50) NOT NULL,
Primary Key ([MaSP])
) 
go

Create table [ThongTinHD]
(
	[MaHD] Integer NOT NULL,
	[MaSP] Integer NOT NULL,
	[SoLuongMua] Integer NOT NULL,
Primary Key ([MaHD],[MaSP])
) 
go

Create table [KhuyenMai]
(
	[MaKM] Integer Identity NOT NULL,
	[GiamGia] Integer NULL,
	[NgayBD] Datetime NULL,
	[NgayKT] Datetime NULL,
Primary Key ([MaKM])
) 
go

Create table [SanPhamKM]
(
	[MaKM] Integer NOT NULL,
	[MaSP] Integer NOT NULL,
	[GiaKM] Integer NULL,
Primary Key ([MaKM],[MaSP])
) 
go

Create table [NhanVien]
(
	[MaNV] Varchar(20) NOT NULL,
	[TenNV] Nvarchar(100) NOT NULL,
	[Anh] Varchar(200) NULL,
	[GioiTinh] Bit NULL,
	[SDT] Varchar(11) NULL,
	[MaCuaHang] Varchar(20) NOT NULL,
Primary Key ([MaNV])
) 
go

Create table [NhaCC]
(
	[MaNCC] Varchar(20) NOT NULL,
	[TenNCC] Nvarchar(100) NULL,
	[DienThoai] Varchar(11) NULL,
	[DiaChi] Nvarchar(100) NULL,
	[Email] Varchar(50) NULL,
Primary Key ([MaNCC])
) 
go

Create table [DanhMuc]
(
	[MaDM] Varchar(50) NOT NULL,
	[TenDM] Nvarchar(100) NOT NULL,
Primary Key ([MaDM])
) 
go

Create table [DongPhieuNhap]
(
	[MaNCC] Varchar(20) NOT NULL,
	[MaSP] Integer NOT NULL,
	[SoLuongNhap] Integer NULL,
Primary Key ([MaNCC],[MaSP])
) 
go

Create table [TaiKhoan]
(
	[TenTK] Varchar(30) NOT NULL,
	[MatKhau] Varchar(30) NOT NULL,
	[ChucVu] Bit NOT NULL,
	[MaNV] Varchar(20) NOT NULL,
Primary Key ([TenTK])
) 
go


Alter table [NhanVien] add  foreign key([MaCuaHang]) references [CuaHang] ([MaCuaHang])  on update no action on delete no action 
go
Alter table [ThongTinHD] add  foreign key([MaHD]) references [HoaDon] ([MaHD])  on update no action on delete no action 
go
Alter table [HoaDon] add  foreign key([SDT]) references [KhachHang] ([SDT])  on update no action on delete no action 
go
Alter table [ThongTinHD] add  foreign key([MaSP]) references [SanPham] ([MaSP])  on update no action on delete no action 
go
Alter table [SanPhamKM] add  foreign key([MaSP]) references [SanPham] ([MaSP])  on update no action on delete no action 
go
Alter table [DongPhieuNhap] add  foreign key([MaSP]) references [SanPham] ([MaSP])  on update no action on delete no action 
go
Alter table [SanPhamKM] add  foreign key([MaKM]) references [KhuyenMai] ([MaKM])  on update no action on delete no action 
go
Alter table [HoaDon] add  foreign key([MaNV]) references [NhanVien] ([MaNV])  on update no action on delete no action 
go
Alter table [TaiKhoan] add  foreign key([MaNV]) references [NhanVien] ([MaNV])  on update no action on delete no action 
go
Alter table [DongPhieuNhap] add  foreign key([MaNCC]) references [NhaCC] ([MaNCC])  on update no action on delete no action 
go
Alter table [SanPham] add  foreign key([MaDM]) references [DanhMuc] ([MaDM])  on update no action on delete no action 
go


Set quoted_identifier on
go


Set quoted_identifier off
go


