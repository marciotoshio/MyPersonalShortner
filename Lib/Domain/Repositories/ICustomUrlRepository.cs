using MyPersonalShortner.Lib.Domain.Url;
using System.Collections.Generic;

namespace MyPersonalShortner.Lib.Domain.Repositories
{
    public interface ICustomUrlRepository : IRepository<CustomUrl>
    {
        CustomUrl GetByCustomPart(string customPart);
        CustomUrl GetByUrl(string url);
        IList<CustomUrl> ListByFacebookId(long fbId);
    }
}
