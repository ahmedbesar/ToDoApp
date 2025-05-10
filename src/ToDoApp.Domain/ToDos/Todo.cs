using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ToDoApp.ToDos
{
    public class Todo : AuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public TodoStatus? Status { get; set; }
        public TodoPriority? Priority { get; set; }
        public DateTime? DueDate { get; set; }

        protected Todo() { }

        public Todo(Guid id, string title, string? description, TodoStatus? status, TodoPriority? priority, DateTime? dueDate)
            : base(id)
        {
            SetTitle(title);
            Description = description;
            Status = status;
            Priority = priority;
            DueDate = dueDate;
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title is required.");
            if (title.Length > 100)
                throw new ArgumentException("Title cannot exceed 100 characters.");
            Title = title;
        }

        public void MarkAsComplete()
        {
            Status = TodoStatus.Completed;
        }
    }

}
