using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using MyPersonalShortner.Lib.CustomExceptions;

namespace MyPersonalShortner.Lib.Infrastructure.EntityFramework
{
    public abstract class EfDataAccess<T> where T : class
    {
        private readonly IDbSet<T> dbset;
        private readonly EfContext context;
        protected EfDataAccess()
        {
            context = new EfDatabaseFactory().Get();
            dbset = context.Set<T>();
        }

        public virtual T Add(T entity)
        {
            var newEntity = dbset.Add(entity);
            return newEntity;
        }

        public virtual T GetById(int id)
        {
            var entity = dbset.Find(id);
            if(entity == null)
            {
                throw new ArgumentOutOfRangeException("Id", id, "Url not found.");
            }
            return entity;
        }

        public T Get(Func<T, bool> where)
        {
            return dbset.Where(where).FirstOrDefault();
        }

        public IList<T> List(Func<T, bool> where)
        {
            return dbset.Where(where).ToList();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public void Remove(int id)
        {
            var entity = GetById(id);
            dbset.Remove(entity);
        }

        public virtual void Save()
        {
            try
            {
                context.SaveChanges();
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
