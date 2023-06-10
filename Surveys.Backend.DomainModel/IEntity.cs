namespace Surveys.Backend.DomainModel;

public interface IEntity<TKey>
{
    TKey Id { get; set; }
}