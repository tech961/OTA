namespace Rs.Tests.Api.Controllers;

public class ToDoItemsControllerTests
{
    private readonly IMapper _mapper;

    public ToDoItemsControllerTests()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ToDoItemProfile>();
            cfg.AddProfile<ToDoItemApiProfile>();
        });

        _mapper = configuration.CreateMapper();
    }

    [Fact]
    public async Task GetById_ShouldReturnOk_WhenItemExists()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var dto = new ToDoItemDto(Guid.NewGuid(), "Read", "Read docs", ToDoStatus.Pending);

        mediatorMock
            .Setup(mediator => mediator.Send(It.IsAny<GetToDoItemByIdQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result.Success(dto));

        var controller = new ToDoItemsController(mediatorMock.Object, _mapper)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            }
        };

        // Act
        var result = await controller.GetById(dto.Id, CancellationToken.None);

        // Assert
        var okResult = result.Result as OkObjectResult;
        okResult.Should().NotBeNull();
        var response = okResult!.Value as ToDoItemResponse;
        response.Should().NotBeNull();
        response!.Id.Should().Be(dto.Id);
    }

    [Fact]
    public async Task GetById_ShouldReturnNotFound_WhenItemIsMissing()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var id = Guid.NewGuid();
        mediatorMock
            .Setup(mediator => mediator.Send(It.IsAny<GetToDoItemByIdQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result.Failure<ToDoItemDto>(ToDoErrors.NotFound(id)));

        var controller = new ToDoItemsController(mediatorMock.Object, _mapper)
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            }
        };

        // Act
        var result = await controller.GetById(id, CancellationToken.None);

        // Assert
        var objectResult = result.Result as ObjectResult;
        objectResult.Should().NotBeNull();
        objectResult!.StatusCode.Should().Be(StatusCodes.Status404NotFound);
    }
}
