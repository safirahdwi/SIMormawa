using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class ProgramKeahlian
    {
        public ProgramKeahlian()
        {
            MahasiswaDiploma = new HashSet<MahasiswaDiploma>();
        }

        public int Id { get; set; }
        public int DirektoratId { get; set; }
        public int? StrukturOrganisasiId { get; set; }
        public string Kode { get; set; }
        public string KodePdpt { get; set; }
        public string Nama { get; set; }
        public string NamaEn { get; set; }
        public int? Kaprodi { get; set; }
        public string Inisial { get; set; }
        public string Alamat { get; set; }
        public int? KotaKabupatenId { get; set; }
        public int? KodePos { get; set; }
        public DateTime? TanggalDibentuk { get; set; }
        public string StatusProgramStudi { get; set; }
        public bool? IsPdd { get; set; }
        public string NoSkDikti { get; set; }
        public DateTime? TanggalSkdikti { get; set; }
        public DateTime? TanggalAkhirSkDikti { get; set; }
        public string Akreditasi { get; set; }
        public string NoSkBan { get; set; }
        public DateTime? TanggalSkBan { get; set; }
        public DateTime? TanggalAkhirSkBan { get; set; }
        public string StatusAkredikasi { get; set; }
        public string KonfirmasiBanpt { get; set; }
        public string ProgramKeahlianBkey { get; set; }

        public virtual ICollection<MahasiswaDiploma> MahasiswaDiploma { get; set; }
    }
}
