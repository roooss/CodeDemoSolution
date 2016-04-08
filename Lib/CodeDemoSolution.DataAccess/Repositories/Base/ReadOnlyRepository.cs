namespace CodeDemoSolution.DataAccess.Repositories.Base
{
    using Interfaces.Context;
    using Interfaces.Repositories.Base;
    using Model.Base;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : class, IDataModelBase
    {
        protected ITodoDbContext _databaseContext { get; private set; }

        protected IDbSet<T> DbSet
        {
            get
            {
                return _databaseContext.Context.Set<T>();
            }
        }

        public ReadOnlyRepository(ITodoDbContext context)
        {
            _databaseContext = context;
        }

        public IEnumerable<T> All
        {
            get
            {
                return DbSet.AsEnumerable<T>();
            }
        }

        public T GetById(int id)
        {
            return DbSet.Where(x => x.Id == id).FirstOrDefault() as T;
        }
    }
}
