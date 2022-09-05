using DiscordQ.Models;

namespace DiscordQ.Services
{
    public interface IUserService
    {
        User GetUser();

        bool SaveUser(User user);
    }
}