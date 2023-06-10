using AutoMapper;
using Surveys.Backend.DomainModel;
using Surveys.Backend.Foundation.Options.Models;

namespace Surveys.Backend.Foundation.Options.Profiles;

public class OptionProfile : Profile
{
    public OptionProfile()
    {
        CreateMap<Option, OptionDto>();
    }
}