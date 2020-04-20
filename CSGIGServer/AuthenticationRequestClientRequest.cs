using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSGIGUserServer
{
    public class AuthenticationRequestClientRequest : Ac4yServiceRequest
    {
        public string fbToken { get; set; }
        public string CheckData { get; set; }

    }
}
