using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class Pengguna
    {
        public Pengguna()
        {
            HakAksesPengguna = new HashSet<HakAksesPengguna>();
        }

        public int Id { get; set; }
        public int? OrangId { get; set; }
        public string Username { get; set; }
        public bool? IsBlokir { get; set; }
        public DateTime? WaktuDibuat { get; set; }

        public virtual Orang Orang { get; set; }
        public virtual ICollection<HakAksesPengguna> HakAksesPengguna { get; set; }
    }
}
