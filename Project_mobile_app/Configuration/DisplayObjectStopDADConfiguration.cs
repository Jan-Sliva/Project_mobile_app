using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_mobile_app.Models;

namespace Project_mobile_app.Configuration
{
    public class DisplayObjectStopDADConfiguration : IEntityTypeConfiguration<DisplayObjectStopDisplayAfterDisplay>
    {
        public void Configure(EntityTypeBuilder<DisplayObjectStopDisplayAfterDisplay> builder)
        {
            builder.ToTable("DisplayObjectStopDisplayAfterDisplay");

            builder.HasKey(x => new { x.StopId, x.DisplayObjectId });

            builder.HasOne(d => d.Stop).WithMany(s => s.DisplayObjectsHints).HasForeignKey(d => d.StopId);

            builder.HasOne(d => d.DisplayObject).WithMany(d => d.HintForTheseStops).HasForeignKey(d => d.DisplayObjectId);

        }
    }
}