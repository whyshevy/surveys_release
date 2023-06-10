namespace Surveys.Backend.Foundation.Roles.Models;

public class RoleDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }


    public RoleDto()
    {
        Name = string.Empty;
    }
}