using TelegramBackgroundService.Bot.Models;

namespace TelegramBackgroundService.Bot.Service.UserServices
{
    public interface IUserService
    {
        public Task Add(UserModel user);
        public Task<List<UserModel>> GetAllUsers();
    }
}
