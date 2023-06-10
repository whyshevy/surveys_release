using MediatR;
using Microsoft.AspNetCore.Identity;
using Surveys.Backend.Common.OperationResult;
using Surveys.Backend.DomainModel;
using Surveys.Backend.Foundation.Security;
using Surveys.Backend.Foundation.Users.SignIn.Errors;

namespace Surveys.Backend.Foundation.Users.SignIn;

public class SignInHandler : IRequestHandler<SignInCommand, OperationResult<Models.SignInResult?, SignInError>>
{
    private readonly UserManager<User> _userManager;
    private readonly IJwtService _jwtService;


    public SignInHandler(UserManager<User> userManager, IJwtService jwtService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
    }


    public async Task<OperationResult<Models.SignInResult?, SignInError>> Handle(SignInCommand signInCommand, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(nameof(signInCommand));

        var user = await _userManager.FindByEmailAsync(signInCommand.Email);
        if (user is null)
        {
            return SignInError.InvalidCredentials;
        }

        var isValidPassword = await _userManager.CheckPasswordAsync(user, signInCommand.Password);
        if (!isValidPassword)
        {
            return SignInError.InvalidCredentials;
        }

        var token = _jwtService.CreateToken(user.Id, user.Email, user.Name);
        var signInResult = CreateFrom(token);

        return signInResult;
    }


    private static Models.SignInResult CreateFrom(string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            throw new ArgumentNullException(nameof(token));
        }

        return new Models.SignInResult
        {
            Token = token
        };
    }
}