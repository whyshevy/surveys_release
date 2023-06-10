using MediatR;
using Surveys.Backend.Repositories.Surveys;

namespace Surveys.Backend.Foundation.Surveys.DeleteById;

public class DeleteByIdHandler : IRequestHandler<DeleteByIdCommand, bool?>
{
    private readonly SurveysRepository _surveysRepository;


    public DeleteByIdHandler(SurveysRepository surveysRepository)
    {
        _surveysRepository = surveysRepository;
    }


    public async Task<bool?> Handle(DeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await _surveysRepository.GetByIdAsync(request.SurveyId, cancellationToken);
        if (result is null)
        {
            return null;
        }

        await _surveysRepository.DeleteAsync(result, cancellationToken);

        return true;
    }
}