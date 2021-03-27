using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_mobile_app.Models;

namespace Project_mobile_app.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasOne(u => u.Statistics).WithOne(s => s.User).HasForeignKey<Statistics>(s => s.UserId);

            builder.HasMany(u => u.Games).WithMany(g => g.Owners);

        }
    }
}