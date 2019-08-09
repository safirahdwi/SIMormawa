using System;
using System.Collections.Generic;

namespace Ormawa.Models
{
    public partial class Departemen
    {
        public Departemen()
        {
            Mayor = new HashSet<Mayor>();
        }

        public int Id { get; set; }
        public int FakultasId { get; set; }
        public string Kode { get; set; }
        public int? Kadep { get; set; }
        public DateTime? TanggalDibentuk { get; set; }
        public string DepartemenBkey { get; set; }

        public virtual StrukturOrganisasi IdNavigation { get; set; }
        public virtual ICollection<Mayor> Mayor { get; set; }
    }
}
