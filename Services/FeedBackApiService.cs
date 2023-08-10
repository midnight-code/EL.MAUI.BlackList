using EL.MAUI.BlackList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EL.MAUI.BlackList.Services
{
    internal class FeedBackApiService
    {
        private readonly HttpClient _httpClient;
        public FeedBackApiService()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://czz.itiss.ru/")
            }; 
        }
        //public async Task<BaseResponse<IEnumerable<FeedBacks>>> GetBaseResponse()
        //{
        //    if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        //        return null;
        //    return await _httpClient.GetFromJsonAsync<BaseResponse<IEnumerable<FeedBacks>>>($"GetSerch/{firstname}?lastName={lastname}&secondName={secondname}");
        //}

        //public async Task<BaseResponse<Drivers>> GetDriverDetails(int idDriver)
        //{
        //    if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        //        return null;
        //    var result = await _httpClient.GetFromJsonAsync<BaseResponse<Drivers>>($"driverByID/{idDriver}");
        //    return await _httpClient.GetFromJsonAsync<BaseResponse<Drivers>>($"driverByID/{idDriver}");

        //}

        public async Task<int> AddNewFeedBackAsync(FeedBacks feedBacks)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return 0;

            var result = await _httpClient.PostAsJsonAsync($"savefeedbacks/{feedBacks}", feedBacks);
            BaseResponse<int> id = await result.Content.ReadFromJsonAsync<BaseResponse<int>>();
            return id.Data;
        }
    }
}
