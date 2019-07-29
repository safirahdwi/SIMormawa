using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ormawa.BusinessModel;
using Ormawa.Models;
using Ormawa.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ormawa.Controllers
{
    public class DaftarPrestasiController : Controller
    {
        private readonly DBINTEGRASI_MASTER_BAYUPPKU2Context _context;
        private readonly Combobox _combobox;

        public DaftarPrestasiController(DBINTEGRASI_MASTER_BAYUPPKU2Context context, Combobox combobox)
        {
            _context = context;
            _combobox = combobox;
        }

        public IActionResult Daftarprestasi()
        {
            DaftarPrestasiOrmawaViewModel vm = new DaftarPrestasiOrmawaViewModel();
            return View(vm);
        }

        // GET: Anggota/Create
        public IActionResult Add()
        {
            DaftarPrestasiOrmawaViewModel vm = new DaftarPrestasiOrmawaViewModel();
            vm.ListOrmawa = new SelectList(_combobox.Ormawa(), "ID", "Value");
            vm.ListJenisPrestasi = new SelectList(_combobox.JenisPrestasiOrmawa(), "ID", "Value");
            return View(vm);
        }

        // POST: Anggota/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Add(DaftarPrestasiOrmawaViewModel vm)
        {
            if (ModelState.IsValid)
            {
                PrestasiOrmawa prestasi = new PrestasiOrmawa();
                prestasi.OrganisasiOrmawaId = vm.OrganisasiOrmawaId;
                prestasi.Tahun = vm.Tahun;
                prestasi.JenisPrestasiOrmawaId = vm.JenisPrestasiOrmawaId;
                prestasi.NamaPrestasi = vm.NamaPrestasi;
                prestasi.InstitusiPenyelenggara = vm.InstitusiPenyelenggara;
                _context.PrestasiOrmawa.Add(prestasi);
                _context.SaveChanges();
                //return RedirectToAction(nameof(Daftaranggota));
                return RedirectToAction("Daftarprestasi", "DaftarPrestasi");
            }
            return RedirectToAction("Daftarprestasi", "DaftarPrestasi");
        }

        // GET: Anggota/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var prestasi = await _context.PrestasiOrmawa.FindAsync(id);
            _context.PrestasiOrmawa.Remove(prestasi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Daftarprestasi));
        }

    }
}
