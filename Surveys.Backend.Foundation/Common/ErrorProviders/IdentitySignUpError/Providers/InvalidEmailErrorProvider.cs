using Surveys.Backend.Common.Errors;
using Surveys.Backend.Foundation.Users.SignUp.Errors;

namespace Surveys.Backend.Foundation.Common.ErrorProviders.IdentitySignUpError.Providers;

public class InvalidEmailErrorProvider : IIdentitySignUpErrorProvider
{
    public string SourceError => IdentityErrors.InvalidEmail;

    public SignUpError GetConvertedError()
        => SignUpError.InvalidEmail;
}