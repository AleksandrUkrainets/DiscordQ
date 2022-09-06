using Foundation;
using Microsoft.Maui.Hosting;

namespace DiscordQ.Comet
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => App.CreateMauiApp();
    }
}