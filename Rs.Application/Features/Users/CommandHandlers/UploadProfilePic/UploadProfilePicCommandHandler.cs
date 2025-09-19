using Rs.Application.Common.Models;
using Rs.Domain.Aggregates.Files;
using Rs.Domain.Events.FileManagers;
using Rs.Domain.Repositories;

namespace Rs.Application.Features.Users.CommandHandlers.UploadProfilePic;

public class UploadProfilePicCommandHandler(
    IFileService fileService,
    FileUploadSettings fileUploadSettings,
    IUnitOfWork unitOfWork,
    IUserRepository userRepository,
    IFileManagerRepository fileManagerRepository,
    IUser user,
    IMapper mapper)
    : ICommandHandler<UploadProfilePicCommand, UploadProfilePicResponse>
{
    public async Task<Result<UploadProfilePicResponse>> Handle(
        UploadProfilePicCommand request,
        CancellationToken cancellationToken)
    {
        var uploadFileResponse = await fileService.UploadFileAsync(
            request.File,
            fileUploadSettings.WriteTo);

        if (uploadFileResponse.IsFailure)
        {
            return Result.Failure<UploadProfilePicResponse>(uploadFileResponse.Error);
        }

        var file = AddFile(uploadFileResponse.Value);

        var updateUserResponse = await UpdateUser(file.Id);
        if (updateUserResponse.IsFailure)
        {
            return Result.Failure<UploadProfilePicResponse>(updateUserResponse.Error);
        }
        
        file.AddDomainEvent(new DeleteCurrentProfilePicEvent(updateUserResponse.Value.CurrentProfilePicId));
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return mapper.Map<UploadProfilePicResponse>(updateUserResponse.Value.User);
    }

    private FileManager AddFile(FileUploadResult uploadResult)
    {
        var file = FileManager.AddFile(uploadResult.Name,
            uploadResult.ContentType,
            uploadResult.PhysicalPath);

        fileManagerRepository.Add(file);
        return file;
    }

    private async Task<Result<UpdateUserResult>> UpdateUser(Guid fileId)
    {
        var userModel = await userRepository.GetUserByIdAsync(user.Id!.Value);
        if (userModel.IsFailure || userModel.Value == null)
        {
            return Result.Failure<UpdateUserResult>(userModel.Error);
        }

        var currentProfilePicId = userModel.Value.ProfilePicId;
        userRepository.UpdateProfilePic(userModel.Value, fileId);

        return new UpdateUserResult(userModel.Value, currentProfilePicId);
    }
}