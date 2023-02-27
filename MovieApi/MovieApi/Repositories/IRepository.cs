using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MovieApi.Models.Entities;

namespace MovieApi.Repositories;

public interface IRepository<T> where T: BaseEntity
{
    DbSet<T> Entity { get; }
    bool Add(T entity);

    bool Update(T entity);

    bool Delete(T entity);

    bool DeleteById(int id);

    IQueryable<T> GetAll();

    T? GetById(int id);
}