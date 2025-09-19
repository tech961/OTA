namespace Rs.Application.Features.Pets;

public static class PetErrors
{
    public static readonly Error NotFound = new(
        HttpErrorCode.NotFound,
        "Pet.NotFound",
        "Pet not found.");
}
