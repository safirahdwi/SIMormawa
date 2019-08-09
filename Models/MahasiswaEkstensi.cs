using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class MahasiswaEkstensi
    {
        public int MahasiswaSarjanaId { get; set; }
        public int? AsalPerguruanTinggiId { get; set; }
        public string FakultasAsal { get; set; }
        public string ProgramStudiAsal { get; set; }
        public double? Ipksebelumnya { get; set; }
        public int? Sksdiakui { get; set; }

        public virtual MahasiswaSarjana MahasiswaSarjana { get; set; }
    }
}
