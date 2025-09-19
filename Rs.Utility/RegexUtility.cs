using static System.Text.RegularExpressions.Regex;

namespace Rs.Utility;

public static class RegexUtility
{
    public static bool IsValidPhoneNumber(string phoneNumber)
    {
        return IsMatch(phoneNumber, @"^09\d{9}$");
    }

    public static bool IsValidEmail(string email)
    {
        return IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }
}