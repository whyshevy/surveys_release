using Ardalis.Specification.EntityFrameworkCore;
using Surveys.Backend.DataAccess;
using Surveys.Backend.DomainModel;

namespace Surveys.Backend.Repositories.SurveyResults;

public class SurveyResultsRepository : RepositoryBase<QuestionnaireResult>
{
    public SurveyResultsRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {

    }
}