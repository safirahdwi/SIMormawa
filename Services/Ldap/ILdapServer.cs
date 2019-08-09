using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPB.Ldap
{
    public interface ILdapServer
    {
        LdapUser Authenticate(string username, string password);
        string Filter { get; set; }
    }
}
