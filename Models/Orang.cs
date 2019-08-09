using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class Orang
    {
        public Orang()
        {
            Mahasiswa = new HashSet<Mahasiswa>();
            PengajuanProposalKegiatanApprovedByNavigation = new HashSet<PengajuanProposalKegiatan>();
            PengajuanProposalKegiatanPenanggungJawab = new HashSet<PengajuanProposalKegiatan>();
            Pengguna = new HashSet<Pengguna>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public string TempatLahir { get; set; }
        public int? TempatLahirId { get; set; }
        public DateTime TanggalLahir { get; set; }
        public byte JenisKelaminId { get; set; }
        public string Nims1key { get; set; }
        public string Nims2key { get; set; }
        public string Nims3key { get; set; }
        public string Pgwaikey { get; set; }
        public string PasanganKey { get; set; }
        public string Anakvkey { get; set; }
        public string S2lama { get; set; }
        public string S3lama { get; set; }
        public string OrangTuaVkey { get; set; }
        public string Nims0key { get; set; }
        public string Nimppdhkey { get; set; }
        public int? OrangTamuKey { get; set; }

        public virtual JenisKelamin JenisKelamin { get; set; }
        public virtual BiodataOrang BiodataOrang { get; set; }
        public virtual ICollection<Mahasiswa> Mahasiswa { get; set; }
        public virtual ICollection<PengajuanProposalKegiatan> PengajuanProposalKegiatanApprovedByNavigation { get; set; }
        public virtual ICollection<PengajuanProposalKegiatan> PengajuanProposalKegiatanPenanggungJawab { get; set; }
        public virtual ICollection<Pengguna> Pengguna { get; set; }
    }
}
