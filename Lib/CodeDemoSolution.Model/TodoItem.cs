﻿namespace CodeDemoSolution.Model
{
    using Base;
    using System;

    public class TodoItem : IDataModelBase
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int TodoListId { get; set; }
        public virtual TodoList TodoList { get; set; }
    }
}
