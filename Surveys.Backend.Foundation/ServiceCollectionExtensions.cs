using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Surveys.Backend.DataAccess;
using Surveys.Backend.DomainModel;
using Surveys.Backend.Foundation.Common.ErrorProviders;
using Surveys.Backend.Foundation.Security;
using Surveys.Backend.Repositories;

namespace Surveys.Backend.Foundation;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFoundation(this IServiceCollection serviceCollection)
    {

        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());

        serviceCollection.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

        serviceCollection.AddRepositories();

        serviceCollection.AddErrorProviders();

        serviceCollection.AddScoped<IJwtService, JwtService>();

        return serviceCollection;
    }
}