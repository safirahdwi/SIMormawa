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
                            NamaEn = o.NamaEn,
                            NomorSk = o.NomorSk,
                            Tmt = o.Tmt,
                            Tst = o.Tst
                        };
            return query;
        }

        public OrganisasiOrmawaVM GetOrganisasiDetails(int id)
        {
            var query = from o in _context.OrganisasiOrmawa
                        join j in _context.JenisOrganisasi on o.JenisOrganisasiId equals j.Id
                        where o.Id == id
                        select new OrganisasiOrmawaVM
                        {
                            Id = o.Id,
                            JenisOrganisasi = j.Nama,
                            Nama = o.Nama,
                            NamaEn = o.NamaEn,
                            NomorSk = o.NomorSk,
                            Tmt = o.Tmt,
                            Tst = o.Tst
                        };
            return query.FirstOrDefault();
        }
    }
}
