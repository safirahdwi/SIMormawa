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
    public class DaftarAnggotaController : Controller
    {
        private readonly DBINTEGRASI_MASTER_BAYUPPKU2Context _context;
        private readonly Combobox _combobox;

        public DaftarAnggotaController(DBINTEGRASI_MASTER_BAYUPPKU2Context context, Combobox combobox)
        {
            _context = context;
            _combobox = combobox;
        }

        // GET: Anggota
        //public async Task<IActionResult> Daftaranggota()
        //{
        //    return View(await _context.AnggotaOrmawa.ToListAsync());
        //}
        public IActionResult Daftaranggota()
        {
            DaftarAnggotaOrmawaViewModel vm = new DaftarAnggotaOrmawaViewModel();
            return View(vm);
        }

        // GET: Anggota/Create
        public IActionResult Add()
        {
            //if (id == 0)
            //    return View(new Anggota());
            //else
            //    return View(_context.AnggotaOrmawa.Find(id));
            DaftarAnggotaOrmawaViewModel vm = new DaftarAnggotaOrmawaViewModel();
            vm.ListMahasiswa = new SelectList(_combobox.Mahasiswa(), "ID", "Value");
            vm.ListOrmawa = new SelectList(_combobox.Ormawa(), "ID", "Value");
            return View(vm);
        }

        // POST: Anggota/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Add(DaftarAnggotaOrmawaViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //if (anggota.AnggotaID == 0)
                //    _context.Add(anggota);
                //else
                //    _context.Update(anggota);
                //await _context.SaveChangesAsync();
                AnggotaOrmawa ormawa = new AnggotaOrmawa();
                ormawa.MahasiswaId = vm.MahasiswaId;
                ormawa.OrganisasiOrmawaId = vm.OrganisasiOrmawaId;
                ormawa.TanggalBergabung = vm.TanggalBergabung;
                ormawa.StatusAnggota = vm.StatusAnggota;
                _context.AnggotaOrmawa.Add(ormawa);
                _context.SaveChanges();
                //return RedirectToAction(nameof(Daftaranggota));
                return RedirectToAction("Daftaranggota", "DaftarAnggota");
            }
            return RedirectToAction("Daftaranggota", "DaftarAnggota");
        }

        // GET: Anggota/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var anggota = await _context.AnggotaOrmawa.FindAsync(id);
            _context.AnggotaOrmawa.Remove(anggota);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Daftaranggota));
        }

    }
}
