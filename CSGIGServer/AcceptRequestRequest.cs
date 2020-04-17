using CSGIGUserServer;
using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGServer
{
    public class AcceptRequestRequest : Ac4yServiceRequest
    {
        public UserToken UserToken { get; set; }
    }
}
