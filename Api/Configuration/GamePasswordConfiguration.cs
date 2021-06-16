using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_mobile_app.Models;

namespace Project_mobile_app.Configuration
{
    public class GamePasswordConfiguration : IEntityTypeConfiguration<GamePassword>
    {
        public void Configure(EntityTypeBuilder<GamePassword> builder)
        {
            builder.Property(gp => gp.Password).HasMaxLength(50).IsRequired(true);
        }
    }
}
