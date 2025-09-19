namespace Rs.Application.Features.Pets.CommandHandlers.DeletePet;

public sealed record DeletePetCommand(Guid Id) : ICommand<DeletePetResponse>;
