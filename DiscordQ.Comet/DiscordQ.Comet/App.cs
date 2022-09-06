using Microsoft.Maui.Controls;
using Microsoft.Maui.Hosting;
using View = Comet.View;

namespace DiscordQ.Comet
{
    public class App : CometApp
    {
        [Body]
        private View view() => new MainPage();

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseCometApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            DependencyService.Register<IUserService, UserService>();
            //-:cnd
#if DEBUG
            builder.EnableHotReload();
#endif
            //+:cnd
            return builder.Build();
        }
    }
}