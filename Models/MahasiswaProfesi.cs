using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class MahasiswaProfesi
    {
        public int MahasiswaId { get; set; }
        public string Nim { get; set; }
        public int? MayorId { get; set; }
        public int? JalurMasukId { get; set; }
        public DateTime? TanggalMasuk { get; set; }
        public short? Angkatan { get; set; }
        public int? StatusAkademikId { get; set; }
        public short? BatasStudi { get; set; }
        public int? TahunSemesterMasukId { get; set; }
        public int? TahunAkademikId { get; set; }

        public virtual Mahasiswa Mahasiswa { get; set; }
        public virtual Mayor Mayor { get; set; }
    }
}
