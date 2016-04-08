namespace CodeDemoSolution.DataAccess.Repositories.Base
{
    using Interfaces.Context;
    using Interfaces.Repositories.Base;
    using Model.Base;
    using System;

    public class ReadWriteRepository<T> : ReadOnlyRepository<T>, IReadWriteRepository<T> where T : class, IDataModelBase
    {
        public ReadWriteRepository(ITodoDbContext context)
            : base (context)
        {
        }

        public T Add(T item)
        {
            item.CreatedOn = DateTime.Now;
            item.UpdatedOn = DateTime.Now;
            item = DbSet.Add(item);
            return item;
        }

        public void Delete(T item)
        {
            DbSet.Remove(item);
        }

        public T Update(T item)
        {
            item.UpdatedOn = DateTime.Now;
            _databaseContext.Context.Entry(item).State = System.Data.Entity.EntityState.Modified;

            return item;
        }
    }
}
