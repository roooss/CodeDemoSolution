namespace CodeDemoSolution.DataAccess.ContextConfig
{
    using CodeDemoSolution.Model;
    using System.Data.Entity;

    public static class FluentApiConfiguration
    {
        public static void ApplyConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoList>().HasKey(t => t.Id);
            modelBuilder.Entity<TodoList>().Property(t => t.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<TodoList>().Property(t => t.Title).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<TodoList>().Property(t => t.Description).HasMaxLength(300).IsRequired();

            modelBuilder.Entity<TodoItem>().HasKey(t => t.Id);
            modelBuilder.Entity<TodoItem>().Property(t => t.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<TodoItem>().Property(t => t.Title).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<TodoItem>().Property(t => t.Body).IsMaxLength().IsRequired();

            modelBuilder.Entity<TodoItem>().HasRequired(c => c.TodoList).WithMany(d => d.TodoItems).HasForeignKey(c => c.TodoListId);
        }
    }
}
