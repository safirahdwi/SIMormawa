using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class HakAksesPengguna
    {
        public int Id { get; set; }
        public int? PenggunaId { get; set; }
        public int? JenisPenggunaId { get; set; }
        public int? StrukturOrganisasiId { get; set; }

        public virtual JenisPengguna JenisPengguna { get; set; }
        public virtual Pengguna Pengguna { get; set; }
    }
}
