using GroceryDelivery.Domain.Commons;
using GroceryDelivery.Domain.Enums;

namespace GroceryDelivery.Domain.Entities;

public class Driver:Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Vehicle Vehicle { get; set; }
}
