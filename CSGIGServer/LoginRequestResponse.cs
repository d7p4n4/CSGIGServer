﻿using CSGIGUserServer;
using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSGIGServer
{
    public class LoginRequestResponse : Ac4yServiceResponse
    {
        public AuthenticationRequest AuthenticationRequest { get; set; }
        public string fbToken { get; set; }
    }
}
