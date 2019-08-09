using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class MahasiswaMagister
    {
        public int Id { get; set; }
        public int MahasiswaId { get; set; }
        public string Nim { get; set; }
        public int MayorId { get; set; }
        public int JalurMasukId { get; set; }
        public DateTime? TanggalMasuk { get; set; }
        public int? TahunMasuk { get; set; }
        public int? BatasStudi { get; set; }
        public byte? AwalSemester { get; set; }
        public string GelarDepan { get; set; }
        public string GelarBelakang { get; set; }
        public byte? StatusVerifikasi { get; set; }
        public int? StatusAkademikId { get; set; }
        public byte? PindahMayor { get; set; }
        public int? TahunSemesterMasukId { get; set; }
        public int? TahunAkademikId { get; set; }
        public bool? IsPercobaan { get; set; }
        public string Sponsor { get; set; }

        public virtual Mahasiswa Mahasiswa { get; set; }
        public virtual Mayor Mayor { get; set; }
    }
}
