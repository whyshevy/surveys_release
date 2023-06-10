namespace Surveys.Backend.DomainModel;

public class Answer : IEntity<Guid>
{
    public const int TextMaxLength = 5000;


    public Guid Id { get; set; }

    public Guid QuestionId { get; set; }

    public Question? Question { get; set; }

    public string? SelectedOptionsIds { get; set; }

    public int? Rating { get; set; }

    public string? Text { get; set; }
}