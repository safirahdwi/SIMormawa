using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class StrukturOrganisasi
    {
        public StrukturOrganisasi()
        {
            HakAksesPengguna = new HashSet<HakAksesPengguna>();
            InverseStrukturOrganisasiNavigation = new HashSet<StrukturOrganisasi>();
            MutasiPegawai = new HashSet<MutasiPegawai>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public string NamaEn { get; set; }
        public string Inisial { get; set; }
        public DateTime? TanggalBerlaku { get; set; }
        public DateTime? TanggalBerakhir { get; set; }
        public int? LevelDariAtas { get; set; }
        public string NomorSk { get; set; }
        public string NamaJabatan { get; set; }
        public byte? Aktif { get; set; }
        public int? StrukturOrganisasiId { get; set; }
        public int? KelompokStrukturId { get; set; }
        public int? KelompokOrganisasiId { get; set; }
        public int? SkkeputusanId { get; set; }
        public int? Urutan { get; set; }
        public string KodeGl { get; set; }
        public string Sobkey { get; set; }

        public virtual StrukturOrganisasi StrukturOrganisasiNavigation { get; set; }
        public virtual Departemen Departemen { get; set; }
        public virtual ICollection<HakAksesPengguna> HakAksesPengguna { get; set; }
        public virtual ICollection<StrukturOrganisasi> InverseStrukturOrganisasiNavigation { get; set; }
        public virtual ICollection<MutasiPegawai> MutasiPegawai { get; set; }
    }
}
