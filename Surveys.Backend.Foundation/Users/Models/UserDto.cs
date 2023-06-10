using Surveys.Backend.Foundation.Roles.Models;

namespace Surveys.Backend.Foundation.Users.Models;

public class UserDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public ICollection<RoleDto> Roles { get; set; }


    public UserDto()
    {
        Name = string.Empty;
        Email = string.Empty;
        Roles = new List<RoleDto>();
    }
}