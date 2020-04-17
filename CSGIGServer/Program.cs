using CSGIGUserServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGServer
{
    class Program
    {
        public static void Main(String[] args)
        {/*
            GetUserFromByTokenResponse getUserFromByTokenResponse =
                new GigServerPersistentObjectService().GetUserFromByToken(new GetUserFromByTokenReqest()
                {
                    fbToken = "123456"
                });
                

            CheckSerialNumberObjectResponse checkSerialNumberObjectResponse =
                new GigServerPersistentObjectService().CheckSerialNumber(new CheckSerialNumberObjectRequest()
                {
                    SerialNumber = 17
                });
                */

            AcceptRequestResponse attachNewDeviceObjectResponse =
                new GigServerPersistentObjectService().AcceptRequest(new AcceptRequestRequest()
                {
                    UserToken = new UserToken()
                    {
                        fbToken = "123456789",
                        UserGuid = "guid2"
                    }
                });
        }
    }
}
