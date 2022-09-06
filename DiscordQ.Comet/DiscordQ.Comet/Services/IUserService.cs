namespace DiscordQ.Comet
{
    public interface IUserService
    {
        User GetUser();

        bool SaveUser(User user);
    }
}