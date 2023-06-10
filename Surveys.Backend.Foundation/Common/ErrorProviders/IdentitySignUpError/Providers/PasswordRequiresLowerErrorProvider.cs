using Surveys.Backend.Common.Errors;
using Surveys.Backend.Foundation.Users.SignUp.Errors;

namespace Surveys.Backend.Foundation.Common.ErrorProviders.IdentitySignUpError.Providers;

public class PasswordRequiresLowerErrorProvider : IIdentitySignUpErrorProvider
{
    public string SourceError => IdentityErrors.PasswordRequiresLower;

    public SignUpError GetConvertedError()
        => SignUpError.PasswordRequiresLower;
}