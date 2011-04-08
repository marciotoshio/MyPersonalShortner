using System.Data.Entity;
using MyPersonalShortner.Lib.Domain.Url;

namespace MyPersonalShortner.Lib.Infrastructure.EntityFramework
{
    public class EfContext : DbContext
    {
        public EfContext()
            : base("MyPersonalShortner")
        {
            try
            {
                Database.CreateIfNotExists();
                Database.SetInitializer(new MyPersonalSHortnerInitializer());
            }
            catch
            {
                Database.SetInitializer<EfContext>(null);
            }
        }

        public DbSet<LongUrl> Urls { get; set; }

        private class MyPersonalSHortnerInitializer : DropCreateDatabaseIfModelChanges<EfContext>
        {
            protected override void Seed(EfContext context)
            {
                context.Urls.Add(new LongUrl { Url = "https://github.com/marciotoshio/MyPersonalShortner" });
                context.SaveChanges();
                base.Seed(context);
            }
        
        }
    }    
}
