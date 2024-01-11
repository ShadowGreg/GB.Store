using Core.Models;

namespace DataBase.Data {
    public static class DatabaseSeeder {
        // Заполняем таблицу категорий
        public static List<Category> Categories = new List<Category> {
            new Category { Name = "Category 1", Description = "Category 1 Description" },
            new Category { Name = "Category 2", Description = "Category 2 Description" },
            new Category { Name = "Category 3", Description = "Category 3 Description" }
        };


        // Заполняем таблицу продуктов
        public static List<Product> Products = new List<Product> {
            new Product {
                Name = "Product 1", Description = "Product 1 Description", CategoryId = Categories[0].Id, Cost = 10
            },
            new Product {
                Name = "Product 2", Description = "Product 2 Description", CategoryId = Categories[1].Id, Cost = 20
            },
            new Product {
                Name = "Product 3", Description = "Product 3 Description", CategoryId = Categories[2].Id, Cost = 30
            }
        };


        // Заполняем таблицу складов
        public static List<Storage> Storages = new List<Storage> {
            new Storage { Name = "Storage 1", Description = "Storage 1 Description" },
            new Storage { Name = "Storage 2", Description = "Storage 2 Description" },
            new Storage { Name = "Storage 3", Description = "Storage 3 Description" }
        };

        // Заполняем таблицу связей продуктов и складов
        public static List<ProductsStorage> ProductsStorages = new List<ProductsStorage> {
            new ProductsStorage { ProductId = Products[0].Id, StorageId = Storages[0].Id },
            new ProductsStorage { ProductId = Products[1].Id, StorageId = Storages[1].Id },
            new ProductsStorage { ProductId = Products[2].Id, StorageId = Storages[2].Id }
        };
    }
}