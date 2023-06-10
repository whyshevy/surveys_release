using Microsoft.EntityFrameworkCore;
using Surveys.Backend.DomainModel;

namespace Surveys.Backend.DataAccess;

public class ApplicationDbContext : DbContext
{
    public DbSet<User>? Users { get; set; }

    public DbSet<Role>? Roles { get; set; }

    public DbSet<Questionnaire>? Questionnaires { get; set; }

    public DbSet<Question>? Questions { get; set; }

    public DbSet<Option>? Options { get; set; }

    public DbSet<Answer>? Answers { get; set; }

    public DbSet<QuestionnaireResult>? QuestionnaireResults { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}