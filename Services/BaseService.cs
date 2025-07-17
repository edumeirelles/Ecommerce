using Ecommerce.Interfaces;
using Ecommerce.Models;
using Ecommerce.Repository;

namespace Ecommerce.Services
{
    public class BaseService<T> : IBaseService<T> where T : EntityBase
    {
        private readonly BaseRepository<T> _repository; 
        public BaseService()
        {
            if (_repository == null)
            {
                _repository = new BaseRepository<T>();
            }
        }
        public Guid Add(T item)
        {
            return _repository.Add(item);
        }

        public T Get(Guid id)
        {
            return _repository.Get(id);
        }

        public IQueryable<T> GetList()
        {
            return _repository.GetList();
        }

        public void Remove(T item)
        {
            _repository.Remove(item);
        }

        public void Update(T item)
        {
            _repository.Update(item);
        }

        async public Task UpdateAsync(T item)
        {
            await _repository.UpdateAsync(item);
        }
        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
