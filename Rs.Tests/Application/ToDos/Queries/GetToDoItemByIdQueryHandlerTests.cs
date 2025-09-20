namespace Rs.Tests.Application.ToDos.Queries;

public class GetToDoItemByIdQueryHandlerTests
{
    private readonly IMapper _mapper;

    public GetToDoItemByIdQueryHandlerTests()
    {
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile<ToDoItemProfile>());
        _mapper = configuration.CreateMapper();
    }

    [Fact]
    public async Task Handle_ShouldReturnItem_WhenItExists()
    {
        // Arrange
        var repositoryMock = new Mock<IToDoItemRepository>();
        var existing = ToDoItem.Create("Plan", "Plan sprint", ToDoStatus.InProgress);

        repositoryMock
            .Setup(repository => repository.GetByIdAsync(existing.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(existing);

        var handler = new GetToDoItemByIdQueryHandler(repositoryMock.Object, _mapper);
        var query = new GetToDoItemByIdQuery(existing.Id);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Id.Should().Be(existing.Id);
        result.Value.Title.Should().Be(existing.Title);
    }
}
