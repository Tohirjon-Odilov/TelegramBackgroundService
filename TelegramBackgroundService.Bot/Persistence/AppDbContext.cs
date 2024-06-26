﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TelegramBackgroundService.Bot.Models;

namespace TelegramBackgroundService.Bot.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<UserModel> Users { get; set; }
    }
}
