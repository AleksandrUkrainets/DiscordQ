using DiscordQ.Models;
using DiscordQ.Services;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace DiscordQ.PageModels
{
    public class ProfilePageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IUserService _userService => DependencyService.Get<IUserService>();

        public ProfilePageModel()
        {
            User = _userService.GetUser();
            SaveUserCommand = new Command(SaveUser);
        }

        private User _user;

        public User User
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged(nameof(User));
                }
            }
        }

        public ICommand SaveUserCommand { get; }

        private void SaveUser()
        {
            var result = _userService.SaveUser(new User()
            {
                NickName = User.NickName,
                FirstName = User.FirstName,
                LastName = User.LastName,
            });

            if (!result)
            {
                throw new Exception("Error");
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}