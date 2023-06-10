using Ardalis.Specification;
using Surveys.Backend.DomainModel;

namespace Surveys.Backend.Repositories.Surveys.Specifications;

public sealed class SurveyByUserIdSpec : Specification<Questionnaire>
{
    public SurveyByUserIdSpec(Guid userId)
    {
        Query.Where(q => q.CreatedById == userId);
    }
}