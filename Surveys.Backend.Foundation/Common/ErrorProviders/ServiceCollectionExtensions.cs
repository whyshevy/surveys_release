using Microsoft.Extensions.DependencyInjection;
using Surveys.Backend.Foundation.Common.ErrorProviders.IdentitySignUpError;

namespace Surveys.Backend.Foundation.Common.ErrorProviders;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddErrorProviders(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddIdentitySignUpErrorProviders();

        return serviceCollection;
    }
}