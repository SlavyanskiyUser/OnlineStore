using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;

namespace OnlineStore.Data;

// Начальные данные для базы (применяются миграцией)
public static class DbSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // Стартовые категории
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Электроника", Description = "Смартфоны, ноутбуки и аксессуары" },
            new Category { Id = 2, Name = "Одежда", Description = "Мужская и женская одежда" },
            new Category { Id = 3, Name = "Книги", Description = "Художественная и техническая литература" }
        );

        // Стартовые товары; картинки — заглушки с placehold.co
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Смартфон Galaxy S24", Description = "Флагманский смартфон Samsung", Price = 89990m, Stock = 15, CategoryId = 1, ImageUrl = "https://placehold.co/300x300/0d6efd/ffffff?text=Galaxy+S24", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Product { Id = 2, Name = "Ноутбук ThinkPad X1", Description = "Бизнес-ноутбук Lenovo", Price = 145000m, Stock = 7, CategoryId = 1, ImageUrl = "https://placehold.co/300x300/212529/ffffff?text=ThinkPad+X1", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Product { Id = 3, Name = "Футболка базовая", Description = "100% хлопок", Price = 1290m, Stock = 120, CategoryId = 2, ImageUrl = "https://placehold.co/300x300/6c757d/ffffff?text=T-Shirt", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Product { Id = 4, Name = "Джинсы классические", Description = "Прямой крой, синий цвет", Price = 3990m, Stock = 45, CategoryId = 2, ImageUrl = "https://placehold.co/300x300/1e3a8a/ffffff?text=Jeans", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new Product { Id = 5, Name = "C# in Depth", Description = "Книга Джона Скита", Price = 2490m, Stock = 30, CategoryId = 3, ImageUrl = "https://placehold.co/300x300/198754/ffffff?text=C%23+Book", CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
        );

        // Стартовые характеристики для части товаров
        modelBuilder.Entity<ProductDetails>().HasData(
            new ProductDetails { Id = 1, ProductId = 1, Manufacturer = "Samsung", CountryOfOrigin = "Южная Корея", Weight = 0.196, Dimensions = "147x70.6x7.6 мм", WarrantyMonths = 24 },
            new ProductDetails { Id = 2, ProductId = 2, Manufacturer = "Lenovo", CountryOfOrigin = "Китай", Weight = 1.12, Dimensions = "315x222x14.9 мм", WarrantyMonths = 36 },
            new ProductDetails { Id = 3, ProductId = 5, Manufacturer = "Manning", CountryOfOrigin = "США", Weight = 0.8, Dimensions = "23x18x3 см", WarrantyMonths = 0 }
        );

        // Тестовый покупатель
        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, FullName = "Иван Иванов", Email = "ivan@example.com", Phone = "+7-999-000-00-01", Address = "Москва, ул. Ленина, 1", RegisteredAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
        );
    }
}
