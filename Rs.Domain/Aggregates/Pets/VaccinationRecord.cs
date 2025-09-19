namespace Rs.Domain.Aggregates.Pets;

public class VaccinationRecord
{
    public VaccinationRecord()
    {
        
    }
    public Guid Id { get; set; }
    public Guid PetId { get; set; }
    public string VaccineName { get; set; }
    public DateTime Date { get; set; }
    public DateTime? NextDueDate { get; set; }
    public string Notes { get; set; }
    public Pet Pet { get; set; }
}