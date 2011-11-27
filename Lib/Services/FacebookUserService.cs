using MyPersonalShortner.Lib.Domain.Account;
using MyPersonalShortner.Lib.Domain.Repositories;

namespace MyPersonalShortner.Lib.Services
{
    public interface IFacebookUserService
    {
        void VerifyIfIsNewUser(FacebookUser fbUser);
    }

    public class FacebookUserService : IFacebookUserService
    {
        private IFacebookUserRepository repository;
        public FacebookUserService(IFacebookUserRepository repository)
        {
            this.repository = repository;
        }
        
        public void VerifyIfIsNewUser(FacebookUser fbUser)
        {
        }
    }
}
