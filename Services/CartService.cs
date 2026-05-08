using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.Models;

namespace OnlineStore.Services;

// Бизнес-сервис корзины покупателя
public interface ICartService
{
    Task<IEnumerable<CartItem>> GetCartAsync(int customerId);
    Task AddToCartAsync(int customerId, int productId, int quantity = 1);
    Task UpdateQuantityAsync(int cartItemId, int quantity);
    Task RemoveFromCartAsync(int cartItemId);
    Task ClearCartAsync(int customerId);
    Task<decimal> GetTotalAsync(int customerId);
}

public class CartService : ICartService
{
    private readonly StoreContext _store;

    public CartService(StoreContext context) => _store = context;

    // Содержимое корзины с подгрузкой товаров
    public async Task<IEnumerable<CartItem>> GetCartAsync(int customerId)
        => await _store.CartItems
            .Include(ci => ci.Product)
            .Where(ci => ci.CustomerId == customerId)
            .ToListAsync();

    // Если товар уже в корзине — увеличиваем количество, иначе добавляем
    public async Task AddToCartAsync(int customerId, int productId, int quantity = 1)
    {
        var existing = await _store.CartItems
            .FirstOrDefaultAsync(ci => ci.CustomerId == customerId && ci.ProductId == productId);

        if (existing != null)
        {
            existing.Quantity += quantity;
        }
        else
        {
            await _store.CartItems.AddAsync(new CartItem
            {
                CustomerId = customerId,
                ProductId = productId,
                Quantity = quantity
            });
        }
        await _store.SaveChangesAsync();
    }

    // Количество <= 0 удаляет позицию из корзины
    public async Task UpdateQuantityAsync(int cartItemId, int quantity)
    {
        var item = await _store.CartItems.FindAsync(cartItemId);
        if (item is null) return;

        if (quantity <= 0)
            _store.CartItems.Remove(item);
        else
            item.Quantity = quantity;

        await _store.SaveChangesAsync();
    }

    public async Task RemoveFromCartAsync(int cartItemId)
    {
        var item = await _store.CartItems.FindAsync(cartItemId);
        if (item is null) return;
        _store.CartItems.Remove(item);
        await _store.SaveChangesAsync();
    }

    public async Task ClearCartAsync(int customerId)
    {
        var items = _store.CartItems.Where(ci => ci.CustomerId == customerId);
        _store.CartItems.RemoveRange(items);
        await _store.SaveChangesAsync();
    }

    // Общая стоимость корзины
    public async Task<decimal> GetTotalAsync(int customerId)
        => await _store.CartItems
            .Where(ci => ci.CustomerId == customerId)
            .SumAsync(ci => ci.Quantity * ci.Product.Price);
}
