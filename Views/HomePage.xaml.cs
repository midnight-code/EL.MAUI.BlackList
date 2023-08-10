using EL.MAUI.BlackList.ViewModel;

namespace EL.MAUI.BlackList.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
        InitializeComponent();
		BindingContext = new HomePageViewModel();
	}
}