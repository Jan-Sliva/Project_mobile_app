using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_mobile_app.Models;

namespace Project_mobile_app.Configuration
{
    public class MapPositionConfiguration : IEntityTypeConfiguration<MapPosition>
    {
        public void Configure(EntityTypeBuilder<MapPosition> builder)
        {
            builder.Property(ch => ch.Description).HasMaxLength(30).IsRequired(false);
        }
    }
}
