namespace CodeDemoSolution.Model.Base
{
    using System;

    public interface IDataModelBase
    {
        int Id { get; set; }

        DateTime CreatedOn { get; set; }
        DateTime UpdatedOn { get; set; }
    }
}
