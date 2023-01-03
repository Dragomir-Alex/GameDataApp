using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameDataApp.Models;

namespace GameDataApp.Data
{
    public class GameDataAppContext : DbContext
    {
        public GameDataAppContext (DbContextOptions<GameDataAppContext> options)
            : base(options)
        {
        }

        public DbSet<GameDataApp.Models.Player> Player { get; set; } = default!;
    }
}
