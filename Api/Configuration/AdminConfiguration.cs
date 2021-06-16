using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_mobile_app.Models;

namespace Project_mobile_app.Configuration
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admin");

            builder.Property(a => a.UserName).HasMaxLength(20).IsRequired(true);

            builder.Property(a => a.Password).HasMaxLength(20).IsRequired(true);

            builder.Property(a => a.Email).HasMaxLength(320).IsRequired(true);

        }
    }
}