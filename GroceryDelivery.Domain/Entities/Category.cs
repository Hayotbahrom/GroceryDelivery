using GroceryDelivery.Domain.Commons;

namespace GroceryDelivery.Domain.Entities;

public class Category:Auditable
{
    public string Name { get; set; }
}
