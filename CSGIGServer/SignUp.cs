using CSGIGUserServer;
using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSGIGServer
{
    public class SignUp
    {
        public SignUpRequestResponse SignUpRequest(SignUpRequestRequest request)
        {
            SignUpRequestResponse response = new SignUpRequestResponse();

            try
            {
                if (new EFUserMethodsCAP().IsExistByFBToken(request.fbToken))
                    throw new Exception("Már létezik az adatbázisban ez a token");

                string guid = new Generator().GuidGenerator();

                new EFUserMethodsCAP().Insert(new User() { FBToken = request.fbToken, Guid = guid });

                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }
    }
}
