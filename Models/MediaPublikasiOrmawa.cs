using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class MediaPublikasiOrmawa
    {
        public int Id { get; set; }
        public int? PublikasiOrmawaId { get; set; }
        public string Urlmedia { get; set; }

        public virtual PublikasiOrmawa PublikasiOrmawa { get; set; }
    }
}
