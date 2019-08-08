using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc.JQuery.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.ViewModels
{
    public class UploadViewModel
    {
        public int Id { get; set; }
        public int? AnggotaOrmawaId { get; set; }
        public string Kegiatan { get; set; }
        public int? TipeKegiatanOrmawaId { get; set; }
        public int? JenisKegiatanOrmawaId { get; set; }
        public long? DanaAnggaran { get; set; }
        public int? PenanggungJawabId { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? TimeApproved { get; set; }

        public string Nama { get; set; }
        public string Urldokumen { get; set; }
        public string AnggotaOrmawa { get; set; }
        public string PenanggungJawab { get; set; }
        public string tipe { get; set; }
        public string jenis { get; set; }
        public string url { get; set; }
        public string NamaDokumen { get; set; }
        public string TipeKegiatanOrmawa { get; set; }
        public string JenisKegiatanOrmawa { get; set; }
        public int PengajuanProposalId { get; set; }
        public int DokumenOrmawaId { get; set; }


        public int? JenisDokumenId { get; set; } 
        public IFormFile FileDokumen { get; set; }
        public DataTableConfigVm DataTableConfigVm { get; set; }
        public IEnumerable<SelectListItem> ListTipe { get; set; }
        public IEnumerable<SelectListItem> ListJenis { get; set; }
        public IEnumerable<SelectListItem> ListPj { get; set; }
    }
    }
