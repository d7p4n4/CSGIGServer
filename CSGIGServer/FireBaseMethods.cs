using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CSGIGServer
{
    public class FireBaseMethods
    {
        public FireBaseResponse SendNotification(FireBaseRequest requestFB)
        {
            FireBaseResponse fireBaseResponse = new FireBaseResponse();
            FireBaseResult fireBaseResult = new FireBaseResult();

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://fcm.googleapis.com/fcm/send"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", "key=" + requestFB.FireBaseKey);

                    request.Content = new StringContent("{\n \"to\" : \"" + requestFB.Token + "\",\n \"notification\" : {\n \"body\" : \"" + requestFB.MessageBody + "\",\n \"title\" : \"" + requestFB.MessageTitle + "\",\n \"content_available\" : true,\n \"priority\" : \"high\"\n },\n \"data\" : {\n \"body\" : \"" + requestFB.MessageBody + "\",\n \"title\" : \"" + requestFB.MessageTitle + "\",\n \"content_available\" : true,\n \"priority\" : \"high\"\n } \n}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = httpClient.SendAsync(request).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        fireBaseResult.SuccessResponse = new FireBaseSuccessResponse();
                        fireBaseResponse.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
                    }
                    else
                    {
                        fireBaseResult.FailedResponse = new FireBaseFailedResponse();
                        fireBaseResponse.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = "HIBA!" };
                    }

                    fireBaseResponse.FireBaseResult = fireBaseResult;
                    return fireBaseResponse;

                }
            }
        }
    }
}
