namespace Surveys.Backend.WebApp.Contracts.V1.Users.Surveys;

public record CreateSurveyRequest(
    string Title,
    string? Description,
    IReadOnlyCollection<CreateSurveyQuestion> Questions
);