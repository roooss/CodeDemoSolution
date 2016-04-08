namespace CodeDemoSolution.Model
{
    using Base;
    using System;
    using System.Collections.Generic;

    public class TodoList : IDataModelBase
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public virtual IList<TodoItem> TodoItems { get; set; }
    }
}
