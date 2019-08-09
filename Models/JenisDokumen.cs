using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class JenisDokumen
    {
        public JenisDokumen()
        {
            DokumenOrmawa = new HashSet<DokumenOrmawa>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public string Keterangan { get; set; }

        public virtual ICollection<DokumenOrmawa> DokumenOrmawa { get; set; }
    }
}
