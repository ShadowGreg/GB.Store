namespace Core.Models; 

public class ProductsStorage {

    public virtual int? ProductId { get; set; }
    public virtual Product? Product { get; set; }

    public virtual int? StorageId { get; set; }
    public virtual Storage? Storage { get; set; }
    
}