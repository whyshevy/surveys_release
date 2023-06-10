namespace Surveys.Backend.DomainModel;

public class Questionnaire : IEntity<Guid>
{
    public const int TitleMaxLength = 500;
    public const int DescriptionMaxLength = 5000;


    public Guid Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public bool RegisteredOnly { get; set; }

    public Guid? CreatedById { get; set; }

    public User? CreatedBy { get; set; }

    public Guid? UpdatedById { get; set; }

    public User? UpdatedBy { get; set; } 

    public ICollection<Question> Questions { get; set; }


    public Questionnaire()
    {
        Questions = new List<Question>();
    }
}