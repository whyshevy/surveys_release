using AutoMapper;
using Surveys.Backend.DomainModel;

namespace Surveys.Backend.Foundation.Users.SignUp.Profiles;

public class SignUpProfile : Profile
{
    public SignUpProfile()
    {
        CreateMap<SignUpCommand, User>()
            .ForMember(u => u.UserName,
                options => options.MapFrom(suc => suc.Email));
    }
}