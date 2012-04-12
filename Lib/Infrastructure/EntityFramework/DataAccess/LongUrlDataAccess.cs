using MyPersonalShortner.Lib.Domain.Url;
using MyPersonalShortner.Lib.Domain.Repositories;

namespace MyPersonalShortner.Lib.Infrastructure.EntityFramework.DataAccess
{
    public class LongUrlDataAccess : EfDataAccess<LongUrl>, ILongUrlRepository
    {
        public override LongUrl Add(LongUrl entity)
        {
            return Get(longUrl => longUrl.Url == entity.Url) ?? base.Add(entity);
        }

        public LongUrl GetByUrl(string url)
        {
            return Get(longUrl => longUrl.Url == url);
        }
    }
}
