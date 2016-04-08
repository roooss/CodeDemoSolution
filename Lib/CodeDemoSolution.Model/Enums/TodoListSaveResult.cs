using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDemoSolution.Model.Enums
{
    public enum TodoListSaveResult
    {
        Saved = 0,
        NoRecordToSave = 1,
        MissingTitle = 2,
        MissingDescription = 3,
        OtherError = 4
    }
}
