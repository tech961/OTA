using Microsoft.AspNetCore.Http;

namespace Rs.Utility;

public static class ValidatorUtility
{
    public static bool BeAValidPhoneNumberOrEmail(string userName)
    {
        return 
            RegexUtility.IsValidPhoneNumber(userName) || 
            RegexUtility.IsValidEmail(userName);
    }
    
    public static bool BeAnExcelFile(IFormFile? file)
    {
        if (file == null)
            return false;

        var extension = Path.GetExtension(file.FileName);
        return extension.Equals(".xlsx", StringComparison.OrdinalIgnoreCase);
    }
}

