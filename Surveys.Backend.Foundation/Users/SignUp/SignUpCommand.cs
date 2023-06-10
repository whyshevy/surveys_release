using MediatR;
using Surveys.Backend.Common.OperationResult;
using Surveys.Backend.Foundation.Users.SignUp.Errors;
using Surveys.Backend.Foundation.Users.SignUp.Models;

namespace Surveys.Backend.Foundation.Users.SignUp;

public class SignUpCommand : IRequest<OperationResult<SignUpResult?, SignUpError>>
{
    public string? Name { get; init; }

    public string? Email { get; init; }

    public string? Password { get; init; }
}