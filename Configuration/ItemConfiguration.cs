using GameDataApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameDataApp.Configuration
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");

            builder.Property(s => s.Description)
                .IsRequired(false);

            builder.HasData(
                new Item
                {
                    Id = 1,
                    Name = "Item 1",
                    Description = "My first item.",
                    IsUsable = true
                },
                new Item
                {
                    Id = 2,
                    Name = "Item 2",
                    Description = "My second item.",
                    IsUsable = true
                }
            );
        }
    }
}