using EL.MAUI.BlackList.ViewModel;
using CommunityToolkit.Maui.Views;

namespace EL.MAUI.BlackList.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginPageViewModel();
	}
}