using System.Data.Entity;
using MyPersonalShortner.Lib.Domain.Url;

namespace MyPersonalShortner.Lib.Infrastructure.EntityFramework
{
    public class EFContext : DbContext
    {
        public EFContext()
            : base("MyPersonalShortner")
        {
            // TODO: Remove In Prod
            Database.CreateIfNotExists();
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        public DbSet<LongUrl> Urls { get; set; }
    }    
}
