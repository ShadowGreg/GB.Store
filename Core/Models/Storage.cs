namespace Core.Models;

public class Storage: BaseModel {
    public virtual Product? Product { get; set; }
    public virtual int ProductId { get; set; }
    public virtual List<ProductsStorage>? Storages { get; set; }
}