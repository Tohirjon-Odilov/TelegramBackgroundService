
using Telegram.Bot.Polling;
using Telegram.Bot;

namespace TelegramBackgroundService.Bot.Service
{
    public class TwoSecondSendMessage : BackgroundService
    {
        private readonly TelegramBotClient client;
        private readonly IUpdateHandler updateHandler;

        public TwoSecondSendMessage(TelegramBotClient client, IUpdateHandler updateHandler)
        {
            this.client = client;
            this.updateHandler = updateHandler;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await client.SendTextMessageAsync(
                    chatId: 1633746526,
                    text: "Salomlar",
                    cancellationToken: stoppingToken
                );

                await Task.Delay(1000);
            }
        }
    }
}
