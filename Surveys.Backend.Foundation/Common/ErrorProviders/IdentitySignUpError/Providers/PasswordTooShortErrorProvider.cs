using Surveys.Backend.Common.Errors;
using Surveys.Backend.Foundation.Users.SignUp.Errors;

namespace Surveys.Backend.Foundation.Common.ErrorProviders.IdentitySignUpError.Providers;

public class PasswordTooShortErrorProvider : IIdentitySignUpErrorProvider
{
    public string SourceError => IdentityErrors.PasswordTooShort;

    public SignUpError GetConvertedError()
        => SignUpError.PasswordTooShort;
}