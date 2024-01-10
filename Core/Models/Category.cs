namespace Core.Models;

public class Category: BaseModel {
    public List<Product>? Products { get; set; } = new List<Product>();
}