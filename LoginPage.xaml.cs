using EL.MAUI.BlackList.ViewModel;

namespace EL.MAUI.BlackList;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginPageViewModel();
	}
}