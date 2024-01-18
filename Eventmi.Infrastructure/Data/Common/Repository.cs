using Eventmi.Infrastructure.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Eventmi.Infrastructure.Data.Common;
/// <summary>
/// Repository class to manage data
/// </summary>
public class Repository : IRepository
{
    /// <summary>
    /// eventmi Database context instance
    /// </summary>
    private readonly EventmiDbContext dbContext;

    /// <summary>
    /// Repository constructor. Db Context injection
    /// </summary>
    /// <param name="dbContext">Context database</param>
    public Repository(EventmiDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    /// <summary>
    /// Provides gi given type DbSet
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    private DbSet<T> GetDbSet<T>() where T : class => dbContext.Set<T>();

    /// <summary>
    /// Add given entity to the DbSet
    /// </summary>
    /// <typeparam name="T">Type of element</typeparam>
    /// <param name="entity">element</param>
    /// <returns></returns>
    public async Task AddAsync<T>(T entity) where T : class
    {
        //dbContext.Add(entity);
        await GetDbSet<T>().AddAsync(entity);
        //await dbContext.Set<T>().AddAsync(entity);
    }

    /// <summary>
    /// Get all elements
    /// </summary>
    /// <typeparam name="T">Type of element</typeparam>
    /// <returns></returns>
    public IQueryable<T> GetAll<T>() where T : class
    {
        //return dbContext.Set<T>();
        return GetDbSet<T>();
    }

    /// <summary>
    /// Get all elements only for reading
    /// </summary>
    /// <typeparam name="T">Type of element</typeparam>
    /// <returns></returns>
    public IQueryable<T> GetAllReadOnly<T>() where T : class
    {
        //return dbContext.Set<T>().AsNoTracking();
        return GetDbSet<T>().AsNoTracking();
    }

    /// <summary>
    /// Get all elements including deleted items
    /// </summary>
    /// <typeparam name="T">Type of items</typeparam>
    /// <returns></returns>
    public IQueryable<T> GetAllWithDeleted<T>()  where T: class, IDeletable
    {
        //return dbContext.Set<T>().IgnoreQueryFilters();
        return GetDbSet<T>().IgnoreQueryFilters();
    }

    /// <summary>
    /// Get all elements including deleted items only for reading
    /// </summary>
    /// <typeparam name="T">Type of items</typeparam>
    /// <returns></returns>
    public IQueryable<T> GetAllWithDeletedReadOnly<T>() where T : class, IDeletable
    {
        //return dbContext.Set<T>().AsNoTracking().Where(e=>e.IsActive== true|| e.IsActive==false);
        //return dbContext.Set<T>().AsNoTracking().IgnoreQueryFilters();
        return GetDbSet<T>().AsNoTracking().IgnoreQueryFilters();
    }

    /// <summary>
    /// Delete item from database
    /// </summary>
    /// <typeparam name="T">type of item</typeparam>
    /// <param name="entity">item</param>
    /// <returns></returns>
    public void Delete<T>(T entity) where T : class, IDeletable
    {
        entity.IsActive = false;
        entity.DeletedOn = DateTime.UtcNow;
    }

    /// <summary>
    /// Save changes into the database
    /// </summary>
    /// <returns></returns>
    public async Task<int> SaveChangesAsync()
    {
        return await dbContext.SaveChangesAsync();
    }
}