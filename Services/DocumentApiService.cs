using EL.MAUI.BlackList.Helpers;
using EL.MAUI.BlackList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EL.MAUI.BlackList.Services
{
    internal class DocumentApiService
    {
        private readonly HttpClient _httpClient;
        public DocumentApiService()
        {
            _httpClient = new HttpClient 
            {
                BaseAddress = new Uri(UriHelp.UriString)
            };
        }

        public async Task<int> AddNewDocumentAsync(FileResult fileResult, int driverid, string imgtype)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return 0;
            using (var multipartFormContent = new MultipartFormDataContent())
            {
                var fileStreamContent = new StreamContent(File.OpenRead(fileResult.FullPath));
                fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue(fileResult.ContentType);

                multipartFormContent.Add(fileStreamContent, name: "file", fileName: fileResult.FileName);
                var result = await _httpClient.PostAsync($"Document/UploadeDocument/{driverid}/{imgtype}", multipartFormContent);
                BaseResponse<int> id = await result.Content.ReadFromJsonAsync<BaseResponse<int>>();
                return id.Data;
            }
        }
    }
}
