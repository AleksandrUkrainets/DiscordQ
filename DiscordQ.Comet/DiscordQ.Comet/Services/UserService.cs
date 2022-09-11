namespace DiscordQ.Comet
{
    public class UserService : IUserService
    {
        private User _user = new User() { FirstName = "James", LastName = "Clancey", NickName = "CometsCreater" };

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