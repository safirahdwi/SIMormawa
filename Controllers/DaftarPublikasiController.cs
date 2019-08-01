using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ormawa.BusinessModel;
using Ormawa.Models;
using Ormawa.ViewModels;

namespace Ormawa.Controllers
{
    public class DaftarPublikasiController : Controller
    {
        private readonly DBINTEGRASI_MASTER_BAYUPPKU2Context _context;
        private readonly Combobox _combobox;

        public DaftarPublikasiController(DBINTEGRASI_MASTER_BAYUPPKU2Context context, Combobox combobox)
        {
            _context = context;
            _combobox = combobox;
        }

        public IActionResult Daftarpublikasi()
        {
            DaftarPublikasiOrmawaViewModel vm = new DaftarPublikasiOrmawaViewModel();
            return View(vm);
        }

        // GET: Anggota/Create
        public IActionResult Add()
        {
            DaftarPublikasiOrmawaViewModel vm = new DaftarPublikasiOrmawaViewModel();
            //Daftar Ormawa
            vm.ListOrmawa = new SelectList(_combobox.Ormawa(), "ID", "Value");
            return View(vm);
        }

        // POST: Anggota/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Add(DaftarPublikasiOrmawaViewModel vm)
        {
            if (ModelState.IsValid)
            {

                PublikasiOrmawa publikasi = new PublikasiOrmawa();
                publikasi.OrganisasiOrmawaId = vm.OrganisasiOrmawaId;
                publikasi.Judul = vm.Judul;
                publikasi.Isi = vm.Isi;
                publikasi.TanggalInsert = vm.TanggalInsert;
                _context.PublikasiOrmawa.Add(publikasi);
                _context.SaveChanges();
                return RedirectToAction("Publikasiormawa", "PublikasiOrmawa");
            }
            return RedirectToAction("Publikasiormawa", "PublikasiOrmawa");
        }
    }
}