using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EL.MAUI.BlackList.Models;
using EL.MAUI.BlackList.Services;
using EL.MAUI.BlackList.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.MAUI.BlackList.ViewModel
{
    [QueryProperty(nameof(iddriver), nameof(iddriver))]
    internal partial class DriverdDetailsPageViewModel : ObservableObject
    {
        private readonly DriverApiServices _driverApiServices;
        public DriverdDetailsPageViewModel()
        {
            _driverApiServices = new DriverApiServices();
        }

        public int iddriver
        {
            set => GetDriverDetails(value);
        }

        [ObservableProperty]
        private Drivers driver;
        private async void GetDriverDetails(int id)
        {
            var result = await _driverApiServices.GetDriverDetails(id);
            if (result.StatusCode == Enum.StatusCode.OK)
            {
                Driver = result.Data;
            }

        }
    }
}
