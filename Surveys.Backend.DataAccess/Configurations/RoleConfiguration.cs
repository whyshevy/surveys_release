using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Surveys.Backend.DataAccess.Configurations.Interfaces;
using Surveys.Backend.DomainModel;

namespace Surveys.Backend.DataAccess.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>, ISeedableConfiguration<Role>
{
    public static Guid AdminId = Guid.Parse("3e4ba5e7-073e-4805-bb2d-e14986a97a0a");
    public static Guid UserId = Guid.Parse("f38d3fa7-4ebd-4759-8532-d0cfdc818ae8");


    public void Configure(EntityTypeBuilder<Role> builder)
    {
        Seed(builder);
    }

    public void Seed(EntityTypeBuilder<Role> builder)
    {
        CreateAdminRole(builder);
        CreateUserRole(builder);
    }

    private static void CreateAdminRole(EntityTypeBuilder<Role> builder)
    {
        const string name = "Admin";

        var admin = new Role
        {
            Id = AdminId,
            Name = name,
            NormalizedName = name.ToUpperInvariant()
        };

        builder.HasData(admin);
    }

    private static void CreateUserRole(EntityTypeBuilder<Role> builder)
    {
        const string name = "User";

        var user = new Role
        {
            Id = UserId,
            Name = name,
            NormalizedName = name.ToUpperInvariant()
        };

        builder.HasData(user);
    }
}