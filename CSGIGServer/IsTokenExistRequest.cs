using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGServer
{
    public class IsTokenExistRequest : Ac4yServiceRequest
    {
        public string fbToken { get; set; }
    }
}
