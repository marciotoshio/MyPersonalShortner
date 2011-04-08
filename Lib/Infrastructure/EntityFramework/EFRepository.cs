using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using MyPersonalShortner.Lib.CustomExceptions;

namespace MyPersonalShortner.Lib.Infrastructure.EntityFramework
{
    public abstract class EfRepository<T> where T : class
    {
        private readonly IDbSet<T> dbset;
        protected EfRepository()
        {
            DatabaseFactory = new EfDatabaseFactory();
            dbset = DataContext.Set<T>();
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
            dbset.Add(entity);            
        }

        public virtual T GetById(int id)
        {
            return dbset.Find(id);
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
                              select string.Format("{0} is invalid: {1}", validationError.PropertyName, validationError.ErrorMessage)).ToList();
                throw new ShortnerValidationException(errors);
            }
        }
    }
}
