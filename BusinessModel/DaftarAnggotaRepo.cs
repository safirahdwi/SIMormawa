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

        public AnggotaOrmawa AddAnggotaOrmawa(AnggotaOrmawa ao)
        {
            _context.AnggotaOrmawa.Add(ao);
            return ao;
        }

       /* public void AddStukturOrmawa()
        {
            var anggota = AddAnggotaOrmawa();
        }*/
    }

}

