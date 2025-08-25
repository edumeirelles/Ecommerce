namespace DAL.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        T Get(Guid id);
        List<T> GetList();
        Guid Add(T item);
        void Remove(T item);
        void Update(T item);
        Task UpdateAsync(T item);
    }
}
