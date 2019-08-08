using Mvc.JQuery.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.ViewModels
{
    public class UploadRow
    {
        [DataTables(Visible =false)]
        public int Id { get; set; }
        [DataTables(Visible = false)]
        public int IdDaftarPengajuan { get; set; }
        [DataTables]
        public int No { get; set; }
        [DataTables]
        public string Kegiatan { get; set; }
        [DataTables]
        //public string Nama { get; set; }
        public string Jenis { get; set; }
        [DataTables]
        public string PenanggungJawab { get; set; }
        //[DataTables]
        //public string Urldokumen { get; set; }
        //[DataTables]
        //public string JenisDokumen { get; set; }
        //[DataTables]
        //public string AnggotaOrmawa { get; set; }

        //[DataTables]
        //public string TipeKegiatanOrmawa { get; set; }
        //[DataTables]
        //public string JenisKegiatanOrmawa { get; set; }
        //[DataTables]
        //public long DanaAnggaran { get; set; }
        //[DataTables]
        //public string NamaDokumen { get; set; }
        //[DataTables]
        //public int? ApprovedBy { get; set; }
        //[DataTables]
        //public DateTime? TimeApproved { get; set; }
        [DataTables]
        public string Aksi { get; set; }
    }
}
