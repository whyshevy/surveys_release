using Surveys.Backend.Foundation.Questions.Models;

namespace Surveys.Backend.Foundation.SurveyResults.Models;

public sealed class AnswerDto
{
    public Guid Id { get; set; }

    public int? Rating { get; set; }

    public string? Text { get; set; }

    public string? SelectedOptionsIds { get; set; }

    public Guid QuestionId { get; set; }

    public QuestionDto? Question { get; set; }
}