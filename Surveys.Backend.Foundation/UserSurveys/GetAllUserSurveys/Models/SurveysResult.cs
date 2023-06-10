namespace Surveys.Backend.Foundation.UserSurveys.GetAllUserSurveys.Models;

public class UserSurveysResult
{
    public IReadOnlyCollection<UserSurvey> UserSurveys { get; set; }


    public UserSurveysResult()
    {
        UserSurveys = new List<UserSurvey>();
    }
}