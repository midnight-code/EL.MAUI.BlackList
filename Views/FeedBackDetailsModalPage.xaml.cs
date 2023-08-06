using EL.MAUI.BlackList.ViewModel;

namespace EL.MAUI.BlackList.Views;

public partial class FeedBackDetailsModalPage : ContentPage
{
	public FeedBackDetailsModalPage()
	{
		InitializeComponent();
        BindingContext = new FeedBackDetailsViewModel();
	}
}