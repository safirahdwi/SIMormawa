using Microsoft.EntityFrameworkCore;
using Ormawa.Models;
using Ormawa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.BusinessModel
{
    public class DaftarPrestasiRepo
    {
        private readonly DBINTEGRASI_MASTER_BAYUPPKU2Context _context;

        public DaftarPrestasiRepo(DBINTEGRASI_MASTER_BAYUPPKU2Context context)
        {
            _context = context;
        }

        public IQueryable<DaftarPrestasiOrmawaRow> GetDaftarPrestasiList()
        {
            var query = from m in _context.PrestasiOrmawa
                        //join s in _context.JenisPrestasiOrmawa on m.Id equals s.Id
                        join o in _context.Mahasiswa on m.MahasiswaId equals o.Id
                        join p in _context.Orang on o.OrangId equals p.Id
                        join ms1 in _context.MahasiswaSarjana on o.Id equals ms1.MahasiswaId
                        select new DaftarPrestasiOrmawaRow
                        {
                            Id = m.Id,
                            OrganisasiOrmawa = m.OrganisasiOrmawa.Nama,
                            Mahasiswa = p.Nama,
                            Tahun = m.Tahun,
                            JenisPrestasiOrmawa = m.JenisPrestasiOrmawa.Nama,
                            NamaPrestasi = m.NamaPrestasi,
                            InstitusiPenyelenggara = m.InstitusiPenyelenggara,
                        };
            return query;
        }
        public DaftarPrestasiOrmawaViewModel GetDetailPrestasi(int Id)
        {
            var prestasi = from m in _context.PrestasiOrmawa
                          //join s in _context.JenisPrestasiOrmawa on m.Id equals s.Id
                          join o in _context.Mahasiswa on m.MahasiswaId equals o.Id
                          join p in _context.Orang on o.OrangId equals p.Id
                          join ms1 in _context.MahasiswaSarjana on o.Id equals ms1.MahasiswaId
                          where m.Id == Id
                          select new DaftarPrestasiOrmawaViewModel
                          {
                              Id = m.Id,
                              OrganisasiOrmawaId = m.OrganisasiOrmawa.Id,
                              OrganisasiOrmawa = m.OrganisasiOrmawa.Nama,
                              MahasiswaId = o.Id,
                              Mahasiswa = p.Nama,
                              Tahun = m.Tahun,
                              JenisPrestasiOrmawaId = m.JenisPrestasiOrmawaId,
                              JenisPrestasiOrmawa = m.JenisPrestasiOrmawa.Nama,
                              NamaPrestasi = m.NamaPrestasi,
                              InstitusiPenyelenggara = m.InstitusiPenyelenggara,
                          };
            return prestasi.FirstOrDefault();
        }
        public void AddPrestasiOrmawa(DaftarPrestasiOrmawaViewModel vmod)
        {
            PrestasiOrmawa ormawa = new PrestasiOrmawa();
            ormawa.MahasiswaId = vmod.MahasiswaId;
            ormawa.OrganisasiOrmawaId = vmod.OrganisasiOrmawaId;
            ormawa.Tahun = vmod.Tahun;
            ormawa.JenisPrestasiOrmawaId = vmod.JenisPrestasiOrmawaId;
            ormawa.NamaPrestasi = vmod.NamaPrestasi;
            ormawa.InstitusiPenyelenggara = vmod.InstitusiPenyelenggara;
            _context.PrestasiOrmawa.Add(ormawa);
            _context.SaveChanges();
        }
        public void EditPrestasiOrmawa(DaftarPrestasiOrmawaViewModel vmod)
        {
            PrestasiOrmawa ormawa = _context.PrestasiOrmawa.Find(vmod.Id);
            ormawa.MahasiswaId = vmod.MahasiswaId;
            ormawa.OrganisasiOrmawaId = vmod.OrganisasiOrmawaId;
            ormawa.Tahun = vmod.Tahun;
            ormawa.JenisPrestasiOrmawaId = vmod.JenisPrestasiOrmawaId;
            ormawa.NamaPrestasi = vmod.NamaPrestasi;
            ormawa.InstitusiPenyelenggara = vmod.InstitusiPenyelenggara;
            _context.Entry(ormawa).State = EntityState.Modified;
            _context.SaveChanges();
        }


    }

}

