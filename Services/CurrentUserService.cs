using Microsoft.EntityFrameworkCore;
using OnlineStore.Data;
using OnlineStore.Models;

namespace OnlineStore.Services;

// Упрощённый сервис текущего пользователя (без авторизации, для демо)
public interface ICurrentUserService
{
    Task<Customer> GetOrCreateDemoCustomerAsync();
}

public class CurrentUserService : ICurrentUserService
{
    private readonly StoreContext _store;

    // Email фиктивного покупателя демо-режима
    private const string DemoEmail = "demo@onlinestore.local";

    public CurrentUserService(StoreContext context) => _store = context;

    // Возвращает существующего демо-покупателя или создаёт нового
    public async Task<Customer> GetOrCreateDemoCustomerAsync()
    {
        var customer = await _store.Customers.FirstOrDefaultAsync(c => c.Email == DemoEmail);

        if (customer == null)
        {
            customer = new Customer
            {
                FullName = "Demo User",
                Email = DemoEmail,
                RegisteredAt = DateTime.UtcNow
            };
            _store.Customers.Add(customer);
            await _store.SaveChangesAsync();
        }
        return customer;
    }
}
