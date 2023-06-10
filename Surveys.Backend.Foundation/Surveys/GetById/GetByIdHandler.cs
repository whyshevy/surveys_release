using AutoMapper;
using MediatR;
using Surveys.Backend.Foundation.Surveys.GetById.Models;
using Surveys.Backend.Foundation.Surveys.Models;
using Surveys.Backend.Repositories.Surveys;
using Surveys.Backend.Repositories.Surveys.Specifications;

namespace Surveys.Backend.Foundation.Surveys.GetById;

public sealed class GetByIdHandler : IRequestHandler<GetByIdCommand, GetByIdResult?>
{
    private readonly IMapper _mapper;
    private readonly SurveysRepository _surveysRepository;


    public GetByIdHandler(IMapper mapper, SurveysRepository surveysRepository)
    {
        _mapper = mapper;
        _surveysRepository = surveysRepository;
    }


    public async Task<GetByIdResult?> Handle(GetByIdCommand request, CancellationToken cancellationToken)
    {
        var specification = new SurveyByIdWithDetails(request.Id);
        var survey = await _surveysRepository.GetBySpecAsync(specification, cancellationToken);
        if (survey is null)
        {
            return null;
        }

        var surveyDto = _mapper.Map<SurveyDto>(survey);

        return CreateFrom(surveyDto);
    }


    private static GetByIdResult CreateFrom(SurveyDto surveyDto)
    {
        return new()
        {
            Survey = surveyDto
        };
    }
}