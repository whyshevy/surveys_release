using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Surveys.Backend.DomainModel;

namespace Surveys.Backend.DataAccess.Configurations;

public sealed class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.Property(a => a.Id)
            .IsRequired();

        builder.Property(a => a.Text)
            .HasMaxLength(Answer.TextMaxLength);
    }
}