using Surveys.Backend.Common.Errors;
using Surveys.Backend.Foundation.Users.SignUp.Errors;

namespace Surveys.Backend.Foundation.Common.ErrorProviders.IdentitySignUpError.Providers;

public class PasswordRequiresUpperErrorProvider : IIdentitySignUpErrorProvider
{
    public string SourceError => IdentityErrors.PasswordRequiresUpper;

    public SignUpError GetConvertedError()
        => SignUpError.PasswordRequiresUpper;
}