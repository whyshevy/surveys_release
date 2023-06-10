namespace Surveys.Backend.Configurations;

public class JwtConfiguration
{
    public const int ExpireDaysLimit = 7;


    public string Secret { get; set; } = string.Empty;
}