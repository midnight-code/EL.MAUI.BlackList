using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EL.MAUI.BlackList.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.MAUI.BlackList.ViewModel
{
    internal partial class PersonalAreaViewModel : ObservableObject
    {
        [RelayCommand]
        private async Task PersonalAreaServices()
        {
            await Shell.Current.Navigation.PushAsync(new PersonalAreaServices());
        }

        [RelayCommand]
        private async Task Services()
        {
            await Shell.Current.Navigation.PushAsync(new ServicesPage());
        }

        [RelayCommand]
        private async Task FinanceServices()
        {
            await Shell.Current.Navigation.PushAsync(new FinanceServicesPage());
        }
    }
}
