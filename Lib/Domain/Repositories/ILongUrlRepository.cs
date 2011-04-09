using MyPersonalShortner.Lib.Domain.Url;

namespace MyPersonalShortner.Lib.Domain.Repositories
{
    public interface ILongUrlRepository : IRepository<LongUrl>
    {
        LongUrl GetByUrl(string url);
    }
}
