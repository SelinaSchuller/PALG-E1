using AloneInSpace.Interfaces;
using AloneInSpace.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace AloneInSpace
{
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            //Place here needed services:
            builder.Services.AddScoped<INavigateToPage, NavigateToPage>();
            builder.Services.AddScoped<IDatabaseProvider, DatabaseProvider>();

#if WINDOWS
			builder.ConfigureLifecycleEvents(events =>
			{
				events.AddWindows(wndLifeCycleBuilder =>
				{
					wndLifeCycleBuilder.OnWindowCreated(window =>
					{
						IntPtr hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
						Microsoft.UI.WindowId myWndId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
						var _appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(myWndId);
						_appWindow.SetPresenter(Microsoft.UI.Windowing.AppWindowPresenterKind.FullScreen);

					});
				});
			});
#endif

			return builder.Build();
        }
    }
}
