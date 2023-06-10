using AutoMapper;
using Surveys.Backend.DomainModel;
using Surveys.Backend.Foundation.Users.Models;

namespace Surveys.Backend.Foundation.Users.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
    }
}