using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EL.MAUI.BlackList.Models;
using EL.MAUI.BlackList.Services;
using EL.MAUI.BlackList.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.MAUI.BlackList.ViewModel
{
    internal partial class SerchDriverViewModel : ObservableObject
    {

        [ObservableProperty]
        private SerchDriver driversColl = new();

        [ObservableProperty]
        private string firstname;

        [ObservableProperty]
        private string lastname;
        [ObservableProperty]
        private string secondname;


        [RelayCommand]
        private async Task GetDriverByNameAsync()
        {
            string driver = $"{Firstname},{Lastname},{Secondname}";
            await Shell.Current.GoToAsync($"{nameof(FoundDriverPage)}?{nameof(FoundDriverPageViewModel.serchDriver)}={driver}");
        }
    }
}
