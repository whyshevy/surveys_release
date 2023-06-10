using Surveys.Backend.Foundation.Questions.Models;
using Surveys.Backend.Foundation.Users.Models;

namespace Surveys.Backend.Foundation.Surveys.Models;

public sealed class SurveyDto
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public bool RegisteredOnly { get; set; }

    public Guid? CreatedById { get; set; }

    public UserDto? CreatedBy { get; set; }

    public Guid? UpdatedById { get; set; }

    public UserDto? UpdatedBy { get; set; } 

    public ICollection<QuestionDto?> Questions { get; set; }
}