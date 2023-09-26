using GroceryDelivery.Domain.Commons;

namespace GroceryDelivery.Domain.Entities;

public class Product:Auditable
{
    public long CategoryId {  get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Quantity { get; set; }
}
