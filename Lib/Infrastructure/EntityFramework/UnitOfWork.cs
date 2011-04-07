using MyPersonalShortner.Lib.Infrastructure.Data;
namespace MyPersonalShortner.Lib.Infrastructure.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFDatabaseFactory databaseFactory;
        private EFContext dataContext;

        public UnitOfWork()
        {
            this.databaseFactory = new EFDatabaseFactory();
        }

        protected EFContext DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get()); }
        }

        public void Commit()
        {
            DataContext.Commit();
        }
    }
}
