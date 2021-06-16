using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_mobile_app.Models;

namespace Project_mobile_app.Configuration
{
    public class ChoiceForChoiceQuestionConfiguration : IEntityTypeConfiguration<ChoiceForChoiceQuestion>
    {
        public void Configure(EntityTypeBuilder<ChoiceForChoiceQuestion> builder)
        {
            builder.Property(ch => ch.Text).HasMaxLength(300).IsRequired(true); // HTML
        }
    }
}
