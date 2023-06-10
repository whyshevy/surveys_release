using Surveys.Backend.DomainModel;
using Surveys.Backend.Foundation.Options.Models;
using Surveys.Backend.Foundation.Surveys.Models;

namespace Surveys.Backend.Foundation.Questions.Models;

public class QuestionDto
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int Order { get; set; }

    public bool IsRequired { get; set; }

    public Guid QuestionnaireId { get; set; }

    public SurveyDto? Questionnaire { get; set; }

    public QuestionType Type { get; set; }

    public ICollection<OptionDto> Options { get; set; }


    public QuestionDto()
    {
        Options = new List<OptionDto>();
    }
}