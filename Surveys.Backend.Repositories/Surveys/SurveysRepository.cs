using Ardalis.Specification.EntityFrameworkCore;
using Surveys.Backend.DataAccess;
using Surveys.Backend.DomainModel;

namespace Surveys.Backend.Repositories.Surveys;

public class SurveysRepository : RepositoryBase<Questionnaire>
{
    public SurveysRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {

    }
}