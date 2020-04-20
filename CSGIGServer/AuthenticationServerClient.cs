using CSGIGUserServer;
using Modul.Final.Class;
using SycomplaWebAppClientCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSGIGServer
{
    public class AuthenticationServerClient
    {
        public string Server { get; set; }
        public string ServerKey { get; set; }

        public AuthenticationServerClient() { }

        public AuthenticationServerClient(string server, string serverKey)
        {
            Server = server;
            ServerKey = serverKey;
        }

        public AuthenticationRequestClientResponse AuthenticatioRequest(AuthenticationRequestClientRequest request)
        {
            AuthenticationRequestClientResponse response = new AuthenticationRequestClientResponse();

            try{
                new Ac4yRestServiceClient(Server, ServerKey).POST("", "{\r\n \"to\" : \"" + request.fbToken + "\",\r\n\r\n \"data\" : {\r\n \"body\" : \"" + request.CheckData + "\"\r\n } \r\n}");

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
