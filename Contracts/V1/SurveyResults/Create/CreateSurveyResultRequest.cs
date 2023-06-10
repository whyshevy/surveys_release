namespace Surveys.Backend.WebApp.Contracts.V1.SurveyResults.Create;

public class CreateSurveyResultRequest
{
    public Guid? PassedById { get; set; }

    public IReadOnlyCollection<CreateSurveyResultAnswer> Answers { get; set; }


    public CreateSurveyResultRequest()
    {
        Answers = new List<CreateSurveyResultAnswer>();
    }
}