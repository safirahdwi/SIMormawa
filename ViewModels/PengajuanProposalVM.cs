using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.ViewModels
{
    public class PengajuanProposalVM
    {
        public int Id { get; set; }
        public int? AnggotaOrmawaId { get; set; }
        public string Kegiatan { get; set; }
        public int? TipeKegiatanOrmawaId { get; set; }
        public int? JenisKegiatanOrmawaId { get; set; }
        public long? DanaAnggaran { get; set; }
        public int? PenanggungJawabId { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? TimeApproved { get; set; }


        public int KegiatanOrmawaId { get; set; }
        public int? PengajuanProposalKegiatanId { get; set; }
        public int? OrganisasiOrmawaId { get; set; }
        public bool? StatusKegiatan { get; set; }
    }
}
