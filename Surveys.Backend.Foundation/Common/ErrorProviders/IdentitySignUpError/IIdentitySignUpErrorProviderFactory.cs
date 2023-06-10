using Surveys.Backend.Foundation.Common.ErrorProviders.IdentitySignUpError.Providers;

namespace Surveys.Backend.Foundation.Common.ErrorProviders.IdentitySignUpError;

public interface IIdentitySignUpErrorProviderFactory
{
    IIdentitySignUpErrorProvider CreateProvider(string identityError);

    IReadOnlyCollection<IIdentitySignUpErrorProvider> CreateProviders(IReadOnlyCollection<string> identityErrors);
}