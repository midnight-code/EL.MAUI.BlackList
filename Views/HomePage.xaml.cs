
using EL.MAUI.BlackList.Models;
using EL.MAUI.BlackList.ViewModel;

namespace EL.MAUI.BlackList.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		BindingContext = new HomePageViewModel();
	}
    //public async void button_Serch(object sender, EventArgs e)
    //{
    //    HomePageViewModel homePageViewModel = new HomePageViewModel();
    //    var result = homePageViewModel.DriversColl;
    //    var serchDriverPageViewModel = new SerchDriverViewModel { serchDriver = result };
    //    var serchDriverPage = new SerchDriversPage();
    //    serchDriverPage.BindingContext = serchDriverPageViewModel;

    //    await Navigation.PushAsync(serchDriverPage);
    //}
}