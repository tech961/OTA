namespace Rs.Application.Features.Pets.CommandHandlers.DeletePet;

public class DeletePetCommandHandler(IDataContext context, ILogger<DeletePetCommandHandler> logger)
    : ICommandHandler<DeletePetCommand, DeletePetResponse>
{
    public async Task<Result<DeletePetResponse>> Handle(DeletePetCommand request, CancellationToken cancellationToken)
    {
        var pet = await context.Pets.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (pet == null)
        {
            return Result.Failure<DeletePetResponse>(PetErrors.NotFound);
        }

        context.Pets.Remove(pet);
        await context.SaveChangesAsync(cancellationToken);

        return new DeletePetResponse(true);
    }
}
