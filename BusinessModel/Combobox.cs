
using Ormawa.Models;
using Ormawa.ViewModel;
using Ormawa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.BusinessModel
{
    public class Combobox
    {
        private readonly DBINTEGRASI_MASTER_BAYUPPKU2Context _context;

        public Combobox(DBINTEGRASI_MASTER_BAYUPPKU2Context context)
        {
            _context = context;
        }

        //Daftar Anggota
        public List<ComboboxViewModel> Mahasiswa()
        {
            var mhs = from m in _context.Mahasiswa
                      join o in _context.Orang on m.OrangId equals o.Id
                      join ms1 in _context.MahasiswaSarjana on m.Id equals ms1.MahasiswaId
                      where m.Id == ms1.MahasiswaId
                      select new ComboboxViewModel
                      {
                          ID = m.Id.ToString(),
                          Value = o.Nama
                      };
            return mhs.ToList();
        }

        //DaftarOrmawa
        public List<ComboboxViewModel> OrganisasiOrmawa()
        {
            var orw = from m in _context.OrganisasiOrmawa
                      select new ComboboxViewModel
                      {
                          ID = m.Id.ToString(),
                          Value = m.Nama
                      };
            return orw.ToList();
        }

        //PengajuanProposal
        public List<ComboboxViewModel> AnggotaOrmawa()
        {
            var Anggota = from m in _context.AnggotaOrmawa
                          join o in _context.OrganisasiOrmawa on m.OrganisasiOrmawaId equals o.Id
                          select new ComboboxViewModel
                          {
                              ID = m.Id.ToString(),
                              Value = o.Nama
                          };
            return Anggota.ToList();
                   
        }
        public List<ComboboxViewModel> TipeKegiatanOrmawa()
        { 
            var TipeKegiatan = from m in _context.TipeKegiatanOrmawa
                      select new ComboboxViewModel
                      {
                          ID = m.Id.ToString(),
                          Value = m.Nama
                      };
            return TipeKegiatan.ToList();
        }

        public List<ComboboxViewModel> JenisKegiatanOrmawa()
        {
            var JenisKegiatan = from m in _context.JenisKegiatanOrmawa
                               select new ComboboxViewModel
                               {
                                   ID = m.Id.ToString(),
                                   Value = m.Nama
                               };
            return JenisKegiatan.ToList();
        }

        //DaftarPrestasi
        public List<ComboboxViewModel> JenisPrestasiOrmawa()
        {
            var JenisPrestasi = from m in _context.JenisPrestasiOrmawa
                                select new ComboboxViewModel
                                {
                                    ID = m.Id.ToString(),
                                    Value = m.Nama
                                };
            return JenisPrestasi.ToList();
        }

        //StrukturalOrmawa
        public List<ComboboxViewModel> JenisJabatanOrmawa()
        {
            var JabatanOrmawa = from m in _context.JabatanOrmawa
                                select new ComboboxViewModel
                                {
                                    ID = m.Id.ToString(),
                                    Value = m.Nama
                                };
            return JabatanOrmawa.ToList();
        }

        //DaftarOrmawa
        public List<ComboboxViewModel> Ormawa()
        {
            var orw = from m in _context.OrganisasiOrmawa
                      select new ComboboxViewModel
                      {
                          ID = m.Id.ToString(),
                          Value = m.Nama
                      };
            return orw.ToList();
        }

        /* public List<ComboboxViewModel> PenanggungJawabOrmawa()
         {
             var JenisKegiatan = from m in _context.Pen
                                 select new ComboboxViewModel
                                 {
                                     ID = m.Id.ToString(),
                                     Value = m.Nama
                                 };
             return JenisKegiatan.ToList();
         }*/
    }
}
