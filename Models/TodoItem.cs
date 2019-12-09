using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowFieldByUser.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public bool IsDone { get; set; }
        public string Title { get; set; }
        public DateTimeOffset? DueAt { get; set; }
        public string UserId { get; set; }
    }
}
