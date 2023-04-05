using System.Linq.Expressions;

namespace BirdApi.Data;

public interface IGenericRepository<TEntity> where TEntity : class
{
    TEntity GetById(int entityId);
    void Insert(TEntity entity);
    void Remove(TEntity entity);
    void Remove(int id);
    void Update(TEntity entity);
    List<TEntity> GetAll();
    List<TEntity> Where(Expression<Func<TEntity, bool>> where);
}
