using System;
using System.Collections.Generic;
using System.Text;

namespace CSGIGServer
{
    class Program
    {
        public static void Main(String[] args)
        {
            GetUserFromByTokenResponse getUserFromByTokenResponse =
                new GigServerPersistentObjectService().GetUserFromByToken(new GetUserFromByTokenReqest()
                {
                    fbToken = "123456"
                });

            Console.WriteLine(getUserFromByTokenResponse);
        }
    }
}
