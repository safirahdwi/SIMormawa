using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class AnggotaOrmawa
    {
        public AnggotaOrmawa()
        {
            PengajuanProposalKegiatan = new HashSet<PengajuanProposalKegiatan>();
            StrukturalOrmawa = new HashSet<StrukturalOrmawa>();
        }

        public int Id { get; set; }
        public int? MahasiswaId { get; set; }
        public int? OrganisasiOrmawaId { get; set; }
        public DateTime? TanggalBergabung { get; set; }
        public bool? StatusAnggota { get; set; }

        public virtual Mahasiswa Mahasiswa { get; set; }
        public virtual OrganisasiOrmawa OrganisasiOrmawa { get; set; }
        public virtual ICollection<PengajuanProposalKegiatan> PengajuanProposalKegiatan { get; set; }
        public virtual ICollection<StrukturalOrmawa> StrukturalOrmawa { get; set; }
    }
}
