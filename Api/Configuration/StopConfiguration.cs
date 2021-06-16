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

            builder.HasOne(s => s.Position).WithOne(mp => mp.PositionOfStop).HasForeignKey<MapPosition>(mp => mp.PositionOfStopId);

            builder.HasMany(s => s.PositionsDisplayAfterDisplay).WithMany(mp => mp.StopDisplayAfterDisplay);

            builder.HasMany(s => s.PositionsDisplayAfterUnlock).WithMany(mp => mp.StopDisplayAfterUnlock);

            builder.HasMany(s => s.Passwords).WithOne(p => p.Stop).IsRequired(true);

            builder.Property(s => s.Name).HasMaxLength(300).IsRequired(true); // HTML
        }
    }
}