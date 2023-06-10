using MediatR;

namespace Surveys.Backend.Foundation.Surveys.DeleteById;

public class DeleteByIdCommand : IRequest<bool?>
{
    public Guid SurveyId { get; set; }
}