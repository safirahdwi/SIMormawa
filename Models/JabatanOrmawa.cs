using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class JabatanOrmawa
    {
        public JabatanOrmawa()
        {
            StrukturalOrmawa = new HashSet<StrukturalOrmawa>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }

        public virtual ICollection<StrukturalOrmawa> StrukturalOrmawa { get; set; }
    }
}
