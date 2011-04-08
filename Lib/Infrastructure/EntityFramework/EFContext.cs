using System.Data.Entity;
using MyPersonalShortner.Lib.Domain.Url;

namespace MyPersonalShortner.Lib.Infrastructure.EntityFramework
{
    public class EFContext : DbContext
    {
        public EFContext()
            : base("MyPersonalShortner")
        {
            try
            {
                Database.CreateIfNotExists();
                Database.SetInitializer(new MyPersonalSHortnerInitializer());
            }
            catch
            {
                Database.SetInitializer<EFContext>(null);
            }
        }

        public DbSet<LongUrl> Urls { get; set; }

        private class MyPersonalSHortnerInitializer : DropCreateDatabaseIfModelChanges<EFContext>
        {
            protected override void Seed(EFContext context)
            {
                context.Urls.Add(new LongUrl { Url = "https://github.com/marciotoshio/MyPersonalShortner" });
                context.SaveChanges();
                base.Seed(context);
            }
        
        }
    }    
}
