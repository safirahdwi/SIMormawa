using Ormawa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ormawa.ViewModels;

namespace Ormawa.BusinessModel
{
    public class OrganisasiOrmawaRepo
    {
        private readonly DBINTEGRASI_MASTER_BAYUPPKU2Context _context;

        public OrganisasiOrmawaRepo(DBINTEGRASI_MASTER_BAYUPPKU2Context context)
        {
            _context = context;
        }

        public IQueryable<OrganisasiOrmawaRow> GetOrganisasiList()
        {
            var query = from o in _context.OrganisasiOrmawa
                        join j in _context.JenisOrganisasi on o.JenisOrganisasiId equals j.Id
                        select new OrganisasiOrmawaRow
                        {
                            Id = o.Id,
                            JenisOrganisasi = j.Nama,
                            Nama = o.Nama,
                          
                        };
            return query;
        }

        public IEnumerable<OrganisasiOrmawaVM> GetOrganisasiDetails(int id)
        {
            var query = from i in _context.AnggotaOrmawa
                        join j in _context.OrganisasiOrmawa on i.OrganisasiOrmawaId equals j.Id
                        join mhs in _context.Mahasiswa on i.MahasiswaId equals mhs.Id
                        join org in _context.Orang on mhs.OrangId equals org.Id
                        where j.Id == id
                        select new OrganisasiOrmawaVM
                        {
                            Id = i.Id,
                            Mahasiswa = org.Nama,
                            OrganisasiOrmawa = j.Nama,
                            StatusAnggota = i.StatusAnggota
                        };
            return query.ToList();
        }

        
    }
}
