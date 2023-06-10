namespace Surveys.Backend.DomainModel;

public class Option : IEntity<Guid>
{
    public const int ContentMaxLength = 500;


    public Guid Id { get; set; }

    public string? Content { get; set; }

    public int Order { get; set; }

    public Guid QuestionId { get; set; }

    public Question? Question { get; set; }
}