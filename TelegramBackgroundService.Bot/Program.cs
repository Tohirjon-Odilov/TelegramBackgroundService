using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Polling;
using TelegramBackgroundService.Bot.Persistence;
using TelegramBackgroundService.Bot.Service;
using TelegramBackgroundService.Bot.Service.Handler;
using TelegramBackgroundService.Bot.Service.MyBackgroundService;
using TelegramBackgroundService.Bot.Service.UserServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//BackgroundService
builder.Services.AddHostedService<MyBackgroundService>();
builder.Services.AddHostedService<TwoSecondSendMessage>();
builder.Services.AddHostedService<SendAllUsers>();

//Singleton
builder.Services.AddSingleton<IUpdateHandler, BotUpdateHandler>();

builder.Services.AddSingleton(p =>
    new TelegramBotClient("6756315206:AAHBksgO4m46pU0gxH43A35lqyRu6diBhdY"));

// Service
builder.Services.AddScoped<IUserService, UserService>();

//Backend
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql("Host=localhost;Port=5432;Database=BotDb;User Id=postgres;Password=coder;");
});

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
