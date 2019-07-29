using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ormawa.Services;
using Ormawa.ViewModel;

namespace Ormawa.Controllers
{
    public class UploadController : Controller
    {
        private IHostingEnvironment _env;
        private string _dir;
        private readonly IFileService _fileService;

        public UploadController(IHostingEnvironment env, IFileService fileService)
        {
            _env = env;
            _dir = _env.ContentRootPath;
            _fileService = fileService;
        }
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> MultipleFiles(UploadViewModel vm)
        {

            try
            {
                if (vm.FileDokumen == null || vm.FileDokumen.Length == 0)
                    return Content("file not selected");

                var namaFile = Path.GetFileName(vm.FileDokumen.FileName);
                var dok = namaFile.Substring(0, namaFile.IndexOf('.'));

                vm.Urldokumen = $"https://{await _fileService.UploadDokumen($"test_{dok}", vm.FileDokumen)}";
                
                
                return RedirectToAction("Index");
            }
            catch
            {
                
                return RedirectToAction("Index");
            }
        }
    }
}