using Azure.Core;
using Microsoft.EntityFrameworkCore;

namespace BirdApi.Data;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _context;
    private DbSet<TEntity> _entities;
    
    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _entities = _context.Set<TEntity>();
    }

    public List<TEntity> GetAll()
    {
        return _entities.AsNoTracking().Take(1000).ToList();
    }

    public TEntity GetById(int entityId)
    {
        return _entities.Find(entityId);
    }

    public void Insert(TEntity entity)
    {
        entity.GetType().GetProperty("CreatedBy").SetValue(entity, "SystemUser");
        entity.GetType().GetProperty("CreatedAt").SetValue(entity, DateTime.UtcNow);

        _entities.Add(entity);
    }

    public void Remove(TEntity entity)
    {
        var column = entity.GetType().GetProperty("IsDeleted");
        if (column is not null)
        {
            entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
        }
        else
        {
            _entities.Remove(entity);
        }
    }

    public void Remove(int id)
    {
        var entity = GetById(id);
        var column = entity.GetType().GetProperty("IsDeleted");
        if (column is not null)
        {
            entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
        }
        else
        {
            _entities.Remove(entity);
        }
    }

    public void Update(TEntity entity)
    {
        _entities.Update(entity);
    }
}
