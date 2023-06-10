using Surveys.Backend.Foundation.Questions.Models;

namespace Surveys.Backend.Foundation.Options.Models;

public class OptionDto
{
    public Guid Id { get; set; }

    public string? Content { get; set; }

    public int Order { get; set; }

    public Guid QuestionId { get; set; }

    public QuestionDto? Question { get; set; }
}