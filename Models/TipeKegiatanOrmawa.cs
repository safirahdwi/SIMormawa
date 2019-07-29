using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class TipeKegiatanOrmawa
    {
        public TipeKegiatanOrmawa()
        {
            PengajuanProposalKegiatan = new HashSet<PengajuanProposalKegiatan>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }

        public virtual ICollection<PengajuanProposalKegiatan> PengajuanProposalKegiatan { get; set; }
    }
}
