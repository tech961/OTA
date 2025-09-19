namespace Rs.Domain.Primitives;

public interface IModifiedDate<TModifierId>
    where TModifierId : struct
{
    DateTime? ModifyDate { get; }
}

public interface IModifiedDate
{
    DateTime? ModifyDate { get; }
}
