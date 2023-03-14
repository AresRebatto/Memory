using CommunityToolkit.Maui;

namespace Memory;

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
                fonts.AddFont("Comfortaa-Bold.ttf", "ComfortaaBold");
                fonts.AddFont("Lexend-Bold.ttf", "LexendBold");
            });
		//ciao ares
		return builder.Build();
	}
}
