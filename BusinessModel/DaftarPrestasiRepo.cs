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
                        select new DaftarPrestasiOrmawaRow
                        {
                            Id = m.Id,
                            OrganisasiOrmawa = m.OrganisasiOrmawa.Nama,
                            Mahasiswa = p.Nama,
                            Tahun = m.Tahun,
                            JenisPrestasiOrmawa = m.JenisPrestasiOrmawa.Nama,
                            NamaPrestasi = m.NamaPrestasi,
                            InstitusiPenyelenggara = m.InstitusiPenyelenggara
                        };
            return query;
        }
    }

}

