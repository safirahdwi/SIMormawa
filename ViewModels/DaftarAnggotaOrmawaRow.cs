using Mvc.JQuery.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.ViewModels
{
    public class DaftarAnggotaOrmawaRow
    {
        [DataTables(Visible = false)]
        public int Id { get; set; }
        [DataTables]
        public string Mahasiswa { get; set; }
        [DataTables]
        public string OrganisasiOrmawa { get; set; }
        [DataTables]
        public DateTime? TanggalBergabung { get; set; }
        [DataTables]
        public bool? StatusAnggota { get; set; }
        [DataTables]
        public string Jabatan { get; set; }
        [DataTables(Visible = false)]
        public int? IdStruktural { get; set; }
        public string Aksi { get; set; }
    }
}
