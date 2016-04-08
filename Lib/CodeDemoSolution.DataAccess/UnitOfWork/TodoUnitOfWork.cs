namespace CodeDemoSolution.DataAccess.UnitOfWork
{
    using System;
    using Interfaces.Context;
    using Interfaces.Repositories;
    using Interfaces.Repositories.Base;
    using Interfaces.UnitOfWork;
    using Model;
    using Repositories;
    using Repositories.Base;

    public class TodoUnitOfWork : ITodoUnitOfWork
    {
        private ITodoDbContext _context { get; set; }

        public ITodoItemRepository TodoItemRepository { get { return new TodoItemRepository(_context); } } 

        public IReadWriteRepository<TodoList> TodoListRepository { get { return new ReadWriteRepository<TodoList>(_context); } }

        public TodoUnitOfWork(ITodoDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            this._context.Context.SaveChanges();
        }
    }
}
