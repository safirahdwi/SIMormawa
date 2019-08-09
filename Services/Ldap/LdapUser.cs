using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novell.Directory.Ldap;

namespace IPB.Ldap
{
    public class LdapUser
    {
        public static LdapUser FromEntry(LdapEntry entry)
        {
            var attributes = entry.getAttributeSet();
            var iter = attributes.GetEnumerator();
            var user = new LdapUser();
            while (iter.MoveNext())
            {
                var attribute = (LdapAttribute)iter.Current;
                var attributeName = attribute.Name.ToUpper();
                var values = attribute.StringValueArray;
                switch (attributeName)
                {
                    case "UID":
                        user.Uid = values[0]; break;
                    case "CN":
                        user.Name = values[0]; break;
                    case "MAIL":
                        user.Email = values[0]; break;
                    case "NIP":
                        user.Nip = values[0]; break;
                    case "NRP":
                        user.Nim = values[0]; break;
                    case "OBJECTCLASS":
                        foreach (var v in values)
                        {
                            switch (v)
                            {
                                case "student":
                                    user.TipeAkun = TipeAkunLdap.Student;
                                    break;
                                case "tendik":
                                    user.TipeAkun = TipeAkunLdap.Tendik;
                                    break;
                                //case "dosen":
                                //    user.TipeAkun = TipeAkunLdap.Dosen;
                                //    break;
                            }
                        }
                        break;
                }
            }

            return user;
        }

        public string Uid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Nip { get; set; }
        public string Nim { get; set; }
        public TipeAkunLdap TipeAkun { get; set; }
    }
}
