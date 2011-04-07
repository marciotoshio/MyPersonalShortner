namespace MyPersonalShortner.Lib.Infrastructure.EntityFramework
{
    public class EFDatabaseFactory : Disposable
    {
        private EFContext dataContext;
        public EFContext Get()
        {
            return dataContext ?? (dataContext = new EFContext());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
