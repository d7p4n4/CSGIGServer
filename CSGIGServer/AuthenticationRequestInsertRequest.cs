using CSGIGUserServer;
using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGServer
{
    public class AuthenticationRequestInsertRequest : Ac4yServiceRequest
    {
        public AuthenticationRequest AuthenticationRequest { get; set; } 
    }
}
