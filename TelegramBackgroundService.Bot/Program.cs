using Telegram.Bot;
using Telegram.Bot.Polling;
using TelegramBackgroundService.Bot.Service;
using TelegramBackgroundService.Bot.Service.Handler;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<MyBackgroundService>();
builder.Services.AddHostedService<TwoSecondSendMessage>();
builder.Services.AddSingleton<IUpdateHandler, BotUpdateHandler>();

builder.Services.AddSingleton(
    new TelegramBotClient("6756315206:AAHBksgO4m46pU0gxH43A35lqyRu6diBhdY"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
