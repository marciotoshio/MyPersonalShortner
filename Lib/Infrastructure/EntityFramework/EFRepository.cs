using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace MyPersonalShortner.Lib.Infrastructure.EntityFramework
{
    public abstract class EFRepository<T> where T : class
    {
        private readonly IDbSet<T> dbset;
        protected EFRepository()
        {
            DatabaseFactory = new EFDatabaseFactory();
            dbset = DataContext.Set<T>();
        }

        private EFContext dataContext;
        protected EFContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }

        protected EFDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public virtual T Add(T entity)
        {
            var result = dbset.Add(entity);            
            return result;
        }

        public virtual T GetById(int id)
        {
            return dbset.Find(id);
        }

        public virtual void Save()
        {
            DataContext.SaveChanges();
        }
    }
}
