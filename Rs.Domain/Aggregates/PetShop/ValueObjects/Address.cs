namespace Rs.Domain.Aggregates.PetShop.ValueObjects;

public class Address : ValueObject
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Phone { get; private set; }
    public string Country { get; private set; }
    public string City { get; private set; }
    public string Line1 { get; private set; }
    public string? Line2 { get; private set; }
    public string PostalCode { get; private set; }

    private Address()
    {
    }

    public Address(string firstName, string lastName, string phone, string country,
        string city, string line1, string? line2, string postalCode)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Country = country;
        City = city;
        Line1 = line1;
        Line2 = line2;
        PostalCode = postalCode;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
        yield return Phone;
        yield return Country;
        yield return City;
        yield return Line1;
        yield return Line2 ?? string.Empty;
        yield return PostalCode;
    }
}
