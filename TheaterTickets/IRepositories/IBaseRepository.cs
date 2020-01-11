using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TheaterTicketsManagement.Repositiories
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetOneByCondition(Expression<Func<T, bool>> expression);
        Task<T> CreateAsync(T entity);
        T Update(T entity);
        void Delete(int id);
    }
}
