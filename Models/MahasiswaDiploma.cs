using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class MahasiswaDiploma
    {
        public int Id { get; set; }
        public int MahasiswaId { get; set; }
        public string Nim { get; set; }
        public int? ProgramKeahlianId { get; set; }
        public int JalurMasukId { get; set; }
        public DateTime? TanggalMasuk { get; set; }
        public int? TahunMasuk { get; set; }
        public int? BatasStudi { get; set; }
        public int? SumberBiaya { get; set; }
        public int? Beasiswa { get; set; }
        public int? Bpmp { get; set; }
        public string PembimbingAkademik { get; set; }
        public int? StatusAkademikId { get; set; }
        public string PindahanPt { get; set; }
        public int? TahunAkademikId { get; set; }
        public int? TahunSemesterMasukId { get; set; }

        public virtual Mahasiswa Mahasiswa { get; set; }
    }
}
