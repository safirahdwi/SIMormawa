using Microsoft.EntityFrameworkCore;
using Ormawa.Models;
using Ormawa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.BusinessModel
{
    public class DaftarAnggotaRepo
    {
        private readonly DBINTEGRASI_MASTER_BAYUPPKU2Context _context;

        public DaftarAnggotaRepo(DBINTEGRASI_MASTER_BAYUPPKU2Context context)
        {
            _context = context;
        }

        public IQueryable<DaftarAnggotaOrmawaRow> GetDaftarAnggotaList()
        {
            var query = from m in _context.AnggotaOrmawa
                        join o in _context.Mahasiswa on m.MahasiswaId equals o.Id
                        join p in _context.Orang on o.OrangId equals p.Id
                        join ms1 in _context.MahasiswaSarjana on o.Id equals ms1.MahasiswaId
                        join struk in _context.StrukturalOrmawa on m.Id equals struk.AnggotaOrmawaId
                        //where m.OrganisasiOrmawaId == id
                        select new DaftarAnggotaOrmawaRow
                        {
                            Id = m.Id,
                            Mahasiswa = p.Nama,
                            TanggalBergabung = m.TanggalBergabung,
                            OrganisasiOrmawa = m.OrganisasiOrmawa.Nama,
                            StatusAnggota = m.StatusAnggota,
                            Jabatan = struk.JabatanOrmawa.Nama
                        };
            return query;
        }
        public DaftarAnggotaOrmawaViewModel GetDetailAnggota(int Id)
        {
            var anggota = from m in _context.AnggotaOrmawa
                          join o in _context.Mahasiswa on m.MahasiswaId equals o.Id
                          join p in _context.Orang on o.OrangId equals p.Id
                          join ms1 in _context.MahasiswaSarjana on o.Id equals ms1.MahasiswaId
                          join struk in _context.StrukturalOrmawa on m.Id equals struk.AnggotaOrmawaId
                          where m.Id == Id
                          select new DaftarAnggotaOrmawaViewModel
                       {
                              Id = m.Id,
                              MahasiswaId = o.Id,
                              Mahasiswa = p.Nama,
                              TanggalBergabung = m.TanggalBergabung,
                              OrganisasiOrmawaId = m.OrganisasiOrmawa.Id,
                              OrganisasiOrmawa = m.OrganisasiOrmawa.Nama,
                              StatusAnggota = m.StatusAnggota,
                              JabatanOrmawaId = struk.JabatanOrmawa.Id,
                              Jabatan = struk.JabatanOrmawa.Nama,
                              Tmt = struk.Tmt,
                              Tst = struk.Tst,
                              StrukturOrmawaId = struk.Id
                          };
            return anggota.FirstOrDefault();
        }
        public void AddAnggotaOrmawa(DaftarAnggotaOrmawaViewModel vmod)
        {
            AnggotaOrmawa ormawa = new AnggotaOrmawa();
            ormawa.MahasiswaId = vmod.MahasiswaId;
            ormawa.OrganisasiOrmawaId = vmod.OrganisasiOrmawaId;
            ormawa.TanggalBergabung = vmod.Tmt;
            ormawa.StatusAnggota = vmod.StatusAnggota;
            _context.AnggotaOrmawa.Add(ormawa);

            StrukturalOrmawa struktur = new StrukturalOrmawa();
            struktur.AnggotaOrmawaId = ormawa.Id;
            struktur.OrganisasiOrmawaId = vmod.OrganisasiOrmawaId;
            struktur.JabatanOrmawaId = vmod.JabatanOrmawaId;
            struktur.Tmt = vmod.Tmt;
            struktur.Tst = vmod.Tst;
            _context.StrukturalOrmawa.Add(struktur);

            _context.SaveChanges();
        }
        public void EditAnggotaOrmawa(DaftarAnggotaOrmawaViewModel vmod)
        {
            AnggotaOrmawa ormawa = _context.AnggotaOrmawa.Find(vmod.Id);
            ormawa.MahasiswaId = vmod.MahasiswaId;
            ormawa.OrganisasiOrmawaId = vmod.OrganisasiOrmawaId;
            ormawa.TanggalBergabung = vmod.Tmt;
            ormawa.StatusAnggota = vmod.StatusAnggota;
            _context.Entry(ormawa).State = EntityState.Modified;

            StrukturalOrmawa struktur = _context.StrukturalOrmawa.Find(vmod.StrukturOrmawaId);            
            struktur.OrganisasiOrmawaId = vmod.OrganisasiOrmawaId;
            struktur.JabatanOrmawaId = vmod.JabatanOrmawaId;
            struktur.Tmt = vmod.Tmt;
            struktur.Tst = vmod.Tst;
            _context.Entry(struktur).State = EntityState.Modified;
            _context.SaveChanges();
        }
        /* public void AddStukturOrmawa()
         {
             var anggota = AddAnggotaOrmawa();
         }*/
    }

}