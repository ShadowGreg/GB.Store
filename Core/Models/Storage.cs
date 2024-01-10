namespace Core.Models;

public class Storage: BaseModel {
    public virtual Product? Product { get; set; }
    public virtual int ProductId { get; set; }
    public int Count { get; set; }
    public virtual List<Storage>? Storages { get; set; }
    public virtual List<int>? StoragesId { get; set; }
}