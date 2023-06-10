namespace Surveys.Backend.Foundation.Security;

public interface IJwtService
{
    string CreateToken(Guid id, string email, string name);
}