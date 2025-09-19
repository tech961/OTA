namespace Rs.Domain.Aggregates.Pets;

public class MedicalRecord
{
    public MedicalRecord()
    {
        
    }
    public Guid Id { get; set; }
    public Guid PetId { get; set; }
    public string Condition { get; set; }
    public string Treatment { get; set; }
    public DateTime Date { get; set; }
    public string Notes { get; set; }
    public Pet Pet { get; set; }
}