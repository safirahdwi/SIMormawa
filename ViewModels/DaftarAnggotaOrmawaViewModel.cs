using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc.JQuery.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.ViewModels
{
    public class DaftarAnggotaOrmawaViewModel
    {
        public int Id { get; set; }
        public int MahasiswaId { get; set; }
        public int OrganisasiOrmawaId { get; set; }
        public DateTime? TanggalBergabung { get; set; }
        public bool? StatusAnggota { get; set; }
        public DataTableConfigVm DataTableConfigVm { get; set; }

        public IEnumerable<SelectListItem> ListMahasiswa { get; set; }
        public IEnumerable<SelectListItem> ListOrmawa { get; set; }
    }
}