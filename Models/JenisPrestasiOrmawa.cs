using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class JenisPrestasiOrmawa
    {
        public JenisPrestasiOrmawa()
        {
            PrestasiOrmawa = new HashSet<PrestasiOrmawa>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }

        public virtual ICollection<PrestasiOrmawa> PrestasiOrmawa { get; set; }
    }
}
