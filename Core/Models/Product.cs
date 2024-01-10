namespace Core.Models;

public class Product: BaseModel {
    public int Cost { get; set; }
    public virtual int CategoryId { get; set; }
    public virtual Category? Category { get; set; }
    public virtual List<ProductsStorage>? Storages { get; set; }
}