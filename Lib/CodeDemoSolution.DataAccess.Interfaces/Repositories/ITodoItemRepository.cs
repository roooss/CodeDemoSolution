namespace CodeDemoSolution.DataAccess.Interfaces.Repositories
{
    using Base;
    using Model;
    using System.Linq;

    public interface ITodoItemRepository : IReadWriteRepository<TodoItem>
    {
        IQueryable<TodoItem> Search(string title, string message);
    }
}
