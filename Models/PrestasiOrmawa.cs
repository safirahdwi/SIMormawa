using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class PrestasiOrmawa
    {
        public int Id { get; set; }
        public int? OrganisasiOrmawaId { get; set; }
        public int? Tahun { get; set; }
        public int? JenisPrestasiOrmawaId { get; set; }
        public string NamaPrestasi { get; set; }
        public string InstitusiPenyelenggara { get; set; }

        public virtual JenisPrestasiOrmawa JenisPrestasiOrmawa { get; set; }
        public virtual OrganisasiOrmawa OrganisasiOrmawa { get; set; }
    }
}
