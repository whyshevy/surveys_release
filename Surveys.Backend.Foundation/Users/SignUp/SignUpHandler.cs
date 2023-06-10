using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Surveys.Backend.DomainModel;
using Surveys.Backend.Common.Extensions;
using Surveys.Backend.Common.OperationResult;
using Surveys.Backend.Foundation.Common.ErrorProviders.IdentitySignUpError;
using Surveys.Backend.Foundation.Security;
using Surveys.Backend.Foundation.Users.SignUp.Errors;
using Surveys.Backend.Foundation.Users.SignUp.Models;

namespace Surveys.Backend.Foundation.Users.SignUp;

public class SignUpHandler : IRequestHandler<SignUpCommand, OperationResult<SignUpResult?, SignUpError>>
{
    private readonly IMapper _mapper;
    private readonly IIdentitySignUpErrorProviderFactory _errorProviderFactory;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly IJwtService _jwtService;


    public SignUpHandler(
        IMapper mapper,
        IIdentitySignUpErrorProviderFactory errorProviderFactory,
        UserManager<User> userManager,
        RoleManager<Role> roleManager,
        IJwtService jwtService)
    {
        _mapper = mapper;
        _errorProviderFactory = errorProviderFactory;
        _userManager = userManager;
        _roleManager = roleManager;
        _jwtService = jwtService;
    }


    public async Task<OperationResult<SignUpResult?, SignUpError>> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var existingUser = await _userManager.FindByEmailAsync(request.Email);
        if (existingUser is not null)
        {
            return SignUpError.DuplicateEmail;
        }

        var role = await _roleManager.FindByNameAsync(DomainModel.Roles.User);

        var user = _mapper.Map<User>(request);
        user.Roles.Add(role);

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            var signUpErrors = CreateFrom(result.Errors.ToList());

            return signUpErrors.ToArray();
        }

        var token = _jwtService.CreateToken(user.Id, user.Email, user.Name);
        var signUpResult = CreateFrom(token);

        return signUpResult;
    }


    private IReadOnlyCollection<SignUpError> CreateFrom(IReadOnlyCollection<IdentityError> identityErrors)
    {
        if (identityErrors.IsNullOrEmpty())
        {
            return Array.Empty<SignUpError>();
        }

        var identityErrorCodes = identityErrors
            .Select(e => e.Code)
            .ToList();

        var errorProviders = _errorProviderFactory.CreateProviders(identityErrorCodes);
        var errors = errorProviders
            .Select(p => p.GetConvertedError())
            .ToList();

        return errors;
    }


    private static SignUpResult CreateFrom(string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            throw new ArgumentNullException(nameof(token));
        }

        return new SignUpResult
        {
            Token = token
        };
    }
}