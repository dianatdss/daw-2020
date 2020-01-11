using TheaterTicketsManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TheaterTicketsManagement.Repositiories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        protected readonly TheaterDbContext context;

        public BaseRepository(TheaterDbContext context)
        {
            this.context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            var result = (await context.Set<T>().AddAsync(entity)).Entity;
            context.SaveChanges();
            return result;
        }

        public void Delete(int id)
        {
            var t = context.Set<T>().Where((entity) => entity.Id == id).FirstOrDefault();
                context.Set<T>().Remove(t);
              context.SaveChanges();
        }

        public async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetOneByCondition(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public T Update(T entity)
        {
            var result = context.Set<T>().Update(entity).Entity;
            context.SaveChanges();
            return result;
          
        }
    }
}
