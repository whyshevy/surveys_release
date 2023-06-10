using Microsoft.Extensions.DependencyInjection;
using Surveys.Backend.Repositories.SurveyResults;
using Surveys.Backend.Repositories.Surveys;

namespace Surveys.Backend.Repositories;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<SurveysRepository>();
        serviceCollection.AddScoped<SurveyResultsRepository>();

        return serviceCollection;
    }
}