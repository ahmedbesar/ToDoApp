using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Application.Contracts;
using ToDoApp.ToDos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TodoApp.Application
{
    public class TodoAppService : ApplicationService, ITodoAppService
    {
        private readonly IRepository<Todo, Guid> _todoRepository;

        public TodoAppService(IRepository<Todo, Guid> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<TodoDto> CreateAsync(CreateUpdateTodoDto input)
        {

            try
            {
                var todo = new Todo(
                GuidGenerator.Create(),
                input.Title,
                input.Description,
                input.Status,
                input.Priority,
                input.DueDate
            );

                await _todoRepository.InsertAsync(todo);
                return ObjectMapper.Map<Todo, TodoDto>(todo);
            }
            catch (Exception)
            {
                throw;
            }



        }

        public async Task<TodoDto> UpdateAsync(Guid id, CreateUpdateTodoDto input)
        {

            try
            {
                var todo = await _todoRepository.GetAsync(id);
                todo.SetTitle(input.Title);
                todo.Description = input.Description;
                todo.Status = input.Status;
                todo.Priority = input.Priority;
                todo.DueDate = input.DueDate;

                await _todoRepository.UpdateAsync(todo);
                return ObjectMapper.Map<Todo, TodoDto>(todo);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                await _todoRepository.DeleteAsync(id);
                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<TodoDto> GetAsync(Guid id)
        {
            try
            {
                var todo = await _todoRepository.GetAsync(id);
                return ObjectMapper.Map<Todo, TodoDto>(todo);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<PagedResultDto<TodoDto>> GetListAsync(TodoGetListDto input)
        {
            try
            {
                var query = await _todoRepository.GetQueryableAsync();

                if (input.Status.HasValue)
                {
                    query = query.Where(t => t.Status == input.Status.Value);
                }

                var totalCount = await AsyncExecuter.CountAsync(query);

                var items = await AsyncExecuter.ToListAsync(
                    query.OrderByDescending(t => t.CreationTime)
                         .Skip(input.SkipCount)
                         .Take(input.MaxResultCount)
                );

                return new PagedResultDto<TodoDto>(
                    totalCount,
                    ObjectMapper.Map<List<Todo>, List<TodoDto>>(items)
                );
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<bool> MarkAsCompleteAsync(Guid id)
        {
            try
            {
                var todo = await _todoRepository.GetAsync(id);
                todo.MarkAsComplete();
                await _todoRepository.UpdateAsync(todo);
                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
