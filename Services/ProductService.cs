using OnlineStore.Models;
using OnlineStore.Repositories;

namespace OnlineStore.Services;

// Бизнес-сервис для работы с товарами
public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
    Task CreateAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
}

public class ProductService : IProductService
{
    private readonly IProductRepository _storeRepo;

    public ProductService(IProductRepository repo) => _storeRepo = repo;

    public Task<IEnumerable<Product>> GetAllAsync() => _storeRepo.GetAllWithCategoryAsync();
    public Task<Product?> GetByIdAsync(int id) => _storeRepo.GetByIdWithDetailsAsync(id);
    public Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId) => _storeRepo.GetByCategoryAsync(categoryId);

    public async Task CreateAsync(Product product)
    {
        await _storeRepo.AddAsync(product);
        await _storeRepo.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _storeRepo.Update(product);
        await _storeRepo.SaveChangesAsync();
    }

    // Удаление: сначала ищем сущность, потом удаляем
    public async Task DeleteAsync(int id)
    {
        var p = await _storeRepo.GetByIdAsync(id);
        if (p is null) return;
        _storeRepo.Remove(p);
        await _storeRepo.SaveChangesAsync();
    }
}
