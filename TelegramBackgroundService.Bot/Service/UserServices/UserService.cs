using Microsoft.EntityFrameworkCore;
using TelegramBackgroundService.Bot.Models;
using TelegramBackgroundService.Bot.Persistence;

namespace TelegramBackgroundService.Bot.Service.UserServices
{
    public class UserService : IUserService
    {
        private readonly AppDbContext appDbContext;

        public UserService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task Add(UserModel user)
        {
            var test = await appDbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            if(test != null)
            {
                return;
            }
            await appDbContext.Users.AddAsync(user);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await appDbContext.Users.ToListAsync();
        }
    }
}
