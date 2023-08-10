using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EL.MAUI.BlackList.Models;
using EL.MAUI.BlackList.Services;
using EL.MAUI.BlackList.Views;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.MAUI.BlackList.ViewModel
{
    internal partial class HomePageViewModel : ObservableObject
    {
     
        [RelayCommand]
        private async Task SerchDriver()
        {
            await Shell.Current.Navigation.PushAsync(new SerchDriversPage());
        }

        [RelayCommand]
        private async Task AddNewDriver()
        {
            await Shell.Current.Navigation.PushAsync(new AddDriverPage());
        }

        [RelayCommand]
        private async Task AddFeedbackDriver()
        {
            await Shell.Current.Navigation.PushAsync(new AddFeedBackPage());
        }
    }
}
