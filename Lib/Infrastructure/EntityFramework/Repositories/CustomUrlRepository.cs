using System.Linq;
using MyPersonalShortner.Lib.Domain.Url;
using MyPersonalShortner.Lib.Domain.Repositories;

namespace MyPersonalShortner.Lib.Infrastructure.EntityFramework.Repositories
{
    public class CustomUrlRepository : EfRepository<CustomUrl>, ICustomUrlRepository
    {
        public CustomUrl GetByCustomPart(string customPart)
        {
            return Dbset.SingleOrDefault(c => c.CustomPart == customPart);
        }
    }
}
