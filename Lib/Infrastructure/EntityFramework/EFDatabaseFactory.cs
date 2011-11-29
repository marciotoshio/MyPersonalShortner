namespace MyPersonalShortner.Lib.Infrastructure.EntityFramework
{
    public class EfDatabaseFactory : Disposable
    {
        private EfContext dataContext;
        public EfContext Get()
        {
            return dataContext ?? (dataContext = new EfContext());
        }

        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
