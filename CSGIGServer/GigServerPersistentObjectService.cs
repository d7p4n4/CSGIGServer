using CSGIGUserServer;
using Modul.Final.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSGIGServer
{
    public class GigServerPersistentObjectService
    {
        public InsertResponse Insert(InsertRequest request)
        {
            InsertResponse response = new InsertResponse();

            try
            {
                response.User = new EFUserMethodsCAP().Insert(request.User);

                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;

        }

        public IsExistByFBTokenResponse isExistByFBToken(IsExistByFBTokenRequest request)
        {
            IsExistByFBTokenResponse response = new IsExistByFBTokenResponse();

            try { 
                if (new EFUserMethodsCAP().IsExistByFBToken(request.fbToken))
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "létezik" };
                else
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "nem létezik" };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }

        public GetByFBTokenResponse GetByFBToken(GetByFBTokenRequest request)
        {
            GetByFBTokenResponse response = new GetByFBTokenResponse();

            try
            {
                response.User = new EFUserMethodsCAP().GetByFBToken(request.fbToken);

                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }

        public isExistByIdResponse isExistById(isExistByIdRequest request)
        {
            isExistByIdResponse response = new isExistByIdResponse();

            try
            {
                if (new EFUserMethodsCAP().IsExistById(request.id))
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "létezik" };
                else
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "nem létezik" };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }
        
        public GetByIdResponse GetById(GetByIdRequest request)
        {
            GetByIdResponse response = new GetByIdResponse();

            try
            {
                response.User = new EFUserMethodsCAP().GetById(request.id);

                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }
        
        public isExistByGuidResponse isExistByGuid(isExistByGuidRequest request)
        {
            isExistByGuidResponse response = new isExistByGuidResponse();

            try
            {
                if (new EFUserMethodsCAP().IsExistByGuid(request.Guid))
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "létezik" };
                else
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "nem létezik" };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }

        public GetByGuidResponse GetByGuid(GetByGuidRequest request)
        {
            GetByGuidResponse response = new GetByGuidResponse();

            try
            {
                response.User = new EFUserMethodsCAP().GetByGuid(request.Guid);

                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }

        public IsUnknownOrInvalidTokenResponse IsUnknownOrInvalidToken(IsUnknownOrInvalidTokenRequest request)
        {
            IsUnknownOrInvalidTokenResponse response = new IsUnknownOrInvalidTokenResponse();

            try
            {
                if (new GigServerService().IsUnknownOrInvalidToken(request.fbToken))
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "létezik" };
                else
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "nem létezik" };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }
        
        public LoginRequestResponse LoginRequest(LoginRequestRequest request)
        {
            LoginRequestResponse response = new LoginRequestResponse();

            try
            {
                if (new GigServerService().LoginRequest(request.fbToken))
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "Mehet a login, a token rendben" };

                    try
                    {
                        new AuthenticationServerClient()
                        {
                            Server = "https://fcm.googleapis.com/fcm/send",
                            ServerKey = "AAAAMrfsOZQ:APA91bE_BRElbjcU7XZyAZn6Yw8C8bhOS1vd3gWGch9am14IepEIJleW_ZKGACIyGzz3gxuQpLwVUcZuZcsRWg7k0UbnJ3_SWL87tCT41I6ALga7lnANK-WlhV94mOn5b08mIVaVv1Dx"
                        }.AuthenticatioRequest(new AuthenticatioRequestRequest() { fbToken = request.fbToken });

                        response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "Authentikáció sikeres" };

                    }
                    catch (Exception exception)
                    {
                        response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
                    }

                }
                
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }

        public GetUserFromByTokenResponse GetUserFromByToken(GetUserFromByTokenReqest request)
        {
            GetUserFromByTokenResponse response = new GetUserFromByTokenResponse();

            try
            {
                GetUserGuidByFBTokenResponse getUserGuidByFBTokenResponse =
                    new UserServerObjectService().GetUserGuidByToken(new GetUserGuidByFBTokenRequest()
                    {
                        fbToken = request.fbToken
                    });

                if (getUserGuidByFBTokenResponse.Result.Success())
                {
                    response.UserGuid = getUserGuidByFBTokenResponse.UserGuid;
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "létezik" };
                }
                else
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "nem létezik" };
                }

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }

    }

}

