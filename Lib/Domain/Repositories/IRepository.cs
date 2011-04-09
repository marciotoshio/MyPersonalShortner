using System.Collections.Generic;
using System;

namespace MyPersonalShortner.Lib.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        T GetById(int id);
        T Get(Func<T, bool> where);
        IEnumerable<T> GetAll();

        void Save();
    }
}
