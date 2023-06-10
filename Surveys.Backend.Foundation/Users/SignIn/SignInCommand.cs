using MediatR;
using Surveys.Backend.Common.OperationResult;
using Surveys.Backend.Foundation.Users.SignIn.Errors;
using Surveys.Backend.Foundation.Users.SignIn.Models;

namespace Surveys.Backend.Foundation.Users.SignIn;

public class SignInCommand : IRequest<OperationResult<SignInResult?, SignInError>>
{
    public string? Email { get; init; }

    public string? Password { get; init; }
}