using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ToDoApp.ToDos
{
    public class TodoGetListDto : PagedAndSortedResultRequestDto
    {
        public TodoStatus? Status { get; set; }
    }
}
