using Microsoft.Maui.Controls;
using static Android.Provider.ContactsContract.CommonDataKinds;
using Button = Comet.Button;
using View = Comet.View;

namespace DiscordQ.Comet
{
    public class MainPage : View
    {
        public class UserProfile : BindingObject
        {
            public string NickName { get => GetProperty<string>(); set => SetProperty(value); }
            public string FirstName { get => GetProperty<string>(); set => SetProperty(value); }
            public string LastName { get => GetProperty<string>(); set => SetProperty(value); }
            public IUserService UserService { get => DependencyService.Get<IUserService>(); } 

            public UserProfile()
            {
                var user = UserService.GetUser();
                NickName = user.NickName;
                FirstName = user.FirstName;
                LastName = user.LastName;
            }
        }

        [State]
        private readonly UserProfile user = new();

        [Body]
        private View body() => new VStack
        {
            new Text(() => $"NickName: {user.NickName}"),
            new TextField(user.NickName, "Enter a NickName"),
            new Text(() => $"FirstName: {user.FirstName}"),
            new TextField(user.FirstName, "Enter a FirstName"),
            new Text(() => $"LastName: {user.LastName}"),
            new TextField(user.LastName, "Enter a LastName"),
            new Button("Save user", () => user.UserService.SaveUser( new User()
            {
                NickName = user.NickName, 
                FirstName = user.FirstName, 
                LastName = user.LastName
            })),
        };
    }
}