using Ardalis.Specification;
using Surveys.Backend.DomainModel;

namespace Surveys.Backend.Repositories.SurveyResults.Specifications;

public sealed class SurveyResultsCountById : Specification<QuestionnaireResult>
{
    public SurveyResultsCountById(Guid surveyIds)
    {
        Query.Where(qr => qr.QuestionnaireId == surveyIds);
    }
}