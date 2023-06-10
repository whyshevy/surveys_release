using MediatR;
using Surveys.Backend.Common.OperationResult;
using Surveys.Backend.Foundation.UserSurveys.CreateSurvey.Errors;
using Surveys.Backend.Foundation.UserSurveys.CreateSurvey.Models;

namespace Surveys.Backend.Foundation.UserSurveys.CreateSurvey;

public class CreateSurveyCommand  : IRequest<OperationResult<CreateSurveyResult?, CreateSurveyError>>
{
    public string Title { get; set; }

    public string? Description { get; set; }

    public Guid CreatedById { get; set; }

    public bool IsRegisteredOnly { get; set; }

    public IReadOnlyCollection<CreateQuestion> Questions { get; set; }


    public CreateSurveyCommand()
    {
        Title = string.Empty;
        Questions = new List<CreateQuestion>();
    }
}