namespace Surveys.Backend.Common.Extensions;

public static class EnumerableExtensions
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? source)
    {
        return source is null || !source.Any();
    }

    public static bool IsEmpty<T>(this IEnumerable<T> source)
        => !source.Any();
}