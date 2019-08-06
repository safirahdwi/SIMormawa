using Mvc.JQuery.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.ViewModels
{
    public class PublikasiRow
    {
        [DataTables(Visible = false)]
        public int Id { get; set; }
        [DataTables]
        public string NamaOrganisasi { get; set; }
        [DataTables]
        public string Judul { get; set; }
        //[DataTables]
        //public string Isi { get; set; }
        [DataTables]
        public string Tanggal { get; set; }
        [DataTables]
        public string Aksi { get; set; }
    }
}
