using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.ViewModels
{
    public class DaftarPublikasiOrmawaViewModel
    {
        public int Id { get; set; }
        public int? OrganisasiOrmawaId { get; set; }
        public string Judul { get; set; }
        public string Isi { get; set; }
        public DateTime? TanggalInsert { get; set; }

        public IEnumerable<SelectListItem> ListOrmawa { get; set; }
    }
}
