using GameDataApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GameDataApp.Configuration
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventory");

            builder.HasData(
                new Inventory
                {
                    Id = 1,
                    PlayerId = 1,
                    Size = 50
                },
                new Inventory
                {
                    Id = 2,
                    PlayerId = 2,
                    Size = 50
                }
            );
        }
    }
}