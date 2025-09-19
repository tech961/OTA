namespace Rs.Domain.Repositories;

public interface IUserRepository
{
    Task<Result<User?>> GetUserByIdAsync(Guid userId);

    Task<Result<string>> GetUserNameAsync(Guid userId);

    Task<Result<User?>> GetUserByNameAsync(string userName);

    Task<Result<User>> CreateUserAsync(string userName);

    Task<Result<bool>> DeleteUserAsync(string userId);
    Task<Result<bool>> DeleteUserAsync(User user);

    void UpdateProfilePic(User user, Guid fileId);
}