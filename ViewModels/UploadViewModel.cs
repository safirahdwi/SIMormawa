using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.ViewModels
{
    public class UploadViewModel
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Urldokumen { get; set; }
        public int? JenisDokumenId { get; set; } 
        public IFormFile FileDokumen { get; set; }

    }
    }
