using System.Data.Entity;
using MyPersonalShortner.Lib.Domain.Url;
using MyPersonalShortner.Lib.Domain.Account;

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
        public DbSet<FacebookUser> FacebookUsers { get; set; }

        private class MyPersonalSHortnerInitializer : DropCreateDatabaseIfModelChanges<EfContext>
        {
            protected override void Seed(EfContext context)
            {
                //Url
                context.Urls.Add(new LongUrl {Url = "https://github.com/marciotoshio/MyPersonalShortner"});
                
                //FacebookUser
                var fbUser = context.FacebookUsers.Add(new FacebookUser { FacebookId = 1410396783, Name = "Marcio Toshio Ide" });

                //Custom urls
                context.CustomUrls.Add(new CustomUrl { Url = "https://github.com/marciotoshio", CustomPart = "github", FacebookUser = fbUser });
                context.CustomUrls.Add(new CustomUrl { Url = "http://www.youtube.com/user/marciotoshioide", CustomPart = "youtube", FacebookUser = fbUser });
                context.CustomUrls.Add(new CustomUrl { Url = "https://twitter.com/marciotoshio", CustomPart = "twitter", FacebookUser = fbUser });
                context.CustomUrls.Add(new CustomUrl { Url = "http://www.facebook.com/marciotoshio", CustomPart = "facebook", FacebookUser = fbUser });
                context.CustomUrls.Add(new CustomUrl { Url = "http://picasaweb.google.com/marciotoshioide", CustomPart = "picasa", FacebookUser = fbUser });
                context.CustomUrls.Add(new CustomUrl { Url = "http://www.linkedin.com/in/marciotoshio", CustomPart = "linkedin", FacebookUser = fbUser });
                context.CustomUrls.Add(new CustomUrl { Url = "https://plus.google.com/108663431789428499352", CustomPart = "googleplus", FacebookUser = fbUser });
            
                context.SaveChanges();
                base.Seed(context);
            }
        
        }
    }    
}
