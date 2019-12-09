using Microsoft.EntityFrameworkCore;
using ShowFieldByUser.Data;
using ShowFieldByUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ShowFieldByUser.Services
{
    public class TodoItemService:ITodoItemService
    {
        private readonly ApplicationDbContext _context;

        public TodoItemService(ApplicationDbContext context)
        {
            this._context = context;

        }
         public  async Task<TodoItem[]> GetIncompleteItemAsync(IdentityUser user)
        {
            return await _context.Items.Where(x => x.IsDone == false && x.UserId == user.Id).ToArrayAsync();
        }

        public async Task<bool> AddItemAsync(TodoItem newItem, IdentityUser user)
        {
            newItem.Id = new Guid();
            newItem.IsDone = false;
            newItem.DueAt = DateTimeOffset.Now.AddDays(3);
            newItem.UserId = user.Id; 

            _context.Items.Add(newItem);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;

        }

        public async Task<bool> MarkDoneAsync(Guid id, IdentityUser user)
        {
            var item = await _context.Items
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
            if (item == null) return false;
            item.IsDone = true;
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1; // One entity should have been updated
        }
    }
}
