using Microsoft.Extensions.DependencyInjection;
using Surveys.Backend.Foundation.Common.ErrorProviders.IdentitySignUpError.Providers;

namespace Surveys.Backend.Foundation.Common.ErrorProviders.IdentitySignUpError;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddIdentitySignUpErrorProviders(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IIdentitySignUpErrorProvider, DuplicateEmailErrorProvider>();
        serviceCollection.AddScoped<IIdentitySignUpErrorProvider, InvalidEmailErrorProvider>();
        serviceCollection.AddScoped<IIdentitySignUpErrorProvider, PasswordRequiresDigitErrorProvider>();
        serviceCollection.AddScoped<IIdentitySignUpErrorProvider, PasswordRequiresLowerErrorProvider>();
        serviceCollection.AddScoped<IIdentitySignUpErrorProvider, PasswordRequiresNonAlphanumericErrorProvider>();
        serviceCollection.AddScoped<IIdentitySignUpErrorProvider, PasswordRequiresUniqueCharsErrorProvider>();
        serviceCollection.AddScoped<IIdentitySignUpErrorProvider, PasswordRequiresUpperErrorProvider>();
        serviceCollection.AddScoped<IIdentitySignUpErrorProvider, PasswordTooShortErrorProvider>();
        serviceCollection.AddScoped<IIdentitySignUpErrorProvider, UnknownErrorProvider>();
        serviceCollection.AddScoped<IIdentitySignUpErrorProvider, PasswordTooShortErrorProvider>();
        serviceCollection.AddScoped<IIdentitySignUpErrorProviderFactory, IdentitySignUpErrorProviderFactory>();

        return serviceCollection;
    }
}