using AutoMapper;
using Surveys.Backend.DomainModel;
using Surveys.Backend.Foundation.Roles.Models;

namespace Surveys.Backend.Foundation.Roles.Profiles;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<Role, RoleDto>();
    }
}