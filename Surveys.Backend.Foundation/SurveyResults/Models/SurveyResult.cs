using Surveys.Backend.Foundation.Users.Models;

namespace Surveys.Backend.Foundation.SurveyResults.Models;

public class SurveyResult
{
    public Guid Id { get; set; }

    public Guid QuestionnaireId { get; set; }

    public Guid? PassedById { get; set; }

    public UserDto? PassedBy { get; set; }

    public IReadOnlyCollection<AnswerDto> Answers { get; set; }


    public SurveyResult()
    {
        Answers = new List<AnswerDto>();
    }
}