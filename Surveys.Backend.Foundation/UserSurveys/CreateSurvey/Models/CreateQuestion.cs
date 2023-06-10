using Surveys.Backend.DomainModel;

namespace Surveys.Backend.Foundation.UserSurveys.CreateSurvey.Models;

public class CreateQuestion
{
    public string Title { get; set; }

    public string? Description { get; set; }

    public int Order { get; set; }

    public QuestionType Type { get; set; }

    public IReadOnlyCollection<CreateOption>? Options { get; set; }


    public CreateQuestion()
    {
        Title = string.Empty;
    }
}