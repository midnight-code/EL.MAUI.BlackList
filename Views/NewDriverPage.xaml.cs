using EL.MAUI.BlackList.Models;
using EL.MAUI.BlackList.ViewModel;

namespace EL.MAUI.BlackList.Views;

public partial class NewDriverPage : ContentPage
{
	public NewDriverPage()
	{
		InitializeComponent();
		BindingContext = new NewDariverPageViewModel();
	}
    public void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var feedBacks = (FeedBacks)e.Item;
        var feedBackDetailsPageViewModel = new FeedBackDetailsViewModel { Feedback = feedBacks };
        var driverDetailsPage = new FeedBackDetailsModalPage();
        driverDetailsPage.BindingContext = feedBackDetailsPageViewModel;

        Navigation.PushAsync(driverDetailsPage);
    }
 }