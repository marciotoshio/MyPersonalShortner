using System.Data.Entity;
using MyPersonalShortner.Lib.Domain.Url;

namespace MyPersonalShortner.Lib.Infrastructure.EntityFramework
{
    public class EFContext : DbContext
    {
        public EFContext()
            : base("MyPersonalShortner") 
        {
        }

        public DbSet<LongUrl> Urls { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
