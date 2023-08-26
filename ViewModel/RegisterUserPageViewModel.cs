using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EL.MAUI.BlackList.Models;
using EL.MAUI.BlackList.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EL.MAUI.BlackList.Views.Modals;
using EL.MAUI.BlackList.Interfaces;
using EL.MAUI.BlackList.Views;

namespace EL.MAUI.BlackList.ViewModel
{
    partial class RegisterUserPageViewModel : ObservableObject
    {
        private readonly Regex _regexPassword = RegexPassword();
        private readonly Regex _regexEmail = regexMail();
        private readonly LoginApiService _loginApiService;
        private readonly IPopupService _popupService;
        public RegisterUserPageViewModel()
        {
            _loginApiService = new LoginApiService();
            _popupService = new PopupService();
        }

        [ObservableProperty]
        private string loginname;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string confirmPassword;

        [ObservableProperty]
        public string phoneNumber;

        //[ObservableProperty]
        //public string email;

        [ObservableProperty]
        public bool checkPhone;

        [RelayCommand]
        private async Task RegisterUser()
        {
            if (Loginname == null || Password == null)
            {
                _popupService.ShowPopup(new ResponsePopup("null"));
            }
            else
            {
                if (Password == ConfirmPassword)
                {
                    var r = _regexEmail.IsMatch(Loginname);
                    var e = _regexPassword.IsMatch(Password);
                    if (_regexEmail.IsMatch(Loginname) && _regexPassword.IsMatch(Password))
                    {
                        RegisterModel registerModel = new()
                        {
                            UserName = Loginname,
                            Password = Password,
                            Email = Loginname
                        };
                        var response = await _loginApiService.GetRegisterNewUserAsync(registerModel);
                        await Shell.Current.Navigation.PushAsync(new HomePage());
                    }
                    _popupService.ShowPopup(new ResponsePopup("regex"));
                }
                else
                    _popupService.ShowPopup(new ResponsePopup("confirm"));
            }
        }

        [GeneratedRegex("^\\S+@\\S+\\.\\S+$")]
        private static partial Regex regexMail();
        [GeneratedRegex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,}$")]
        private static partial Regex RegexPassword();
    }
}
