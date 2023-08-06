using EL.MAUI.BlackList.ViewModel;

namespace EL.MAUI.BlackList.Views;

public partial class AddDriverPage : ContentPage
{
	public AddDriverPage()
	{
		InitializeComponent();
		BindingContext = new AddDriverPageViewModel();
	}
}