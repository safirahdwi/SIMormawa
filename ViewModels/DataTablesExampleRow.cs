using System;
using Mvc.JQuery.DataTables;
using Mvc.JQuery.DataTables.Models;

namespace Ormawa.ViewModels
{
    public class DataTablesExampleRow
    {
        [DataTables(Searchable = false, Visible = false)]
        public int Id { get; set; }
        
        [DataTables(Searchable = false, Sortable = false)]
        public int No { get; set; }
        
        [DataTables(SortDirection = SortDirection.Ascending)]
        public string Nama { get; set; }
        public string NIM { get; set; }

        public string TempatLahir { get; set; }
        
        [DataTables(Searchable = false)]
        public DateTime TanggalLahir { get; set; }
        
        [DataTables(Searchable = false, Sortable = false)]
        public string Aksi { get; set; }
    }
}