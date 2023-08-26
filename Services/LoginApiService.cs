using EL.MAUI.BlackList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EL.MAUI.BlackList.Services
{
    
    public class LoginApiService
    {
        private readonly HttpClient _httpClient;
        private readonly DTBlackListService _blackListService;

        public LoginApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(Helpers.UriHelp.UriString)
            };
            _blackListService = new DTBlackListService();
        }

        public async Task<string> GetUserBase(string user, string password)
        {
            LoginModel loginModel = new()
            {
                UserName = user,
                Password = password
            };
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return null;

            var response = await _httpClient.PostAsJsonAsync($"login", loginModel);

            if ((int)response.StatusCode == 200)
            {
                BaseResponse<TokenModel> baseResponse = await response.Content.ReadFromJsonAsync<BaseResponse<TokenModel>>();
                if (baseResponse.StatusCode == Enum.StatusCode.OK)
                {
                    UserBaseTokenModel model = new()
                    {
                        DateAdd = baseResponse.Data.DateAdd,
                        Token = baseResponse.Data.Token,
                        DateEnd = baseResponse.Data.DateAdd.AddDays(30),
                        UserID = baseResponse.Data.Users
                    };

                    //Загрузить из базы данные по пользователю и сохранить их в локальной базе.
                   // await _blackListService.DropUserBaseTokenModelAsync();
                    await _blackListService.SaveUserBaseTokenModelAsync(model);
                    return  model.Token;
                }
            }
            return null;
        }

        public async Task<string> GetNewToken()
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return string.Empty;

            var result = await _blackListService.GetUserNameAsync();

            ResetPasswordTokenModel tokenModel = new()
            {
                UserName = result.UserName
            };

            var response = await _httpClient.PostAsJsonAsync($"reset-password-token", tokenModel);
            if ((int)response.StatusCode == 200)
            {
                BaseResponse<string> baseResponse = await response.Content.ReadFromJsonAsync<BaseResponse<string>>();
                if (baseResponse.StatusCode == Enum.StatusCode.OK)
                {
                    UserBaseTokenModel userBase = new()
                    {
                        Token = baseResponse.Data,
                        DateAdd = DateTime.Now,
                        DateEnd = DateTime.Now.AddDays(30)
                    };
                    await _blackListService.SaveUserBaseTokenModelAsync(userBase);
                    return "Ok";
                }
            }
            return string.Empty;
        }

        public async Task<string> GetRegisterNewUserAsync(RegisterModel register)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return string.Empty;

            var response = await _httpClient.PostAsJsonAsync($"registeruser", register);
            if ((int)response.StatusCode == 200)
            {
                BaseResponse<string> baseResponse = await response.Content.ReadFromJsonAsync<BaseResponse<string>>();
                if (baseResponse.StatusCode == Enum.StatusCode.OK)
                {
                    return await Task.Run(() => baseResponse.Data);
                }
            }
            return null;
        }
    }
}
