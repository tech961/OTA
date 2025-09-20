namespace Rs.Tests.Application.ToDos.Commands;

public class UpdateToDoItemCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly IToDoItemDomainService _domainService = new ToDoItemDomainService();

    public UpdateToDoItemCommandHandlerTests()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile<ToDoItemProfile>());
        _mapper = configuration.CreateMapper();
    }

    [Fact]
    public async Task Handle_ShouldReturnFailure_WhenTransitionIsInvalid()
    {
        // Arrange
        var repositoryMock = new Mock<IToDoItemRepository>();
        var existing = ToDoItem.Create("Write docs", null, ToDoStatus.Completed);
        repositoryMock
            .Setup(repository => repository.GetByIdAsync(existing.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existing);

        var handler = new UpdateToDoItemCommandHandler(repositoryMock.Object, _domainService, _mapper);
        var command = new UpdateToDoItemCommand(existing.Id, "Write docs", null, ToDoStatus.Pending);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(ToDoErrors.InvalidStatusTransition(ToDoStatus.Completed, ToDoStatus.Pending));
        repositoryMock.Verify(repository => repository.Update(It.IsAny<ToDoItem>()), Times.Never);
    }
}
