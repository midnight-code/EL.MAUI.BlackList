using EL.MAUI.BlackList.Models;
using EL.MAUI.BlackList.ViewModel;

namespace EL.MAUI.BlackList.Views;

public partial class FoundDriverPage : ContentPage
{
	public FoundDriverPage()
	{
		InitializeComponent();
		BindingContext = new FoundDriverPageViewModel();
	}
    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var driver = (Drivers)e.Item;
        var driverDetailsView = new DriverdDetailsPageViewModel { iddriver = driver.Id };
        var driverPage = new DriverDetailsPage();
        driverPage.BindingContext = driverDetailsView;
        await Navigation.PushAsync(driverPage);
    }
}