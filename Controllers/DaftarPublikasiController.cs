using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc.JQuery.DataTables;
using Ormawa.BusinessModel;
using Ormawa.Models;
using Ormawa.ViewModels;

namespace Ormawa.Controllers
{
    public class DaftarPublikasiController : Controller
    {
        private readonly DBINTEGRASI_MASTER_BAYUPPKU2Context _context;
        private readonly Combobox _combobox;
        private readonly PublikasiRepo _repo;
        DaftarPublikasiOrmawaViewModel vmod = new DaftarPublikasiOrmawaViewModel();

        public DaftarPublikasiController(DBINTEGRASI_MASTER_BAYUPPKU2Context context, Combobox combobox, PublikasiRepo repo)
        {
            _context = context;
            _combobox = combobox;
            _repo = repo;
        }

        // GET: Anggota/Create
        public IActionResult Add()
        {
            DaftarPublikasiOrmawaViewModel vmod = new DaftarPublikasiOrmawaViewModel();
            //Daftar Ormawa
            vmod.ListOrmawa = new SelectList(_combobox.Ormawa(), "ID", "Value");
            return View(vmod);
        }

        // POST: Anggota/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Add(DaftarPublikasiOrmawaViewModel vmod)
        {
            if (ModelState.IsValid)
            {

                PublikasiOrmawa publikasi = new PublikasiOrmawa();
                publikasi.OrganisasiOrmawaId = vmod.OrganisasiOrmawaId;
                publikasi.Judul = vmod.Judul;
                publikasi.Isi = vmod.Isi;
                publikasi.TanggalInsert = DateTime.Now;
                _context.PublikasiOrmawa.Add(publikasi);
                _context.SaveChanges();
                return RedirectToAction("Index", "DaftarPublikasi");
            }
            return RedirectToAction("Index", "DaftarPublikasi");
        }
        public IActionResult Index()
        {
            var dataProviderUrl = Url.Action("DataTables");
            var viewModel = DataTablesHelper.DataTableVm<PublikasiRow>("dataTable", dataProviderUrl);

            viewModel.ShowFilterInput = true;
            viewModel.PageLength = 10;

            vmod.DataTableConfigVm = viewModel;

            return View(vmod);
        }

        public DataTablesResult<PublikasiRow> DataTables(DataTablesParam param)
        {
            var query = _repo.GetPublikasiList();

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
                         + "<a href='/DaftarPublikasi/Edit/" + ID + "' class='btn btn-warning btn-sm btn-flat'>"
                           + "<span class='fa fa-pencil'></span>"
                         + "</a>"
                         + "<a href='/DaftarPublikasi/Details/" + ID + "' class='btn btn-primary btn-sm btn-flat'>"
                           + "<span class='fa fa-calendar-o'></span>"
                         + "</a>"
                         + "<a href='/DaftarPublikasi/Delete/" + ID + "' class='btn btn-danger btn-sm btn-flat' data-target=\"#myModal\" data-toggle=\"modal\">"
                           + "<span class='fa fa-trash'></span>"
                         + "</a>"
                    + "</div>";
            return res;
        }
        public IActionResult Details(int id)
        {
            var DetailUpload = _repo.GetPublikasiDetails(id);
            vmod = DetailUpload;

            return View(vmod);
        }
    }
}