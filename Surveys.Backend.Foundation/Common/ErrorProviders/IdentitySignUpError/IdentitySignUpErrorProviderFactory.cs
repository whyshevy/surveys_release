using Surveys.Backend.Foundation.Common.ErrorProviders.IdentitySignUpError.Providers;

namespace Surveys.Backend.Foundation.Common.ErrorProviders.IdentitySignUpError;

public class IdentitySignUpErrorProviderFactory : IIdentitySignUpErrorProviderFactory
{
    private readonly IEnumerable<IIdentitySignUpErrorProvider> _providers;


    public IdentitySignUpErrorProviderFactory(IEnumerable<IIdentitySignUpErrorProvider> providers)
    {
        _providers = providers;
    }


    public IIdentitySignUpErrorProvider CreateProvider(string identityError)
    {
        var provider = _providers.FirstOrDefault(p => p.SourceError == identityError, new UnknownErrorProvider());

        return provider;
    }

    public IReadOnlyCollection<IIdentitySignUpErrorProvider> CreateProviders(IReadOnlyCollection<string> identityErrors)
    {
        var providers = _providers
            .Where(p => identityErrors.Contains(p.SourceError))
            .ToList();

        return providers;
    }
}