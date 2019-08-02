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
            var query = from o in _context.DokumenOrmawa
                       // join j in _context.JenisDokumen on o.JenisDokumenId equals j.Id
                        select new UploadRow
                        {
                            Id = o.Id,
                            Nama = o.Nama,
                            Urldokumen = o.Urldokumen,
                            //JenisDokumen = o.JenisDokumen
                        };
            return query;
        }
}
}
