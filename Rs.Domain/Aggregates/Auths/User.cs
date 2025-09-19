using Microsoft.AspNetCore.Identity;
using Rs.Domain.Aggregates.Pets;

namespace Rs.Domain.Aggregates.Auths;

public class User : IdentityUser<Guid>
{
    private List<Pet> _pets = [];
    
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }

    public Guid? ProfilePicId { get; private set; }

    public IReadOnlyCollection<Pet> Pets => _pets;
    
    public void UpdateUser(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public void UpdateProfilePic(Guid profilePicId)
    {
        ProfilePicId = profilePicId;
    }
}