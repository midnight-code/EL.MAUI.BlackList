using EL.MAUI.BlackList.ViewModel;

namespace EL.MAUI.BlackList.Views;

public partial class AddFeedBackPage : ContentPage
{
	public AddFeedBackPage()
	{
		InitializeComponent();
		BindingContext = new AddFeedBackPageViewModel();
	}
}