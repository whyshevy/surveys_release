using Surveys.Backend.Foundation.Common.ErrorProviders.Interfaces;
using Surveys.Backend.Foundation.Users.SignUp.Errors;

namespace Surveys.Backend.Foundation.Common.ErrorProviders.IdentitySignUpError.Providers;

public interface IIdentitySignUpErrorProvider : IErrorProvider<string, SignUpError>
{

}





