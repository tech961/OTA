namespace Rs.Domain.Primitives;

public interface ICreateDate<TCreatorId>
{
    DateTime CreateDate { get; }
}

public interface ICreateDate
{
    DateTime CreateDate { get; }
}
