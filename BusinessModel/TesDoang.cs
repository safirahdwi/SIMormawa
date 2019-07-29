using Ormawa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.BusinessModel
{
    public class TesDoang
    {
        private readonly DBINTEGRASI_MASTER_BAYUPPKU2Context _db;

        public TesDoang(DBINTEGRASI_MASTER_BAYUPPKU2Context db)
        {
            _db = db;
        }

        public Orang Orang()
        {
            var a = from s in _db.Orang
                    select s;
            return a.FirstOrDefault();
        }
    }
}
