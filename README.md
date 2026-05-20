# OnlineStore — интернет-магазин электроники

<div align="center">

![.NET Version](https://img.shields.io/badge/.NET-8.0-purple)
![Blazor](https://img.shields.io/badge/Blazor-Server-brightgreen)
![Entity Framework](https://img.shields.io/badge/EF%20Core-8.0-blue)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-16-blue)
![Docker](https://img.shields.io/badge/Docker-✓-2496ED)
![License](https://img.shields.io/badge/License-MIT-green)

**Курсовой проект по дисциплине «Кроссплатформенная среда исполнения программного обеспечения»**

</div>

---

## О проекте

**OnlineStore** — это веб-приложение интернет-магазина электроники, разработанное с использованием современного стека технологий .NET 8, ASP.NET Core, Blazor Server и PostgreSQL. Приложение позволяет пользователям просматривать каталог товаров, управлять корзиной покупок, оформлять заказы с проверкой остатков на складе и отслеживать историю заказов.

Проект демонстрирует навыки работы с кроссплатформенной средой .NET, Entity Framework Core (Code First), Dependency Injection, контейнеризацией Docker, а также построением интерактивных веб-интерфейсов на Blazor Server.

### Основные возможности

- **Просмотр каталога товаров** – список товаров с ценами, изображениями и описанием
- **Фильтрация по категориям** – отображение товаров выбранной категории (Смартфоны, Ноутбуки, Аксессуары)
- **Управление корзиной** – добавление товаров, изменение количества, удаление позиций, расчёт итоговой суммы
- **Оформление заказа** – форма с валидацией данных покупателя, проверка остатков на складе
- **История заказов** – просмотр ранее оформленных заказов с детализацией по позициям
- **Демо-пользователь** – автоматическое создание гостевого аккаунта (guest@onlinestore.local) без необходимости регистрации
- **Модальные окна** – подтверждение действий (очистка корзины, удаление позиции)
- **Полная контейнеризация** – запуск приложения и базы данных через Docker Compose

---

## Технологии

| Технология | Назначение |
|------------|------------|
| .NET 8 | Кроссплатформенная среда исполнения |
| ASP.NET Core | Веб-фреймворк |
| Blazor Server | Интерактивный веб-интерфейс на C# |
| Entity Framework Core 8 | ORM, Code First, миграции |
| PostgreSQL 16 | Реляционная база данных |
| FluentValidation | Валидация моделей |
| Blazored.Modal | Модальные окна для Blazor |
| Docker / Docker Compose | Контейнеризация и оркестрация |
| Git | Система контроля версий |

---

## 📁 Структура проекта

```
OnlineStore/
├── OnlineStore/ # 📦 Основной веб-проект
│ ├── Components/ # 🧩 Blazor компоненты
│ │ ├── Layout/ # 🏗️ Макеты и навигация
│ │ │ ├── MainLayout.razor
│ │ │ └── NavMenu.razor
│ │ └── Pages/ # 📄 Страницы приложения
│ │ ├── Home.razor
│ │ ├── Products.razor
│ │ ├── ProductDetails.razor
│ │ ├── Cart.razor
│ │ ├── Checkout.razor
│ │ └── Orders.razor
│ │
│ ├── Data/ # 🗄️ Доступ к данным
│ │ ├── Configurations/ # ⚙️ Fluent API конфигурации
│ │ │ ├── CategoryConfiguration.cs
│ │ │ ├── CustomerConfiguration.cs
│ │ │ ├── OrderConfiguration.cs
│ │ │ ├── ProductConfiguration.cs
│ │ │ └── ProductDetailsConfiguration.cs
│ │ ├── DbSeeder.cs # 🌱 Начальные данные (Seed)
│ │ └── StoreContext.cs # 🔗 Контекст БД
│ │
│ ├── Models/ # 📋 Модели сущностей
│ │ ├── Category.cs # 🏷️ Категория товара
│ │ ├── Product.cs # 📱 Товар
│ │ ├── ProductDetails.cs # 📊 Характеристики товара (1:1)
│ │ ├── Customer.cs # 👤 Покупатель
│ │ ├── Order.cs # 📦 Заказ
│ │ ├── OrderItem.cs # 📃 Позиция заказа
│ │ └── CartItem.cs # 🛒 Корзина
│ │
│ ├── Repositories/ # 📚 Репозитории
│ │ ├── IRepository.cs # 🔌 Интерфейс универсального репозитория
│ │ ├── Repository.cs # ⚙️ Реализация универсального репозитория
│ │ ├── ProductRepository.cs # 📱 Репозиторий товаров (+ Include)
│ │ └── OrderRepository.cs # 📦 Репозиторий заказов (+ Include)
│ │
│ ├── Services/ # ⚙️ Бизнес-логика
│ │ ├── ProductService.cs
│ │ ├── CategoryService.cs
│ │ ├── CartService.cs
│ │ ├── OrderService.cs
│ │ └── CurrentUserService.cs # 👤 Демо-пользователь (guest)
│ │
│ ├── Validators/ # ✅ FluentValidation валидаторы
│ │ └── Validators.cs
│ │
│ ├── wwwroot/ # 🌐 Статические файлы
│ │ ├── css/
│ │ ├── js/
│ │ └── images/
│ │
│ ├── appsettings.json # ⚙️ Конфигурация
│ ├── Program.cs # 🚀 Точка входа, DI, миграции
│ ├── Dockerfile # 🐳 Docker-образ приложения
│ └── onlinestore.dockerignore # 🚫 Исключения для Docker
│
├── docker-compose.yml # 🐳 Оркестрация контейнеров
├── README.md # 📖 Документация
└── .gitignore # 🚫 Исключения для Git
```

---

## Быстрый старт

### Предварительные требования

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (для локальной разработки)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (для контейнеризации)
- [PostgreSQL](https://www.postgresql.org/download/) (при локальном запуске без Docker)
- [Git](https://git-scm.com/)

---

## Запуск через Docker (рекомендуемый способ)

Этот способ не требует установки .NET SDK и PostgreSQL на хост-машине — всё работает в изолированных контейнерах.

### Шаг 1: Клонирование репозитория
https://hub.docker.com/r/slavyanskiyuser/onlinestore
https://github.com/SlavyanskiyUser/OnlineStore/tree/main

git clone https://github.com/your-username/PasswordManager.git
cd onlinestore

### Шаг 2: Запуск контейнеров
docker-compose up -d
### Шаг 3: Открыть приложение
http://localhost:8008
