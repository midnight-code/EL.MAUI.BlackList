using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.MAUI.BlackList.ViewModel
{
    partial class PersonalPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string firstname;

        [ObservableProperty]
        private string lastname;

        [ObservableProperty]
        private string secondname;

        [ObservableProperty]
        private string nameTaxiPool;

        [ObservableProperty]
        public DateTime dateRogden;

        [ObservableProperty]
        public string region;

        [ObservableProperty]
        public string sityName;

        [ObservableProperty]
        public string phoneNumber;

        [ObservableProperty]
        public string publicPhoneNumber;

        [ObservableProperty]
        public bool checkPhone;

        [RelayCommand]
        private async Task UpdatePersonalUser()
        {

        }

    }
}