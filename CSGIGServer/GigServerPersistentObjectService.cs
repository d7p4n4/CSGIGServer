using CSGIGAuthenticationServer;
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

            try
            {
                IsExistTokenByTokenResponse isExistTokenByTokenResponse =
                    new UserServerObjectService().IsExistTokenByToken(new IsExistTokenByTokenRequest()
                    {
                        fbToken = request.fbToken
                    });

                if (isExistTokenByTokenResponse.Result.Success())
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
                IsUnknownOrInvalidTokenResponse isUnknownOrInvalidTokenResponse =
                    new UserServerObjectService().IsUnknownOrInvalidToken(new IsUnknownOrInvalidTokenRequest()
                    {
                        fbToken = request.fbToken
                    });

                if (isUnknownOrInvalidTokenResponse.Result.Success())
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "unknown or invalid token" };
                else
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "létező token" };
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
                IsUnknownOrInvalidTokenResponse isUnknownOrInvalidTokenResponse =
                    new UserServerObjectService().IsUnknownOrInvalidToken(new IsUnknownOrInvalidTokenRequest()
                        { 
                            fbToken = request.fbToken
                        });

                if (!isUnknownOrInvalidTokenResponse.Result.Success())
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "Mehet a login, a token rendben" };

                    int checkData = new Generator().CheckDataGenerator();

                    User user = null;

                    GetUserByTokenResponse getUserByTokenResponse =
                        new UserServerObjectService().GetUserByToken(new GetUserByTokenRequest()
                        {
                            fbToken = request.fbToken
                        });

                    if (getUserByTokenResponse.Result.Success())
                    {
                        user = getUserByTokenResponse.User;

                        isExistByGuidResponse isExistByGuidResponse =
                            new UserServerObjectService().IsExistByGuid(new isExistByGuidRequest()
                            {
                                Guid = user.Guid
                            });

                        if (!isExistByGuidResponse.Result.Success())
                        {

                            AuthenticationRequestInsertResponse authenticationRequestInsertResponse =
                                new UserServerObjectService().AuthenticationRequestInsert(new AuthenticationRequestInsertRequest()
                                {
                                    AuthenticationRequest = new AuthenticationRequest()
                                    {
                                        Guid = user.Guid,
                                        CheckData = checkData.ToString()
                                    }
                                });

                            response.AuthenticationRequest = authenticationRequestInsertResponse.AuthenticationRequest;
                            response.fbToken = request.fbToken;
                            response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "Sikeres request insert" };
                        }
                        else
                        {
                            response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "Ezzel a guiddal már létezik rekord a db-ben" };
                        }
                    }
                    else
                    {
                        response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "Technikai hiba történt, próbálja meg később" };
                    }
                    
                }
                else
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "Ismeretlen, lejárt, ..." };
                }

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }
     
        public CheckSerialNumberObjectResponse CheckSerialNumber(CheckSerialNumberObjectRequest request)
        {
            CheckSerialNumberObjectResponse response = new CheckSerialNumberObjectResponse();

            try
            {
                CheckSerialNumberResponse checkSerialNumberResponse =
                    new UserServerObjectService().CheckSerialNumber(new CheckSerialNumberRequest()
                    {
                        SerialNumber = request.SerialNumber,
                        fbToken = request.fbToken
                    });

                if (checkSerialNumberResponse.Result.Success())
                {
                    response.UserGuid = checkSerialNumberResponse.UserGuid;
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "létezik" };
                }
                else
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "nem létezik az adott sorszám, vagy a token már hozzá van rendelve" };
                }

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }

        public SendAcceptRequestResponse SendAcceptRequest(SendAcceptRequestRequest request)
        {
            return new SendAcceptRequestResponse();
        }

        public AttachNewDeviceObjectResponse AttachNewDevice(AttachNewDeviceObjectRequest request)
        {
            AttachNewDeviceObjectResponse response = new AttachNewDeviceObjectResponse();

            try
            {
                AttachNewDeviceResponse attachNewDeviceResponse =
                    new UserServerObjectService().AttachNewDevice(new AttachNewDeviceRequest()
                    {
                        UserToken = request.UserToken
                    });

                if (attachNewDeviceResponse.Result.Success())
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "Sikeres insert" };

                    DeleteUserResponse deleteUserResponse =
                        new UserServerObjectService().DeleteUser(new DeleteUserRequest()
                        {
                            fbToken = request.UserToken.fbToken
                        });

                    if(deleteUserResponse.Result.Success())
                        response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "Sikeres insert és delete" };
                }
                else
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "Insert nem sikerült" };
                }

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }


        public AcceptRequestResponse AcceptRequest(AcceptRequestRequest request)
        {
            AcceptRequestResponse response = new AcceptRequestResponse();

            try
            {
                AttachNewDeviceResponse attachNewDeviceResponse =
                    new UserServerObjectService().AttachNewDevice(new AttachNewDeviceRequest()
                    {
                        UserToken = request.UserToken
                    });

                if (attachNewDeviceResponse.Result.Success())
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "Sikeres insert" };
                }
                else
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "Insert nem sikerült" };
                }

            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }

        public AuthenticationRequestGetByGuidResponse AuthenticationRequestGetByGuid(AuthenticationRequestGetByGuidRequest request)
        {
            AuthenticationRequestGetByGuidResponse response = new AuthenticationRequestGetByGuidResponse();

            try
            {
                CSGIGUserServer.AuthenticationRequestGetByGuidResponse authenticationRequestGetByGuidResponse =
                    new UserServerObjectService().AuthenticationRequestGetByGuid(new CSGIGUserServer.AuthenticationRequestGetByGuidRequest()
                    {
                        Guid = request.Guid
                    });

                if (authenticationRequestGetByGuidResponse.Result.Success())
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "Létezik adott guiddal request" };
                    response.AuthenticationRequest = authenticationRequestGetByGuidResponse.AuthenticationRequest;
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

        public AcceptAuthenticationResponse AcceptAuthentication(AcceptAuthenticationRequest request)
        {
            AcceptAuthenticationResponse response = new AcceptAuthenticationResponse();

            try
            {
                response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "A reguestGuid: " + request.RequestGuid +
                    " és a checkData: " + request.CheckData + " megérkezett." };
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }

        public SignUpRequestResponse SignUpRequest(SignUpRequestRequest request)
        {
            SignUpRequestResponse response = new SignUpRequestResponse();

            try
            {
                IsExistTokenByTokenResponse isExistTokenByTokenResponse =
                    new UserServerObjectService().IsExistTokenByToken(new IsExistTokenByTokenRequest()
                    {
                        fbToken = request.fbToken
                    });

                if (isExistTokenByTokenResponse.Result.Success())
                {
                    throw new Exception("Már létezik az adatbázisban ez a token");

                    //response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = "A token már létezik a db-ben" };
                }

                string guid = new Generator().GuidGenerator();

                InsertNewUserResponse insertNewUserResponse =
                    new UserServerObjectService().InsertNewUser(new InsertNewUserRequest()
                    {
                        User = new User()
                        {
                            Guid = guid,
                            Name = request.Name,
                            UserName = request.UserName,
                            PhoneNumber = request.PhoneNumber,
                            Email = request.Email,
                            Password = request.Password
                        }
                    });

                if (insertNewUserResponse.Result.Success())
                {
                    InsertNewTokenResponse insertNewTokenResponse =
                        new UserServerObjectService().InsertNewToken(new InsertNewTokenRequest()
                        {
                            UserToken = new UserToken()
                            {
                                fbToken = request.fbToken,
                                UserGuid = guid
                            }
                        });

                    if(insertNewTokenResponse.Result.Success())
                        response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "Mindkét insert, így a sign up is sikeres" };
                }
            }
            catch (Exception exception)
            {
                response.Result = (new Ac4yProcessResult() { Code = Ac4yProcessResult.FAIL, Message = exception.Message, Description = exception.StackTrace });
            }
            return response;
        }

        public IsTokenExistResponse IsTokenExist(IsTokenExistRequest request)
        {
            IsTokenExistResponse response = new IsTokenExistResponse();

            try
            {
                IsExistTokenByTokenResponse isExistTokenByTokenResponse =
                    new UserServerObjectService().IsExistTokenByToken(new IsExistTokenByTokenRequest()
                    {
                        fbToken = request.fbToken
                    });

                if (isExistTokenByTokenResponse.Result.Success())
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.SUCCESS, Message = "létezik a token" };
                }
                else
                {
                    response.Result = new Ac4yProcessResult() { Code = Ac4yProcessResult.INEFFECTIVE, Message = "nem létezik a token" };
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

