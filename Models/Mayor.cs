using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class Mayor
    {
        public Mayor()
        {
            MahasiswaDoktor = new HashSet<MahasiswaDoktor>();
            MahasiswaMagister = new HashSet<MahasiswaMagister>();
            MahasiswaProfesi = new HashSet<MahasiswaProfesi>();
            MahasiswaSarjana = new HashSet<MahasiswaSarjana>();
        }

        public int Id { get; set; }
        public int? StrukturOrganisasiId { get; set; }
        public int DepartemenId { get; set; }
        public int StrataId { get; set; }
        public string Kode { get; set; }
        public string KodePdpt { get; set; }
        public string Nama { get; set; }
        public string NamaEn { get; set; }
        public string Inisial { get; set; }
        public int? Kaprodi { get; set; }
        public DateTime? TanggalDibentuk { get; set; }
        public string NomorSkdibentuk { get; set; }
        public string MayorSarjanaBkey { get; set; }
        public string MayorPascasarjanaBkey { get; set; }
        public DateTime? TanggalDitutup { get; set; }
        public string NomorSkditutup { get; set; }
        public int? RumpunIlmuProgramStudiId { get; set; }

        public virtual Departemen Departemen { get; set; }
        public virtual ICollection<MahasiswaDoktor> MahasiswaDoktor { get; set; }
        public virtual ICollection<MahasiswaMagister> MahasiswaMagister { get; set; }
        public virtual ICollection<MahasiswaProfesi> MahasiswaProfesi { get; set; }
        public virtual ICollection<MahasiswaSarjana> MahasiswaSarjana { get; set; }
    }
}
