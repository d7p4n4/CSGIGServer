using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGServer
{
    public class CheckSerialNumberObjectRequest : Ac4yServiceRequest
    {
        public int SerialNumber { get; set; }
    }
}
