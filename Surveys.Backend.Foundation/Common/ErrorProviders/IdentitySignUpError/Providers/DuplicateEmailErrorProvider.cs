using Surveys.Backend.Common.Errors;
using Surveys.Backend.Foundation.Users.SignUp.Errors;

namespace Surveys.Backend.Foundation.Common.ErrorProviders.IdentitySignUpError.Providers;

public class DuplicateEmailErrorProvider : IIdentitySignUpErrorProvider
{
    public string SourceError => IdentityErrors.DuplicateEmail;

    public SignUpError GetConvertedError()
        => SignUpError.DuplicateEmail;
}