using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyPersonalShortner.Lib.Domain.Url;
using MyPersonalShortner.Lib.Domain.Repositories;

namespace MyPersonalShortner.Lib.Infrastructure.EntityFramework.Repositories
{
    public class LongUrlRepository : EFRepository<LongUrl>, ILongUrlRepository
    {
    }
}
