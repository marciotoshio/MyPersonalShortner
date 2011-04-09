using MyPersonalShortner.Lib.Domain.Url;

namespace MyPersonalShortner.Lib.Domain.Repositories
{
    public interface ICustomUrlRepository : IRepository<CustomUrl>
    {
        CustomUrl GetByCustomPart(string customPart);
        CustomUrl GetByUrl(string url);
    }
}
