using CommunityToolkit.Maui;
using EL.MAUI.BlackList.Interfaces;
using EL.MAUI.BlackList.Services;
using Microsoft.Extensions.Logging;

namespace EL.MAUI.BlackList;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("ArtPostTYGRA.ttf", "ArtPost");
                fonts.AddFont("BLAGO.ttf", "BLAGO");
                fonts.AddFont("BloodLust.ttf", "BloodLust");
                fonts.AddFont("Lobster-Regular.ttf", "Lobster-Regular");
                fonts.AddFont("MagicSchoolTwo-4n5D.ttf", "MagicSchool");
            });
        builder.Services.AddSingleton<DTBlackListService>()
			.AddTransient<IPopupService, PopupService>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
