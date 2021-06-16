using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_mobile_app.Models;

namespace Project_mobile_app.Configuration
{
    public class IntroductionConfiguration : IEntityTypeConfiguration<Introduction>
    {
        public void Configure(EntityTypeBuilder<Introduction> builder)
        {
            builder.ToTable("Introduction");

            builder.HasMany(i => i.DisplayObjects).WithOne(d => d.Introduction);

            builder.HasMany(i => i.MapPositions).WithOne(mp => mp.Introduction);

            builder.Property(i => i.Title).HasMaxLength(300).IsRequired(true); // HTML
        }
    }
}