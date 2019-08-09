using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.Models
{
    public class PegawaiViewMutasiPegawai
    {
        public int ID { get; set; }
        public int pegawaiid { get; set; }
        public int strukturorganisasiid { get; set; }
        public DateTime? TMT { get; set; }
        public DateTime? Tanggalentri { get; set; }
        public int? rn { get; set; }
    }
}
