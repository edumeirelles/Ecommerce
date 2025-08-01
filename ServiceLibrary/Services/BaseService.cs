using DAL;
using DAL.Models;
using DAL.Interfaces;


namespace ServiceLibrary.Services
{
    public class BaseService<T> : IDisposable, IBaseService<T> where T : EntityBase
    {
        private readonly Context _db;        
        public BaseService()
        {
            if (_db == null)
            {
                _db = new Context();
            }
        }
        public T Get(Guid id)
        {
            return _db.Set<T>().FirstOrDefault(x => x.Id == id)!;
        }

        public IQueryable<T> GetList()
        {
            return _db.Set<T>();
        }

        public Guid Add(T item)
        {
            _db.Set<T>().Add(item);
            _db.SaveChanges();
            return item.Id;
        }

        public void Remove(T item)
        {
            _db.Set<T>().Remove(item);
            _db.SaveChanges();
        }

        public void Update(T item)
        {
            _db.Set<T>().Update(item);
            _db.SaveChanges();
        }

        public async Task UpdateAsync(T item)
        {
            _db.Set<T>().Update(item);
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
