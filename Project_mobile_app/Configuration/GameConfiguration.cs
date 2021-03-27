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

            builder.HasMany(g => g.Stops).WithOne(s => s.PartOfGame);

            builder.HasOne(g => g.FirstStop).WithOne(s => s.FirstStopOfGame).HasForeignKey<Stop>(s => s.GameFirstStopId);

            builder.HasOne(g => g.Introduction).WithOne(i => i.Game).HasForeignKey<Introduction>(i => i.GameId);

        }
    }
}