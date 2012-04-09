using MyPersonalShortner.Lib.Domain.Url;
using MyPersonalShortner.Lib.Domain.Repositories;
using System.Collections.Generic;

namespace MyPersonalShortner.Lib.Infrastructure.EntityFramework.DataAccess
{
    public class CustomUrlDataAccess : EfDataAccess<CustomUrl>, ICustomUrlRepository
    {
        public override CustomUrl Add(CustomUrl entity)
        {
            return Get(customUrl => customUrl.Url == entity.Url) ?? base.Add(entity);
        }

        public CustomUrl GetByCustomPart(string customPart)
        {
            return Get(customUrl => customUrl.CustomPart == customPart);
        }

        public CustomUrl GetByUrl(string url)
        {
            return Get(customUrl => customUrl.Url == url);
        }
    }
}
