using CommunityToolkit.Mvvm.ComponentModel;
using EL.MAUI.BlackList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EL.MAUI.BlackList.ViewModel
{
    internal partial class FeedBackDetailsViewModel : ObservableObject
    {
        public int feedBackId
        {
            set 
            {
                GetFeedBak(value);
            }
        }
        [ObservableProperty]
        private FeedBacks feedback;
        private void GetFeedBak(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.GetFromJsonAsync<FeedBacks>("");
            }
        }
    }
}
