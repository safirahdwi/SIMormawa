using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ormawa.BusinessModel;
using Ormawa.Models;
using Ormawa.Services;
using Ormawa.ViewModel;
using Ormawa.Controllers;

namespace Ormawa.Controllers
{
    public class UploadController : AbstractBaseController
    {
        private readonly DBINTEGRASI_MASTER_BAYUPPKU2Context _db;
        private IHostingEnvironment _context;
        private string _dir;
        private readonly IFileService _fileService;

        public UploadController(IHostingEnvironment context, IFileService fileservices, DBINTEGRASI_MASTER_BAYUPPKU2Context db)
        {
            _context = context;
            _dir = _context.ContentRootPath;
            _fileService = fileservices;
            _db = db;
        }
        public IActionResult Index() {
            UploadViewModel vm = new UploadViewModel();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> MultipleFiles(UploadViewModel vm)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (vm.FileDokumen == null || vm.FileDokumen.Length == 0)
                        return Content("file not selected");

                    var namaFile = Path.GetFileName(vm.FileDokumen.FileName);
                    var dok = namaFile.Substring(0, namaFile.IndexOf('.'));

                    vm.Urldokumen = $"https://{await _fileService.UploadDokumen($"test_{dok}", vm.FileDokumen)}";

                    DokumenOrmawa dokumen = new DokumenOrmawa();
                    dokumen.Nama = vm.Nama;
                    dokumen.Urldokumen = vm.Urldokumen;
                    dokumen.JenisDokumenId = vm.JenisDokumenId;
                    _db.DokumenOrmawa.Add(dokumen);
                    _db.SaveChanges();
                    //return RedirectToAction(nameof(Daftaranggota));
                    SetSuccessNotification("Dokumen Berhasil di Upload");
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                SetErrorNotification(e.Message);
                return RedirectToAction("Index");
            }
        }
    }
}