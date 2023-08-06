using EL.MAUI.BlackList.Views;

namespace EL.MAUI.BlackList;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(SerchDriversPage), typeof(SerchDriversPage));
    }
}
