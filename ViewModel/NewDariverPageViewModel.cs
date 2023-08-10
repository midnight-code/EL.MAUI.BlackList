using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EL.MAUI.BlackList.Models;
using EL.MAUI.BlackList.Services;
using EL.MAUI.BlackList.Views;

namespace EL.MAUI.BlackList.ViewModel
{
    [QueryProperty(nameof(driverid), nameof(driverid))]
    internal partial class NewDariverPageViewModel : ObservableObject
    {
        private readonly DriverApiServices _driverApiServices;
        public NewDariverPageViewModel()
        {
            _driverApiServices = new DriverApiServices();
        }

        [ObservableProperty]
        private Drivers driver;

        [ObservableProperty]
        private FeedBacks feedBack1;

        public int driverid
        {
            set => GetDriverByID(value);
        }

        [RelayCommand]
        private async Task Back()
        {
            await Shell.Current.Navigation.PopToRootAsync();
        }

        [RelayCommand]
        private async Task AddFeedbackDriver()
        {
            
            FeedBacks feedBacks = new()
            {
                DriversId = Driver.Id,
                TaxiPoolsId = Driver.TaxiPoolsId,
                AddDate= DateTime.Now,
                CityId = 1,
                UserGuid = new Guid().ToString()
            };
            var feedbackDetailsView = new AddFeedBackPageViewModel { FeedBack = feedBacks };
            var feedBackPage = new AddFeedBackPage();
            feedBackPage.BindingContext = feedbackDetailsView;
            await Shell.Current.Navigation.PushModalAsync(feedBackPage);
        }

        public async void GetDriverByID(int id)
        {
            if (id > 0)
            {
                var drivers = await _driverApiServices.GetDriverDetails(id);
                if (drivers is not null && drivers.StatusCode == Enum.StatusCode.OK)
                {
                    Driver = drivers.Data;
                }
            }
        }
    }
}
