using Surveys.Backend.Common.Errors;
using Surveys.Backend.Foundation.Users.SignUp.Errors;

namespace Surveys.Backend.Foundation.Common.ErrorProviders.IdentitySignUpError.Providers;

public class PasswordRequiresNonAlphanumericErrorProvider : IIdentitySignUpErrorProvider
{
    public string SourceError => IdentityErrors.PasswordRequiresNonAlphanumeric;

    public SignUpError GetConvertedError()
        => SignUpError.PasswordRequiresNonAlphanumeric;
}