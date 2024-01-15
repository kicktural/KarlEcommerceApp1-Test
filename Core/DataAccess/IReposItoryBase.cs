using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //generic types
    public interface IReposItoryBase<TEntity>
    {
        void Add(TEntity Tentity);
        void Update(TEntity Tentity);
        void Delete(TEntity Tentity);
        TEntity Get(Expression<Func<TEntity, bool>> expression);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>>? expression = null);
    }
}
