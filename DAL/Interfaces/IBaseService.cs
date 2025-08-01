namespace DAL.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        T Get(Guid id);
        IQueryable<T> GetList();
        Guid Add(T item);
        void Remove(T item);
        void Update(T item);
        Task UpdateAsync(T item);
    }
}
