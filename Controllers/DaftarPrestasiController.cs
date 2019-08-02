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
    public class DaftarPrestasiController : Controller
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

            // GET: Anggota/Create
        public IActionResult Add()
        {
            vmod.ListOrmawa = new SelectList(_combobox.Ormawa(), "ID", "Value");
            vmod.ListJenisPrestasi = new SelectList(_combobox.JenisPrestasiOrmawa(), "ID", "Value");
            vmod.ListMahasiswa = new SelectList(_combobox.Mahasiswa(), "ID", "Value");
            return View(vmod);
        }

        // POST: Anggota/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Add(DaftarPrestasiOrmawaViewModel vmod)
        {
            if (ModelState.IsValid)
            {
                PrestasiOrmawa prestasi = new PrestasiOrmawa();
                prestasi.OrganisasiOrmawaId = vmod.OrganisasiOrmawaId;
                prestasi.Tahun = vmod.Tahun;
                prestasi.JenisPrestasiOrmawaId = vmod.JenisPrestasiOrmawaId;
                prestasi.NamaPrestasi = vmod.NamaPrestasi;
                prestasi.InstitusiPenyelenggara = vmod.InstitusiPenyelenggara;
                prestasi.MahasiswaId = vmod.MahasiswaId;
                _context.PrestasiOrmawa.Add(prestasi);
                _context.SaveChanges();
                return RedirectToAction("Index", "DaftarPrestasi");
            }
            return RedirectToAction("Index", "DaftarPrestasi");
        }

        // GET: Anggota/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var prestasi = await _context.PrestasiOrmawa.FindAsync(id);
            _context.PrestasiOrmawa.Remove(prestasi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
                         + "<a href='/DaftarPrestasi/Detail/" + ID + "' class='btn btn-primary btn-sm btn-flat'>"
                           + "<span class='fa fa-calendar-o'></span>"
                         + "</a>"
                         + "<a href='/DaftarPrestasi/Delete/" + ID + "' class='btn btn-danger btn-sm btn-flat' data-target=\"#myModal\" data-toggle=\"modal\">"
                           + "<span class='fa fa-trash'></span>"
                         + "</a>"
                    + "</div>";
            return res;
        }
    }
}