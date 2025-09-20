namespace Rs.Tests.Domain.ToDos;

public class ToDoItemDomainServiceTests
{
    private readonly ToDoItemDomainService _service = new();

    [Theory]
    [InlineData(ToDoStatus.Pending, ToDoStatus.InProgress)]
    [InlineData(ToDoStatus.Pending, ToDoStatus.Completed)]
    [InlineData(ToDoStatus.InProgress, ToDoStatus.Completed)]
    public void ValidateStatusTransition_ShouldReturnSuccess_ForAllowedTransitions(ToDoStatus current, ToDoStatus next)
    {
        // Act
        var result = _service.ValidateStatusTransition(current, next);

        // Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Theory]
    [InlineData(ToDoStatus.Completed, ToDoStatus.Pending)]
    [InlineData(ToDoStatus.Completed, ToDoStatus.InProgress)]
    [InlineData(ToDoStatus.InProgress, ToDoStatus.Pending)]
    public void ValidateStatusTransition_ShouldReturnFailure_ForInvalidTransitions(ToDoStatus current, ToDoStatus next)
    {
        // Act
        var result = _service.ValidateStatusTransition(current, next);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ToDoErrors.InvalidStatusTransition(current, next));
    }
}
