namespace Surveys.Backend.Foundation.UserSurveys.CreateSurvey.Errors;

public enum CreateSurveyError
{
    TitleRequired,
    TitleTooLong,
    DescriptionTooLong,
    Unknown
}