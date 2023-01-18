using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameDataApp.Models;
using GameDataApp.Configuration;

namespace GameDataApp.Data
{
    public class GameDataAppContext : DbContext
    {
        public GameDataAppContext (DbContextOptions<GameDataAppContext> options)
            : base(options)
        {
        }

        public DbSet<GameDataApp.Models.Player> Player { get; set; } = default!;

        public DbSet<GameDataApp.Models.Inventory> Inventory { get; set; } = default!;

        public DbSet<GameDataApp.Models.Quest> Quest { get; set; } = default!;

        public DbSet<GameDataApp.Models.Item> Item { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryConfiguration());
            modelBuilder.ApplyConfiguration(new QuestConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
        }
    }
}
