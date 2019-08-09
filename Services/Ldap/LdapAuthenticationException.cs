using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPB.Ldap
{
    public class LdapAuthenticationException : Exception
    {
        public LdapAuthenticationException()
        {
        }

        public LdapAuthenticationException(string message) : base(message)
        {
        }
    }
}
