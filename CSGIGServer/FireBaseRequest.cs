using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSGIGServer
{
    public class FireBaseRequest : Ac4yServiceRequest
    {
        public string FireBaseKey { get; set; }
        public string Token { get; set; }
        public string MessageBody { get; set; }
        public string MessageTitle { get; set; }
    }
}
