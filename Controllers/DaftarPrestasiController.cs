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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ormawa.Controllers
{
    public class DaftarPrestasiController : AbstractBaseController
    {
        private readonly DaftarPrestasiRepo _repo;
        private readonly DBINTEGRASI_MASTER_BAYUPPKU2Context _context;
        private readonly Combobox _combobox;
        DaftarPrestasiOrmawaViewModel vmod = new DaftarPrestasiOrmawaViewModel();

        public DaftarPrestasiController(DBINTEGRASI_MASTER_BAYUPPKU2Context context, DaftarPrestasiRepo repo, Combobox combobox)
        {
            _repo = repo;
            _context = context;
            _combobox = combobox;
        }

        public IActionResult Index()
        {
            var dataProviderUrl = Url.Action("DataTables");
            var viewModel = DataTablesHelper.DataTableVm<DaftarPrestasiOrmawaRow>("dataTable", dataProviderUrl);

            viewModel.ShowFilterInput = true;
            viewModel.PageLength = 10;

            vmod.DataTableConfigVm = viewModel;

            return View(vmod);
        }

        // GET:/Create
        public IActionResult Add()
        {
            vmod.ListOrmawa = new SelectList(_combobox.OrganisasiOrmawa(), "ID", "Value");
            vmod.ListJenisPrestasi = new SelectList(_combobox.JenisPrestasiOrmawa(), "ID", "Value");
            vmod.ListMahasiswa = new SelectList(_combobox.Mahasiswa(), "ID", "Value");
            return View(vmod);
        }

        // POST:/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Add(DaftarPrestasiOrmawaViewModel vmod)
        {
            if (ModelState.IsValid)
            {

                _repo.AddPrestasiOrmawa(vmod);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public DataTablesResult<DaftarPrestasiOrmawaRow> DataTables(DataTablesParam param)
        {
            var query = _repo.GetDaftarPrestasiList();

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
                         + "<a href='DaftarPrestasi/Edit/" + ID + "' class='btn btn-warning btn-sm btn-flat'>"
                           + "<span class='fa fa-pencil'></span>"
                         + "</a>"
                         + "<a onclick='Delete(" + ID + ")' class='btn btn-danger btn-sm btn-flat'>"
                           + "<span class='fa fa-trash' style='color:white'></span>"
                         + "</a>"
                      + "</div>"; ;
            return res;
        }
        public IActionResult Edit(int Id)
        {
            vmod = _repo.GetDetailPrestasi(Id);
            vmod.ListMahasiswa = new SelectList(_combobox.Mahasiswa(), "ID", "Value", vmod.MahasiswaId);
            vmod.ListOrmawa = new SelectList(_combobox.OrganisasiOrmawa(), "ID", "Value", vmod.OrganisasiOrmawaId);
            vmod.ListJenisPrestasi = new SelectList(_combobox.JenisPrestasiOrmawa(), "ID", "Value", vmod.JenisPrestasiOrmawaId);
            return View(vmod);
        }

        [HttpPost]
        public IActionResult Edit(DaftarPrestasiOrmawaViewModel vmod)
        {
            if (ModelState.IsValid)
            {
                _repo.EditPrestasiOrmawa(vmod);
                //return RedirectToAction(nameof(Daftaranggota));
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "DaftarPrestasi");
        }

        public void DeletePrestasi(int Id)
        {
            try
            {
                _repo.DeletePrestasiOrmawa(Id);
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