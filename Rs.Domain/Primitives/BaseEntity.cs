using System.ComponentModel.DataAnnotations.Schema;

namespace Rs.Domain.Primitives;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
}
