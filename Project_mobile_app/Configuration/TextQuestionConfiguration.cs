using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_mobile_app.Models;

namespace Project_mobile_app.Configuration
{
    public class TextQuestionConfiguration : IEntityTypeConfiguration<TextQuestion>
    {
        public void Configure(EntityTypeBuilder<TextQuestion> builder)
        {
            builder.HasOne(tq => tq.DefaultChoice).WithOne(dc => dc.Question).HasForeignKey<DefaultChoice>(b => b.QuestionId);

            builder.HasMany(tq => tq.Choices).WithOne(c => c.Question);

        }
    }
}