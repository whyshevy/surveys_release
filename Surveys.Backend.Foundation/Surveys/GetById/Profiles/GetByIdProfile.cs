using AutoMapper;
using Surveys.Backend.DomainModel;
using Surveys.Backend.Foundation.Surveys.Models;

namespace Surveys.Backend.Foundation.Surveys.GetById.Profiles;

public class GetByIdProfile : Profile
{
    public GetByIdProfile()
    {
        CreateMap<Questionnaire, SurveyDto>();
    }
}