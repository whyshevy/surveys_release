using Surveys.Backend.Common.Errors;
using Surveys.Backend.Foundation.Users.SignUp.Errors;

namespace Surveys.Backend.Foundation.Common.ErrorProviders.IdentitySignUpError.Providers;

public class UnknownErrorProvider : IIdentitySignUpErrorProvider
{
    public string SourceError => IdentityErrors.DefaultError;

    public SignUpError GetConvertedError()
        => SignUpError.PasswordTooShort;
}