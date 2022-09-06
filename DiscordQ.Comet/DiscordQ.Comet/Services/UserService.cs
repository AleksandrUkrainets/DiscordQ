namespace DiscordQ.Comet
{
    public class UserService : IUserService
    {
        private User _user = new User() { FirstName = "UserProfile FirstName", LastName = "UserProfile LastName", NickName = "UserProfile NickName" };

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