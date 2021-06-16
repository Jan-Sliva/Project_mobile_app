using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_mobile_app.Models;

namespace Project_mobile_app.Configuration
{
    public class DisplayObjectConfiguration : IEntityTypeConfiguration<DisplayObject>
    {
        public void Configure(EntityTypeBuilder<DisplayObject> builder)
        {
            builder.Property(dob => dob.Title).HasMaxLength(300).IsRequired(true); // HTML
        }
    }
}
