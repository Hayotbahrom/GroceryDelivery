using GroceryDelivery.Domain.Commons;

namespace GroceryDelivery.Domain.Entities;

public class Customer:Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string Location { get; set; }

}
