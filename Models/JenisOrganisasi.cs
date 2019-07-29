using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class JenisOrganisasi
    {
        public JenisOrganisasi()
        {
            OrganisasiOrmawa = new HashSet<OrganisasiOrmawa>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }

        public virtual ICollection<OrganisasiOrmawa> OrganisasiOrmawa { get; set; }
    }
}
