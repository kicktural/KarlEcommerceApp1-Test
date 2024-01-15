
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.SQLServer.EntityFrameWork
{
    public class EFRepositoryBase<TEntity, TContext> : IReposItoryBase<TEntity>
        where TEntity : class
        where TContext : DbContext, new()
    {     
        public void Add(TEntity Tentity)
        {
           using TContext TContext = new();
            var addentity = TContext.Entry(Tentity);
            addentity.State = EntityState.Added;
            TContext.SaveChanges();
        }

        public void Delete(TEntity Tentity)
        {
            using TContext context = new();
            var deleteentity = context.Entry(Tentity);
            deleteentity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            using TContext context = new();
            return context.Set<TEntity>().FirstOrDefault(expression);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? expression = null)
        {
            using TContext context = new();
            return expression == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(expression).ToList();
        }

        public void Update(TEntity Tentity)
        {
            using TContext context = new();
            var updateentity = context.Entry(Tentity);
            updateentity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
