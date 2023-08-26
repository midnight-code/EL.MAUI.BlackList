using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Views;
using EL.MAUI.BlackList.Services;
using EL.MAUI.BlackList.Views;
using EL.MAUI.BlackList.Views.Modals;
using System.Text.RegularExpressions;
using EL.MAUI.BlackList.Interfaces;

namespace EL.MAUI.BlackList.ViewModel
{
    partial class LoginPageViewModel : ObservableObject
    {
        private readonly Regex _regex = new(@"^\\S+@\\S+\\.\\S+$");
        private readonly LoginApiService _loginApiService;
        private readonly IPopupService _popupService;

        public LoginPageViewModel()
        {
            _loginApiService = new LoginApiService();
            _popupService = new PopupService();
        }

        [ObservableProperty]
        string loginName;

        [ObservableProperty]
        string password;

        [RelayCommand]
        private async Task NewLogin()
        {
            var result = _regex.IsMatch(LoginName);
            if (!result)
            {
                if (!string.IsNullOrWhiteSpace(LoginName) && !string.IsNullOrWhiteSpace(Password))
                {
                    string userBase = await _loginApiService.GetUserBase(LoginName, Password);
                    if (!string.IsNullOrWhiteSpace(userBase))
                    {
                        await Shell.Current.Navigation.PushAsync(new PinPage());
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Error", "Error login on password", "OK");
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Error login on password is not null", "OK");
                }
            }
        }

        [RelayCommand]
        private async Task RegisterUser()
        {
            //_popupService.ShowPopup(new ResponsePopup());
            await Shell.Current.Navigation.PushAsync(new RegisterUserPage());
        }
    }
}
