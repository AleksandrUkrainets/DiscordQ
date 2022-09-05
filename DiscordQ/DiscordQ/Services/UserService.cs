using DiscordQ.Models;

namespace DiscordQ.Services
{
    public class UserService : IUserService
    {
        private User _user = new User() { FirstName = "User FirstName", LastName = "User LastName", NickName = "User NickName" };

        public User GetUser()
        {
            return _user;
        }

        public bool SaveUser(User user)
        {
            if (user == null)
                return false;

            _user = user;
            return true;
        }
    }
}