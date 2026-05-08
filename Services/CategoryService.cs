using OnlineStore.Models;
using OnlineStore.Repositories;

namespace OnlineStore.Services;

// Бизнес-сервис для работы с категориями товаров
public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task CreateAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(int id);
}

public class CategoryService : ICategoryService
{
    private readonly IRepository<Category> _storeRepo;

    public CategoryService(IRepository<Category> repo) => _storeRepo = repo;

    public Task<IEnumerable<Category>> GetAllAsync() => _storeRepo.GetAllAsync();
    public Task<Category?> GetByIdAsync(int id) => _storeRepo.GetByIdAsync(id);

    public async Task CreateAsync(Category category)
    {
        await _storeRepo.AddAsync(category);
        await _storeRepo.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        _storeRepo.Update(category);
        await _storeRepo.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var c = await _storeRepo.GetByIdAsync(id);
        if (c is null) return;
        _storeRepo.Remove(c);
        await _storeRepo.SaveChangesAsync();
    }
}
