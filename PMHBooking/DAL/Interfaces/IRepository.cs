using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PMHBooking.DAL.Interfaces
{
    /// <summary>
    /// This repostiory pattern is influenced by EF on which the first implementation is based. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Returns entities that make the predicate true and eager loads 
        /// entities that were specified by includes parameter.        
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        IQueryable<T> Get(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Wrapper around EF Find method. Please note: not every Find methods
        /// call will hit the database
        /// </summary>
        /// <param name="key">Primary key(s) of entity to be returned</param>
        /// <returns></returns>
        T Find(params object[] key);
        T Add(T t);
        void Delete(T t);
        void Update(T t);
    }
}
