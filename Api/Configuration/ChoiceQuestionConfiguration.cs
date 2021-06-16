using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_mobile_app.Models;

namespace Project_mobile_app.Configuration
{
    public class ChoiceQuestionConfiguration : IEntityTypeConfiguration<ChoiceQuestion>
    {
        public void Configure(EntityTypeBuilder<ChoiceQuestion> builder)
        {
            builder.HasMany(cq => cq.Choices).WithOne(c => c.Question);

        }
    }
}