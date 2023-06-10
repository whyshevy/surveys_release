namespace Surveys.Backend.WebApp.Contracts.V1.Users.Surveys;

public record SurveyResponse(Guid Id, string Title, DateTime UpdatedAt, int ResponsesCount);