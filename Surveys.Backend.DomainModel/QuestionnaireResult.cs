namespace Surveys.Backend.DomainModel;

public class QuestionnaireResult : IEntity<Guid>
{
    public Guid Id { get; set; }

    public Guid QuestionnaireId { get; set; }

    public Guid? PassedById { get; set; }

    public User? PassedBy { get; set; }

    public ICollection<Answer> Answers { get; set; }

    public QuestionnaireResult()
    {
        Answers = new List<Answer>();
    }
}