using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;

namespace OnlineStore.Repositories;

// Базовая реализация универсального репозитория поверх EF Core
public class Repository<T> : IRepository<T> where T : class
{
    protected readonly StoreContext _store;
    protected readonly DbSet<T> _dbTable;

    public Repository(StoreContext context)
    {
        _store = context;
        _dbTable = context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync() => await _dbTable.ToListAsync();

    public virtual async Task<T?> GetByIdAsync(int id) => await _dbTable.FindAsync(id);

    // Поиск по произвольному условию
    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        => await _dbTable.Where(predicate).ToListAsync();

    public async Task AddAsync(T entity) => await _dbTable.AddAsync(entity);
    public void Update(T entity) => _dbTable.Update(entity);
    public void Remove(T entity) => _dbTable.Remove(entity);

    public async Task<int> SaveChangesAsync() => await _store.SaveChangesAsync();
}
