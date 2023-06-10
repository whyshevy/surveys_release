using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Surveys.Backend.DataAccess.Configurations.Interfaces;
using Surveys.Backend.DomainModel;

namespace Surveys.Backend.DataAccess.Configurations;

public sealed class QuestionConfiguration : IEntityTypeConfiguration<Question>, ISeedableConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.Property(q => q.Id)
            .IsRequired();

        builder.Property(q => q.Title)
            .HasMaxLength(Question.TitleMaxLength);

        builder.Property(q => q.Description)
            .HasMaxLength(Question.DescriptionMaxLength);

        builder.Property(q => q.IsRequired)
            .HasDefaultValue(false);

        builder.Property(q => q.QuestionnaireId)
            .IsRequired();

        builder.HasMany(q => q.Options)
            .WithOne(q => q.Question)
            .IsRequired();

        
        Seed(builder);
    }

    public void Seed(EntityTypeBuilder<Question> builder)
    {
        builder.HasData(
            CreateQuestion(
                Guid.Parse("03ec14a4-586c-4f84-9a46-ecb36af457ab"),
                "Question title 1",
                "Text Question description",
                1,
                true,
                QuestionType.SingleChoice,
                QuestionnaireConfiguration.QuestionnaireId
            ),
            CreateQuestion(
                Guid.Parse("cb22e35c-5360-4f91-b66b-f139fdfaf3f7"),
                "Question title 2",
                "Text Question description",
                2,
                true,
                QuestionType.MultipleChoice,
                QuestionnaireConfiguration.QuestionnaireId
            )
        );
    }


    private static Question CreateQuestion(
        Guid id,
        string title,
        string description,
        int order,
        bool isRequired,
        QuestionType type,
        Guid questionnaireId)
    {
        return new()
        {
            Id = id,
            Title = title,
            Description = description,
            Order = order,
            IsRequired = isRequired,
            Type = type,
            QuestionnaireId = questionnaireId,
        };
    }
}