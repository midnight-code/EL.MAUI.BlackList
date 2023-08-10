using EL.MAUI.BlackList.Models;
using System.Net.Http.Json;

namespace EL.MAUI.BlackList.Services
{
    internal class DriverApiServices
    {
        private readonly HttpClient _httpClient;
        public DriverApiServices()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://czz.itiss.ru/")
            };
        }

        public async Task<BaseResponse<IEnumerable<Drivers>>> GetBaseResponse(string firstname, string lastname, string secondname)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return null;
            return await _httpClient.GetFromJsonAsync<BaseResponse<IEnumerable<Drivers>>>($"GetSerch/{firstname}?lastName={lastname}&secondName={secondname}");
        }

        public async Task<BaseResponse<Drivers>> GetDriverDetails(int idDriver)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return null;
            var result = await _httpClient.GetFromJsonAsync<BaseResponse<Drivers>>($"driverByID/{idDriver}");
            return await _httpClient.GetFromJsonAsync<BaseResponse<Drivers>>($"driverByID/{idDriver}");

        }

        public async Task<int> AddNewDriverAsync(Drivers drivers)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return 0;

            var result = await _httpClient.PostAsJsonAsync($"savedriver/{drivers}", drivers);
            BaseResponse<int> id = await result.Content.ReadFromJsonAsync<BaseResponse<int>>();
            return id.Data;
        }
    }
}
