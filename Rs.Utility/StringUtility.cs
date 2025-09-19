namespace Rs.Utility;

public static class StringUtility
{
    public static string? GetFullName(string? firstName, string? lastName)
    {
        return string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName)
            ? null
            : $"{firstName} {lastName}";
    }
}