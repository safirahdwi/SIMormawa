using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class PublikasiOrmawa
    {
        public PublikasiOrmawa()
        {
            MediaPublikasiOrmawa = new HashSet<MediaPublikasiOrmawa>();
        }

        public int Id { get; set; }
        public int? OrganisasiOrmawaId { get; set; }
        public string Judul { get; set; }
        public string Isi { get; set; }
        public DateTime? TanggalInsert { get; set; }

        public virtual OrganisasiOrmawa OrganisasiOrmawa { get; set; }
        public virtual ICollection<MediaPublikasiOrmawa> MediaPublikasiOrmawa { get; set; }
    }
}
