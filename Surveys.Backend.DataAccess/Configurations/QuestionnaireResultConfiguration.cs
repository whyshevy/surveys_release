using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Surveys.Backend.DomainModel;

namespace Surveys.Backend.DataAccess.Configurations;

public sealed class QuestionnaireResultConfiguration : IEntityTypeConfiguration<QuestionnaireResult>
{
    public void Configure(EntityTypeBuilder<QuestionnaireResult> builder)
    {
        builder.Property(qr => qr.Id)
            .IsRequired();

        builder.Property(qr => qr.QuestionnaireId)
            .IsRequired();

        builder.HasMany(qr => qr.Answers);
    }
}