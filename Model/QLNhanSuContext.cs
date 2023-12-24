using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ck5.Model
{
    public partial class QLNhanSuContext : DbContext
    {
        public QLNhanSuContext()
        {
        }

        public QLNhanSuContext(DbContextOptions<QLNhanSuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NhanVien> NhanViens { get; set; } = null!;
        public virtual DbSet<PhongBan> PhongBans { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-EQDI98Q\\SQLEXPRESS;Initial Catalog=QLNhanSu;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__NhanVien__2725D70A1FC79727");

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MaNV")
                    .IsFixedLength();

                entity.Property(e => e.Gioitinh).HasMaxLength(3);

                entity.Property(e => e.HoTen).HasMaxLength(30);

                entity.Property(e => e.MaPb)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("MaPB")
                    .IsFixedLength();

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.NgoaiNgu).HasMaxLength(20);

                entity.HasOne(d => d.MaPbNavigation)
                    .WithMany(p => p.NhanViens)
                    .HasForeignKey(d => d.MaPb)
                    .HasConstraintName("FK__NhanVien__MaPB__398D8EEE");
            });

            modelBuilder.Entity<PhongBan>(entity =>
            {
                entity.HasKey(e => e.MaPb)
                    .HasName("PK__PhongBan__2725E7E4554C5C63");

                entity.ToTable("PhongBan");

                entity.Property(e => e.MaPb)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("MaPB")
                    .IsFixedLength();

                entity.Property(e => e.NgayThanhLap).HasColumnType("date");

                entity.Property(e => e.TenPb)
                    .HasMaxLength(30)
                    .HasColumnName("TenPB");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
