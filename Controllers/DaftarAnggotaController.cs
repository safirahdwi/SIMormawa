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
    public class DaftarAnggotaController : Controller
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
            vmod.ListOrmawa = new SelectList(_combobox.Ormawa(), "ID", "Value");
            return View(vmod);
        }
        [HttpPost]
        public IActionResult Add(DaftarAnggotaOrmawaViewModel vmod)
        {
            if (ModelState.IsValid)
            {
              
                AnggotaOrmawa ormawa = new AnggotaOrmawa();
                ormawa.MahasiswaId = vmod.MahasiswaId;
                ormawa.OrganisasiOrmawaId = vmod.OrganisasiOrmawaId;
                ormawa.TanggalBergabung = vmod.TanggalBergabung;
                ormawa.StatusAnggota = vmod.StatusAnggota;
                _context.AnggotaOrmawa.Add(ormawa);
                _context.SaveChanges();
                //return RedirectToAction(nameof(Daftaranggota));
                return RedirectToAction("Index", "DaftarAnggota");
            }
            return RedirectToAction("Index", "DaftarAnggota");
        }
        // GET: Anggota/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var anggota = await _context.AnggotaOrmawa.FindAsync(id);
            _context.AnggotaOrmawa.Remove(anggota);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public DataTablesResult<DaftarAnggotaOrmawaRow> DataTables(DataTablesParam param)
        {
            var query = _repo.GetDaftarAnggotaList();

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
                         + "<a href='DaftarAnggota/Edit/" + ID + "' class='btn btn-warning btn-sm btn-flat'>"
                           + "<span class='fa fa-pencil'></span>"
                         + "</a>"
                         + "<a href='/DaftarAnggota/Detail/" + ID + "' class='btn btn-primary btn-sm btn-flat'>"
                           + "<span class='fa fa-calendar-o'></span>"
                         + "</a>"
                         + "<a href='/DaftarAnggota/Delete/" + ID + "' class='btn btn-danger btn-sm btn-flat' data-target=\"#myModal\" data-toggle=\"modal\">"
                           + "<span class='fa fa-trash'></span>"
                         + "</a>"
                    + "</div>";
            return res;
        }
    }
}
