using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Surveys.Backend.DataAccess.Configurations.Interfaces;
using Surveys.Backend.DomainModel;

namespace Surveys.Backend.DataAccess.Configurations;

public sealed class OptionConfiguration : IEntityTypeConfiguration<Option>, ISeedableConfiguration<Option>
{
    public void Configure(EntityTypeBuilder<Option> builder)
    {
        builder.Property(o => o.Id)
            .IsRequired();

        builder.Property(o => o.Content)
            .HasMaxLength(Option.ContentMaxLength)
            .IsRequired();

        builder.Property(o => o.QuestionId)
            .IsRequired();
        
        Seed(builder);
    }

    public void Seed(EntityTypeBuilder<Option> builder)
    {
        const string questionId = "03ec14a4-586c-4f84-9a46-ecb36af457ab";

        builder.HasData(
            CreateOption(
                "3d55bb8d-d042-4cc4-9423-994e21141308",
                "Option content 1",
                1,
                questionId
            ),
            CreateOption(
                "bd56f9e1-6b78-4a30-858b-f18ff91b967f",
                "Option content 2",
                2,
                questionId
            ),
            CreateOption(
                "ab39b4ae-8f88-4604-b4ba-911d59b61cb9",
                "Option content 3",
                3,
                questionId
            )
        );
    }

    private static Option CreateOption(string id, string content, int order, string questionId)
    {
        return new()
        {
            Id = Guid.Parse(id),
            Content = content,
            Order = order,
            QuestionId = Guid.Parse(questionId),
        };
    }
}