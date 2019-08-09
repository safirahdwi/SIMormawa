using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class DokumenOrmawa
    {
        public DokumenOrmawa()
        {
            DaftarDokumenOrmawa = new HashSet<DaftarDokumenOrmawa>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public string Urldokumen { get; set; }
        public int? JenisDokumenId { get; set; }

        public virtual JenisDokumen JenisDokumen { get; set; }
        public virtual ICollection<DaftarDokumenOrmawa> DaftarDokumenOrmawa { get; set; }
    }
}
