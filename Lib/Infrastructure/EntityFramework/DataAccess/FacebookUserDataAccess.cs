using MyPersonalShortner.Lib.Domain.Repositories;
using MyPersonalShortner.Lib.Domain.Account;

namespace MyPersonalShortner.Lib.Infrastructure.EntityFramework.DataAccess
{
    public class FacebookUserDataAccess : EfDataAccess<FacebookUser>, IFacebookUserRepository
    {
        public FacebookUser GetByFacebookId(long fbId)
        {
            return Get(facebookUser => facebookUser.FacebookId == fbId);
        }
    }
}
