namespace Core.Models;

public class Storage: BaseModel {
    public virtual List<Product>? Products { get; set; } = new();
}