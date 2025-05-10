using System;
using System.Threading.Tasks;
using ToDoApp.ToDos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ToDoApp.Application.Contracts
{
    public interface ITodoAppService : IApplicationService
    {
        Task<TodoDto>CreateAsync(CreateUpdateTodoDto input);
        Task<TodoDto> UpdateAsync(Guid id, CreateUpdateTodoDto input);
        Task<bool> DeleteAsync(Guid id);
        Task<TodoDto> GetAsync(Guid id);
        Task<PagedResultDto<TodoDto>> GetListAsync(TodoGetListDto input);
        Task<bool> MarkAsCompleteAsync(Guid id);
    }
}