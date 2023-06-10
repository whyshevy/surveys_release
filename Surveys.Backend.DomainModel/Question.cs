namespace Surveys.Backend.DomainModel;

public class Question : IEntity<Guid>
{
    public const int TitleMaxLength = 500;
    public const int DescriptionMaxLength = 5000;


    public Guid Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int Order { get; set; }

    public bool IsRequired { get; set; }

    public Guid QuestionnaireId { get; set; }

    public Questionnaire? Questionnaire { get; set; }

    public QuestionType Type { get; set; }

    public ICollection<Option> Options { get; set; }


    public Question()
    {
        Options = new List<Option>();
    }
}