using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.ViewModels
{
    public class DashboardViewModel
    {
        public string Judul { get; set; }
        public string Isi { get; set; }
        public string Nama { get; set; }
        public DateTime? TanggalInsert { get; set; }

        public List<DashboardViewModel> ListPublikasi { get; set; }
    }
}
