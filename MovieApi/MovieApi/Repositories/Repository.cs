using Microsoft.EntityFrameworkCore;
using MovieApi.Contexts;
using MovieApi.Models.Entities;

namespace MovieApi.Repositories;

public class Repository<T> : IRepository<T> where T: BaseEntity
{
    
    private readonly MovieDbContext _context;

    public Repository(MovieDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Entity => _context.Set<T>();

    public  bool Add(T entity)
    {
        var entityEntry = Entity.Add(entity);
        if (entityEntry.State == EntityState.Added)
        {
            _context.SaveChanges();
            return true;
        }

        return false;
    }

    public bool Update(T entity)
    {
        var entityEntry = Entity.Update(entity);
        if (entityEntry.State == EntityState.Modified)
        {
            _context.SaveChanges();
            return true;
        }

        return false;
    }

    public bool Delete(T entity)
    {
        var entityEntry = Entity.Remove(entity);
        if (entityEntry.State == EntityState.Deleted)
        {
            _context.SaveChanges();
            return true;
        }

        return false;
    }

    public bool DeleteById(int id)
    {
        var entity =  Entity.First(p => p.Id == id);
        if (Entity.Remove(entity).State == EntityState.Deleted)
        {
            _context.SaveChanges();
            return true;
        }
        
        return false;
    }

    public IQueryable<T> GetAll()
    {
        return Entity.AsQueryable();
    }

    public T? GetById(int id)
    {
        return Entity.FirstOrDefault(p => p.Id == id);
    }
}