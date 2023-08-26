using EL.MAUI.BlackList.ViewModel;

namespace EL.MAUI.BlackList;

public partial class PinPage : ContentPage
{
	public PinPage()
	{
		InitializeComponent();
		BindingContext = new PinPageViewModel();
	}
}