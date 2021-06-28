using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BTL.Models
{
    public partial class QLBanMyPhamContext : DbContext
    {
        public QLBanMyPhamContext()
        {
        }

        public QLBanMyPhamContext(DbContextOptions<QLBanMyPhamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CuaHang> CuaHangs { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<DongPhieuNhap> DongPhieuNhaps { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }
        public virtual DbSet<NhaCc> NhaCcs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<SanPhamKm> SanPhamKms { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThongTinHd> ThongTinHds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CONGIT;Initial Catalog=QLBanMyPham;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CuaHang>(entity =>
            {
                entity.HasKey(e => e.MaCuaHang)
                    .HasName("PK__CuaHang__0840BCA62C315AAD");

                entity.ToTable("CuaHang");

                entity.Property(e => e.MaCuaHang).HasMaxLength(20);

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DienThoai)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.SoTaiKhoan).HasMaxLength(100);

                entity.Property(e => e.TenCuaHang)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.HasKey(e => e.MaDm)
                    .HasName("PK__DanhMuc__2725866EB1CF973E");

                entity.ToTable("DanhMuc");

                entity.Property(e => e.MaDm)
                    .HasMaxLength(50)
                    .HasColumnName("MaDM");

                entity.Property(e => e.TenDm)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TenDM");
            });

            modelBuilder.Entity<DongPhieuNhap>(entity =>
            {
                entity.HasKey(e => new { e.MaPhieuNhap, e.MaSp })
                    .HasName("PK__DongPhie__C602BFBA812388E7");

                entity.ToTable("DongPhieuNhap");

                entity.Property(e => e.MaPhieuNhap).HasMaxLength(20);

                entity.Property(e => e.MaSp)
                    .HasMaxLength(20)
                    .HasColumnName("MaSP");

                entity.Property(e => e.GiaNhap).HasColumnType("money");

                entity.HasOne(d => d.MaPhieuNhapNavigation)
                    .WithMany(p => p.DongPhieuNhaps)
                    .HasForeignKey(d => d.MaPhieuNhap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DongPhieu__MaPhi__3B75D760");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.DongPhieuNhaps)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DongPhieuN__MaSP__3C69FB99");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .HasName("PK__HoaDon__2725A6E0D6C960A7");

                entity.ToTable("HoaDon");

                entity.Property(e => e.MaHd)
                    .HasMaxLength(20)
                    .HasColumnName("MaHD");

                entity.Property(e => e.MaKh)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("MaKH");

                entity.Property(e => e.MaNv)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("MaNV");

                entity.Property(e => e.NgayLap).HasColumnType("datetime");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HoaDon__MaKH__3D5E1FD2");

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HoaDon__MaNV__3E52440B");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh)
                    .HasName("PK__KhachHan__2725CF1EE62C9AFD");

                entity.ToTable("KhachHang");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(20)
                    .HasColumnName("MaKH");

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenKh)
                    .HasMaxLength(100)
                    .HasColumnName("TenKH");
            });

            modelBuilder.Entity<KhuyenMai>(entity =>
            {
                entity.HasKey(e => e.MaKm)
                    .HasName("PK__KhuyenMa__2725CF156855E08B");

                entity.ToTable("KhuyenMai");

                entity.Property(e => e.MaKm)
                    .HasMaxLength(20)
                    .HasColumnName("MaKM");

                entity.Property(e => e.NgayBd)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayBD");

                entity.Property(e => e.NgayKt)
                    .HasColumnType("datetime")
                    .HasColumnName("NgayKT");
            });

            modelBuilder.Entity<NhaCc>(entity =>
            {
                entity.HasKey(e => e.MaNcc)
                    .HasName("PK__NhaCC__3A185DEB4883957D");

                entity.ToTable("NhaCC");

                entity.Property(e => e.MaNcc)
                    .HasMaxLength(20)
                    .HasColumnName("MaNCC");

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DienThoai)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.Fax)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SoTaiKhoan)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TenNcc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TenNCC");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__NhanVien__2725D70A91300C20");

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(20)
                    .HasColumnName("MaNV");

                entity.Property(e => e.Anh).HasMaxLength(200);

                entity.Property(e => e.MaCuaHang)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(11)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenNv)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TenNV");

                entity.HasOne(d => d.MaCuaHangNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaCuaHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NhanVien__MaCuaH__3F466844");
            });

            modelBuilder.Entity<PhieuNhap>(entity =>
            {
                entity.HasKey(e => e.MaPhieuNhap)
                    .HasName("PK__PhieuNha__1470EF3B46A49B30");

                entity.ToTable("PhieuNhap");

                entity.Property(e => e.MaPhieuNhap).HasMaxLength(20);

                entity.Property(e => e.MaCuaHang)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.MaNcc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("MaNCC");

                entity.Property(e => e.NgayNhap).HasColumnType("datetime");

                entity.Property(e => e.NguoiNhap)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ThanhToan).HasMaxLength(50);

                entity.HasOne(d => d.MaCuaHangNavigation)
                    .WithMany(p => p.PhieuNhaps)
                    .HasForeignKey(d => d.MaCuaHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PhieuNhap__MaCua__403A8C7D");

                entity.HasOne(d => d.MaNccNavigation)
                    .WithMany(p => p.PhieuNhaps)
                    .HasForeignKey(d => d.MaNcc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PhieuNhap__MaNCC__412EB0B6");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("PK__SanPham__2725081CC9F4D1C5");

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(20)
                    .HasColumnName("MaSP");

                entity.Property(e => e.DonGia).HasColumnType("money");

                entity.Property(e => e.DonViTinh)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaDm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MaDM");

                entity.Property(e => e.Slton).HasColumnName("SLTon");

                entity.Property(e => e.TenSp)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TenSP");

                entity.Property(e => e.ThuongHieu)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.XuatXu)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.MaDmNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaDm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SanPham__MaDM__4222D4EF");
            });

            modelBuilder.Entity<SanPhamKm>(entity =>
            {
                entity.HasKey(e => new { e.MaKm, e.MaSp })
                    .HasName("PK__SanPhamK__F5579F941D135435");

                entity.ToTable("SanPhamKM");

                entity.Property(e => e.MaKm)
                    .HasMaxLength(20)
                    .HasColumnName("MaKM");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(20)
                    .HasColumnName("MaSP");

                entity.Property(e => e.GiaKm).HasColumnName("GiaKM");

                entity.HasOne(d => d.MaKmNavigation)
                    .WithMany(p => p.SanPhamKms)
                    .HasForeignKey(d => d.MaKm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SanPhamKM__MaKM__4316F928");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.SanPhamKms)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SanPhamKM__MaSP__440B1D61");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.TenTk)
                    .HasName("PK__TaiKhoan__4CF9E776A868FB75");

                entity.ToTable("TaiKhoan");

                entity.Property(e => e.TenTk)
                    .HasMaxLength(30)
                    .HasColumnName("TenTK");

                entity.Property(e => e.MaNv)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("MaNV");

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.MaNvNavigation)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.MaNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TaiKhoan__MaNV__44FF419A");
            });

            modelBuilder.Entity<ThongTinHd>(entity =>
            {
                entity.HasKey(e => new { e.MaHd, e.MaSp })
                    .HasName("PK__ThongTin__F557F661D113B957");

                entity.ToTable("ThongTinHD");

                entity.Property(e => e.MaHd)
                    .HasMaxLength(20)
                    .HasColumnName("MaHD");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(20)
                    .HasColumnName("MaSP");

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany(p => p.ThongTinHds)
                    .HasForeignKey(d => d.MaHd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ThongTinHD__MaHD__45F365D3");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.ThongTinHds)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ThongTinHD__MaSP__46E78A0C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
