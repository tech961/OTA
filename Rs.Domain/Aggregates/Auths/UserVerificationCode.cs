namespace Rs.Domain.Aggregates.Auths;

public class UserVerificationCode : BaseEntity
{
    protected UserVerificationCode()
    {
    }

    private UserVerificationCode(
        string code,
        string userName,
        DateTime expirationTime)
    {
        Code = code;
        UserName = userName;
        ExpirationTime = expirationTime;
    }

    public string Code { get; private set; }

    public string UserName { get; private set; }

    public DateTime ExpirationTime { get; private set; }

    public static UserVerificationCode AddCode(
        string code,
        string userName,
        TimeSpan expirationTime)
    {
        var exp = DateTime.UtcNow.Add(expirationTime);
        var model = new UserVerificationCode(code, userName, exp);

        return model;
    }
}
