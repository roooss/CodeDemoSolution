namespace CodeDemoSolution.DataAccess.Interfaces.Repositories.Base
{
    using Model.Base;
    using System.Collections.Generic;

    public interface IReadOnlyRepository<T> where T : class, IDataModelBase
    {
        IEnumerable<T> All { get; }
        T GetById(int id);
    }
}
