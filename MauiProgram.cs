using Microsoft.Extensions.Logging;

namespace EL.MAUI.BlackList;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
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

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
