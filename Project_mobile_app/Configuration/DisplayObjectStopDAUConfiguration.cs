using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_mobile_app.Models;

namespace Project_mobile_app.Configuration
{
    public class DisplayObjectStopDAUConfiguration : IEntityTypeConfiguration<DisplayObjectStopDisplayAfterUnlock>
    {
        public void Configure(EntityTypeBuilder<DisplayObjectStopDisplayAfterUnlock> builder)
        {
            builder.ToTable("DisplayObjectStopDisplayAfterUnlock");

            builder.HasKey(x => new { x.StopId, x.DisplayObjectId });

            builder.HasOne(d => d.Stop).WithMany(s => s.DisplayObjectsRewards).HasForeignKey(d => d.StopId);

            builder.HasOne(d => d.DisplayObject).WithMany(d => d.RewardForTheseStops).HasForeignKey(d => d.DisplayObjectId);

        }
    }
}