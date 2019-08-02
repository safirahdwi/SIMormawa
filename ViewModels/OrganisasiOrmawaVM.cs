using Mvc.JQuery.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ormawa.ViewModels;

namespace Ormawa.ViewModels
{
    public class OrganisasiOrmawaVM
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string NamaEn { get; set; }
        public string NomorSk { get; set; }
        public DateTime? Tmt { get; set; }
        public DateTime? Tst { get; set; }
        public string JenisOrganisasi { get; set; }

        public string Mahasiswa { get; set; }
        public string OrganisasiOrmawa { get; set; }
        public DateTime? TanggalBergabung { get; set; }
        public bool? StatusAnggota { get; set; }
        public DataTableConfigVm DataTableConfigVm { get; set; }

        public IQueryable<DaftarAnggotaOrmawaRow> ListAnggota { get; set; }
        public IEnumerable<OrganisasiOrmawaVM> GetDetails { get; set; }
    }
}
