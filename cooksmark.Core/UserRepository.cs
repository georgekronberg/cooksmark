using System;
using cooksmark.Core.DataAccess;

namespace cooksmark.Core
{
    public class UserRepository : IRepository
    {
        public T Get<T, TKey>(TKey id) where T : class, IEntity<TKey>
        {
            throw new NotImplementedException();
        }

        public T Find<T, TKey>(TKey id) where T : class, IEntity<TKey>
        {
            throw new NotImplementedException();
        }

        public T Save<T, TKey>(T entity) where T : class, IEntity<TKey>
        {
            throw new NotImplementedException();
        }

        public void Delete<T, TKey>(TKey id) where T : class, IEntity<TKey>
        {
            throw new NotImplementedException();
        }

        public void Delete<T, TKey>(T entity) where T : class, IEntity<TKey>
        {
            throw new NotImplementedException();
        }
    }
}