using Rs.Domain.Shared.Enums.Pet;

namespace Rs.Domain.Aggregates.Pets;

public class Pet: BaseAuditableEntity
{
    private static readonly List<VaccinationRecord> _vaccinations = [];
    private static readonly List<MedicalRecord> _medicalHistory = [];
    private static readonly List<ActivityRecord> _activities = [];

    public Pet()
    {
        
    }
    
    public Pet(Guid id,
        string name,
        string photoUrl,
        int? birthYear,
        Species species,
        string breed,
        Gender gender,
        LivingSituation livingSituation,
        double? weightKg,
        string city,
        Guid ownerId, 
        User owner, 
        bool isArchived)
    {
        Id = id;
        Name = name;
        PhotoUrl = photoUrl;
        BirthYear = birthYear;
        Species = species;
        Breed = breed;
        Gender = gender;
        LivingSituation = livingSituation;
        WeightKg = weightKg;
        City = city;
        OwnerId = ownerId;
        Owner = owner;
        IsArchived = isArchived;
    }

    public new Guid Id { get; set; } 

    public string Name { get; set; }          
    public string PhotoUrl { get; set; }      
    public int? BirthYear { get; set; }
    public Species Species { get; set; } 
    public string Breed { get; set; }        
    public Gender Gender { get; set; }

    public LivingSituation LivingSituation { get; set; }
    
    public double? WeightKg { get; set; }   
    public string HealthStatus { get; set; }  
    public string VaccinationStatus { get; set; } 
    
    public string Country { get; set; }
    public string City { get; set; }
    
    public Guid OwnerId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public bool IsArchived { get; set; } = false;
    
    public IReadOnlyCollection<VaccinationRecord> Vaccinations = _vaccinations;
    public IReadOnlyCollection<MedicalRecord> MedicalHistory = _medicalHistory;
    public IReadOnlyCollection<ActivityRecord> Activities = _activities;
    public User Owner { get; set; }
}