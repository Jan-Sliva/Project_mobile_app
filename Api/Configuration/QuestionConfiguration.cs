using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_mobile_app.Models;
using System.Collections.Generic;

namespace Project_mobile_app.Configuration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Question");

            builder.HasMany(q => q.ChoicesThatOpensThis).WithMany(c => c.OpensQuestions)
              .UsingEntity<Dictionary<string, object>>(
                "QuestionChoice",
                j => j.HasOne<Choice>().WithMany().OnDelete(DeleteBehavior.NoAction),
                j => j.HasOne<Question>().WithMany().OnDelete(DeleteBehavior.NoAction));

            builder.Property(q => q.QuestionText).HasMaxLength(1000).IsRequired(true); //HTML
        }
    }
}