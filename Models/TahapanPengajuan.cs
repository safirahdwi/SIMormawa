using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class TahapanPengajuan
    {
        public int Id { get; set; }
        public int? PengajuanProposalKegiatanId { get; set; }
        public int? StatusPengajuanId { get; set; }
        public string Keterangan { get; set; }

        public virtual PengajuanProposalKegiatan PengajuanProposalKegiatan { get; set; }
        public virtual StatusPengajuan StatusPengajuan { get; set; }
    }
}
