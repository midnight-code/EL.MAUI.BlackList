using CommunityToolkit.Mvvm.ComponentModel;
using EL.MAUI.BlackList.Models;
using EL.MAUI.BlackList.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.MAUI.BlackList.ViewModel
{
    [QueryProperty(nameof(serchDriver), nameof(serchDriver))]
    internal partial class FoundDriverPageViewModel : ObservableObject
    {
        private readonly DriverApiServices _driverApiServices;
        public FoundDriverPageViewModel()
        {
            _driverApiServices = new DriverApiServices();
        }

        [ObservableProperty]
        private ObservableCollection<Drivers> driversColl = new();

        public string serchDriver
        {
            set => GetDriverByName(value);
        }

        private async void GetDriverByName(string serchDriver)
        {
            DriversColl = new();

            var result = await _driverApiServices.GetBaseResponse(serchDriver.Split(',')[0], serchDriver.Split(',')[1], serchDriver.Split(',')[2]);
            if (result == null)
            {
                DriversColl.Add(new Drivers()
                {
                    FirstName = "вернуло null"
                });
            }
            else
            {
                foreach (Drivers drv in result.Data)
                {
                    DriversColl.Add(drv);
                }
            }
        }
    }
}
