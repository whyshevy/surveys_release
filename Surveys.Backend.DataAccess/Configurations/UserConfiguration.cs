using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Surveys.Backend.DataAccess.Configurations.Interfaces;
using Surveys.Backend.DomainModel;

namespace Surveys.Backend.DataAccess.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>, ISeedableConfiguration<User>
{
    public static Guid AdminId = Guid.Parse("670c28b5-0731-4334-866b-0fb107bf7a31");


    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Ignore(u => u.EmailConfirmed);
        builder.Ignore(u => u.PhoneNumber);
        builder.Ignore(u => u.PhoneNumberConfirmed);
        builder.Ignore(u => u.TwoFactorEnabled);
        builder.Ignore(u => u.LockoutEnabled);
        builder.Ignore(u => u.LockoutEnd);
        builder.Ignore(u => u.AccessFailedCount);
        builder.Ignore(u => u.LockoutEnabled);

        builder.Property(u => u.Id)
            .IsRequired();
        
        Seed(builder);
    }

    public void Seed(EntityTypeBuilder<User> builder)
    {
       CreateAdmin(builder);
    }


    private static void CreateAdmin(EntityTypeBuilder<User> builder)
    {
        const string email = "admin@admin.com";
        const string name = "Admin name";
        const string password = "admin";

        var admin = new User
        {
            Id = AdminId,
            Email = email,
            Name = name,
        };

        admin.PasswordHash = GeneratePasswordHash(admin, password);

        builder.HasData(admin);
    }

    private static string GeneratePasswordHash(User user, string password)
    {
        var hasher = new PasswordHasher<User>();

        return hasher.HashPassword(user, password);
    }
}