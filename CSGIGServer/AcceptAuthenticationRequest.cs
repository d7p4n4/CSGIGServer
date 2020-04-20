using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGServer
{
    public class AcceptAuthenticationRequest : Ac4yServiceRequest
    {
        public string RequestGuid { get; set; }
        public string CheckData { get; set; }
    }
}
