using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IRepository<TEntity> : IDisposable where TEntity : IEntity
    {
        public Task<TEntity> GetBy(int id);
        public Task<TEntity> Insert(TEntity entity);
        public Task<TEntity> Update(int id, TEntity entity);
        public Task<bool> RemoveBy(int id);
    }
}
