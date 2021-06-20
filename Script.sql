/*
Created		6/16/2021
Modified		6/19/2021
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2005 
*/

use master
go

create database QLBanNuocHoa
go

use QLBanNuocHoa
go


Create table [CuaHang]
(
	[MaCuaHang] Nvarchar(20) NOT NULL,
	[TenCuaHang] Nvarchar(100) NOT NULL,
	[DiaChi] Nvarchar(100) NOT NULL,
	[DienThoai] Nvarchar(11) NOT NULL,
	[SoTaiKhoan] Nvarchar(100) NULL,
Primary Key ([MaCuaHang])
) 
go

Create table [HoaDon]
(
	[MaHD] Integer Identity NOT NULL,
	[NgayLap] Datetime NOT NULL,
	[SDT] Nvarchar(11) NOT NULL,
	[MaNV] Nvarchar(20) NOT NULL,
Primary Key ([MaHD])
) 
go

Create table [KhachHang]
(
	[TenKH] Nvarchar(100) NULL,
	[SDT] Nvarchar(11) NOT NULL,
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
	[XuatXu] Nvarchar(100) NOT NULL,
	[ThuongHieu] Nvarchar(100) NOT NULL,
	[MaDM] Nvarchar(50) NOT NULL,
	[DonViTinh] Nvarchar(50) NOT NULL,
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
	[MaNV] Nvarchar(20) NOT NULL,
	[TenNV] Nvarchar(100) NOT NULL,
	[Anh] Nvarchar(200) NULL,
	[GioiTinh] Bit NULL,
	[SDT] Nvarchar(11) NULL,
	[MaCuaHang] Nvarchar(20) NOT NULL,
Primary Key ([MaNV])
) 
go

Create table [NhaCC]
(
	[MaNCC] Nvarchar(20) NOT NULL,
	[TenNCC] Nvarchar(100) NOT NULL,
	[DienThoai] Nvarchar(11) NOT NULL,
	[DiaChi] Nvarchar(100) NOT NULL,
	[Fax] Nvarchar(100) NOT NULL,
	[SoTaiKhoan] Nvarchar(100) NOT NULL,
Primary Key ([MaNCC])
) 
go

Create table [DanhMuc]
(
	[MaDM] Nvarchar(50) NOT NULL,
	[TenDM] Nvarchar(100) NOT NULL,
Primary Key ([MaDM])
) 
go

Create table [TaiKhoan]
(
	[TenTK] Nvarchar(30) NOT NULL,
	[MatKhau] Nvarchar(30) NOT NULL,
	[ChucVu] Bit NOT NULL,
	[MaNV] Nvarchar(20) NOT NULL,
Primary Key ([TenTK])
) 
go

Create table [PhieuNhap]
(
	[MaPhieuNhap] Integer Identity NOT NULL,
	[MaCuaHang] Nvarchar(20) NOT NULL,
	[MaNCC] Nvarchar(20) NOT NULL,
	[NgayNhap] Datetime NOT NULL,
	[ThanhToan] Nvarchar(50) NULL,
	[NguoiNhap] Nvarchar(20) NOT NULL,
Primary Key ([MaPhieuNhap])
) 
go

Create table [DongPhieuNhap]
(
	[MaPhieuNhap] Integer NOT NULL,
	[MaSP] Integer NOT NULL,
	[SoLuong] Integer NULL,
	[GiaNhap] Money NULL,
Primary Key ([MaPhieuNhap],[MaSP])
) 
go


Alter table [NhanVien] add  foreign key([MaCuaHang]) references [CuaHang] ([MaCuaHang])  on update no action on delete no action 
go
Alter table [PhieuNhap] add  foreign key([MaCuaHang]) references [CuaHang] ([MaCuaHang])  on update no action on delete no action 
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
Alter table [PhieuNhap] add  foreign key([MaNCC]) references [NhaCC] ([MaNCC])  on update no action on delete no action 
go
Alter table [SanPham] add  foreign key([MaDM]) references [DanhMuc] ([MaDM])  on update no action on delete no action 
go
Alter table [DongPhieuNhap] add  foreign key([MaPhieuNhap]) references [PhieuNhap] ([MaPhieuNhap])  on update no action on delete no action 
go


Set quoted_identifier on
go


Set quoted_identifier off
go


