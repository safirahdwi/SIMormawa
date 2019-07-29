using Mvc.JQuery.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public DataTableConfigVm DataTableConfigVm { get; set; }
    }
}
