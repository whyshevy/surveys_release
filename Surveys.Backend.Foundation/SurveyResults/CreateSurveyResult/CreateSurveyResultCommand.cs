using MediatR;
using Surveys.Backend.Foundation.SurveyResults.Models;

namespace Surveys.Backend.Foundation.SurveyResults.CreateSurveyResult;

public class CreateSurveyResultCommand : IRequest<SurveyResult>
{
    public Guid SurveyId { get; set; }

    public Guid? PassedById { get; set; }

    public IReadOnlyCollection<AnswerDto> Answers { get; set; }


    public CreateSurveyResultCommand()
    {
        Answers = new List<AnswerDto>();
    }
}