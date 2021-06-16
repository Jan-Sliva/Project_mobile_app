using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_mobile_app.Models;

namespace Project_mobile_app.Configuration
{
    public class StopStopConfiguration : IEntityTypeConfiguration<StopStop>
    {
        public void Configure(EntityTypeBuilder<StopStop> builder)
        {
            builder.ToTable("StopStop");

            builder.HasOne(d => d.Opens).WithMany(s => s.StopsOpenThis).HasForeignKey(d => d.OpensId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.StopOpensThis).WithMany(d => d.Opens).HasForeignKey(d => d.StopOpensThisId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}