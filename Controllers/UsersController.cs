using MediatR;
using Microsoft.AspNetCore.Mvc;
using Surveys.Backend.Foundation.Users.SignIn;
using Surveys.Backend.Foundation.Users.SignUp;
using Surveys.Backend.WebApp.Contracts.V1;
using Surveys.Backend.WebApp.Contracts.V1.Users.SignIn;
using Surveys.Backend.WebApp.Contracts.V1.Users.SignUp;

namespace Surveys.Backend.WebApp.Controllers;

public class UsersController : ApiController
{
    private readonly IMediator _mediator;


    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    [Route(Routes.Users.SignUp)]
    public async Task<IActionResult> SignUp([FromBody] SignUpRequest signUpRequest)
    {
        var signUpCommand = new SignUpCommand
        {
            Email = signUpRequest.Email,
            Name = signUpRequest.Name,
            Password = signUpRequest.Password
        };

        var signUpResult = await _mediator.Send(signUpCommand);
        if (!signUpResult.IsSuccessful)
        {
            return Problem(signUpResult.CreateSingleStringError(), statusCode: StatusCodes.Status400BadRequest);
        }

        var signUpResponse = new SignUpResponse
        {
            Token = signUpResult.Result?.Token ?? string.Empty
        };

        return Ok(signUpResponse);
    }

    [HttpPost]
    [Route(Routes.Users.SignIn)]
    [ProducesResponseType(typeof(SignUpResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignIn([FromBody] SignInRequest signInRequest)
    {
        var signInCommand = new SignInCommand
        {
            Email = signInRequest.Email,
            Password = signInRequest.Password
        };

        var signInResult = await _mediator.Send(signInCommand);
        if (!signInResult.IsSuccessful)
        {
            return Problem(signInResult.CreateSingleStringError(), statusCode: StatusCodes.Status400BadRequest);
        }

        var signUpResponse = new SignUpResponse
        {
            Token = signInResult.Result?.Token ?? string.Empty
        };

        return Ok(signUpResponse);
    }
}