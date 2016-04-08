namespace CodeDemoSolution.DataAccess.Interfaces.Context
{
    using Model;
    using System.Data.Entity;

    public interface ITodoDbContext
    {
        DbContext Context { get; }
        IDbSet<TodoItem> TodoItems{ get; }
    }
}
