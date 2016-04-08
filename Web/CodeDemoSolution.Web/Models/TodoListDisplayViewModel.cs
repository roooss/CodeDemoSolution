using CodeDemoSolution.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeDemoSolution.Web.Models
{
    public class TodoListDisplayViewModel
    {
        public List<TodoList> TodoLists{ get; set; }

        public TodoListDisplayViewModel()
        {
            TodoLists = new List<TodoList>();
        }
    }
}