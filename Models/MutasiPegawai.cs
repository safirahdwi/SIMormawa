using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class MutasiPegawai
    {
        public int Id { get; set; }
        public int PegawaiId { get; set; }
        public int StrukturOrganisasiId { get; set; }
        public string NomorSk { get; set; }
        public DateTime? Tmt { get; set; }
        public DateTime? TanggalEntri { get; set; }
        public byte? StatusAktif { get; set; }
        public string MutasiPegawaiBkey { get; set; }

        public virtual StrukturOrganisasi StrukturOrganisasi { get; set; }
    }
}
