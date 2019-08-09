using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.Models
{
    public class Akd_DaftarMahasiswaMultiStrata
    {
        [Key]
        public Guid ID { get; set; }
        public int? OrangID { get; set; }
        public int? MahasiswaID { get; set; }
        public string Nama { get; set; }
        public string JenisKelamin { get; set; }
        public string NIM { get; set; }
        public int? StrataID { get; set; }
        public string Strata { get; set; }
        public DateTime TanggalMasuk { get; set; }
        public string Prodi { get; set; }
        public int? DepartemenID { get; set; }
        public int? FakultasID { get; set; }
        public string Departemen { get; set; }
        public string Fakultas { get; set; }
        public string StatusAkademik { get; set; }
    }
}
