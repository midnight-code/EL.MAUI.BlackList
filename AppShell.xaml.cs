using EL.MAUI.BlackList.Views;

namespace EL.MAUI.BlackList;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(SerchDriversPage), typeof(SerchDriversPage));
		Routing.RegisterRoute(nameof(NewDriverPage), typeof(NewDriverPage));
		Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
		Routing.RegisterRoute(nameof(FoundDriverPage), typeof(FoundDriverPage));
        Routing.RegisterRoute(nameof(AddDriverPage), typeof(AddDriverPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(PinPage), typeof(PinPage));
    }

}
