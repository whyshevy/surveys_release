using AutoMapper;
using Surveys.Backend.DomainModel;
using Surveys.Backend.Foundation.Questions.Models;

namespace Surveys.Backend.Foundation.Questions.Profiles;

public class QuestionProfile : Profile
{
    public QuestionProfile()
    {
        CreateMap<Question, QuestionDto>();
    }
}