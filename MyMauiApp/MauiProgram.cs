using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;
using SvgML;

namespace MyMauiApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		
		// TODO: Add UseSvgML() extension method to MauiAppBuilder
		GC.KeepAlive(typeof(svg));
        GC.KeepAlive(typeof(defs));
        GC.KeepAlive(typeof(linearGradient));
        GC.KeepAlive(typeof(stop));
        GC.KeepAlive(typeof(rect));
        GC.KeepAlive(typeof(circle));

        
        
        GC.KeepAlive(typeof(Canvas));
		
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			// TODO:
			.UseSkiaSharp()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
