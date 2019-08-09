using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class JenisPengguna
    {
        public JenisPengguna()
        {
            HakAksesPengguna = new HashSet<HakAksesPengguna>();
        }

        public int Id { get; set; }
        public int? JenisSistemId { get; set; }
        public string Nama { get; set; }

        public virtual ICollection<HakAksesPengguna> HakAksesPengguna { get; set; }
    }
}
