using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class StrukturalOrmawa
    {
        public int Id { get; set; }
        public int? OrganisasiOrmawaId { get; set; }
        public int? AnggotaOrmawaId { get; set; }
        public int? JabatanOrmawaId { get; set; }
        public DateTime? Tmt { get; set; }
        public DateTime? Tst { get; set; }

        public virtual AnggotaOrmawa AnggotaOrmawa { get; set; }
        public virtual JabatanOrmawa JabatanOrmawa { get; set; }
        public virtual OrganisasiOrmawa OrganisasiOrmawa { get; set; }
    }
}
