using EL.MAUI.BlackList.Services;
using EL.MAUI.BlackList.Views;

namespace EL.MAUI.BlackList;

public partial class App : Application
{
    public App()
	{
		InitializeComponent();
        MainPage = new PinPage();
	}
}
