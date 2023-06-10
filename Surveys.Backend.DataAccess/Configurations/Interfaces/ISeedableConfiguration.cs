using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Surveys.Backend.DataAccess.Configurations.Interfaces;

public interface ISeedableConfiguration<T> where T : class
{
    void Seed(EntityTypeBuilder<T> builder);
}