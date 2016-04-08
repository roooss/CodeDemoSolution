namespace CodeDemoSolution.DataAccess.Context
{
    using Interfaces.Context;
    using Model;
    using ContextConfig;
    using System.Data.Entity;

    public class TodoDbContext : DbContext, ITodoDbContext
    {
        public IDbSet<TodoItem> TodoItems { get; set; }

        public DbContext Context
        {
            get
            {
                return this;
            }
        }

        public TodoDbContext ()
            : base ("TodoContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            FluentApiConfiguration.ApplyConfiguration(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
