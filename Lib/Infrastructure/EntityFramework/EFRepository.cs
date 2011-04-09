using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using MyPersonalShortner.Lib.CustomExceptions;

namespace MyPersonalShortner.Lib.Infrastructure.EntityFramework
{
    public abstract class EfRepository<T> where T : class
    {
        protected readonly IDbSet<T> Dbset;
        protected EfRepository()
        {
            DatabaseFactory = new EfDatabaseFactory();
            Dbset = DataContext.Set<T>();
        }

        private EfContext dataContext;
        protected EfContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }

        protected EfDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public virtual void Add(T entity)
        {
            Dbset.Add(entity);            
        }

        public virtual T GetById(int id)
        {
            var entity = Dbset.Find(id);
            if(entity == null)
            {
                throw new ArgumentOutOfRangeException("Id", id, "Url not found.");
            }
            return entity;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Dbset.ToList();
        }

        public virtual void Save()
        {
            try
            {
                DataContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var errors = (from validationErrors in dbEx.EntityValidationErrors
                              from validationError in validationErrors.ValidationErrors
                              select validationError.ErrorMessage).ToList();
                throw new ShortnerValidationException(errors);
            }
        }
    }
}
