using Microsoft.EntityFrameworkCore;
using Mvc.JQuery.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.ViewModels
{
    public class DaftarPrestasiOrmawaRow
    {
        [DataTables(Visible = false)]
        public int Id { get; set; }
        [DataTables]
        public string OrganisasiOrmawa { get; set; }
        [DataTables]
        public string Mahasiswa { get; set; }
        [DataTables]
        public string NamaPrestasi { get; set; }
        [DataTables]
        public string JenisPrestasiOrmawa { get; set; }
        [DataTables]
        public string InstitusiPenyelenggara { get; set; }
        [DataTables]
        public int? Tahun { get; set; }

        public string Aksi { get; set; }

    }
}
