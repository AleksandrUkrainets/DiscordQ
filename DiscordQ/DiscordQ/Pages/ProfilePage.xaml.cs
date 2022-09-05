using DiscordQ.PageModels;
using Xamarin.Forms;

namespace DiscordQ
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = new ProfilePageModel();
        }
    }
}