using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace MyPersonalShortner.Lib.Infrastructure.EntityFramework
{
    public abstract class EFRepository<T> where T : class
    {
        private EFContext dataContext;
        private readonly IDbSet<T> dbset;
        protected EFRepository()
        {
            DatabaseFactory = new EFDatabaseFactory();
            dbset = DataContext.Set<T>();
        }

        protected EFDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected EFContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }

        public virtual T Add(T entity)
        {
            return dbset.Add(entity);
        }

        public virtual T GetById(int id)
        {
            return dbset.Find(id);
        }
    }
}
