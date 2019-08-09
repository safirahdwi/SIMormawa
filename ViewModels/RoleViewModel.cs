using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.ViewModels
{
    public class RoleViewModel
    {
        public string Username { get; set; }
        public string Nama { get; set; }
        public string OrangID { get; set; }
        public string PegawaiID { get; set; }
        public string JenisPengguna { get; set; }
        public string JenisPenggunaID { get; set; }
        public string StrukturOrganisasiID { get; set; }
        public string StrukturOrganisasi { get; set; }
        public string MahasiswaID { get; set; }

        public RoleViewModel() { }
        public RoleViewModel(string OrangID, string Nama, string JenisPenggunaID, string JenisPengguna, string StrukturOrganisasiID, string StrukturOrganisasi, string MahasiswaID)
        {
            this.OrangID = OrangID;
            this.Nama = Nama;
            this.JenisPenggunaID = JenisPenggunaID;
            this.JenisPengguna = JenisPengguna;
            this.StrukturOrganisasiID = StrukturOrganisasiID;
            this.StrukturOrganisasi = StrukturOrganisasi;
            this.MahasiswaID = MahasiswaID;
        }
    }
}
