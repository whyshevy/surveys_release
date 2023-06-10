using Surveys.Backend.DomainModel;

namespace Surveys.Backend.WebApp.Contracts.V1.Users.Surveys;

public record CreateSurveyQuestion(
    string Title,
    string? Description,
    int Order,
    QuestionType Type,
    IReadOnlyCollection<CreateSurveyOption>? Options
);