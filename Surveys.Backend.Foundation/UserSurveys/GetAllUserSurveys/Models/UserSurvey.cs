namespace Surveys.Backend.Foundation.UserSurveys.GetAllUserSurveys.Models;

public class UserSurvey
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int ResponsesCount { get; set; }
}