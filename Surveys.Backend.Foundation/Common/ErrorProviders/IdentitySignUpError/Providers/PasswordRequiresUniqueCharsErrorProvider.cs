using Surveys.Backend.Common.Errors;
using Surveys.Backend.Foundation.Users.SignUp.Errors;

namespace Surveys.Backend.Foundation.Common.ErrorProviders.IdentitySignUpError.Providers;

public class PasswordRequiresUniqueCharsErrorProvider : IIdentitySignUpErrorProvider
{
    public string SourceError => IdentityErrors.PasswordRequiresUniqueChars;

    public SignUpError GetConvertedError()
        => SignUpError.PasswordRequiresUniqueChars;
}
