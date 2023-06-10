using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Surveys.Backend.Configurations;
using Surveys.Backend.DataAccess;
using Surveys.Backend.Foundation;
using Surveys.Backend.Foundation.Security;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString(ConnectionStringsConfiguration.DefaultName);

// At this point we must have JwtConfiguration:Secret in user-secrets
var jwtConfiguration = new JwtConfiguration();
builder.Configuration
    .GetSection(nameof(JwtConfiguration))
    .Bind(jwtConfiguration);

builder.Services.AddSingleton(jwtConfiguration);

builder.Services.AddDatabase(connectionString);

var corsConfiguration = new CorsConfiguration();
builder.Configuration.GetSection(CorsConfiguration.Name)
    .Bind(corsConfiguration);

builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsConfiguration.Name, configurePolicyBuilder =>
    {
        configurePolicyBuilder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
});

builder.Services.AddFoundation();

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
    });

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = JwtService.CreateSymmetricSecurityKey(jwtConfiguration.Secret),
            ValidateIssuer = false,
            RequireExpirationTime = false,
            ValidateLifetime = true
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header",
        Type = SecuritySchemeType.Http,
        Name = "Authentication"
    });
    
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(CorsConfiguration.Name);

app.MapControllers();

app.Run();