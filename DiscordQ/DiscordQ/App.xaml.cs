using DiscordQ.Services;
using Xamarin.Forms;

namespace DiscordQ
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<IUserService, UserService>();
            MainPage = new ProfilePage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}