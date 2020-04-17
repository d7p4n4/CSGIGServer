using CSGIGUserServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSGIGServer
{
    public class GigServerService
    {
        public bool IsUnknownOrInvalidToken(string fbToken)
        {
            return !(new EFUserMethodsCAP().IsExistByFBToken(fbToken));
        }

        public bool LoginRequest(string fbToken)
        {
            if (IsUnknownOrInvalidToken(fbToken))
                throw new Exception("Unknown or Invalid Token!");

            return true;
        }
    }
}
