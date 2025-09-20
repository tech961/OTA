namespace Rs.Application.ToDos;

public class ToDoItemProfile : Profile
{
    public ToDoItemProfile()
    {
        CreateMap<ToDoItem, ToDoItemDto>();
    }
}
