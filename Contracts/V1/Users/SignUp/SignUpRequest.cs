namespace Surveys.Backend.WebApp.Contracts.V1.Users.SignUp;

public class SignUpRequest
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}