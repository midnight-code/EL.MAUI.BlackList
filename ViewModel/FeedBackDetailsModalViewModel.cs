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
    [QueryProperty(nameof(feedbackid), nameof(feedbackid))]
    public partial class FeedBackDetailsModalViewModel : ObservableObject
    {
        public int feedbackid {
            set
            {
                GetFeedBak(value);
            }
        }
        [ObservableProperty]
        private FeedBacks feedback;
        private void GetFeedBak(int id)
        {
            using(var httpClient=new HttpClient())
            {
                var result = httpClient.GetFromJsonAsync<FeedBacks>("");
            }
        }
    }
}
