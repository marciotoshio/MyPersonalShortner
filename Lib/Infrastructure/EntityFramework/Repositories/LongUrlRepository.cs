using MyPersonalShortner.Lib.Domain.Url;
using MyPersonalShortner.Lib.Domain.Repositories;

namespace MyPersonalShortner.Lib.Infrastructure.EntityFramework.Repositories
{
    public class LongUrlRepository : EfRepository<LongUrl>, ILongUrlRepository
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
