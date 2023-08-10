using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EL.MAUI.BlackList.Models;
using EL.MAUI.BlackList.Services;
using EL.MAUI.BlackList.Views;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.MAUI.BlackList.ViewModel;

internal partial class AddDriverPageViewModel : ObservableObject
{
    private readonly DriverApiServices _driverApiServices;
    private readonly DocumentApiService _documentApiService;
    public AddDriverPageViewModel()
    {
        _driverApiServices = new DriverApiServices();
        _documentApiService = new DocumentApiService();
    }
    #region Поля
    [ObservableProperty]
    private string firstname;

    [ObservableProperty]
    private string lastname;

    [ObservableProperty]
    private string secondname;

    [ObservableProperty]
    private bool addlist;

    [ObservableProperty]
    private DateTime daterogden;

    [ObservableProperty]
    private int avatarid;

    [ObservableProperty]
    private string inn;

    [ObservableProperty]
    private bool isTaskRunning = false;

    [ObservableProperty]
    private DateTime endDate = DateTime.Now.AddYears(-65);

    [ObservableProperty]
    private DateTime maxiDate = DateTime.Now.AddYears(-21);

    [ObservableProperty]
    private string imagName = "noavatar.png";

    [ObservableProperty]
    private string dl1 = "dl1.png";

    [ObservableProperty]
    private string dl2 = "dl2.png";

    private FileResult[] fileResults = new FileResult[3];

    #endregion

    #region Действия
    [RelayCommand]
    private async Task AddNewDriver()
    {
        IsTaskRunning = true;

        if(fileResults[0]==null)
        {

        }

        Drivers driver = new Drivers()
        {
            FirstName = Firstname,
            LastName = Lastname,
            SecondName = Secondname,
            AddList = Addlist,
            Inn = "01010101010101",
            AvatarId = (fileResults[0] != null) ? await _documentApiService.AddNewDocumentAsync(fileResults[0], 0, "avatar") : 1,
            DateRogden = Daterogden,
            PasportId = 1,
            TaxiPoolsId = 1
        };
        var result = await _driverApiServices.AddNewDriverAsync(driver);

        foreach(FileResult fileResult in fileResults)
        {
            if(fileResult != null)
            {
                await _documentApiService.AddNewDocumentAsync(fileResult, result, "licenz");
            }
        }


        IsTaskRunning = false;
        await Shell.Current.GoToAsync($"{nameof(NewDriverPage)}?{nameof(NewDariverPageViewModel.driverid)}={result}");
    }

    [RelayCommand]
    private async Task AddAvatar()
    {
        fileResults[0] = await MediaPicker.Default.CapturePhotoAsync();
        if (fileResults[0] != null)
        {
            ImagName = fileResults[0].FullPath;
        }
    }

    [RelayCommand]
    private async Task AddDriverLicenc1()
    {
        fileResults[1] = await MediaPicker.Default.CapturePhotoAsync();
        if (fileResults[1] != null) {
            Dl1 = fileResults[1].FullPath;
        }
    }

    [RelayCommand]
    private async Task AddDriverLicenc2()
    {
        fileResults[2] = await MediaPicker.Default.CapturePhotoAsync();
        if (fileResults[2] != null)
        {
            Dl2 = fileResults[2].FullPath;
        }
    }
    #endregion

    #region
    private void AddNewImages(FileResult result)
    {
        if(result is not null)
        {

        }
    }
    #endregion
}