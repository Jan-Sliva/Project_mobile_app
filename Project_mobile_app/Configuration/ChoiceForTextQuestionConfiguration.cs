using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_mobile_app.Models;

namespace Project_mobile_app.Configuration
{
    public class ChoiceForTextQuestionConfiguration : IEntityTypeConfiguration<ChoiceForTextQuestion>
    {
        public void Configure(EntityTypeBuilder<ChoiceForTextQuestion> builder)
        {
            builder.Property(ch => ch.Text).HasMaxLength(50).IsRequired(true);
        }
    }
}
