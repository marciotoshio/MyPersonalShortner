using MyPersonalShortner.Lib.Domain.Account;
using MyPersonalShortner.Lib.Domain.Repositories;

namespace MyPersonalShortner.Lib.Services
{
    public interface IFacebookUserService
    {
        FacebookUser GetByFacebookId(long fbId);
        void Create(FacebookUser facebookUser);
    }

    public class FacebookUserService : IFacebookUserService
    {
        private IFacebookUserRepository repository;
        public FacebookUserService(IFacebookUserRepository repository)
        {
            this.repository = repository;
        }

        public FacebookUser GetByFacebookId(long fbId)
        {
            return repository.GetByFacebookId(fbId);
        }

        public void Create(FacebookUser facebookUser)
        {
            repository.Add(facebookUser);
            repository.Save();
        }
    }
}
