using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Surveys.Backend.DataAccess.Configurations.Interfaces;
using Surveys.Backend.DomainModel;

namespace Surveys.Backend.DataAccess.Configurations;

public sealed class QuestionnaireConfiguration : IEntityTypeConfiguration<Questionnaire>, ISeedableConfiguration<Questionnaire>
{
    public static readonly Guid QuestionnaireId = Guid.Parse("48bd6426-f2bc-4c04-a15d-25eb88d6fb67");


    public void Configure(EntityTypeBuilder<Questionnaire> builder)
    {
        builder.Property(q => q.Id)
            .IsRequired();

        builder.Property(q => q.Title)
            .IsRequired()
            .HasMaxLength(Questionnaire.TitleMaxLength);

        builder.Property(q => q.Description)
            .HasMaxLength(Questionnaire.DescriptionMaxLength);

        builder.Property(q => q.RegisteredOnly)
            .HasDefaultValue(false);

        Seed(builder);
    }

    public void Seed(EntityTypeBuilder<Questionnaire> builder)
    {
        CreateQuestionnaire(builder);
    }


    private static void CreateQuestionnaire(EntityTypeBuilder<Questionnaire> builder)
    {
        var questionnaire = new Questionnaire
        {
            Id = QuestionnaireId,
            Description = "Questionnaire description",
            Title = "Questionnaire title",
            RegisteredOnly = false,
            CreatedById = UserConfiguration.AdminId,
            UpdatedById = UserConfiguration.AdminId
        };

        builder.HasData(questionnaire);
    }
}