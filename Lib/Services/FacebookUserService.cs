using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPersonalShortner.Lib.Domain.Account;

namespace MyPersonalShortner.Lib.Services
{
    public interface IFacebookUserService
    {
        void VerifyIfIsNewUser(FacebookUser fbUser);
    }

    public class FacebookUserService : IFacebookUserService
    {

        public void VerifyIfIsNewUser(FacebookUser fbUser)
        {
        }
    }
}
