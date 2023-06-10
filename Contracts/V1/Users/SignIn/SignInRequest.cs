namespace Surveys.Backend.WebApp.Contracts.V1.Users.SignIn;

public class SignInRequest
{
    public string? Email { get; set; }

    public string? Password { get; set; }
}