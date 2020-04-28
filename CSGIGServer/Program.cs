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
            
            CheckSerialNumberObjectResponse checkSerialNumberObjectResponse =
                new GigServerPersistentObjectService().CheckSerialNumber(new CheckSerialNumberObjectRequest()
                {
                    SerialNumber = 1,
                    fbToken = "123456"
                });
                
            
            AcceptRequestResponse attachNewDeviceObjectResponse =
                new GigServerPersistentObjectService().AcceptRequest(new AcceptRequestRequest()
                {
                    UserToken = new UserToken()
                    {
                        fbToken = "123456789",
                        UserGuid = "guid2"
                    }
                });
                
            AuthenticationRequestInsertResponse authenticationRequestInsertResponse =
                new GigServerPersistentObjectService().AuthenticationRequestInsert(new AuthenticationRequestInsertRequest()
                {
                    AuthenticationRequest = new AuthenticationRequest()
                    {
                        Guid = new Generator().GuidGenerator(),
                        CheckData = new Generator().CheckDataGenerator().ToString()
                    }
                });

            AuthenticationRequestGetByGuidResponse authenticationRequestGetByGuidResponse =
                new GigServerPersistentObjectService().AuthenticationRequestGetByGuid(new AuthenticationRequestGetByGuidRequest()
                {
                    Guid = "��f2�6�OBy�?D�@>�$L����a��@�-Q}��a9�������m���1VdE8��q?!"
                });
                */
            LoginRequestResponse loginRequestResponse =
                new GigServerPersistentObjectService().LoginRequest(new LoginRequestRequest()
                {
                    fbToken = "c6QuWuYRrEDsn58FUUp_7D:APA91bHD3AbJ7IvcyJycQ1zqx7Y0ohRUmVOjuBj8ag0wugh_ffTHOivGKTimYqSWozEccJ3I-TQOKv5rs9AOaNBD_RXtrjBIKZqZEeMvzjoDxc1-kt_tM_7qK51763wTjHL1ul_G5pAE"
                });/*

            SignUpRequestResponse signUpRequestResponse =
                new GigServerPersistentObjectService().SignUpRequest(new SignUpRequestRequest()
                {
                    fbToken = "c6QuWuYRrEDsn58FUUp_7D:APA91bEDmyi_yR7tIBEqrfg2hRHAOf1j2Nre0QAdT4Btx3bJrxropZYTmD6YooKh5O59WQZF_9EHAM04if5BJuZwk_16-FYmj7rs31zIuoI_ZIrzXA3TwPmpcxZRVNZ4dnVDaqn3Z7ZD"
                });
                
            CheckSerialNumberObjectResponse checkSerialNumberObjectResponse =
                new GigServerPersistentObjectService().CheckSerialNumber(new CheckSerialNumberObjectRequest()
                {
                    fbToken = "c6QuWuYRrEDsn58FUUp_7D:APA91bFwFWffQjPiIiJ2117wvcIv_PkEkmxMGuURFx9c4YIIMp8mRUig2n7do7gxO9opoXmHvDJ_748Xn7_JdZWW3j7YSJO-mOKIuSEGPA2i6p6sH8sFoSBWblu3S_C4lYiV-W5jPhce",
                    SerialNumber = 2
                });

            string guid = checkSerialNumberObjectResponse.UserGuid;

            AcceptRequestResponse acceptRequestResponse =
                new GigServerPersistentObjectService().AcceptRequest(new AcceptRequestRequest()
                {
                    UserGuid = guid,
                    fbToken = "c6QuWuYRrEDsn58FUUp_7D:APA91bFwFWffQjPiIiJ2117wvcIv_PkEkmxMGuURFx9c4YIIMp8mRUig2n7do7gxO9opoXmHvDJ_748Xn7_JdZWW3j7YSJO-mOKIuSEGPA2i6p6sH8sFoSBWblu3S_C4lYiV-W5jPhce"
                });*/
        }
    }
}
