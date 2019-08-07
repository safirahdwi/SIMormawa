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
    public class DaftarAnggotaController : AbstractBaseController
    {
        private readonly DaftarAnggotaRepo _repo;
        private readonly DBINTEGRASI_MASTER_BAYUPPKU2Context _context;
        private readonly Combobox _combobox;
        DaftarAnggotaOrmawaViewModel vmod = new DaftarAnggotaOrmawaViewModel();

        public DaftarAnggotaController(DBINTEGRASI_MASTER_BAYUPPKU2Context context, DaftarAnggotaRepo repo, Combobox combobox)
        {
            _repo = repo;
            _combobox = combobox;
            _context = context;
        }

        public IActionResult Index()
        {
            var dataProviderUrl = Url.Action("DataTables");
            var viewModel = DataTablesHelper.DataTableVm<DaftarAnggotaOrmawaRow>("dataTable", dataProviderUrl);

            viewModel.ShowFilterInput = true;
            viewModel.PageLength = 10;

            vmod.DataTableConfigVm = viewModel;

            return View(vmod);

        }
        public IActionResult Add()
        {
            vmod.ListMahasiswa = new SelectList(_combobox.Mahasiswa(), "ID", "Value");
            vmod.ListOrmawa = new SelectList(_combobox.OrganisasiOrmawa(), "ID", "Value");
            vmod.ListJabatan = new SelectList(_combobox.JenisJabatanOrmawa(), "ID", "Value");
            //vmod.ListAnggotaOrmawa = new SelectList(_combobox.AnggotaOrmawa(), "ID", "Value");
            return View(vmod);
        }

        [HttpPost]
        public IActionResult Add(DaftarAnggotaOrmawaViewModel vmod)
        {
            if (ModelState.IsValid)
            {

                _repo.AddAnggotaOrmawa(vmod);
                //return RedirectToAction(nameof(Daftaranggota));
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public DataTablesResult<DaftarAnggotaOrmawaRow> DataTables(DataTablesParam param)
        {
            var query = _repo.GetDaftarAnggotaList();

            var no = param.iDisplayStart + 1;

            return DataTablesResult.Create(query, param, row => new
            {
                // custom formatting
                Aksi = Buttonstring(row.Id,row.IdStruktural)
            });
        }

        public string Buttonstring(int ID, int? IdStruktural)
        {
            var res = "<div class='btn-group'>"
                         + "<a href='DaftarAnggota/Edit/" + ID + "' class='btn btn-warning btn-sm btn-flat'>"
                           + "<span class='fa fa-pencil'></span>"
                         + "</a>"
                         + "<a href='/DaftarAnggota/Detail/" + ID + "' class='btn btn-primary btn-sm btn-flat'>"
                           + "<span class='fa fa-calendar-o'></span>"
                         + "</a>"
                         + "<a onclick='Delete(" + IdStruktural + ")' class='btn btn-danger btn-sm btn-flat'>"
                           + "<span class='fa fa-trash' style='color:white'></span>"
                         + "</a>"
                    + "</div>";
            return res;
        }
        public IActionResult Edit(int Id)
        {
            vmod = _repo.GetDetailAnggota(Id);
            vmod.ListMahasiswa = new SelectList(_combobox.Mahasiswa(), "ID", "Value", vmod.MahasiswaId);
            vmod.ListOrmawa = new SelectList(_combobox.OrganisasiOrmawa(), "ID", "Value", vmod.AnggotaOrmawaId);
            vmod.ListJabatan = new SelectList(_combobox.JenisJabatanOrmawa(), "ID", "Value");
            //vmod.ListAnggotaOrmawa = new SelectList(_combobox.AnggotaOrmawa(), "ID", "Value");
            return View(vmod);
        }

        [HttpPost]
        public IActionResult Edit(DaftarAnggotaOrmawaViewModel vmod)
        {
            if (ModelState.IsValid)
            {
                _repo.EditAnggotaOrmawa(vmod);
                //return RedirectToAction(nameof(Daftaranggota));
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "DaftarAnggota");
        }

        public void DeleteAnggota(int Id)
        {
            try
            {
                _repo.DeleteAnggotaOrmawa(Id);
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
