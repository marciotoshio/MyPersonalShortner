using System.Data.Entity;
using System.Linq;
using MyPersonalShortner.Lib.Domain.Url;
using MyPersonalShortner.Lib.Domain.Account;
using System.Data.Entity.Validation;
using MyPersonalShortner.Lib.CustomExceptions;

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
                context.CustomUrls.Add(new CustomUrl { Url = "https://github.com/marciotoshio", CustomPart = "github", FacebookUserId = 1410396783 });
                context.CustomUrls.Add(new CustomUrl { Url = "http://www.youtube.com/user/marciotoshioide", CustomPart = "youtube", FacebookUserId = 1410396783 });
                context.CustomUrls.Add(new CustomUrl { Url = "https://twitter.com/marciotoshio", CustomPart = "twitter", FacebookUserId = 1410396783 });
                context.CustomUrls.Add(new CustomUrl { Url = "http://www.facebook.com/marciotoshio", CustomPart = "facebook", FacebookUserId = 1410396783 });
                context.CustomUrls.Add(new CustomUrl { Url = "http://picasaweb.google.com/marciotoshioide", CustomPart = "picasa", FacebookUserId = 1410396783 });
                context.CustomUrls.Add(new CustomUrl { Url = "http://www.linkedin.com/in/marciotoshio", CustomPart = "linkedin", FacebookUserId = 1410396783 });
                context.CustomUrls.Add(new CustomUrl { Url = "https://plus.google.com/108663431789428499352", CustomPart = "googleplus", FacebookUserId = 1410396783 });

                context.Save();

                base.Seed(context);
            }
        
        }

        public void Save()
        {
            try
            {
                this.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var errors = (from validationErrors in dbEx.EntityValidationErrors
                              from validationError in validationErrors.ValidationErrors
                              select validationError.ErrorMessage).ToList();
                throw new ShortnerValidationException(errors);
            }
        }
    }    
}
