using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.ViewModels
{
    public class DaftarPrestasiOrmawaViewModel
    {
        public int Id { get; set; }
        public int? OrganisasiOrmawaId { get; set; }
        public int? Tahun { get; set; }
        public int? JenisPrestasiOrmawaId { get; set; }
        public string NamaPrestasi { get; set; }
        public string InstitusiPenyelenggara { get; set; }
        public int? MahasiswaId { get; set; }

        //Mahasiswa
        public int? OrangId { get; set; }
        public int? StrataId { get; set; }
        public string Nimkey { get; set; }

        public IEnumerable<SelectListItem> ListOrmawa { get; set; }
        public IEnumerable<SelectListItem> ListJenisPrestasi { get; set; }
        public IEnumerable<SelectListItem> ListMahasiswa { get; set; }
    }
}