using System.Data.Entity;
using MyPersonalShortner.Lib.Domain.Url;

namespace MyPersonalShortner.Lib.Infrastructure.EntityFramework
{
    public class EfContext : DbContext
    {
        public EfContext()
            : base("MyPersonalShortner")
        {
            Database.SetInitializer(new MyPersonalSHortnerInitializer());
        }

        public DbSet<LongUrl> Urls { get; set; }
        public DbSet<CustomUrl> CustomUrls { get; set; }

        private class MyPersonalSHortnerInitializer : DropCreateDatabaseIfModelChanges<EfContext>
        {
            protected override void Seed(EfContext context)
            {
                //Url
                context.Urls.Add(new LongUrl {Url = "https://github.com/marciotoshio/MyPersonalShortner"});
                
                //Custom urls
                context.CustomUrls.Add(new CustomUrl { Url = "https://github.com/marciotoshio", CustomPart = "github" });
                context.CustomUrls.Add(new CustomUrl { Url = "http://www.youtube.com/user/marciotoshioide", CustomPart = "youtube" });
                context.CustomUrls.Add(new CustomUrl { Url = "https://twitter.com/marciotoshio", CustomPart = "twitter" });
                context.CustomUrls.Add(new CustomUrl { Url = "http://www.facebook.com/marciotoshio", CustomPart = "facebook" });
                context.CustomUrls.Add(new CustomUrl { Url = "http://picasaweb.google.com/marciotoshioide", CustomPart = "picasa" });
                context.CustomUrls.Add(new CustomUrl { Url = "http://www.linkedin.com/in/marciotoshio", CustomPart = "linkedin" });
            
                context.SaveChanges();
                base.Seed(context);
            }
        
        }
    }    
}
