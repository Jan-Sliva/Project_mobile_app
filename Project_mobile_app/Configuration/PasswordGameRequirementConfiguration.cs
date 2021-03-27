using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_mobile_app.Models;

namespace Project_mobile_app.Configuration
{
    public class PasswordGameRequirementConfiguration : IEntityTypeConfiguration<PasswordGameRequirement>
    {
        public void Configure(EntityTypeBuilder<PasswordGameRequirement> builder)
        {
            builder.ToTable("PasswordGameRequirement");

            builder.HasMany(pgr => pgr.Passwords).WithOne(p => p.PasswordGameRequirement);

        }
    }
}