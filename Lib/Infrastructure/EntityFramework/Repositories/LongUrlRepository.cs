using MyPersonalShortner.Lib.Domain.Url;
using MyPersonalShortner.Lib.Domain.Repositories;

namespace MyPersonalShortner.Lib.Infrastructure.EntityFramework.Repositories
{
    public class LongUrlRepository : EfRepository<LongUrl>, ILongUrlRepository
    {
    }
}
