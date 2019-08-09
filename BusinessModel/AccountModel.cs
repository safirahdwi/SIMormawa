using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPB.Ldap;
using Microsoft.Extensions.Configuration;
using Ormawa.Models;
using Ormawa.ViewModels;

namespace Ormawa.BusinessModel
{
    public class AccountModel
    {
        private readonly DBINTEGRASI_MASTER_BAYUPPKU2Context _db;
        private readonly ILdapServer _ldap;
        private readonly IConfiguration _config;
        private const int JenisSistemID = 22;
        private const int JenisPenggunaMahasiswa = 177;
        private const int JenisPenggunaOrmawa = 178;
        private const int JenisPenggunaSuperUser = 179;

        public AccountModel(DBINTEGRASI_MASTER_BAYUPPKU2Context db, ILdapServer ldap, IConfiguration config)
        {
            _db = db;
            _ldap = ldap;
            _config = config;
        }
        public async Task<LdapUser> Authenticate(string username, string password)
        {
            try
            {
                var ldapUser = _ldap.Authenticate(username, password);
                if (ldapUser == null) throw new AuthenticationException("Username tidak ditemukan");
                return ldapUser;
            }
            catch (LdapAuthenticationException e)
            {
                throw new AuthenticationException(e.Message);
            }
        }
        public List<RoleViewModel> QueryMahasiswa(string nim, string username)
        {
            var query = (from akd in _db.Akd_DaftarMahasiswaMultiStratas
                         join jpeng in _db.JenisPengguna on JenisPenggunaMahasiswa equals jpeng.Id
                         where akd.NIM == nim
                         select new RoleViewModel
                         {
                             OrangID = akd.OrangID.ToString(),
                             JenisPenggunaID = jpeng.Id.ToString(),
                             JenisPengguna = jpeng.Nama,
                             StrukturOrganisasiID = "",
                             StrukturOrganisasi = akd.Departemen,
                             Nama = akd.Nama,
                             Username = username,
                             MahasiswaID = akd.MahasiswaID.ToString()
                         }).Distinct().ToList();
            return query;
        }

        public DaftarAnggotaOrmawaViewModel GetNamaOrganisasi(int id)
        {
            var himpunan = from m in _db.AnggotaOrmawa
                           join p in _db.OrganisasiOrmawa on m.OrganisasiOrmawaId equals p.Id
                           where m.MahasiswaId == id
                           select new DaftarAnggotaOrmawaViewModel()
                           {
                               Id = m.Id,
                               //Mahasiswa = m.Nama,
                               OrganisasiOrmawa = p.Nama
                           };
            return himpunan.FirstOrDefault();
        }

        public List<RoleViewModel> LoginMahasiswa(string nim, string username)
        {
            var role = new List<RoleViewModel>();

            //if (!string.IsNullOrWhiteSpace(nim))
            //{
            //    var query = QueryMahasiswa(nim, username);
            //    role.AddRange(query);
            //}

            if (!string.IsNullOrEmpty(username))
            {
                //Cek ke tabel Pengguna
                var querypengguna = from p in _db.Pengguna
                                    join h in _db.HakAksesPengguna on p.Id equals h.PenggunaId
                                    join m in _db.Mahasiswa on p.OrangId equals m.OrangId
                                    where p.Username == username && h.JenisPengguna.JenisSistemId == AccountModel.JenisSistemID && p.IsBlokir != true
                                    select new
                                    {
                                        p.Orang.Nama,
                                        h.JenisPenggunaId,
                                        JenisPengguna = h.JenisPengguna.Nama,
                                        StrukturOrganisasi = h.StrukturOrganisasi.Nama,
                                        h.StrukturOrganisasiId,
                                        OrangId = p.OrangId,
                                        MahasiswaID = m.Id
                                    };
                //USER PENGGUNA
                foreach (var pg in querypengguna)
                {
                    role.Add(new RoleViewModel(pg.OrangId.ToString(), pg.Nama, pg.JenisPenggunaId.ToString(),
                        pg.JenisPengguna, pg.StrukturOrganisasiId.ToString(), pg.StrukturOrganisasi, pg.MahasiswaID.ToString()));
                }
            }

            // jadikan unique untuk satu StrukturOrganisasi
            //role = role.GroupBy(r => r.StrukturOrganisasiID).Select(g => g.First()).ToList();
            role.ForEach(e =>
            {
                e.OrangID = e.OrangID;
                e.JenisPenggunaID = e.JenisPenggunaID;
                e.StrukturOrganisasiID = e.StrukturOrganisasiID;
            });

            return role;

        }
    }
}
