using Surveys.Backend.Common.Errors;
using Surveys.Backend.Foundation.Users.SignUp.Errors;

namespace Surveys.Backend.Foundation.Common.ErrorProviders.IdentitySignUpError.Providers;

public class PasswordRequiresDigitErrorProvider : IIdentitySignUpErrorProvider
{
    public string SourceError => IdentityErrors.PasswordRequiresDigit;

    public SignUpError GetConvertedError()
        => SignUpError.PasswordRequiresDigit;
}