using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using Surveys.Backend.Common.Extensions;
using Surveys.Backend.DomainModel;
using Surveys.Backend.Foundation.UserSurveys.GetAllUserSurveys.Models;
using Surveys.Backend.Repositories;
using Surveys.Backend.Repositories.SurveyResults;
using Surveys.Backend.Repositories.SurveyResults.Specifications;
using Surveys.Backend.Repositories.Surveys;
using Surveys.Backend.Repositories.Surveys.Specifications;

namespace Surveys.Backend.Foundation.UserSurveys.GetAllUserSurveys;

public class GetAllUserSurveysHandler : IRequestHandler<GetAllUserSurveysCommand, UserSurveysResult>
{
    private readonly SurveyResultsRepository _surveyResultsRepository;
    private readonly SurveysRepository _repository;


    public GetAllUserSurveysHandler(SurveysRepository repository, SurveyResultsRepository surveyResultsRepository)
    {
        _repository = repository;
        _surveyResultsRepository = surveyResultsRepository;
    }


    public async Task<UserSurveysResult> Handle(GetAllUserSurveysCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var userSurveys = new List<UserSurvey>();
        
        var questionnaires = await _repository.ListAsync(new SurveyByUserIdSpec(request.UserId), cancellationToken);
        foreach (var questionnaire in questionnaires)
        {
            var surveyResponsesCount = await _surveyResultsRepository.CountAsync(new SurveyResultsCountById(questionnaire.Id), cancellationToken);

            var userSurvey = CreateFrom(questionnaire, surveyResponsesCount);
            userSurveys.Add(userSurvey);
        }

        return new UserSurveysResult()
        {
            UserSurveys = userSurveys
        };
    }


    private UserSurveysResult CreateFrom(IReadOnlyCollection<Questionnaire> questionnaires)
    {
        IReadOnlyCollection<UserSurvey> userSurveys = Array.Empty<UserSurvey>();

        return new()
        {
            UserSurveys = userSurveys,
        };
    }

    private UserSurvey CreateFrom(Questionnaire questionnaire, int count)
    {
        return new()
        {
            Id = questionnaire.Id,
            Title = questionnaire.Title ?? string.Empty,
            UpdatedAt = DateTime.Now,
            ResponsesCount = count,
        };
    }
}