using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_mobile_app.Models;

namespace Project_mobile_app.Configuration
{
    public class ChoiceStopConfiguration : IEntityTypeConfiguration<ChoiceStop>
    {
        public void Configure(EntityTypeBuilder<ChoiceStop> builder)
        {
            builder.ToTable("ChoiceStop");

            builder.HasOne(d => d.Opens).WithMany(s => s.ChoicesOpenThis).HasForeignKey(d => d.OpensId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.ChoiceOpensThis).WithMany(d => d.OpensStops).HasForeignKey(d => d.ChoiceOpensThisId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}