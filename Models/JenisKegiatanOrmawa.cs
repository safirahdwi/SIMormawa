using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class JenisKegiatanOrmawa
    {
        public JenisKegiatanOrmawa()
        {
            PengajuanProposalKegiatan = new HashSet<PengajuanProposalKegiatan>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }

        public virtual ICollection<PengajuanProposalKegiatan> PengajuanProposalKegiatan { get; set; }
    }
}
