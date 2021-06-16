using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_mobile_app.Models;

namespace Project_mobile_app.Configuration
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Game");

            builder.HasMany(g => g.Stops).WithOne(s => s.PartOfGame).IsRequired(true);

            builder.HasOne(g => g.Introduction).WithOne(i => i.Game).HasForeignKey<Introduction>(i => i.GameId).IsRequired(true);

            builder.Property(g => g.Name).HasMaxLength(50).IsRequired(true);

            builder.Property(g => g.Description).HasMaxLength(1000).IsRequired(true); // HTML
        }
    }
}