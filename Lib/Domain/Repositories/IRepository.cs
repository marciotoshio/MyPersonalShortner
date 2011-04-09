using System.Collections.Generic;

namespace MyPersonalShortner.Lib.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();

        void Save();
    }
}
