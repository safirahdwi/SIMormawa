using Mvc.JQuery.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.ViewModels
{
    public class OrganisasiOrmawaRow
    {
        [DataTables(Visible =false)]
        public int Id { get; set; }
        [DataTables]
        public string Nama { get; set; }
        [DataTables]
        public string JenisOrganisasi { get; set; }
        [DataTables]
        public string Aksi { get; set; }
    }
}
