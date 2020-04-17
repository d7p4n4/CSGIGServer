using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSGIGServer
{
    public class GetUserFromByTokenResponse : Ac4yServiceResponse
    {
        public string UserGuid { get; set; }
    }
}
