namespace CodeDemoSolution.DataAccess.Repositories
{
    using Base;
    using Interfaces.Context;
    using Interfaces.Repositories;
    using Model;
    using System.Linq;

    public class TodoItemRepository : ReadWriteRepository<TodoItem>, ITodoItemRepository
    {
        public TodoItemRepository(ITodoDbContext context)
            : base (context)
        {
        }

        public IQueryable<TodoItem> Search(string title, string message)
        {
            IQueryable<TodoItem> returnObject = _databaseContext.TodoItems;

            if (!string.IsNullOrEmpty(title))
            {
                returnObject = returnObject.Where(x => x.Title.StartsWith(title));
            }

            if (!string.IsNullOrEmpty(message))
            {
                returnObject = returnObject.Where(x => x.Title.StartsWith(message));
            }

            return returnObject;
        }
    }
}
