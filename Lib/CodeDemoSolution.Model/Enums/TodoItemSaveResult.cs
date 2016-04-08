using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDemoSolution.Model.Enums
{
    public enum TodoItemSaveResult
    {
        Saved = 0,
        NoTodoListKnown = 1,
        MissingTitle = 2,
        MissingMessage = 3,
        OtherError = 4,
        TodoListNotFound = 5
    }
}
