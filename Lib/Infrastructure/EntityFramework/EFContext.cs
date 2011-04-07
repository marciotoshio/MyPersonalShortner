using System.Data.Entity;
using MyPersonalShortner.Lib.Domain.Url;

namespace MyPersonalShortner.Lib.Infrastructure.EntityFramework
{
    public class EFContext : DbContext
    {
        public EFContext()
            : base("MyPersonalShortner")
        {
            Database.SetInitializer(new MyPersonalSHortnerInitializer());
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
