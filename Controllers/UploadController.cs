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
using Ormawa.ViewModels;
using Ormawa.Controllers;
using Mvc.JQuery.DataTables;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ormawa.Controllers
{
    public class UploadController : AbstractBaseController
    {
        private readonly DBINTEGRASI_MASTER_BAYUPPKU2Context _db;
        private IHostingEnvironment _context;
        private string _dir;
        private readonly Combobox _combobox;
        private readonly IFileService _fileService;
        UploadViewModel vmod = new UploadViewModel();
        private readonly UploadRepo _repo;

        public UploadController(IHostingEnvironment context, IFileService fileservices, DBINTEGRASI_MASTER_BAYUPPKU2Context db, UploadRepo repo, Combobox combobox)
        {
            _context = context;
            _dir = _context.ContentRootPath;
            _fileService = fileservices;
            _db = db;
            _combobox = combobox;
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
                no = no++,
                Aksi = Buttonstring(row.Id)
            });
        }

        public string Buttonstring(int ID)
        {
            var res = "<div class='btn-group'>"
                         + "<a href='/Upload/Edit/" + ID + "' class='btn btn-warning btn-sm btn-flat'>"
                           + "<span class='fa fa-pencil'></span>"
                         + "</a>"
                         + "<a href='/Upload/Details/" + ID + "' class='btn btn-primary btn-sm btn-flat'>"
                           + "<span class='fa fa-calendar-o'></span>"
                         + "</a>"
                          + "<a onclick='Delete(" + ID + ")' class='btn btn-danger btn-sm btn-flat'>"
                           + "<span class='fa fa-trash' style='color:white'></span>"
                         + "</a>"
                    + "</div>";
            return res;
        }
        public IActionResult Upload()
        {
            vmod.ListTipe = new SelectList(_combobox.TipeKegiatanOrmawa(), "ID", "Value");
            vmod.ListJenis = new SelectList(_combobox.JenisKegiatanOrmawa(), "ID", "Value");
            vmod.ListPj = new SelectList(_combobox.AnggotaOrmawa(), "ID", "Value");
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

                    _repo.Insert(vmod);

                    //return RedirectToAction(nameof(Daftaranggota));
                    SetSuccessNotification("Dokumen Berhasil di Upload");
                    return RedirectToAction("Index", "Upload");
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                SetErrorNotification(e.Message);
                return RedirectToAction("Index", "Upload");
            }
        }

        public IActionResult Details(int id)
        {
            var DetailUpload = _repo.GetDetail(id);
            vmod = DetailUpload;

            return View(vmod);
        }

        public IActionResult Edit(int Id)
        {
            vmod = _repo.GetDetail(Id);
            vmod.ListTipe = new SelectList(_combobox.TipeKegiatanOrmawa(), "ID", "Value");
            vmod.ListJenis = new SelectList(_combobox.JenisKegiatanOrmawa(), "ID", "Value");
            vmod.ListPj = new SelectList(_combobox.AnggotaOrmawa(), "ID", "Value", vmod.AnggotaOrmawaId);
            return View(vmod);
        }

        [HttpPost]
        public IActionResult Edit(UploadViewModel vmod)
        {
            if (ModelState.IsValid)
            {
                _repo.Edit(vmod);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Upload");
        }

        public void DeleteUpload(int Id)
        {
            try
            {
                _repo.DeleteUpload(Id);
                SetSuccessNotification("Data removed successfully");
            }
            catch (Exception e)
            {
                var a = e.Message;
                SetErrorNotification("Failed to remove data");
            }

        }
    }
}