using MediatR;
using Surveys.Backend.Foundation.UserSurveys.GetAllUserSurveys.Models;

namespace Surveys.Backend.Foundation.UserSurveys.GetAllUserSurveys;

public class GetAllUserSurveysCommand : IRequest<UserSurveysResult>
{
    public Guid UserId { get; set; }
}