using Microsoft.Maui.Controls;

namespace DiscordQ.Comet.Pages
{
    public class UserProfile : BindingObject
    {
        private IUserService _userService { get => DependencyService.Get<IUserService>(); }

        public string NickName { get => GetProperty<string>(); set => SetProperty(value); }
        public string FirstName { get => GetProperty<string>(); set => SetProperty(value); }
        public string LastName { get => GetProperty<string>(); set => SetProperty(value); }

        public UserProfile()
        {
            User user = GetCurrentUser();
            NickName = user.NickName;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }

        public User GetCurrentUser()
        {
            return _userService.GetUser();
        }

        public bool SaveCurrentUser()
        {
            return _userService.SaveUser(new User()
            {
                NickName = NickName,
                FirstName = FirstName,
                LastName = LastName
            });
        }
    }
}