using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class PengajuanProposalKegiatan
    {
        public PengajuanProposalKegiatan()
        {
            DaftarDokumenOrmawa = new HashSet<DaftarDokumenOrmawa>();
            KegiatanOrmawa = new HashSet<KegiatanOrmawa>();
            TahapanPengajuan = new HashSet<TahapanPengajuan>();
        }

        public int Id { get; set; }
        public int? AnggotaOrmawaId { get; set; }
        public string Kegiatan { get; set; }
        public int? TipeKegiatanOrmawaId { get; set; }
        public int? JenisKegiatanOrmawaId { get; set; }
        public long? DanaAnggaran { get; set; }
        public int? PenanggungJawabId { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? TimeApproved { get; set; }

        public virtual AnggotaOrmawa AnggotaOrmawa { get; set; }
        public virtual Orang ApprovedByNavigation { get; set; }
        public virtual JenisKegiatanOrmawa JenisKegiatanOrmawa { get; set; }
        public virtual Orang PenanggungJawab { get; set; }
        public virtual TipeKegiatanOrmawa TipeKegiatanOrmawa { get; set; }
        public virtual ICollection<DaftarDokumenOrmawa> DaftarDokumenOrmawa { get; set; }
        public virtual ICollection<KegiatanOrmawa> KegiatanOrmawa { get; set; }
        public virtual ICollection<TahapanPengajuan> TahapanPengajuan { get; set; }
    }
}
