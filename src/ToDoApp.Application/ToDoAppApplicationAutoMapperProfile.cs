using AutoMapper;
using ToDoApp.ToDos;

namespace ToDoApp;

public class ToDoAppApplicationAutoMapperProfile : Profile
{
    public ToDoAppApplicationAutoMapperProfile()
    {
        CreateMap<Todo, TodoDto>();
        CreateMap<CreateUpdateTodoDto, Todo>();
    }
}
