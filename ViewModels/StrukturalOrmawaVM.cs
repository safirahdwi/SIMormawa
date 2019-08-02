using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.ViewModels
{
    public class StrukturalOrmawaVM
    {
        public int Id { get; set; }
        public int? OrganisasiOrmawaId { get; set; }
        public int? AnggotaOrmawaId { get; set; }
        public int? JabatanOrmawaId { get; set; }
        public DateTime? Tmt { get; set; }
        public DateTime? Tst { get; set; }
    }
}
