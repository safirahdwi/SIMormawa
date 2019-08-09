using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ormawa.Models
{
    public partial class DBINTEGRASI_MASTER_BAYUPPKU2Context : DbContext
    {
        public DBINTEGRASI_MASTER_BAYUPPKU2Context()
        {
        }

        public DBINTEGRASI_MASTER_BAYUPPKU2Context(DbContextOptions<DBINTEGRASI_MASTER_BAYUPPKU2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AnggotaOrmawa> AnggotaOrmawa { get; set; }
        public virtual DbSet<BiodataOrang> BiodataOrang { get; set; }
        public virtual DbSet<DaftarDokumenOrmawa> DaftarDokumenOrmawa { get; set; }
        public virtual DbSet<Departemen> Departemen { get; set; }
        public virtual DbSet<DokumenOrmawa> DokumenOrmawa { get; set; }
        public virtual DbSet<HakAksesPengguna> HakAksesPengguna { get; set; }
        public virtual DbSet<JabatanOrmawa> JabatanOrmawa { get; set; }
        public virtual DbSet<JenisDokumen> JenisDokumen { get; set; }
        public virtual DbSet<JenisKegiatanOrmawa> JenisKegiatanOrmawa { get; set; }
        public virtual DbSet<JenisKelamin> JenisKelamin { get; set; }
        public virtual DbSet<JenisOrganisasi> JenisOrganisasi { get; set; }
        public virtual DbSet<JenisPengguna> JenisPengguna { get; set; }
        public virtual DbSet<JenisPrestasiOrmawa> JenisPrestasiOrmawa { get; set; }
        public virtual DbSet<KalenderKegiatanOrmawa> KalenderKegiatanOrmawa { get; set; }
        public virtual DbSet<KegiatanOrmawa> KegiatanOrmawa { get; set; }
        public virtual DbSet<Mahasiswa> Mahasiswa { get; set; }
        public virtual DbSet<MahasiswaDiploma> MahasiswaDiploma { get; set; }
        public virtual DbSet<MahasiswaDoktor> MahasiswaDoktor { get; set; }
        public virtual DbSet<MahasiswaEkstensi> MahasiswaEkstensi { get; set; }
        public virtual DbSet<MahasiswaMagister> MahasiswaMagister { get; set; }
        public virtual DbSet<MahasiswaProfesi> MahasiswaProfesi { get; set; }
        public virtual DbSet<MahasiswaSarjana> MahasiswaSarjana { get; set; }
        public virtual DbSet<Mayor> Mayor { get; set; }
        public virtual DbSet<MediaPublikasiOrmawa> MediaPublikasiOrmawa { get; set; }
        public virtual DbSet<MutasiPegawai> MutasiPegawai { get; set; }
        public virtual DbSet<Orang> Orang { get; set; }
        public virtual DbSet<OrganisasiOrmawa> OrganisasiOrmawa { get; set; }
        public virtual DbSet<PengajuanProposalKegiatan> PengajuanProposalKegiatan { get; set; }
        public virtual DbSet<Pengguna> Pengguna { get; set; }
        public virtual DbSet<PrestasiOrmawa> PrestasiOrmawa { get; set; }
        public virtual DbSet<ProgramKeahlian> ProgramKeahlian { get; set; }
        public virtual DbSet<PublikasiOrmawa> PublikasiOrmawa { get; set; }
        public virtual DbSet<StatusPengajuan> StatusPengajuan { get; set; }
        public virtual DbSet<StrukturOrganisasi> StrukturOrganisasi { get; set; }
        public virtual DbSet<StrukturalOrmawa> StrukturalOrmawa { get; set; }
        public virtual DbSet<TahapanPengajuan> TahapanPengajuan { get; set; }
        public virtual DbSet<TipeKegiatanOrmawa> TipeKegiatanOrmawa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=172.17.0.136;Database=DBINTEGRASI_MASTER_BAYUPPKU2;uid=sys-ormawa;pwd=PKLormawa1p8;ConnectRetryCount=0");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<AnggotaOrmawa>(entity =>
            {
                entity.ToTable("AnggotaOrmawa", "OrmMst");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MahasiswaId).HasColumnName("MahasiswaID");

                entity.Property(e => e.OrganisasiOrmawaId).HasColumnName("OrganisasiOrmawaID");

                entity.Property(e => e.TanggalBergabung).HasColumnType("date");

                entity.HasOne(d => d.Mahasiswa)
                    .WithMany(p => p.AnggotaOrmawa)
                    .HasForeignKey(d => d.MahasiswaId)
                    .HasConstraintName("FK_AnggotaOrmawa_Mahasiswa");

                entity.HasOne(d => d.OrganisasiOrmawa)
                    .WithMany(p => p.AnggotaOrmawa)
                    .HasForeignKey(d => d.OrganisasiOrmawaId)
                    .HasConstraintName("FK_AnggotaOrmawa_OrganisasiOrmawa");
            });

            modelBuilder.Entity<BiodataOrang>(entity =>
            {
                entity.ToTable("BiodataOrang", "IPBMst");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AgamaId).HasColumnName("AgamaID");

                entity.Property(e => e.AsalNegaraId).HasColumnName("AsalNegaraID");

                entity.Property(e => e.GolonganDarahId).HasColumnName("GolonganDarahID");

                entity.Property(e => e.PekerjaanId).HasColumnName("PekerjaanID");

                entity.Property(e => e.PengubahId).HasColumnName("PengubahID");

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

            modelBuilder.Entity<DaftarDokumenOrmawa>(entity =>
            {
                entity.ToTable("DaftarDokumenOrmawa", "OrmRef");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DokumenOrmawaId).HasColumnName("DokumenOrmawaID");

                entity.Property(e => e.PengajuanProposalKegiatanId).HasColumnName("PengajuanProposalKegiatanID");

                entity.HasOne(d => d.DokumenOrmawa)
                    .WithMany(p => p.DaftarDokumenOrmawa)
                    .HasForeignKey(d => d.DokumenOrmawaId)
                    .HasConstraintName("FK_DaftarDokumenOrmawa_DokumenOrmawa");

                entity.HasOne(d => d.PengajuanProposalKegiatan)
                    .WithMany(p => p.DaftarDokumenOrmawa)
                    .HasForeignKey(d => d.PengajuanProposalKegiatanId)
                    .HasConstraintName("FK_DaftarDokumenOrmawa_PengajuanProposalKegiatan");
            });

            modelBuilder.Entity<Departemen>(entity =>
            {
                entity.ToTable("Departemen", "IPBMst");

                entity.HasIndex(e => e.Kode)
                    .HasName("IX_refDepartemen");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DepartemenBkey)
                    .HasColumnName("DepartemenBKey")
                    .HasMaxLength(10);

                entity.Property(e => e.FakultasId).HasColumnName("FakultasID");

                entity.Property(e => e.Kode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TanggalDibentuk).HasColumnType("date");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Departemen)
                    .HasForeignKey<Departemen>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departemen_StrukturOrganisasi");
            });

            modelBuilder.Entity<DokumenOrmawa>(entity =>
            {
                entity.ToTable("DokumenOrmawa", "OrmRef");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.JenisDokumenId).HasColumnName("JenisDokumenID");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Urldokumen)
                    .HasColumnName("URLDokumen")
                    .HasColumnType("text");

                entity.HasOne(d => d.JenisDokumen)
                    .WithMany(p => p.DokumenOrmawa)
                    .HasForeignKey(d => d.JenisDokumenId)
                    .HasConstraintName("FK_DokumenOrmawa_JenisDokumen");
            });

            modelBuilder.Entity<HakAksesPengguna>(entity =>
            {
                entity.ToTable("HakAksesPengguna", "IPBTrx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.JenisPenggunaId).HasColumnName("JenisPenggunaID");

                entity.Property(e => e.PenggunaId).HasColumnName("PenggunaID");

                entity.Property(e => e.StrukturOrganisasiId).HasColumnName("StrukturOrganisasiID");

                entity.HasOne(d => d.JenisPengguna)
                    .WithMany(p => p.HakAksesPengguna)
                    .HasForeignKey(d => d.JenisPenggunaId)
                    .HasConstraintName("FK_HakAksesPengguna_JenisPengguna");

                entity.HasOne(d => d.Pengguna)
                    .WithMany(p => p.HakAksesPengguna)
                    .HasForeignKey(d => d.PenggunaId)
                    .HasConstraintName("FK_HakAksesPengguna_Pengguna");

                entity.HasOne(d => d.StrukturOrganisasi)
                    .WithMany(p => p.HakAksesPengguna)
                    .HasForeignKey(d => d.StrukturOrganisasiId)
                    .HasConstraintName("FK_HakAksesPengguna_StrukturOrganisasi");
            });

            modelBuilder.Entity<JabatanOrmawa>(entity =>
            {
                entity.ToTable("JabatanOrmawa", "OrmRef");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JenisDokumen>(entity =>
            {
                entity.ToTable("JenisDokumen", "OrmRef");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Keterangan).HasColumnType("text");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JenisKegiatanOrmawa>(entity =>
            {
                entity.ToTable("JenisKegiatanOrmawa", "OrmRef");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JenisKelamin>(entity =>
            {
                entity.ToTable("JenisKelamin", "IPBRef");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JenisOrganisasi>(entity =>
            {
                entity.ToTable("JenisOrganisasi", "OrmRef");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JenisPengguna>(entity =>
            {
                entity.ToTable("JenisPengguna", "IPBRef");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.JenisSistemId).HasColumnName("JenisSistemID");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JenisPrestasiOrmawa>(entity =>
            {
                entity.ToTable("JenisPrestasiOrmawa", "OrmRef");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KalenderKegiatanOrmawa>(entity =>
            {
                entity.ToTable("KalenderKegiatanOrmawa", "OrmHis");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KegiatanOrmawaId).HasColumnName("KegiatanOrmawaID");

                entity.Property(e => e.Tmt)
                    .HasColumnName("TMT")
                    .HasColumnType("date");

                entity.Property(e => e.Tst)
                    .HasColumnName("TST")
                    .HasColumnType("date");

                entity.HasOne(d => d.KegiatanOrmawa)
                    .WithMany(p => p.KalenderKegiatanOrmawa)
                    .HasForeignKey(d => d.KegiatanOrmawaId)
                    .HasConstraintName("FK_KalenderKegiatanOrmawa_KegiatanOrmawa");
            });

            modelBuilder.Entity<KegiatanOrmawa>(entity =>
            {
                entity.ToTable("KegiatanOrmawa", "OrmTrx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OrganisasiOrmawaId).HasColumnName("OrganisasiOrmawaID");

                entity.Property(e => e.PengajuanProposalKegiatanId).HasColumnName("PengajuanProposalKegiatanID");

                entity.HasOne(d => d.OrganisasiOrmawa)
                    .WithMany(p => p.KegiatanOrmawa)
                    .HasForeignKey(d => d.OrganisasiOrmawaId)
                    .HasConstraintName("FK_KegiatanOrmawa_OrganisasiOrmawa");

                entity.HasOne(d => d.PengajuanProposalKegiatan)
                    .WithMany(p => p.KegiatanOrmawa)
                    .HasForeignKey(d => d.PengajuanProposalKegiatanId)
                    .HasConstraintName("FK_KegiatanOrmawa_PengajuanProposalKegiatan");
            });

            modelBuilder.Entity<Mahasiswa>(entity =>
            {
                entity.ToTable("Mahasiswa", "AkdMst");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nimkey)
                    .HasColumnName("nimkey")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.OrangId).HasColumnName("OrangID");

                entity.Property(e => e.StrataId).HasColumnName("StrataID");

                entity.HasOne(d => d.Orang)
                    .WithMany(p => p.Mahasiswa)
                    .HasForeignKey(d => d.OrangId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Mahasiswa_Orang");
            });

            modelBuilder.Entity<MahasiswaDiploma>(entity =>
            {
                entity.ToTable("MahasiswaDiploma", "AkdMst");

                entity.HasIndex(e => e.MahasiswaId)
                    .HasName("UQ_MahasiswaDiploma")
                    .IsUnique();

                entity.HasIndex(e => e.Nim);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bpmp).HasColumnName("BPMP");

                entity.Property(e => e.JalurMasukId).HasColumnName("JalurMasukID");

                entity.Property(e => e.MahasiswaId).HasColumnName("MahasiswaID");

                entity.Property(e => e.Nim)
                    .IsRequired()
                    .HasColumnName("NIM")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.PembimbingAkademik)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PindahanPt)
                    .HasColumnName("PindahanPT")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProgramKeahlianId).HasColumnName("ProgramKeahlianID");

                entity.Property(e => e.StatusAkademikId).HasColumnName("StatusAkademikID");

                entity.Property(e => e.TahunAkademikId).HasColumnName("TahunAkademikID");

                entity.Property(e => e.TahunSemesterMasukId).HasColumnName("TahunSemesterMasukID");

                entity.Property(e => e.TanggalMasuk).HasColumnType("date");

                entity.HasOne(d => d.Mahasiswa)
                    .WithOne(p => p.MahasiswaDiploma)
                    .HasForeignKey<MahasiswaDiploma>(d => d.MahasiswaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MahasiswaDiploma_Mahasiswa");

                entity.HasOne(d => d.ProgramKeahlian)
                    .WithMany(p => p.MahasiswaDiploma)
                    .HasForeignKey(d => d.ProgramKeahlianId)
                    .HasConstraintName("FK_MahasiswaDiploma_ProgramKeahlian");
            });

            modelBuilder.Entity<MahasiswaDoktor>(entity =>
            {
                entity.ToTable("MahasiswaDoktor", "AkdMst");

                entity.HasIndex(e => e.MahasiswaId)
                    .HasName("UQ_MahasiswaDoktor")
                    .IsUnique();

                entity.HasIndex(e => e.Nim);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GelarBelakang)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GelarDepan)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.JalurMasukId).HasColumnName("JalurMasukID");

                entity.Property(e => e.MahasiswaId).HasColumnName("MahasiswaID");

                entity.Property(e => e.MayorId).HasColumnName("MayorID");

                entity.Property(e => e.Nim)
                    .IsRequired()
                    .HasColumnName("NIM")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Sponsor)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StatusAkademikId).HasColumnName("StatusAkademikID");

                entity.Property(e => e.TahunAkademikId).HasColumnName("TahunAkademikID");

                entity.Property(e => e.TahunSemesterMasukId).HasColumnName("TahunSemesterMasukID");

                entity.Property(e => e.TanggalMasuk).HasColumnType("datetime");

                entity.HasOne(d => d.Mahasiswa)
                    .WithOne(p => p.MahasiswaDoktor)
                    .HasForeignKey<MahasiswaDoktor>(d => d.MahasiswaId)
                    .HasConstraintName("FK_MahasiswaDoktor_Mahasiswa");

                entity.HasOne(d => d.Mayor)
                    .WithMany(p => p.MahasiswaDoktor)
                    .HasForeignKey(d => d.MayorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MahasiswaDoktor_Mayor");
            });

            modelBuilder.Entity<MahasiswaEkstensi>(entity =>
            {
                entity.HasKey(e => e.MahasiswaSarjanaId)
                    .HasName("PK__Mahasisw__896F7314E61DA4A5");

                entity.ToTable("MahasiswaEkstensi", "AkdMst");

                entity.Property(e => e.MahasiswaSarjanaId)
                    .HasColumnName("MahasiswaSarjanaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AsalPerguruanTinggiId).HasColumnName("AsalPerguruanTinggiID");

                entity.Property(e => e.FakultasAsal)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ipksebelumnya).HasColumnName("IPKSebelumnya");

                entity.Property(e => e.ProgramStudiAsal)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sksdiakui).HasColumnName("SKSDiakui");

                entity.HasOne(d => d.MahasiswaSarjana)
                    .WithOne(p => p.MahasiswaEkstensi)
                    .HasForeignKey<MahasiswaEkstensi>(d => d.MahasiswaSarjanaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MahasiswaSarjana_MahasiswaEkstensi");
            });

            modelBuilder.Entity<MahasiswaMagister>(entity =>
            {
                entity.ToTable("MahasiswaMagister", "AkdMst");

                entity.HasIndex(e => e.MahasiswaId)
                    .HasName("UQ_MahasiswaMagister")
                    .IsUnique();

                entity.HasIndex(e => e.Nim);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GelarBelakang)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GelarDepan)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.JalurMasukId).HasColumnName("JalurMasukID");

                entity.Property(e => e.MahasiswaId).HasColumnName("MahasiswaID");

                entity.Property(e => e.MayorId).HasColumnName("MayorID");

                entity.Property(e => e.Nim)
                    .IsRequired()
                    .HasColumnName("NIM")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Sponsor)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StatusAkademikId).HasColumnName("StatusAkademikID");

                entity.Property(e => e.TahunAkademikId).HasColumnName("TahunAkademikID");

                entity.Property(e => e.TahunSemesterMasukId).HasColumnName("TahunSemesterMasukID");

                entity.Property(e => e.TanggalMasuk).HasColumnType("datetime");

                entity.HasOne(d => d.Mahasiswa)
                    .WithOne(p => p.MahasiswaMagister)
                    .HasForeignKey<MahasiswaMagister>(d => d.MahasiswaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MahasiswaMagister_Mahasiswa");

                entity.HasOne(d => d.Mayor)
                    .WithMany(p => p.MahasiswaMagister)
                    .HasForeignKey(d => d.MayorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MahasiswaMagister_Mayor");
            });

            modelBuilder.Entity<MahasiswaProfesi>(entity =>
            {
                entity.HasKey(e => e.MahasiswaId);

                entity.ToTable("MahasiswaProfesi", "AkdMst");

                entity.Property(e => e.MahasiswaId)
                    .HasColumnName("MahasiswaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.JalurMasukId).HasColumnName("JalurMasukID");

                entity.Property(e => e.MayorId).HasColumnName("MayorID");

                entity.Property(e => e.Nim)
                    .HasColumnName("NIM")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusAkademikId).HasColumnName("StatusAkademikID");

                entity.Property(e => e.TahunAkademikId).HasColumnName("TahunAkademikID");

                entity.Property(e => e.TahunSemesterMasukId).HasColumnName("TahunSemesterMasukID");

                entity.Property(e => e.TanggalMasuk).HasColumnType("date");

                entity.HasOne(d => d.Mahasiswa)
                    .WithOne(p => p.MahasiswaProfesi)
                    .HasForeignKey<MahasiswaProfesi>(d => d.MahasiswaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MahasiswaProfesi_Mahasiswa");

                entity.HasOne(d => d.Mayor)
                    .WithMany(p => p.MahasiswaProfesi)
                    .HasForeignKey(d => d.MayorId)
                    .HasConstraintName("FK_MahasiswaProfesi_Mayor");
            });

            modelBuilder.Entity<MahasiswaSarjana>(entity =>
            {
                entity.ToTable("MahasiswaSarjana", "AkdMst");

                entity.HasIndex(e => e.MahasiswaId)
                    .HasName("IX_MahasiswaSarjana")
                    .IsUnique();

                entity.HasIndex(e => e.Nim);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IsTpb).HasColumnName("isTPB");

                entity.Property(e => e.JalurMasukId).HasColumnName("JalurMasukID");

                entity.Property(e => e.MahasiswaId).HasColumnName("MahasiswaID");

                entity.Property(e => e.MayorId).HasColumnName("MayorID");

                entity.Property(e => e.MinorId).HasColumnName("MinorID");

                entity.Property(e => e.Nim)
                    .IsRequired()
                    .HasColumnName("NIM")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.StatusAkademikId).HasColumnName("StatusAkademikID");

                entity.Property(e => e.TahunAkademikId).HasColumnName("TahunAkademikID");

                entity.Property(e => e.TahunAkademikTpbid).HasColumnName("TahunAkademikTPBID");

                entity.Property(e => e.TahunSemesterMasukId).HasColumnName("TahunSemesterMasukID");

                entity.Property(e => e.TanggalMasuk).HasColumnType("date");

                entity.HasOne(d => d.Mahasiswa)
                    .WithOne(p => p.MahasiswaSarjana)
                    .HasForeignKey<MahasiswaSarjana>(d => d.MahasiswaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MahasiswaSarjana_Mahasiswa");

                entity.HasOne(d => d.Mayor)
                    .WithMany(p => p.MahasiswaSarjana)
                    .HasForeignKey(d => d.MayorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MahasiswaSarjana_Mayor");
            });

            modelBuilder.Entity<Mayor>(entity =>
            {
                entity.ToTable("Mayor", "AkdMst");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DepartemenId).HasColumnName("DepartemenID");

                entity.Property(e => e.Inisial)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Kode).HasMaxLength(10);

                entity.Property(e => e.KodePdpt)
                    .HasColumnName("KodePDPT")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.MayorPascasarjanaBkey)
                    .HasColumnName("MayorPascasarjanaBKey")
                    .HasMaxLength(5);

                entity.Property(e => e.MayorSarjanaBkey)
                    .HasColumnName("MayorSarjanaBKey")
                    .HasMaxLength(5);

                entity.Property(e => e.Nama)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.NamaEn).HasMaxLength(255);

                entity.Property(e => e.NomorSkdibentuk)
                    .HasColumnName("NomorSKDibentuk")
                    .HasMaxLength(15);

                entity.Property(e => e.NomorSkditutup)
                    .HasColumnName("NomorSKDitutup")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RumpunIlmuProgramStudiId).HasColumnName("RumpunIlmuProgramStudiID");

                entity.Property(e => e.StrataId).HasColumnName("StrataID");

                entity.Property(e => e.StrukturOrganisasiId).HasColumnName("StrukturOrganisasiID");

                entity.Property(e => e.TanggalDibentuk).HasColumnType("date");

                entity.Property(e => e.TanggalDitutup).HasColumnType("date");

                entity.HasOne(d => d.Departemen)
                    .WithMany(p => p.Mayor)
                    .HasForeignKey(d => d.DepartemenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mayor_Departemen");
            });

            modelBuilder.Entity<MediaPublikasiOrmawa>(entity =>
            {
                entity.ToTable("MediaPublikasiOrmawa", "OrmMst");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PublikasiOrmawaId).HasColumnName("PublikasiOrmawaID");

                entity.Property(e => e.Urlmedia)
                    .HasColumnName("URLMedia")
                    .HasColumnType("text");

                entity.HasOne(d => d.PublikasiOrmawa)
                    .WithMany(p => p.MediaPublikasiOrmawa)
                    .HasForeignKey(d => d.PublikasiOrmawaId)
                    .HasConstraintName("FK_MediaPublikasiOrmawa_PublikasiOrmawa");
            });

            modelBuilder.Entity<MutasiPegawai>(entity =>
            {
                entity.ToTable("MutasiPegawai", "PegHis");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MutasiPegawaiBkey)
                    .HasColumnName("MutasiPegawaiBKey")
                    .HasMaxLength(255);

                entity.Property(e => e.NomorSk)
                    .IsRequired()
                    .HasColumnName("NomorSK")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PegawaiId).HasColumnName("PegawaiID");

                entity.Property(e => e.StrukturOrganisasiId).HasColumnName("StrukturOrganisasiID");

                entity.Property(e => e.TanggalEntri).HasColumnType("datetime");

                entity.Property(e => e.Tmt)
                    .HasColumnName("TMT")
                    .HasColumnType("date");

                entity.HasOne(d => d.StrukturOrganisasi)
                    .WithMany(p => p.MutasiPegawai)
                    .HasForeignKey(d => d.StrukturOrganisasiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MutasiPegawai_StrukturOrganisasi");
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

                entity.HasOne(d => d.JenisKelamin)
                    .WithMany(p => p.Orang)
                    .HasForeignKey(d => d.JenisKelaminId)
                    .HasConstraintName("FK_Orang_JenisKelamin");
            });

            modelBuilder.Entity<OrganisasiOrmawa>(entity =>
            {
                entity.ToTable("OrganisasiOrmawa", "OrmMst");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.JenisOrganisasiId).HasColumnName("JenisOrganisasiID");

                entity.Property(e => e.Nama)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NamaEn)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomorSk)
                    .HasColumnName("NomorSK")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tmt)
                    .HasColumnName("TMT")
                    .HasColumnType("date");

                entity.Property(e => e.Tst)
                    .HasColumnName("TST")
                    .HasColumnType("date");

                entity.HasOne(d => d.JenisOrganisasi)
                    .WithMany(p => p.OrganisasiOrmawa)
                    .HasForeignKey(d => d.JenisOrganisasiId)
                    .HasConstraintName("FK_OrganisasiOrmawa_JenisOrganisasi");
            });

            modelBuilder.Entity<PengajuanProposalKegiatan>(entity =>
            {
                entity.ToTable("PengajuanProposalKegiatan", "OrmTrx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AnggotaOrmawaId).HasColumnName("AnggotaOrmawaID");

                entity.Property(e => e.JenisKegiatanOrmawaId).HasColumnName("JenisKegiatanOrmawaID");

                entity.Property(e => e.Kegiatan).IsUnicode(false);

                entity.Property(e => e.PenanggungJawabId).HasColumnName("PenanggungJawabID");

                entity.Property(e => e.TimeApproved).HasColumnType("datetime");

                entity.Property(e => e.TipeKegiatanOrmawaId).HasColumnName("TipeKegiatanOrmawaID");

                entity.HasOne(d => d.AnggotaOrmawa)
                    .WithMany(p => p.PengajuanProposalKegiatan)
                    .HasForeignKey(d => d.AnggotaOrmawaId)
                    .HasConstraintName("FK_PengajuanProposalKegiatan_AnggotaOrmawa");

                entity.HasOne(d => d.ApprovedByNavigation)
                    .WithMany(p => p.PengajuanProposalKegiatanApprovedByNavigation)
                    .HasForeignKey(d => d.ApprovedBy)
                    .HasConstraintName("FK_PengajuanProposalKegiatan_Orang");

                entity.HasOne(d => d.JenisKegiatanOrmawa)
                    .WithMany(p => p.PengajuanProposalKegiatan)
                    .HasForeignKey(d => d.JenisKegiatanOrmawaId)
                    .HasConstraintName("FK_PengajuanProposalKegiatan_JenisKegiatanOrmawa");

                entity.HasOne(d => d.PenanggungJawab)
                    .WithMany(p => p.PengajuanProposalKegiatanPenanggungJawab)
                    .HasForeignKey(d => d.PenanggungJawabId)
                    .HasConstraintName("FK_PengajuanProposalKegiatan_Orang1");

                entity.HasOne(d => d.TipeKegiatanOrmawa)
                    .WithMany(p => p.PengajuanProposalKegiatan)
                    .HasForeignKey(d => d.TipeKegiatanOrmawaId)
                    .HasConstraintName("FK_PengajuanProposalKegiatan_TipeKegiatanOrmawa");
            });

            modelBuilder.Entity<Pengguna>(entity =>
            {
                entity.ToTable("Pengguna", "IPBMst");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IsBlokir).HasColumnName("isBlokir");

                entity.Property(e => e.OrangId).HasColumnName("OrangID");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WaktuDibuat).HasColumnType("datetime");

                entity.HasOne(d => d.Orang)
                    .WithMany(p => p.Pengguna)
                    .HasForeignKey(d => d.OrangId)
                    .HasConstraintName("FK_Pengguna_Orang");
            });

            modelBuilder.Entity<PrestasiOrmawa>(entity =>
            {
                entity.ToTable("PrestasiOrmawa", "OrmMst");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InstitusiPenyelenggara)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.JenisPrestasiOrmawaId).HasColumnName("JenisPrestasiOrmawaID");

                entity.Property(e => e.MahasiswaId).HasColumnName("MahasiswaID");

                entity.Property(e => e.NamaPrestasi)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OrganisasiOrmawaId).HasColumnName("OrganisasiOrmawaID");

                entity.HasOne(d => d.JenisPrestasiOrmawa)
                    .WithMany(p => p.PrestasiOrmawa)
                    .HasForeignKey(d => d.JenisPrestasiOrmawaId)
                    .HasConstraintName("FK_PrestasiOrmawa_JenisPrestasiOrmawa");

                entity.HasOne(d => d.Mahasiswa)
                    .WithMany(p => p.PrestasiOrmawa)
                    .HasForeignKey(d => d.MahasiswaId)
                    .HasConstraintName("FK_PrestasiOrmawa_Mahasiswa");

                entity.HasOne(d => d.OrganisasiOrmawa)
                    .WithMany(p => p.PrestasiOrmawa)
                    .HasForeignKey(d => d.OrganisasiOrmawaId)
                    .HasConstraintName("FK_PrestasiOrmawa_OrganisasiOrmawa");
            });

            modelBuilder.Entity<ProgramKeahlian>(entity =>
            {
                entity.ToTable("ProgramKeahlian", "AkdMst");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Akreditasi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Alamat)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DirektoratId).HasColumnName("DirektoratID");

                entity.Property(e => e.Inisial)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsPdd).HasColumnName("IsPDD");

                entity.Property(e => e.Kode).HasMaxLength(10);

                entity.Property(e => e.KodePdpt)
                    .HasColumnName("KodePDPT")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.KonfirmasiBanpt)
                    .HasColumnName("KonfirmasiBANPT")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KotaKabupatenId).HasColumnName("KotaKabupatenID");

                entity.Property(e => e.Nama)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.NamaEn).HasMaxLength(255);

                entity.Property(e => e.NoSkBan)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoSkDikti)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProgramKeahlianBkey)
                    .HasColumnName("ProgramKeahlianBKey")
                    .HasMaxLength(10);

                entity.Property(e => e.StatusAkredikasi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusProgramStudi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StrukturOrganisasiId).HasColumnName("StrukturOrganisasiID");

                entity.Property(e => e.TanggalAkhirSkBan).HasColumnType("datetime");

                entity.Property(e => e.TanggalAkhirSkDikti).HasColumnType("datetime");

                entity.Property(e => e.TanggalDibentuk).HasColumnType("date");

                entity.Property(e => e.TanggalSkBan).HasColumnType("datetime");

                entity.Property(e => e.TanggalSkdikti)
                    .HasColumnName("TanggalSKDikti")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<PublikasiOrmawa>(entity =>
            {
                entity.ToTable("PublikasiOrmawa", "OrmMst");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Isi).HasColumnType("text");

                entity.Property(e => e.Judul).HasColumnType("text");

                entity.Property(e => e.OrganisasiOrmawaId).HasColumnName("OrganisasiOrmawaID");

                entity.Property(e => e.TanggalInsert).HasColumnType("datetime");

                entity.HasOne(d => d.OrganisasiOrmawa)
                    .WithMany(p => p.PublikasiOrmawa)
                    .HasForeignKey(d => d.OrganisasiOrmawaId)
                    .HasConstraintName("FK_PublikasiOrmawa_OrganisasiOrmawa");
            });

            modelBuilder.Entity<StatusPengajuan>(entity =>
            {
                entity.ToTable("StatusPengajuan", "OrmRef");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StrukturOrganisasi>(entity =>
            {
                entity.ToTable("StrukturOrganisasi", "IPBMst");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Inisial)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KelompokOrganisasiId).HasColumnName("KelompokOrganisasiID");

                entity.Property(e => e.KelompokStrukturId).HasColumnName("KelompokStrukturID");

                entity.Property(e => e.KodeGl)
                    .HasColumnName("KodeGL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nama)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NamaEn)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NamaJabatan)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomorSk)
                    .HasColumnName("NomorSK")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SkkeputusanId).HasColumnName("SKKeputusanID");

                entity.Property(e => e.Sobkey)
                    .HasColumnName("SOBKey")
                    .HasMaxLength(10);

                entity.Property(e => e.StrukturOrganisasiId).HasColumnName("StrukturOrganisasiID");

                entity.HasOne(d => d.StrukturOrganisasiNavigation)
                    .WithMany(p => p.InverseStrukturOrganisasiNavigation)
                    .HasForeignKey(d => d.StrukturOrganisasiId)
                    .HasConstraintName("FK_StrukturOrganisasi_selfStrukturOrganisasi");
            });

            modelBuilder.Entity<StrukturalOrmawa>(entity =>
            {
                entity.ToTable("StrukturalOrmawa", "OrmMst");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AnggotaOrmawaId).HasColumnName("AnggotaOrmawaID");

                entity.Property(e => e.JabatanOrmawaId).HasColumnName("JabatanOrmawaID");

                entity.Property(e => e.OrganisasiOrmawaId).HasColumnName("OrganisasiOrmawaID");

                entity.Property(e => e.Tmt)
                    .HasColumnName("TMT")
                    .HasColumnType("date");

                entity.Property(e => e.Tst)
                    .HasColumnName("TST")
                    .HasColumnType("date");

                entity.HasOne(d => d.AnggotaOrmawa)
                    .WithMany(p => p.StrukturalOrmawa)
                    .HasForeignKey(d => d.AnggotaOrmawaId)
                    .HasConstraintName("FK_StrukturalOrmawa_AnggotaOrmawa");

                entity.HasOne(d => d.JabatanOrmawa)
                    .WithMany(p => p.StrukturalOrmawa)
                    .HasForeignKey(d => d.JabatanOrmawaId)
                    .HasConstraintName("FK_StrukturalOrmawa_JabatanOrmawa");

                entity.HasOne(d => d.OrganisasiOrmawa)
                    .WithMany(p => p.StrukturalOrmawa)
                    .HasForeignKey(d => d.OrganisasiOrmawaId)
                    .HasConstraintName("FK_StrukturalOrmawa_OrganisasiOrmawa");
            });

            modelBuilder.Entity<TahapanPengajuan>(entity =>
            {
                entity.ToTable("TahapanPengajuan", "OrmRef");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Keterangan).HasColumnType("text");

                entity.Property(e => e.PengajuanProposalKegiatanId).HasColumnName("PengajuanProposalKegiatanID");

                entity.Property(e => e.StatusPengajuanId).HasColumnName("StatusPengajuanID");

                entity.HasOne(d => d.PengajuanProposalKegiatan)
                    .WithMany(p => p.TahapanPengajuan)
                    .HasForeignKey(d => d.PengajuanProposalKegiatanId)
                    .HasConstraintName("FK_TahapanPengajuan_PengajuanProposalKegiatan");

                entity.HasOne(d => d.StatusPengajuan)
                    .WithMany(p => p.TahapanPengajuan)
                    .HasForeignKey(d => d.StatusPengajuanId)
                    .HasConstraintName("FK_TahapanPengajuan_StatusPengajuan");
            });

            modelBuilder.Entity<TipeKegiatanOrmawa>(entity =>
            {
                entity.ToTable("TipeKegiatanOrmawa", "OrmRef");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
