using EL.MAUI.BlackList.Models;
using EL.MAUI.BlackList.ViewModel;

namespace EL.MAUI.BlackList.Views;

public partial class SerchDriversPage : ContentPage
{
	public SerchDriversPage()
	{
		InitializeComponent();
        BindingContext = new SerchDriverViewModel();
	}

}