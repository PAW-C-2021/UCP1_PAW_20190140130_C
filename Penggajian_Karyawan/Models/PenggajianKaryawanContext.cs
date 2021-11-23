using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Penggajian_Karyawan.Models
{
    public partial class PenggajianKaryawanContext : DbContext
    {
        public PenggajianKaryawanContext()
        {
        }

        public PenggajianKaryawanContext(DbContextOptions<PenggajianKaryawanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Gaji> Gajis { get; set; }
        public virtual DbSet<Golongan> Golongans { get; set; }
        public virtual DbSet<Pegawai> Pegawais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Gaji>(entity =>
            {
                entity.HasKey(e => e.IdGaji);

                entity.ToTable("Gaji");

                entity.Property(e => e.IdGaji)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Gaji");

                entity.Property(e => e.IdGolongan).HasColumnName("ID_Golongan");

                entity.Property(e => e.IdPegawai).HasColumnName("ID_Pegawai");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Potongan)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Tunjangan)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Golongan>(entity =>
            {
                entity.HasKey(e => e.IdGolongan);

                entity.ToTable("Golongan");

                entity.Property(e => e.IdGolongan)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Golongan");

                entity.Property(e => e.JenisGolongan)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Jenis_Golongan");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pegawai>(entity =>
            {
                entity.HasKey(e => e.IdPegawai)
                    .HasName("PK_Data_Pegawai");

                entity.ToTable("Pegawai");

                entity.Property(e => e.IdPegawai)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Pegawai");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JenisKelamin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Jenis_Kelamin");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
