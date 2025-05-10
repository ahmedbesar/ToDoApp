using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ToDoApp.ToDos
{
    public class TodoDto : AuditedEntityDto<Guid>
    {
        [Required]
        [MinLength(100)]
        public string Title { get; set; }
        public string? Description { get; set; }
        public TodoStatus? Status { get; set; }
        public TodoPriority? Priority { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
