using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.BusinessModel
{
    public class AuthenticationException : Exception
    {
        public string ErrorMessage { get; }
        public AuthenticationException()
        {

        }

        public AuthenticationException(string message)
        {
            ErrorMessage = message;
        }
    }
}
