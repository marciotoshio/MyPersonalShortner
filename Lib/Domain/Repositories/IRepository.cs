using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPersonalShortner.Lib.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        T GetById(int Id);
        void Save();
    }
}
