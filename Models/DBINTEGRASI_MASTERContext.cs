using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ormawa.Models
{
    public partial class DBINTEGRASI_MASTERContext : DbContext
    {
        public virtual DbSet<BiodataOrang> BiodataOrang { get; set; }
        public virtual DbSet<Orang> Orang { get; set; }

        public DBINTEGRASI_MASTERContext(DbContextOptions<DBINTEGRASI_MASTERContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BiodataOrang>(entity =>
            {
                entity.ToTable("BiodataOrang", "IPBMst");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AgamaId).HasColumnName("AgamaID");

                entity.Property(e => e.GolonganDarahId).HasColumnName("GolonganDarahID");

                entity.Property(e => e.PekerjaanId).HasColumnName("PekerjaanID");

                entity.Property(e => e.PertamaMerokok)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StatusKawinId).HasColumnName("StatusKawinID");

                entity.Property(e => e.SukuBangsaId).HasColumnName("SukuBangsaID");

                entity.Property(e => e.WargaNegaraId).HasColumnName("WargaNegaraID");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.BiodataOrang)
                    .HasForeignKey<BiodataOrang>(d => d.Id)
                    .HasConstraintName("FK_Biodata_Orang");
            });

            modelBuilder.Entity<Orang>(entity =>
            {
                entity.ToTable("Orang", "IPBMst");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Anakvkey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JenisKelaminId).HasColumnName("JenisKelaminID");

                entity.Property(e => e.Nama)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nimppdhkey)
                    .HasColumnName("NIMPPDHKey")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nims0key)
                    .HasColumnName("NIMS0Key")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nims1key)
                    .HasColumnName("NIMS1key")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nims2key)
                    .HasColumnName("NIMS2Key")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nims3key)
                    .HasColumnName("NIMS3Key")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrangTuaVkey)
                    .HasColumnName("OrangTuaVKey")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasanganKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pgwaikey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.S2lama)
                    .HasColumnName("S2Lama")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.S3lama)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TanggalLahir).HasColumnType("date");

                entity.Property(e => e.TempatLahir)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TempatLahirId).HasColumnName("TempatLahirID");
            });
        }
    }
}
