using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class JenisKelamin
    {
        public JenisKelamin()
        {
            Orang = new HashSet<Orang>();
        }

        public byte Id { get; set; }
        public string Nama { get; set; }

        public virtual ICollection<Orang> Orang { get; set; }
    }
}
