using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class OrganisasiOrmawa
    {
        public OrganisasiOrmawa()
        {
            AnggotaOrmawa = new HashSet<AnggotaOrmawa>();
            KegiatanOrmawa = new HashSet<KegiatanOrmawa>();
            PrestasiOrmawa = new HashSet<PrestasiOrmawa>();
            PublikasiOrmawa = new HashSet<PublikasiOrmawa>();
            StrukturalOrmawa = new HashSet<StrukturalOrmawa>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public string NamaEn { get; set; }
        public string NomorSk { get; set; }
        public DateTime? Tmt { get; set; }
        public DateTime? Tst { get; set; }
        public int? JenisOrganisasiId { get; set; }

        public virtual JenisOrganisasi JenisOrganisasi { get; set; }
        public virtual ICollection<AnggotaOrmawa> AnggotaOrmawa { get; set; }
        public virtual ICollection<KegiatanOrmawa> KegiatanOrmawa { get; set; }
        public virtual ICollection<PrestasiOrmawa> PrestasiOrmawa { get; set; }
        public virtual ICollection<PublikasiOrmawa> PublikasiOrmawa { get; set; }
        public virtual ICollection<StrukturalOrmawa> StrukturalOrmawa { get; set; }
    }
}
