using CSGIGUserServer;
using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGServer
{
    public class AcceptRequestRequest : Ac4yServiceRequest
    {
        public string fbToken { get; set; }
        public string UserGuid { get; set; }
    }
}
