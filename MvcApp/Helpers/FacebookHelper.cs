using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyPersonalShortner.Lib.Domain.Account;
using Facebook.Web;
using MyPersonalShortner.Lib.Services;

namespace MyPersonalShortner.MvcApp.Helpers
{
    public class FacebookHelper
    {
        public static FacebookUser CurrentUser()
        {
            if (!FacebookWebContext.Current.IsAuthenticated()) return null;

            var client = new FacebookWebClient();
            dynamic me = client.Get("me");
            var facebookUser = new FacebookUser();
            facebookUser.FacebookId = long.Parse(me.id);
            facebookUser.Name = me.name;
            return facebookUser;
        }
    }
}