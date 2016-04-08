namespace CodeDemoSolution.DataAccess.Interfaces.Repositories.Base
{
    using Model.Base;

    public interface IReadWriteRepository<T> : IReadOnlyRepository<T> where T : class, IDataModelBase
    {
        T Add(T item);
        T Update(T item);
        void Delete(T item);
    }
}
