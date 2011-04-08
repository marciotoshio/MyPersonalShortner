namespace MyPersonalShortner.Lib.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T GetById(int id);
        void Save();
    }
}
