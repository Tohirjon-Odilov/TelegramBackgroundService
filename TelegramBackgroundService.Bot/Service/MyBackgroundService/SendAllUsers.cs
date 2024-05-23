using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using TelegramBackgroundService.Bot.Models;
using TelegramBackgroundService.Bot.Service.UserServices;

namespace TelegramBackgroundService.Bot.Service.MyBackgroundService
{
    public class SendAllUsers : BackgroundService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly TelegramBotClient client;

        public SendAllUsers(IServiceScopeFactory serviceScopeFactory, TelegramBotClient telegramBotClient)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.client = telegramBotClient;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    var userRepository = scope.ServiceProvider.GetRequiredService<IUserService>();

                    var users = await userRepository.GetAllUsers();

                    foreach (var user in users)
                    {
                        await SendNotification(user, stoppingToken);
                    }
                }

                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
            }
        }

        private async Task SendNotification(UserModel user, CancellationToken token)
        {
            try
            {
                await client.SendTextMessageAsync(
                    chatId: user.Id,
                    text: "Qales!?",
                    cancellationToken: token);
            } catch 
            {
                Console.WriteLine("Someone block the bot!");
            }
        }
    }
}
