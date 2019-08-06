using Ormawa.Models;
using Ormawa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.BusinessModel
{
    public class UploadRepo
    {
        private readonly DBINTEGRASI_MASTER_BAYUPPKU2Context _context;

        public UploadRepo(DBINTEGRASI_MASTER_BAYUPPKU2Context context)
        {
            _context = context;
        }
        public IQueryable<UploadRow> GetUploadList()
        {
            var query = from o in _context.PengajuanProposalKegiatan
                        join b in _context.DaftarDokumenOrmawa on o.Id equals b.PengajuanProposalKegiatanId
                        join c in _context.DokumenOrmawa on b.DokumenOrmawaId equals c.Id
                        join d in _context.JenisKegiatanOrmawa on o.JenisKegiatanOrmawaId equals d.Id
                        join e in _context.AnggotaOrmawa on o.AnggotaOrmawaId equals e.Id
                        join f in _context.AnggotaOrmawa on o.PenanggungJawabId equals f.Id
                        join g in _context.TipeKegiatanOrmawa on o.TipeKegiatanOrmawaId equals g.Id
                        select new UploadRow
                        {
                            Id = o.Id,
                            Jenis = d.Nama,
                            //ang = e.Mahasiswa.Orang.Nama,
                            PenanggungJawab = f.Mahasiswa.Orang.Nama,
                            // tipe = g.Nama,
                            // jenis = d.Nama,
                            //DanaAnggaran = Convert.ToInt64(o.DanaAnggaran),
                            //  url = c.URLDokumen,
                            //NamaDokumen = c.Nama,
                            Kegiatan = o.Kegiatan,
                            //AnggotaOrmawa = e.Mahasiswa.Orang.Nama,


                        };
            return query;

        }
        public UploadViewModel GetDetail(int Id)
        {
            var query = from peng in _context.PengajuanProposalKegiatan
                        join daf in _context.DaftarDokumenOrmawa on peng.Id equals daf.PengajuanProposalKegiatanId
                        join dok in _context.DokumenOrmawa on daf.DokumenOrmawaId equals dok.Id
                        join jen in _context.JenisKegiatanOrmawa on peng.JenisKegiatanOrmawaId equals jen.Id
                        join ang in _context.AnggotaOrmawa on peng.AnggotaOrmawaId equals ang.Id
                        join pj in _context.AnggotaOrmawa on peng.PenanggungJawabId equals pj.Id
                        join tipe in _context.TipeKegiatanOrmawa on peng.TipeKegiatanOrmawaId equals tipe.Id
                        where peng.Id == Id
                        select new UploadViewModel
                        {
                            Id = peng.Id,
                            Nama = jen.Nama,
                            AnggotaOrmawa = ang.Mahasiswa.Orang.Nama,
                            PenanggungJawab = pj.Mahasiswa.Orang.Nama,
                            tipe = tipe.Nama,
                            jenis = jen.Nama,
                            DanaAnggaran = Convert.ToInt64(peng.DanaAnggaran),
                            url = dok.Urldokumen,
                            NamaDokumen = dok.Nama,
                            Kegiatan = peng.Kegiatan,
                            

                        };

            return query.FirstOrDefault();

        }
        public void Insert (UploadViewModel vmod)
        {
            DokumenOrmawa dokumen = new DokumenOrmawa();
            dokumen.Nama = vmod.Nama;
            dokumen.Urldokumen = vmod.Urldokumen;
            dokumen.JenisDokumenId = vmod.JenisDokumenId;
            _context.DokumenOrmawa.Add(dokumen);

            PengajuanProposalKegiatan pengajuan = new PengajuanProposalKegiatan();
            pengajuan.DanaAnggaran = vmod.DanaAnggaran;
            pengajuan.Kegiatan = vmod.Kegiatan;
            pengajuan.AnggotaOrmawaId = 2;
            pengajuan.TipeKegiatanOrmawaId = vmod.TipeKegiatanOrmawaId;
            pengajuan.JenisKegiatanOrmawaId = vmod.JenisKegiatanOrmawaId;
            pengajuan.PenanggungJawabId = 7;
            _context.PengajuanProposalKegiatan.Add(pengajuan);

            DaftarDokumenOrmawa daftar = new DaftarDokumenOrmawa();
            daftar.PengajuanProposalKegiatanId = pengajuan.Id;
            daftar.DokumenOrmawaId = dokumen.Id;
            _context.DaftarDokumenOrmawa.Add(daftar);
            _context.SaveChanges();
        }
}
}
