namespace Rs.Tests.Application.ToDos.Commands;

public class CreateToDoItemCommandHandlerTests
{
    private readonly IMapper _mapper;

    public CreateToDoItemCommandHandlerTests()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile<ToDoItemProfile>());
        _mapper = configuration.CreateMapper();
    }

    [Fact]
    public async Task Handle_ShouldCreateToDoItem_WhenRequestIsValid()
    {
        // Arrange
        var repositoryMock = new Mock<IToDoItemRepository>();
        repositoryMock
            .Setup(repository => repository.AddAsync(It.IsAny<ToDoItem>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask)
            .Verifiable();

        var handler = new CreateToDoItemCommandHandler(repositoryMock.Object, _mapper);
        var command = new CreateToDoItemCommand("Write tests", "Cover core features", ToDoStatus.Pending);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Title.Should().Be(command.Title);
        result.Value.Status.Should().Be(ToDoStatus.Pending);
        repositoryMock.Verify();
    }
}
