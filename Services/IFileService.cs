using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.Services
{
    public interface IFileService
    {
        Task<string> UploadDokumen(string namaBerkas, IFormFile file);
    }
}
