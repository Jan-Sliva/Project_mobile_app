using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_mobile_app.Models;

namespace Project_mobile_app.Configuration
{
    public class StopConfiguration : IEntityTypeConfiguration<Stop>
    {
        public void Configure(EntityTypeBuilder<Stop> builder)
        {
            builder.ToTable("Stop");

            builder.HasMany(s => s.Questions).WithMany(q => q.StopsThatOpenThis);

            builder.HasMany(s => s.Opens).WithMany(s => s.StopsThatOpenThis);

            builder.HasMany(s => s.ChoicesThatOpenThis).WithMany(s => s.OpensStops);

            builder.HasOne(s => s.Position).WithOne(mp => mp.PositionOfStop).HasForeignKey<MapPosition>(mp => mp.PositionOfStopId);

            builder.HasMany(s => s.PositionsDisplayAfterDisplay).WithOne(mp => mp.StopDisplayAfterDisplay);

            builder.HasMany(s => s.PositionsDisplayAfterUnlock).WithOne(mp => mp.StopDisplayAfterUnlock);

            builder.HasMany(s => s.Passwords).WithOne(p => p.Stop);

        }
    }
}