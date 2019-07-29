using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.ViewModels
{
    public class DaftarAnggotaOrmawaViewModel
    {
        public int Id { get; set; }
        public int? MahasiswaId { get; set; }
        public int? OrganisasiOrmawaId { get; set; }
        public DateTime? TanggalBergabung { get; set; }
        public bool? StatusAnggota { get; set; }

        //Mahasiswa
        public int? OrangId { get; set; }
        public int? StrataId { get; set; }
        public string Nimkey { get; set; }

        public IEnumerable<SelectListItem> ListMahasiswa { get; set; }
        public IEnumerable<SelectListItem> ListOrmawa { get; set; }
    }
}