using Rs.Api.Contracts.ToDoItems.Requests;
using Rs.Api.Contracts.ToDoItems.Responses;
using Rs.Application.ToDos.Commands.CreateToDoItem;
using Rs.Application.ToDos.Commands.UpdateToDoItem;
using Rs.Application.ToDos.Models;

namespace Rs.Api.Contracts.ToDoItems;

public class ToDoItemApiProfile : Profile
{
    public ToDoItemApiProfile()
    {
        CreateMap<CreateToDoItemRequest, CreateToDoItemCommand>();
        CreateMap<UpdateToDoItemRequest, UpdateToDoItemCommand>();
        CreateMap<ToDoItemDto, ToDoItemResponse>();
    }
}
