using DataBase.Repositories;

namespace DataBase.Data; 

public class EfDbInitializer : IDbInitializer
{
    private readonly DataContext _dataContext;

    public EfDbInitializer(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
        
    public void InitializeDb()
    {
        _dataContext.Database.EnsureDeleted();
        _dataContext.Database.EnsureCreated();

        _dataContext.AddRange(DatabaseSeeder.Categories);
        _dataContext.SaveChanges();
            
        _dataContext.AddRange(DatabaseSeeder.Products);
        _dataContext.SaveChanges();
        
        _dataContext.AddRange(DatabaseSeeder.Storages);
        _dataContext.SaveChanges();
        
        _dataContext.AddRange(DatabaseSeeder.ProductsStorages);
        _dataContext.SaveChanges();
    }
}