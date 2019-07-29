using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class KalenderKegiatanOrmawa
    {
        public int Id { get; set; }
        public int? KegiatanOrmawaId { get; set; }
        public DateTime? Tmt { get; set; }
        public DateTime? Tst { get; set; }

        public virtual KegiatanOrmawa KegiatanOrmawa { get; set; }
    }
}
