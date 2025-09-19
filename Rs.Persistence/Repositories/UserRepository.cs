using Microsoft.AspNetCore.Identity;
using Rs.Domain.Aggregates.Auths;
using Rs.Domain.DomainErrors.Users;
using Rs.Domain.Repositories;
using Rs.Domain.Shared;
using Rs.Persistence.DbPersistence;

namespace Rs.Persistence.Repositories;

public class UserRepository(
    UserManager<User> userManager,
    DataContext context) : IUserRepository
{
    public async Task<Result<User?>> GetUserByIdAsync(Guid userId)
    {
        var user = await userManager.FindByIdAsync(userId.ToString());
        return user ?? Result.Failure<User?>(UserErrors.UserNotFound);
    }

    public async Task<Result<string>> GetUserNameAsync(Guid userId)
    {
        var user = await userManager.FindByIdAsync(userId.ToString());
        return user == null ? Result.Failure<string>(UserErrors.UserNotFound) : user?.UserName;
    }

    public async Task<Result<User?>> GetUserByNameAsync(string userName)
    {
        var user = await userManager.FindByNameAsync(userName);

        return user ?? Result.Failure<User?>(UserErrors.UserNotFound);
    }

    public async Task<Result<User>> CreateUserAsync(string userName)
    {
        var user = new User
        {
            UserName = userName,
            PhoneNumber = userName,
        };
        var result = await userManager.CreateAsync(user);

        if (result.Errors.Any())
        {
            return Result.Failure<User>(new Error(
                HttpErrorCode.BadRequest,
                "User.CreateUser",
                string.Join(", ", result.Errors)));
        }

        return user;
    }

    public async Task<Result<bool>> DeleteUserAsync(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);

        return user == null ?
            Result.Failure<bool>(UserErrors.UserNotFound) :
            await DeleteUserAsync(user);
    }

    public async Task<Result<bool>> DeleteUserAsync(User user)
    {
        var result = await userManager.DeleteAsync(user);

        if (result.Errors.Any())
        {
            return Result.Failure<bool>(new Error(
                HttpErrorCode.BadRequest,
                "User.DeleteUser",
                string.Join(", ", result.Errors)));
        }

        return result.Succeeded;
    }

    public void UpdateProfilePic(User user, Guid fileId)
    {
        user.UpdateProfilePic(fileId);
        context.Set<User>().Update(user);
    }
}