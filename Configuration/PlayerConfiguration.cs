using GameDataApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GameDataApp.Configuration
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Player");

            builder.HasData(
                new Player
                {
                    Id = 1,
                    Username = "Player_1",
                    Password = "12345",
                },
                new Player
                {
                    Id = 2,
                    Username = "Player_2",
                    Password = "12345",
                }
            );
        }
    }
}
