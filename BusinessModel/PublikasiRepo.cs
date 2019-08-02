using Ormawa.Models;
using Ormawa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.BusinessModel
{
    public class PublikasiRepo
    {
        private readonly DBINTEGRASI_MASTER_BAYUPPKU2Context _context;

        public PublikasiRepo(DBINTEGRASI_MASTER_BAYUPPKU2Context context)
        {
            _context = context;
        }

        public IQueryable<PublikasiRow> GetPublikasiList()
        {
            var query = from o in _context.PublikasiOrmawa
                        join j in _context.OrganisasiOrmawa on o.OrganisasiOrmawaId equals j.Id
                        //join j in _context.JenisOrganisasi on o.JenisOrganisasiId equals j.Id
                        select new PublikasiRow
                        {
                            Id = o.Id,
                            NamaOrganisasi = j.Nama,
                            Judul = o.Judul,
                        //    Isi = o.Isi,
                            Tanggal = o.TanggalInsert.ToString()
                        };
            return query;
        }

        public DaftarPublikasiOrmawaViewModel GetPublikasiDetails(int id)
        {
            var query = from o in _context.PublikasiOrmawa
                        join j in _context.OrganisasiOrmawa on o.OrganisasiOrmawaId equals j.Id
                        where o.Id == id
                        select new DaftarPublikasiOrmawaViewModel
                        {
                            Id = o.Id,
                            NamaOrganisasi = j.Nama,
                            Judul = o.Judul,
                            Isi = o.Isi,
                            TanggalInsert = o.TanggalInsert
                        };
            return query.FirstOrDefault();
        }

        public List <DashboardViewModel> GetPublikasiListDashboard()
        {
            var query = from o in _context.PublikasiOrmawa
                        join j in _context.OrganisasiOrmawa on o.OrganisasiOrmawaId equals j.Id
                        select new DashboardViewModel
                        {
                            Judul = o.Judul,
                            Nama = j.Nama,
                            Isi = o.Isi,
                            TanggalInsert = o.TanggalInsert
                        };
            return query.ToList();
        }

    }
}
