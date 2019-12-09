using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShowFieldByUser.Models;
using Microsoft.AspNetCore.Identity;

namespace ShowFieldByUser.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemAsync(IdentityUser user);
        Task<bool> AddItemAsync(TodoItem newItem, IdentityUser user);
        Task<bool> MarkDoneAsync(Guid id, IdentityUser user);
    }
}
