namespace CodeDemoSolution.DataAccess.Interfaces.UnitOfWork
{
    using Repositories;
    using Repositories.Base;
    using Model;

    public interface ITodoUnitOfWork
    {
        ITodoItemRepository TodoItemRepository { get; }

        IReadWriteRepository<TodoList> TodoListRepository { get; }

        void Save();
    }
}
