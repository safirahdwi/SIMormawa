using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class Orang
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string TempatLahir { get; set; }
        public int? TempatLahirId { get; set; }
        public DateTime TanggalLahir { get; set; }
        public byte JenisKelaminId { get; set; }
        public string Nims1key { get; set; }
        public string Nims2key { get; set; }
        public string Nims3key { get; set; }
        public string Pgwaikey { get; set; }
        public string PasanganKey { get; set; }
        public string Anakvkey { get; set; }
        public string S2lama { get; set; }
        public string S3lama { get; set; }
        public string OrangTuaVkey { get; set; }
        public string Nims0key { get; set; }
        public string Nimppdhkey { get; set; }

        public BiodataOrang BiodataOrang { get; set; }
    }
}
