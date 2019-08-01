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
using Ormawa.ViewModels;
using Mvc.JQuery.DataTables;

namespace Ormawa.Controllers
{
    public class UploadController : AbstractBaseController
    {
        private readonly DBINTEGRASI_MASTER_BAYUPPKU2Context _db;
        private IHostingEnvironment _context;
        private string _dir;
        private readonly IFileService _fileService;
        UploadViewModel vmod = new UploadViewModel();
        private readonly UploadRepo _repo;

        public UploadController(IHostingEnvironment context, IFileService fileservices, DBINTEGRASI_MASTER_BAYUPPKU2Context db, UploadRepo repo)
        {
            _context = context;
            _dir = _context.ContentRootPath;
            _fileService = fileservices;
            _db = db;
            _repo = repo;
        }
      
        public IActionResult Index()
        {
            var dataProviderUrl = Url.Action("DataTables");
            var viewModel = DataTablesHelper.DataTableVm<UploadRow>("dataTable", dataProviderUrl);

            viewModel.ShowFilterInput = true;
            viewModel.PageLength = 10;

            vmod.DataTableConfigVm = viewModel;

            return View(vmod);
        }

        public DataTablesResult<UploadRow> DataTables(DataTablesParam param)
        {
            var query = _repo.GetUploadList();

            var no = param.iDisplayStart + 1;

            return DataTablesResult.Create(query, param, row => new
            {
                // custom formatting
                Aksi = Buttonstring(row.Id)
            });
        }

        public string Buttonstring(int ID)
        {
            var res = "<div class='btn-group'>"
                         + "<a href='/Upload/Edit/" + ID + "' class='btn btn-warning btn-sm btn-flat'>"
                           + "<span class='fa fa-pencil'></span>"
                         + "</a>"
                         + "<a href='/Upload/Detail/" + ID + "' class='btn btn-primary btn-sm btn-flat'>"
                           + "<span class='fa fa-calendar-o'></span>"
                         + "</a>"
                         + "<a href='/Upload/Delete/" + ID + "' class='btn btn-danger btn-sm btn-flat' data-target=\"#myModal\" data-toggle=\"modal\">"
                           + "<span class='fa fa-trash'></span>"
                         + "</a>"
                    + "</div>";
            return res;
        }
        public IActionResult Upload() {
            return View(vmod);
        }

        [HttpPost]
        public async Task<IActionResult> MultipleFiles(UploadViewModel vmod)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (vmod.FileDokumen == null || vmod.FileDokumen.Length == 0)
                        return Content("file not selected");

                    var namaFile = Path.GetFileName(vmod.FileDokumen.FileName);
                    var dok = namaFile.Substring(0, namaFile.IndexOf('.'));

                    vmod.Urldokumen = $"https://{await _fileService.UploadDokumen($"test_{dok}", vmod.FileDokumen)}";

                    DokumenOrmawa dokumen = new DokumenOrmawa();
                    dokumen.Nama = vmod.Nama;
                    dokumen.Urldokumen = vmod.Urldokumen;
                    dokumen.JenisDokumenId = vmod.JenisDokumenId;
                    _db.DokumenOrmawa.Add(dokumen);
                    _db.SaveChanges();
                    //return RedirectToAction(nameof(Daftaranggota));
                    SetSuccessNotification("Dokumen Berhasil di Upload");
                    return RedirectToAction("Index", "Upload");
                }
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                SetErrorNotification(e.Message);
                return RedirectToAction("Index", "Upload");
            }
        }
      
    }
}