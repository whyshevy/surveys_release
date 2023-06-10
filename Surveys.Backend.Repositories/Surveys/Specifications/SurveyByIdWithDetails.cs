using Ardalis.Specification;
using Surveys.Backend.DomainModel;

namespace Surveys.Backend.Repositories.Surveys.Specifications;

public sealed class SurveyByIdWithDetails : Specification<Questionnaire>, ISingleResultSpecification
{
    public SurveyByIdWithDetails(Guid id)
    {
        Query.Where(q => q.Id == id)
            .AsSplitQuery()
            .Include(q => q.Questions).ThenInclude(qq => qq.Options)
            .Include(q => q.CreatedBy)
            .Include(q => q.UpdatedBy);
    }
}