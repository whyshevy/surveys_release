namespace Surveys.Backend.WebApp.Contracts.V1.SurveyResults.Create;

public class CreateSurveyResultAnswer
{
    public int? Rating { get; set; }

    public string? Text { get; set; }

    public string? SelectedOptionsIds { get; set; }

    public Guid QuestionId { get; set; }
}