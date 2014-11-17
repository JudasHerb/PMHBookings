using PMHBooking.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PMHBooking.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly UnitOfWork _entities;

        public Repository(UnitOfWork entities)
        {
            _entities = entities;
        }

        #region IRepository<T> Members

        public virtual IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            return Get(e => true, includes);
        }

        public IQueryable<T> Get(
                Expression<Func<T, bool>> predicate,
                params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entities.Set<T>().Where(predicate);

            if (includes != null)
            {
                query = includes.Aggregate(query,
                                           (current, include) => current.Include(include));
            }

            return query;
        }

        public T Find(params object[] key)
        {
            return _entities.Set<T>().Find(key);
        }

        public virtual T Add(T t)
        {
            _entities.Set<T>().Add(t);
            return t;
        }

        public virtual void Delete(T t)
        {
            _entities.Set<T>().Remove(t);
        }

        public virtual void Update(T t)
        {
            _entities.Entry(t).State = EntityState.Modified;
        }

        #endregion
    }
}