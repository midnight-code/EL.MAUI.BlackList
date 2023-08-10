using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EL.MAUI.BlackList.Models;
using EL.MAUI.BlackList.Services;

namespace EL.MAUI.BlackList.ViewModel
{
    internal partial class AddFeedBackPageViewModel : ObservableObject
    {
        private readonly FeedBackApiService _feedBackService;
        public AddFeedBackPageViewModel()
        {
            _feedBackService = new FeedBackApiService();
        }

        [ObservableProperty]
        FeedBacks feedBack;// = new();

        [ObservableProperty]
        private int driversID;

        [RelayCommand]
        private async Task AddFeedBack()
        {
            //FeedBack.AddDate = FeedBack.AddDate;
            if (!string.IsNullOrEmpty(FeedBack.Subjest))
            {
                var result = _feedBackService.AddNewFeedBackAsync(FeedBack);
            }
            await Shell.Current.Navigation.PopModalAsync();
        }
        [RelayCommand]
        private async Task Back()
        {
            await Shell.Current.Navigation.PopModalAsync();
        }
    }
}
