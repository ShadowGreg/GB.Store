using DataBase.Repositories;

namespace DataBase.Data;

public class EfDbInitializer: IDbInitializer {
    private readonly DataContext _dataContext;

    public EfDbInitializer(DataContext dataContext) {
        _dataContext = dataContext;
    }

    public void InitializeDb()
    {
        _dataContext.Database.EnsureDeleted();
        _dataContext.Database.EnsureCreated();

        InitializeCategories();
        InitializeStorages();
        InitializeProducts();
        InitializeProductsStorages();
    }

    private void InitializeCategories()
    {
        foreach (var category in InitializeDatabaseSeeder.Categories)
        {
            if (!_dataContext.Categories.Any(c => c.Id == category.Id))
            {
                _dataContext.Categories.Add(category);
            }
        }
        _dataContext.SaveChanges();
    }

    private void InitializeStorages()
    {
        foreach (var storage in InitializeDatabaseSeeder.Storages)
        {
            if (!_dataContext.Storages.Any(s => s.Id == storage.Id))
            {
                _dataContext.Storages.Add(storage);
            }
        }
        _dataContext.SaveChanges();
    }

    private void InitializeProducts()
    {
        foreach (var product in InitializeDatabaseSeeder.Products)
        {
            if (!_dataContext.Products.Any(p => p.Id == product.Id))
            {
                _dataContext.Products.Add(product);
            }
        }
        _dataContext.SaveChanges();
    }

    private void InitializeProductsStorages()
    {
        foreach (var productsStorage in InitializeDatabaseSeeder.ProductsStorages)
        {
            var existingProductsStorage = _dataContext.ProductsStorages
                .FirstOrDefault(ps => ps.ProductId == productsStorage.ProductId && ps.StorageId == productsStorage.StorageId);

            if (existingProductsStorage == null)
            {
                _dataContext.ProductsStorages.Add(productsStorage);
            }
        }
        _dataContext.SaveChanges();
    }
}