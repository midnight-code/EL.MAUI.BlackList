using CommunityToolkit.Maui.Views;
using EL.MAUI.BlackList.ViewModel;

namespace EL.MAUI.BlackList.Views;

public partial class RegisterUserPage : ContentPage
{
	public RegisterUserPage()
	{
		InitializeComponent();
		BindingContext = new RegisterUserPageViewModel();
	}
}