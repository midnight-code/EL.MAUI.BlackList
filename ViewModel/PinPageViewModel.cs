using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EL.MAUI.BlackList.Interfaces;
using EL.MAUI.BlackList.Models;
using EL.MAUI.BlackList.Services;
using EL.MAUI.BlackList.Views;
using EL.MAUI.BlackList.Views.Modals;

namespace EL.MAUI.BlackList.ViewModel
{
    partial class PinPageViewModel : ObservableObject
    {
        private readonly DTBlackListService _blackListService;
        private readonly LoginApiService _loginApiService;
        private readonly IPopupService _popupService;
        private string PinCode;
        private int i = 0;
        public PinPageViewModel()
        {
            _blackListService = new DTBlackListService();
            _loginApiService = new LoginApiService();
            _popupService = new PopupService();
            TokenLogin();
        }

        [ObservableProperty]
        public bool isVisibleRepite;
        
        [ObservableProperty]
        public bool isVisibleNewPinCode;

        [ObservableProperty]
        public string pincodeText;

        [ObservableProperty]
        public string pincodeTextRepite;

        [RelayCommand]
        private async Task addPinCode(object sender)
        {
            ++i;
            PinCode += sender;
            PincodeText += "*";

            if (i == 4)
            {
                int pin = await _blackListService.GetPinCodeUserBaseAsync();
                if (pin != 0)
                {
                    if (pin == Convert.ToInt32(PinCode))
                    {
                        Application.Current.MainPage = new AppShell();
                        await Shell.Current.Navigation.PushAsync(new HomePage());
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Ошибка", "Не верный пин код", "OK");
                        i = 0;
                        PincodeText = string.Empty;
                        PinCode = string.Empty;
                    }
                }
                else
                {
                    IsVisibleRepite = true;
                    PincodeTextRepite = PinCode;
                    PincodeText = string.Empty;
                    PinCode = string.Empty;
                    IsVisibleRepite = false;
                    IsVisibleNewPinCode = true;
                    i= 0;
                }
            }
        }

        [RelayCommand]
        private async Task addPinCodeRepite(object sender)
        {
            ++i;
            PincodeText += "*";
            PinCode += sender;
            if (i == 4)
            {
                var e = Convert.ToInt32(PinCode);
                var r = Convert.ToInt32(PincodeTextRepite);
                if (Convert.ToInt32(PinCode) == Convert.ToInt32(PincodeTextRepite)) 
                {
                    var result = await _blackListService.GetUserBaseAsync();
                    if(result is not null)
                    {
                        result.PinCode = Convert.ToInt32(PinCode);
                        await _blackListService.SaveUserBaseAsync(result);
                    }
                    else
                    {
                        UserBase userBase = new() { PinCode = Convert.ToInt32(PinCode) };
                        await _blackListService.SaveUserBaseAsync(userBase);
                    }
                    Application.Current.MainPage = new AppShell();
                    await Shell.Current.Navigation.PushAsync(new HomePage());
                }
            }
        }
        private async void TokenLogin()
        {
            var result = await _blackListService.GetUserBaseTokenModelAsync();
            if (result == null)
            {
                var loginPageViewModel = new LoginPageViewModel();
                var loginPage = new LoginPage();
                loginPage.BindingContext = loginPageViewModel;
                Application.Current.MainPage = new LoginPage();
                await Shell.Current.Navigation.PushAsync(new LoginPage());
            }
            else
            {
                if (result.DateEnd <= DateTime.Now)
                {
                    await _loginApiService.GetNewToken();
                }
                IsVisibleRepite = true;
                IsVisibleNewPinCode = false;
            }
        }
    }
}
