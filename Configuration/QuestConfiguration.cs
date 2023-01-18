using GameDataApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GameDataApp.Configuration
{
    public class QuestConfiguration : IEntityTypeConfiguration<Quest>
    {
        public void Configure(EntityTypeBuilder<Quest> builder)
        {
            builder.ToTable("Quest");

            builder.Property(s => s.Description)
                .IsRequired(false);

            builder.HasData(
                new Quest
                {
                    Id = 1,
                    Name = "First Quest",
                    Description = "This is the first quest.",
                    Reward = "This is the reward for the first quest."
                },
                new Quest
                {
                    Id = 2,
                    Name = "Second Quest",
                    Description = "This is the second quest.",
                    Reward = "This is the reward for the second quest."
                }
            );
        }
    }
}
