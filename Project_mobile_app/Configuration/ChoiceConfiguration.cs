using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_mobile_app.Models;

namespace Project_mobile_app.Configuration
{
    public class ChoiceConfiguration : IEntityTypeConfiguration<Choice>
    {
        public void Configure(EntityTypeBuilder<Choice> builder)
        {
            builder.ToTable("Choice");

            builder.HasMany(c => c.OpensMapPositions).WithMany(mp => mp.ChoicesThatOpenThis);

        }
    }
}